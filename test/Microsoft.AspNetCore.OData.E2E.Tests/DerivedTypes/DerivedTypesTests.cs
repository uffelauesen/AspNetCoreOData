//-----------------------------------------------------------------------------
// <copyright file="DerivedTypesTests.cs" company=".NET Foundation">
//      Copyright (c) .NET Foundation and Contributors. All rights reserved.
//      See License.txt in the project root for license information.
// </copyright>
//------------------------------------------------------------------------------

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.OData.TestCommon;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Xunit;

namespace Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes
{
    public class DerivedTypeTests : WebApiTestBase<DerivedTypeTests>
    {
        public DerivedTypeTests(WebApiTestFixture<DerivedTypeTests> fixture)
            : base(fixture)
        {
        }

        protected static void UpdateConfigureServices(IServiceCollection services)
        {
            services.ConfigureControllers(typeof(CustomersController));
            services.AddControllers().AddOData(opt => opt.AddRouteComponents("odata", GetEdmModel()).Count().Filter().OrderBy().Expand().SetMaxTop(null).Select());
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Customer>("Customers");
            builder.EntityType<Order>();
            builder.EntityType<VipCustomer>().DerivesFrom<Customer>();
            return builder.GetEdmModel();
        }

        [Fact]
        public async Task RestrictEntitySetToDerivedTypeInstances()
        {
            // Arrange
            string requestUri = "/odata/Customers/Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes.VipCustomer";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            HttpClient client = CreateClient();

            // Act
            HttpResponseMessage response = await client.SendAsync(request);
            string py = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.True(response.IsSuccessStatusCode);

            string expectedContent = "\"value\":[{\"Id\":2,\"Name\":\"Customer 2\",\"LoyaltyCardNo\":\"9876543210\"}]";
            Assert.Contains(expectedContent, await response.Content.ReadAsStringAsync());
        }

        [Theory]
        [InlineData("Customers(2)/Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes.VipCustomer")]
        [InlineData("Customers/Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes.VipCustomer(2)")] // So far, we don't support key after the type cast.
        public async Task RestrictEntityToDerivedTypeInstance(string path)
        {
            // Arrange: Key preceeds name of the derived type
            string requestUri = $"odata/{path}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            HttpClient client = CreateClient();

            // Act
            HttpResponseMessage response = await client.SendAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);

            string expectedContent = "\"Id\":2,\"Name\":\"Customer 2\",\"LoyaltyCardNo\":\"9876543210\"";
            Assert.Contains(expectedContent, await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task ReturnNotFound_ForKeyNotAssociatedWithDerivedType()
        {
            // Arrange: Customer with Id 1 is not a VipCustomer
            string requestUri = "/odata/Customers(1)/Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes.VipCustomer";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            HttpClient client = CreateClient();

            // Act
            HttpResponseMessage response = await client.SendAsync(request);

            // Assert
            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task RestrictEntitySetToDerivedTypeInstances_ThenExpandNavProperty()
        {
            // Arrange
            string requestUri = "/odata/Customers/Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes.VipCustomer?$expand=Orders";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            HttpClient client = CreateClient();

            // Act
            HttpResponseMessage response = await client.SendAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);

            string expectedContent = "\"value\":[{\"Id\":2,\"Name\":\"Customer 2\",\"LoyaltyCardNo\":\"9876543210\"," +
                "\"Orders\":[{\"Id\":2,\"Amount\":230},{\"Id\":3,\"Amount\":150}]}]";
            Assert.Contains(expectedContent, await response.Content.ReadAsStringAsync());
        }

        [Theory]
        [InlineData("Customers(2)/Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes.VipCustomer?$expand=Orders")]
        [InlineData("Customers/Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes.VipCustomer(2)?$expand=Orders")]
        public async Task RestrictEntityToDerivedTypeInstance_ThenExpandNavProperty(string pathAndQuery)
        {
            // Arrange: Key preceeds name of the derived type
            string requestUri = $"/odata/{pathAndQuery}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            HttpClient client = CreateClient();

            // Act
            HttpResponseMessage response = await client.SendAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);

            string expectedContent = "\"Id\":2,\"Name\":\"Customer 2\",\"LoyaltyCardNo\":\"9876543210\"," +
                "\"Orders\":[{\"Id\":2,\"Amount\":230},{\"Id\":3,\"Amount\":150}]";
            Assert.Contains(expectedContent, await response.Content.ReadAsStringAsync());
        }

        [Theory]
        [InlineData("Customers(4)")]
        [InlineData("Customers(4)/Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes.GoldCustomer")]
        [InlineData("Customers/Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes.GoldCustomer(4)")]
        public async Task DerivedTypeNavPropertyLink_FullMetadata(string pathAndQuery)
        {
            // Arrange: Key preceeds name of the derived type
            string requestUri = $"/odata/{pathAndQuery}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json;odata.metadata=full"));
            HttpClient client = CreateClient();

            // Act
            HttpResponseMessage response = await client.SendAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);

            string expectedContent = "{\"@odata.context\":\"http://localhost/odata/$metadata#Customers/Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes.GoldCustomer/$entity\"," + 
                "\"@odata.type\":\"#Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes.GoldCustomer\"," + 
                "\"@odata.id\":\"http://localhost/odata/Customers(4)\"," + 
                "\"@odata.editLink\":\"Customers(4)/Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes.GoldCustomer\"," + 
                "\"Id\":4,\"Name\":\"Customer 4\",\"LoyaltyCardNo\":\"9876543211\"," + 
                "\"Orders@odata.associationLink\":\"http://localhost/odata/Customers(4)/Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes.GoldCustomer/Orders/$ref\"," + 
                "\"Orders@odata.navigationLink\":\"http://localhost/odata/Customers(4)/Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes.GoldCustomer/Orders\"," + 
                "\"BulkOrders@odata.associationLink\":\"http://localhost/odata/Customers(4)/Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes.GoldCustomer/BulkOrders/$ref\"," + 
                "\"BulkOrders@odata.navigationLink\":\"http://localhost/odata/Customers(4)/Microsoft.AspNetCore.OData.E2E.Tests.DerivedTypes.GoldCustomer/BulkOrders\"}";
            
            Assert.Equal(expectedContent, await response.Content.ReadAsStringAsync());
        }
    }
}
