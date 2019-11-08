//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v10.0.27.0 (Newtonsoft.Json v12.0.0.0) (http://NJsonSchema.org)
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

    /// <summary>A horizontal planer datum.</summary>
    [Newtonsoft.Json.JsonConverter(typeof(Elements.Serialization.JSON.JsonInheritanceConverter), "discriminator")]
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v12.0.0.0)")]
    [UserElement]
	public partial class Origin : Plane
    {
        [Newtonsoft.Json.JsonConstructor]
        public Origin(double @elevation, Vector3 @origin, Vector3 @normal)
            : base(origin, normal)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<Origin>();
            if(validator != null)
            {
                validator.Validate(new object[]{ @elevation, @origin, @normal});
            }
        
            this.Elevation = @elevation;
        }
    
        /// <summary>The elevation in meters of the Level.</summary>
        [Newtonsoft.Json.JsonProperty("Elevation", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Range(0, int.MaxValue)]
        public double Elevation { get; set; }
    
    
    }
}