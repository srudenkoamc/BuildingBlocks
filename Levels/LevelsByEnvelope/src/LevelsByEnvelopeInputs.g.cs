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
using System;
using System.Collections.Generic;
using System.Linq;
using Line = Elements.Geometry.Line;
using Polygon = Elements.Geometry.Polygon;

namespace LevelsByEnvelope
{
#pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]

    public class LevelsByEnvelopeInputs : S3Args

    {
        [Newtonsoft.Json.JsonConstructor]

        public LevelsByEnvelopeInputs(double @groundLevelHeight, double @standardLevelHeight, double @penthouseLevelHeight, string bucketName, string uploadsBucket, Dictionary<string, string> modelInputKeys, string gltfKey, string elementsKey, string ifcKey) :
        base(bucketName, uploadsBucket, modelInputKeys, gltfKey, elementsKey, ifcKey)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<LevelsByEnvelopeInputs>();
            if (validator != null)
            {
                validator.PreConstruct(new object[] { @groundLevelHeight, @standardLevelHeight, @penthouseLevelHeight });
            }

            this.GroundLevelHeight = @groundLevelHeight;
            this.StandardLevelHeight = @standardLevelHeight;
            this.PenthouseLevelHeight = @penthouseLevelHeight;

            if (validator != null)
            {
                validator.PostConstruct(this);
            }
        }

        /// <summary>Height of ground level.</summary>
        [Newtonsoft.Json.JsonProperty("Ground Level Height", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(2.0D, 20.0D)]
        public double GroundLevelHeight { get; set; } = 5D;

        /// <summary>Standard height of repeated levels.</summary>
        [Newtonsoft.Json.JsonProperty("Standard Level Height", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(2.0D, 20.0D)]
        public double StandardLevelHeight { get; set; } = 4D;

        /// <summary>Height of the top level.</summary>
        [Newtonsoft.Json.JsonProperty("Penthouse Level Height", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(2.0D, 20.0D)]
        public double PenthouseLevelHeight { get; set; } = 5D;


    }
}