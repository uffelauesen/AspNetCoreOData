﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.AspNetCore.OData.Query {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SRResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SRResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.AspNetCore.OData.Query.Properties.SRResources", typeof(SRResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The HttpActionContext.ActionDescriptor is null..
        /// </summary>
        internal static string ActionContextMustHaveDescriptor {
            get {
                return ResourceManager.GetString("ActionContextMustHaveDescriptor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The HttpActionContext.Request is null..
        /// </summary>
        internal static string ActionContextMustHaveRequest {
            get {
                return ResourceManager.GetString("ActionContextMustHaveRequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The HttpExecutedActionContext.Request is null..
        /// </summary>
        internal static string ActionExecutedContextMustHaveRequest {
            get {
                return ResourceManager.GetString("ActionExecutedContextMustHaveRequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The query option is not bound to any CLR type. &apos;{0}&apos; is only supported with a query option bound to a CLR type..
        /// </summary>
        internal static string ApplyToOnUntypedQueryOption {
            get {
                return ResourceManager.GetString("ApplyToOnUntypedQueryOption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot apply {0} of &apos;{1}&apos; to {2} of &apos;{3}&apos;..
        /// </summary>
        internal static string CannotApplyETagOfT {
            get {
                return ResourceManager.GetString("CannotApplyETagOfT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot apply {0} of &apos;{1}&apos; to {2} of &apos;{3}&apos;..
        /// </summary>
        internal static string CannotApplyODataQueryOptionsOfT {
            get {
                return ResourceManager.GetString("CannotApplyODataQueryOptionsOfT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property &apos;ElementClrType&apos; of {0} cannot be null..
        /// </summary>
        internal static string ElementClrTypeNull {
            get {
                return ResourceManager.GetString("ElementClrTypeNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The entity type &apos;{0}&apos; does not match the expected entity type &apos;{1}&apos; as set on the query context..
        /// </summary>
        internal static string EntityTypeMismatch {
            get {
                return ResourceManager.GetString("EntityTypeMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The ETag is not well-formed..
        /// </summary>
        internal static string ETagNotWellFormed {
            get {
                return ResourceManager.GetString("ETagNotWellFormed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot create an EDM model as the action &apos;{0}&apos; on controller &apos;{1}&apos; has a void return type..
        /// </summary>
        internal static string FailedToBuildEdmModelBecauseReturnTypeIsNull {
            get {
                return ResourceManager.GetString("FailedToBuildEdmModelBecauseReturnTypeIsNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot create an EDM model as the action &apos;{0}&apos; on controller &apos;{1}&apos; has a return type &apos;{2}&apos; that does not implement IEnumerable&lt;T&gt;..
        /// </summary>
        internal static string FailedToRetrieveTypeToBuildEdmModel {
            get {
                return ResourceManager.GetString("FailedToRetrieveTypeToBuildEdmModel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Query option &apos;{0}&apos; is not allowed. To allow it, set the &apos;{1}&apos; property on EnableQueryAttribute or QueryValidationSettings..
        /// </summary>
        internal static string NotAllowedQueryOption {
            get {
                return ResourceManager.GetString("NotAllowedQueryOption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value for OData query &apos;{0}&apos; cannot be empty..
        /// </summary>
        internal static string QueryCannotBeEmpty {
            get {
                return ResourceManager.GetString("QueryCannotBeEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The query parameter &apos;{0}&apos; is not supported..
        /// </summary>
        internal static string QueryParameterNotSupported {
            get {
                return ResourceManager.GetString("QueryParameterNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The limit of &apos;{0}&apos; for {1} query has been exceeded. The value from the incoming request is &apos;{2}&apos;..
        /// </summary>
        internal static string SkipTopLimitExceeded {
            get {
                return ResourceManager.GetString("SkipTopLimitExceeded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The query specified in the URI is not valid. {0}.
        /// </summary>
        internal static string UriQueryStringInvalid {
            get {
                return ResourceManager.GetString("UriQueryStringInvalid", resourceCulture);
            }
        }
    }
}
