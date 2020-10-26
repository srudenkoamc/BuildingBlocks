//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v10.1.21.0 (Newtonsoft.Json v12.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------
using Elements;
using Elements.GeoJSON;
using Elements.Geometry;
using Elements.Geometry.Solids;
using Elements.Properties;
using Elements.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using Line = Elements.Geometry.Line;
using Polygon = Elements.Geometry.Polygon;

namespace Elements
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    [UserElement]
	public partial class vertices 
    {
        [Newtonsoft.Json.JsonConstructor]
        public vertices(int @index, bool @isBoundary, Vector3 @position)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<vertices>
            ();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @index, @isBoundary, @position});
            }
        
                this.Index = @index;
                this.IsBoundary = @isBoundary;
                this.Position = @position;
            
            if(validator != null)
            {
            validator.PostConstruct(this);
            }
            }
    
        /// <summary>Identifier for this vertex within the mesh.</summary>
        [Newtonsoft.Json.JsonProperty("index", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Index { get; set; }
    
        /// <summary>Whether the vertex represents an boundary of the mesh. That is, whether attached edges may bound a single face rather than two.</summary>
        [Newtonsoft.Json.JsonProperty("isBoundary", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsBoundary { get; set; }
    
        [Newtonsoft.Json.JsonProperty("position", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Vector3 Position { get; set; }
    
        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();
    
        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    
    
    }
}