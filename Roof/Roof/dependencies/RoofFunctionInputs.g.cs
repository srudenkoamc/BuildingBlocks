// This code was generated by Hypar.
// Edits to this code will be overwritten the next time you run 'hypar init'.
// DO NOT EDIT THIS FILE.

using Elements;
using Elements.GeoJSON;
using Elements.Geometry;
using Elements.Geometry.Solids;
using Elements.Validators;
using Elements.Serialization.JSON;
using Hypar.Functions;
using Hypar.Functions.Execution;
using Hypar.Functions.Execution.AWS;
using Hypar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Line = Elements.Geometry.Line;
using Polygon = Elements.Geometry.Polygon;

namespace RoofFunction
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public  class RoofFunctionInputs : S3Args
    
    {
        [Newtonsoft.Json.JsonConstructor]
        
        public RoofFunctionInputs(Color @roofColor, double @roofThickness, double @insulationThickness, Color @insulationColor, bool @keepRoofBelowEnvelope, string bucketName, string uploadsBucket, Dictionary<string, string> modelInputKeys, string gltfKey, string elementsKey, string ifcKey):
        base(bucketName, uploadsBucket, modelInputKeys, gltfKey, elementsKey, ifcKey)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<RoofFunctionInputs>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @roofColor, @roofThickness, @insulationThickness, @insulationColor, @keepRoofBelowEnvelope});
            }
        
            this.RoofColor = @roofColor;
            this.RoofThickness = @roofThickness;
            this.InsulationThickness = @insulationThickness;
            this.InsulationColor = @insulationColor;
            this.KeepRoofBelowEnvelope = @keepRoofBelowEnvelope;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        /// <summary>What color should be used to display the roof</summary>
        [Newtonsoft.Json.JsonProperty("Roof Color", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Color RoofColor { get; set; }
    
        /// <summary>The Length.</summary>
        [Newtonsoft.Json.JsonProperty("Roof Thickness", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(0.001D, 2D)]
        public double RoofThickness { get; set; }
    
        /// <summary>The Length.</summary>
        [Newtonsoft.Json.JsonProperty("Insulation Thickness", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(0.0D, 2D)]
        public double InsulationThickness { get; set; } = 0D;
    
        [Newtonsoft.Json.JsonProperty("Insulation Color", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Color InsulationColor { get; set; }
    
        /// <summary>The height of the envelope is the top of the roof level</summary>
        [Newtonsoft.Json.JsonProperty("Keep Roof Below Envelope", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool KeepRoofBelowEnvelope { get; set; } = false;
    
    }
}