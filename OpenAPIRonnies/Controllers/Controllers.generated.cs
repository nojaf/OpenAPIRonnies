//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.6.2.0 (NJsonSchema v10.1.23.0 (Newtonsoft.Json v11.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

using System.Net.Http;
using OpenAPIRonnies;

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."

namespace OpenAPIRonnies
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.6.2.0 (NJsonSchema v10.1.23.0 (Newtonsoft.Json v11.0.0.0))")]
    public interface IController
    {
        /// <summary>List All ronnies xx</summary>
        /// <returns>Successful response - returns an array of `Ronny` entities.</returns>
        System.Threading.Tasks.Task<SwaggerResponse<System.Collections.Generic.ICollection<Ronny>>> GetRonniesAsync();
    
        /// <summary>Create a Ronny</summary>
        /// <param name="body">A new `Ronny` to be created.</param>
        /// <returns>Successful response.</returns>
        System.Threading.Tasks.Task<SwaggerResponse<Ronny>> CreateRonnyAsync(CreateOrUpdateRonny body);
    
        /// <summary>Get a Ronny</summary>
        /// <param name="ronnyId">A unique identifier for a `Ronny`.</param>
        /// <returns>Successful response - returns a single `Ronny`.</returns>
        System.Threading.Tasks.Task<SwaggerResponse<Ronny>> GetRonnyAsync(string ronnyId);
    
        /// <summary>Update a Ronny</summary>
        /// <param name="body">Updated `Ronny` information.</param>
        /// <param name="ronnyId">A unique identifier for a `Ronny`.</param>
        /// <returns>Successful response.</returns>
        System.Threading.Tasks.Task<SwaggerResponse<Ronny>> UpdateRonnyAsync(CreateOrUpdateRonny body, string ronnyId);
    
        /// <summary>Delete a Ronny</summary>
        /// <param name="ronnyId">A unique identifier for a `Ronny`.</param>
        /// <returns>Successful response.</returns>
        System.Threading.Tasks.Task<SwaggerResponse> DeleteRonnyAsync(string ronnyId);
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.6.2.0 (NJsonSchema v10.1.23.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class Controller : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private IController _implementation;
    
        public Controller(IController implementation)
        {
            _implementation = implementation;
        }
    
        /// <summary>List All ronnies xx</summary>
        /// <returns>Successful response - returns an array of `Ronny` entities.</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("ronnies")]
        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetRonnies()
        {
            if(! ModelState.IsValid) {
                // maybe map model to different type
                return this.CreateBadRequestFromModelState();
            }
    
            var result = await _implementation.GetRonniesAsync().ConfigureAwait(false);
    
            var status = (System.Net.HttpStatusCode)result.StatusCode;
            var response = this.CreateResponse(status, result);
    
            foreach (var header in result.Headers)
                Response.Headers.Add(header.Key, header.Value);
    
            return response;
        }
    
        /// <summary>Create a Ronny</summary>
        /// <param name="body">A new `Ronny` to be created.</param>
        /// <returns>Successful response.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("ronnies")]
        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> CreateRonny([Microsoft.AspNetCore.Mvc.FromBody] CreateOrUpdateRonny body)
        {
            if(! ModelState.IsValid) {
                // maybe map model to different type
                return this.CreateBadRequestFromModelState();
            }
    
            var result = await _implementation.CreateRonnyAsync(body).ConfigureAwait(false);
    
            var status = (System.Net.HttpStatusCode)result.StatusCode;
            var response = this.CreateResponse(status, result);
    
            foreach (var header in result.Headers)
                Response.Headers.Add(header.Key, header.Value);
    
            return response;
        }
    
        /// <summary>Get a Ronny</summary>
        /// <param name="ronnyId">A unique identifier for a `Ronny`.</param>
        /// <returns>Successful response - returns a single `Ronny`.</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("ronnies/{ronnyId}")]
        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetRonny(string ronnyId)
        {
            if(! ModelState.IsValid) {
                // maybe map model to different type
                return this.CreateBadRequestFromModelState();
            }
    
            var result = await _implementation.GetRonnyAsync(ronnyId).ConfigureAwait(false);
    
            var status = (System.Net.HttpStatusCode)result.StatusCode;
            var response = this.CreateResponse(status, result);
    
            foreach (var header in result.Headers)
                Response.Headers.Add(header.Key, header.Value);
    
            return response;
        }
    
        /// <summary>Update a Ronny</summary>
        /// <param name="body">Updated `Ronny` information.</param>
        /// <param name="ronnyId">A unique identifier for a `Ronny`.</param>
        /// <returns>Successful response.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("ronnies/{ronnyId}")]
        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> UpdateRonny([Microsoft.AspNetCore.Mvc.FromBody] CreateOrUpdateRonny body, string ronnyId)
        {
            if(! ModelState.IsValid) {
                // maybe map model to different type
                return this.CreateBadRequestFromModelState();
            }
    
            var result = await _implementation.UpdateRonnyAsync(body, ronnyId).ConfigureAwait(false);
    
            var status = (System.Net.HttpStatusCode)result.StatusCode;
            var response = this.CreateResponse(status, result);
    
            foreach (var header in result.Headers)
                Response.Headers.Add(header.Key, header.Value);
    
            return response;
        }
    
        /// <summary>Delete a Ronny</summary>
        /// <param name="ronnyId">A unique identifier for a `Ronny`.</param>
        /// <returns>Successful response.</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("ronnies/{ronnyId}")]
        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> DeleteRonny(string ronnyId)
        {
            if(! ModelState.IsValid) {
                // maybe map model to different type
                return this.CreateBadRequestFromModelState();
            }
    
            var result = await _implementation.DeleteRonnyAsync(ronnyId).ConfigureAwait(false);
    
            var status = (System.Net.HttpStatusCode)result.StatusCode;
            var response = this.CreateResponse(status);
    
            foreach (var header in result.Headers)
                Response.Headers.Add(header.Key, header.Value);
    
            return response;
        }
    
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Ronny 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("price", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Price { get; set; }
    
        [Newtonsoft.Json.JsonProperty("created", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
        public System.DateTimeOffset Created { get; set; }
    
        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();
    
        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CreateOrUpdateRonny 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("price", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Price { get; set; }
    
        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();
    
        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v11.0.0.0)")]
    internal class DateFormatConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
    {
        public DateFormatConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.6.2.0 (NJsonSchema v10.1.23.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class SwaggerResponse
    {
        public System.Net.HttpStatusCode StatusCode { get; private set; }

        public System.Collections.Generic.IReadOnlyDictionary<string, string> Headers { get; private set; } = new System.Collections.Generic.Dictionary<string, string>();

        public string Error { get; protected set; }

        public SwaggerResponse(System.Net.HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public SwaggerResponse(System.Net.HttpStatusCode statusCode, System.Collections.Generic.IReadOnlyDictionary<string, string> headers)
        {
            StatusCode = statusCode;
            Headers = headers;
        }

        public static SwaggerResponse BadRequest(string error)
        {
            return new SwaggerResponse(System.Net.HttpStatusCode.BadRequest)
            {
                Error = error
            };
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.6.2.0 (NJsonSchema v10.1.23.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class SwaggerResponse<TResult> : SwaggerResponse
    {
        public TResult Result { get; private set; }

        public SwaggerResponse(System.Net.HttpStatusCode statusCode): base(statusCode)
        {

        }

        public SwaggerResponse(System.Net.HttpStatusCode statusCode, TResult result)
            : base(statusCode)
        {
            Result = result;
        }

        public SwaggerResponse(System.Net.HttpStatusCode statusCode, System.Collections.Generic.IReadOnlyDictionary<string, string> headers, TResult result)
            : base(statusCode, headers)
        {
            Result = result;
        }

        public static SwaggerResponse<TResult> BadRequest(string error)
        {
            return new SwaggerResponse<TResult>(System.Net.HttpStatusCode.BadRequest)
            {
                Error = error
            };
        }
    }

}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108