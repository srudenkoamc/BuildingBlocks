//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v10.1.21.0 (Newtonsoft.Json v13.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------
using Elements;
using Elements.GeoJSON;
using Elements.Geometry;
using Elements.Geometry.Solids;
using Elements.Spatial;
using Elements.Validators;
using Elements.Serialization.JSON;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Line = Elements.Geometry.Line;
using Polygon = Elements.Geometry.Polygon;

namespace Elements
{
    #pragma warning disable // Disable all warnings

    /// <summary>A single drainable roof section.</summary>
    [JsonConverter(typeof(Elements.Serialization.JSON.JsonInheritanceConverter), "discriminator")]
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class DrainableRoofSection : GeometricElement
    {
        [JsonConstructor]
        public DrainableRoofSection(Polygon @boundary, IList<Line> @perimeterLowLines, IList<Line> @interiorLowLines, int @index, DrainableRoofSectionConfiguration @configuration, DrainableRoofSection @parent, Transform @transform = null, Material @material = null, Representation @representation = null, bool @isElementDefinition = false, System.Guid @id = default, string @name = null)
            : base(transform, material, representation, isElementDefinition, id, name)
        {
            this.Boundary = @boundary;
            this.PerimeterLowLines = @perimeterLowLines;
            this.InteriorLowLines = @interiorLowLines;
            this.Index = @index;
            this.Configuration = @configuration;
            this.Parent = @parent;
            }
        
        // Empty constructor
        public DrainableRoofSection()
            : base()
        {
        }
    
        /// <summary>The boundary of the space.</summary>
        [JsonProperty("Boundary", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Polygon Boundary { get; set; }
    
        /// <summary>Low Lines that lie on the perimeter of the roof.</summary>
        [JsonProperty("Perimeter Low Lines", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<Line> PerimeterLowLines { get; set; }
    
        /// <summary>Low lines that lie within the roof's boundary.</summary>
        [JsonProperty("Interior Low Lines", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<Line> InteriorLowLines { get; set; }
    
        /// <summary>(temporary) Indicates the order of this section within the building.</summary>
        [JsonProperty("index", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Index { get; set; }
    
        [JsonProperty("Configuration", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DrainableRoofSectionConfiguration Configuration { get; set; }
    
        [JsonProperty("Parent", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DrainableRoofSection Parent { get; set; }
    
    
    }
}