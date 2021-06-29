﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.OData.Edm;
using Microsoft.AspNetCore.OData.TestCommon;
using Microsoft.AspNetCore.OData.Tests.Commons;
using Microsoft.OData.Edm;
using Moq;
using Xunit;

namespace Microsoft.AspNetCore.OData.Tests.Edm
{
    public class EdmHelpersTests
    {
        public static TheoryDataSet<IEdmType, bool, Type> ToEdmTypeReferenceTestData
        {
            get
            {
                IEdmEntityType entity = new EdmEntityType("NS", "Entity");
                IEdmComplexType complex = new EdmComplexType("NS", "Complex");
                IEdmEnumType enumType = new EdmEnumType("NS", "Enum");
                IEdmPrimitiveType primitive = EdmCoreModel.Instance.GetPrimitiveType(EdmPrimitiveTypeKind.Int32);
                IEdmPathType path = EdmCoreModel.Instance.GetPathType(EdmPathTypeKind.AnnotationPath);
                IEdmTypeDefinition typeDefinition = new EdmTypeDefinition("NS", "TypeDef", primitive);
                IEdmCollectionType collection = new EdmCollectionType(new EdmEntityTypeReference(entity, isNullable: false));
                IEdmCollectionType collectionNullable = new EdmCollectionType(new EdmEntityTypeReference(entity, isNullable: true));
                IEdmEntityReferenceType entityReferenenceType = new EdmEntityReferenceType(entity);

                return new TheoryDataSet<IEdmType, bool, Type>
                {
                    { primitive, true, typeof(IEdmPrimitiveTypeReference) },
                    { primitive, false, typeof(IEdmPrimitiveTypeReference) },
                    { enumType, true, typeof(IEdmEnumTypeReference) },
                    { enumType, false, typeof(IEdmEnumTypeReference) },
                    { entity, true, typeof(IEdmEntityTypeReference) },
                    { entity, false, typeof(IEdmEntityTypeReference) },
                    { complex, true, typeof(IEdmComplexTypeReference) },
                    { complex, false, typeof(IEdmComplexTypeReference) },
                    { collectionNullable, true, typeof(IEdmCollectionTypeReference) },
                    { collection, false, typeof(IEdmCollectionTypeReference) },
                    { path, true, typeof(IEdmPathTypeReference) },
                    { path, false, typeof(IEdmPathTypeReference) },
                    { typeDefinition, true, typeof(IEdmTypeDefinitionReference) },
                    { typeDefinition, false, typeof(IEdmTypeDefinitionReference) },
                    { entityReferenenceType, true, typeof(IEdmEntityReferenceTypeReference) },
                    { entityReferenenceType, true, typeof(IEdmEntityReferenceTypeReference) },
                };
            }
        }

        [Theory]
        [MemberData(nameof(ToEdmTypeReferenceTestData))]
        public void ToEdmTypeReference_InstantiatesRightEdmTypeReference(IEdmType edmType, bool isNullable, Type expectedType)
        {
            // Arrange & Act
            IEdmTypeReference result = edmType.ToEdmTypeReference(isNullable);

            // Assert
            IEdmCollectionTypeReference collection = result as IEdmCollectionTypeReference;
            if (collection != null)
            {
                Assert.Equal(isNullable, collection.ElementType().IsNullable);
            }
            else
            {
                Assert.Equal(isNullable, result.IsNullable);
            }

            Assert.Equal(edmType, result.Definition);
            Assert.IsAssignableFrom(expectedType, result);
        }

        [Fact]
        public void ToEdmTypeReference_ThrowsNotSupportedException_UnknownTypeKind()
        {
            // Arrange & Act
            Mock<IEdmType> mock = new Mock<IEdmType>();
            mock.Setup(s => s.TypeKind).Returns(EdmTypeKind.None);
            ExceptionAssert.Throws<NotSupportedException>(() => mock.Object.ToEdmTypeReference(false),
                "UnknownType is not a supported EDM type.");
        }

        [Fact]
        public void ToCollection_ThrowsArgumentNull_EdmType()
        {
            // Arrange & Act
            IEdmType edmType = null;
            ExceptionAssert.ThrowsArgumentNull(() => edmType.ToCollection(false), "edmType");
        }
    }
}
