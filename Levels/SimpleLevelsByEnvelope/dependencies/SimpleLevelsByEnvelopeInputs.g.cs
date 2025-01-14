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

namespace SimpleLevelsByEnvelope
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public  class SimpleLevelsByEnvelopeInputs : S3Args
    
    {
        [Newtonsoft.Json.JsonConstructor]
        
        public SimpleLevelsByEnvelopeInputs(IList<double> @baseLevels, double @topLevelHeight, double @subgradeLevelHeight, string bucketName, string uploadsBucket, Dictionary<string, string> modelInputKeys, string gltfKey, string elementsKey, string ifcKey):
        base(bucketName, uploadsBucket, modelInputKeys, gltfKey, elementsKey, ifcKey)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<SimpleLevelsByEnvelopeInputs>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @baseLevels, @topLevelHeight, @subgradeLevelHeight});
            }
        
            this.BaseLevels = @baseLevels;
            this.TopLevelHeight = @topLevelHeight;
            this.SubgradeLevelHeight = @subgradeLevelHeight;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        /// <summary>Supply a list of level floor-to-floor heights. The last supplied value will be treated as the typical level height and repeated until the top level.</summary>
        [Newtonsoft.Json.JsonProperty("Base Levels", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<double> BaseLevels { get; set; }
    
        /// <summary>Height of the penthouse level.</summary>
        [Newtonsoft.Json.JsonProperty("Top Level Height", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(3.0D, 20.0D)]
        public double TopLevelHeight { get; set; } = 5D;
    
        /// <summary>Height of levels below grade.</summary>
        [Newtonsoft.Json.JsonProperty("Subgrade Level Height", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(2.7D, 6D)]
        public double SubgradeLevelHeight { get; set; } = 3D;
    
    }
}