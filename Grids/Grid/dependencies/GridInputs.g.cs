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

namespace Grid
{
    #pragma warning disable // Disable all warnings

    /// <summary>A simplified schema for a 1d grid used for a special geometry input</summary>
    [Newtonsoft.Json.JsonConverter(typeof(Elements.Serialization.JSON.JsonInheritanceConverter), "discriminator")]
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class Grid1dInput 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public Grid1dInput(Polyline @curve, IList<Vector3> @splitPoints, Grid1dInputSubdivisionMode? @subdivisionMode, SubdivisionSettings @subdivisionSettings)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<Grid1dInput>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @curve, @splitPoints, @subdivisionMode, @subdivisionSettings});
            }
        
            this.Curve = @curve;
            this.SplitPoints = @splitPoints;
            this.SubdivisionMode = @subdivisionMode;
            this.SubdivisionSettings = @subdivisionSettings;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        /// <summary>The base curve for the grid</summary>
        [Newtonsoft.Json.JsonProperty("Curve", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Polyline Curve { get; set; }
    
        /// <summary>The points at which the grid is split</summary>
        [Newtonsoft.Json.JsonProperty("SplitPoints", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<Vector3> SplitPoints { get; set; }
    
        /// <summary>How is this curve subdivided</summary>
        [Newtonsoft.Json.JsonProperty("SubdivisionMode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Grid1dInputSubdivisionMode? SubdivisionMode { get; set; } = Grid1dInputSubdivisionMode.Manual;
    
        /// <summary>What parameters drive the subdivision?</summary>
        [Newtonsoft.Json.JsonProperty("SubdivisionSettings", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SubdivisionSettings SubdivisionSettings { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public  class GridInputs : S3Args
    
    {
        [Newtonsoft.Json.JsonConstructor]
        
        public GridInputs(GridInputsMode @mode, IList<GridAreas> @gridAreas, bool @showDebugGeometry, Overrides @overrides, string bucketName, string uploadsBucket, Dictionary<string, string> modelInputKeys, string gltfKey, string elementsKey, string ifcKey):
        base(bucketName, uploadsBucket, modelInputKeys, gltfKey, elementsKey, ifcKey)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<GridInputs>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @mode, @gridAreas, @showDebugGeometry, @overrides});
            }
        
            this.Mode = @mode;
            this.GridAreas = @gridAreas;
            this.ShowDebugGeometry = @showDebugGeometry;
            this.Overrides = @overrides;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        /// <summary>Are the gridlines calculated from a typical target, as grid positions absolute from their origin, or relative to the last gridline?</summary>
        [Newtonsoft.Json.JsonProperty("Mode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public GridInputsMode Mode { get; set; } = GridInputsMode.Typical;
    
        /// <summary>List of grids enclosed by the area they apply to.</summary>
        [Newtonsoft.Json.JsonProperty("Grid Areas", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<GridAreas> GridAreas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Show Debug Geometry", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ShowDebugGeometry { get; set; } = false;
    
        [Newtonsoft.Json.JsonProperty("overrides", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Overrides Overrides { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    public enum Grid1dInputSubdivisionMode
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Manual")]
        Manual = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Divide by count")]
        Divide_by_count = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Divide by approximate length")]
        Divide_by_approximate_length = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Divide by fixed length")]
        Divide_by_fixed_length = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Divide by pattern")]
        Divide_by_pattern = 4,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class SubdivisionSettings 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public SubdivisionSettings(int @count, double @targetLength, double @length, SubdivisionSettingsRemainderMode @remainderMode, SubdivisionSettingsCycleMode @cycleMode)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<SubdivisionSettings>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @count, @targetLength, @length, @remainderMode, @cycleMode});
            }
        
            this.Count = @count;
            this.TargetLength = @targetLength;
            this.Length = @length;
            this.RemainderMode = @remainderMode;
            this.CycleMode = @cycleMode;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Count", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Count { get; set; } = 1;
    
        [Newtonsoft.Json.JsonProperty("Target Length", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double TargetLength { get; set; } = 1D;
    
        [Newtonsoft.Json.JsonProperty("Length", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Length { get; set; } = 1D;
    
        [Newtonsoft.Json.JsonProperty("Remainder Mode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public SubdivisionSettingsRemainderMode RemainderMode { get; set; } = SubdivisionSettingsRemainderMode.Remainder_at_both_ends;
    
        [Newtonsoft.Json.JsonProperty("Cycle Mode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public SubdivisionSettingsCycleMode CycleMode { get; set; } = SubdivisionSettingsCycleMode.Cycle;
    
        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();
    
        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    public enum GridInputsMode
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Absolute")]
        Absolute = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Relative")]
        Relative = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Typical")]
        Typical = 2,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class GridAreas 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public GridAreas(string @name, Transform @orientation, U @u, V @v)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<GridAreas>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @name, @orientation, @u, @v});
            }
        
            this.Name = @name;
            this.Orientation = @orientation;
            this.U = @u;
            this.V = @v;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; } = "Main";
    
        /// <summary>The origin and rotation of your grid</summary>
        [Newtonsoft.Json.JsonProperty("Orientation", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Transform Orientation { get; set; }
    
        [Newtonsoft.Json.JsonProperty("U", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public U U { get; set; }
    
        [Newtonsoft.Json.JsonProperty("V", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public V V { get; set; }
    
        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();
    
        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class Overrides 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public Overrides(IList<GridOriginsOverride> @gridOrigins, IList<UGridSubdivisionsOverride> @uGridSubdivisions, IList<VGridSubdivisionsOverride> @vGridSubdivisions, IList<GridlineNamesOverride> @gridlineNames)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<Overrides>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @gridOrigins, @uGridSubdivisions, @vGridSubdivisions, @gridlineNames});
            }
        
            this.GridOrigins = @gridOrigins;
            this.UGridSubdivisions = @uGridSubdivisions;
            this.VGridSubdivisions = @vGridSubdivisions;
            this.GridlineNames = @gridlineNames;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Grid Origins", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<GridOriginsOverride> GridOrigins { get; set; }
    
        [Newtonsoft.Json.JsonProperty("U Grid Subdivisions", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<UGridSubdivisionsOverride> UGridSubdivisions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("V Grid Subdivisions", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<VGridSubdivisionsOverride> VGridSubdivisions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Gridline Names", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<GridlineNamesOverride> GridlineNames { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    public enum SubdivisionSettingsRemainderMode
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Remainder at end")]
        Remainder_at_end = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Remainder at start")]
        Remainder_at_start = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Remainder at both ends")]
        Remainder_at_both_ends = 2,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    public enum SubdivisionSettingsCycleMode
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Repeat Last")]
        Repeat_Last = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Cycle")]
        Cycle = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Wrap")]
        Wrap = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = @"None")]
        None = 3,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class U 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public U(string @name, IList<double> @spacing, IList<GridLines> @gridLines, double @targetTypicalSpacing, double @offsetStart, double @offsetEnd)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<U>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @name, @spacing, @gridLines, @targetTypicalSpacing, @offsetStart, @offsetEnd});
            }
        
            this.Name = @name;
            this.Spacing = @spacing;
            this.GridLines = @gridLines;
            this.TargetTypicalSpacing = @targetTypicalSpacing;
            this.OffsetStart = @offsetStart;
            this.OffsetEnd = @offsetEnd;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; } = "{A}";
    
        /// <summary>Please use Relative mode and Grid Lines &gt; Spacing instead of Spacing.</summary>
        [Newtonsoft.Json.JsonProperty("Spacing", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<double> Spacing { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Grid Lines", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<GridLines> GridLines { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Target Typical Spacing", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(3D, 15D)]
        public double TargetTypicalSpacing { get; set; } = 7.6D;
    
        [Newtonsoft.Json.JsonProperty("Offset Start", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(0D, 15D)]
        public double OffsetStart { get; set; } = 0.5D;
    
        [Newtonsoft.Json.JsonProperty("Offset End", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(0D, 15D)]
        public double OffsetEnd { get; set; } = 0.5D;
    
        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();
    
        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class V 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public V(string @name, IList<double> @spacing, IList<GridLines> @gridLines, double @targetTypicalSpacing, double @offsetStart, double @offsetEnd)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<V>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @name, @spacing, @gridLines, @targetTypicalSpacing, @offsetStart, @offsetEnd});
            }
        
            this.Name = @name;
            this.Spacing = @spacing;
            this.GridLines = @gridLines;
            this.TargetTypicalSpacing = @targetTypicalSpacing;
            this.OffsetStart = @offsetStart;
            this.OffsetEnd = @offsetEnd;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; } = "{1}";
    
        /// <summary>Please use Relative mode and Grid Lines &gt; Spacing instead of Spacing.</summary>
        [Newtonsoft.Json.JsonProperty("Spacing", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<double> Spacing { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Grid Lines", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<GridLines> GridLines { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Target Typical Spacing", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(3D, 15D)]
        public double TargetTypicalSpacing { get; set; } = 7.6D;
    
        [Newtonsoft.Json.JsonProperty("Offset Start", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(0D, 15D)]
        public double OffsetStart { get; set; } = 0.5D;
    
        [Newtonsoft.Json.JsonProperty("Offset End", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(0D, 15D)]
        public double OffsetEnd { get; set; } = 0.5D;
    
        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();
    
        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class GridOriginsOverride 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public GridOriginsOverride(string @id, GridOriginsIdentity @identity, GridOriginsValue @value)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<GridOriginsOverride>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @id, @identity, @value});
            }
        
            this.Id = @id;
            this.Identity = @identity;
            this.Value = @value;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Identity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public GridOriginsIdentity Identity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public GridOriginsValue Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class UGridSubdivisionsOverride 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public UGridSubdivisionsOverride(string @id, UGridSubdivisionsIdentity @identity, UGridSubdivisionsValue @value)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<UGridSubdivisionsOverride>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @id, @identity, @value});
            }
        
            this.Id = @id;
            this.Identity = @identity;
            this.Value = @value;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Identity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public UGridSubdivisionsIdentity Identity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public UGridSubdivisionsValue Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class VGridSubdivisionsOverride 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public VGridSubdivisionsOverride(string @id, VGridSubdivisionsIdentity @identity, VGridSubdivisionsValue @value)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<VGridSubdivisionsOverride>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @id, @identity, @value});
            }
        
            this.Id = @id;
            this.Identity = @identity;
            this.Value = @value;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Identity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public VGridSubdivisionsIdentity Identity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public VGridSubdivisionsValue Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class GridlineNamesOverride 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public GridlineNamesOverride(string @id, GridlineNamesIdentity @identity, GridlineNamesValue @value)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<GridlineNamesOverride>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @id, @identity, @value});
            }
        
            this.Id = @id;
            this.Identity = @identity;
            this.Value = @value;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Identity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public GridlineNamesIdentity Identity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public GridlineNamesValue Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class GridLines 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public GridLines(double @location, double @spacing, int @quantity)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<GridLines>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @location, @spacing, @quantity});
            }
        
            this.Location = @location;
            this.Spacing = @spacing;
            this.Quantity = @quantity;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Location", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Location { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Spacing", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Spacing { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Quantity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Quantity { get; set; } = 1;
    
        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();
    
        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class GridOriginsIdentity 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public GridOriginsIdentity(string @name)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<GridOriginsIdentity>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @name});
            }
        
            this.Name = @name;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class GridOriginsValue 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public GridOriginsValue(Transform @transform)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<GridOriginsValue>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @transform});
            }
        
            this.Transform = @transform;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Transform", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Transform Transform { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class UGridSubdivisionsIdentity 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public UGridSubdivisionsIdentity(string @name)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<UGridSubdivisionsIdentity>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @name});
            }
        
            this.Name = @name;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class UGridSubdivisionsValue 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public UGridSubdivisionsValue(Grid1dInput @uGrid)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<UGridSubdivisionsValue>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @uGrid});
            }
        
            this.UGrid = @uGrid;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("UGrid", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Grid1dInput UGrid { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class VGridSubdivisionsIdentity 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public VGridSubdivisionsIdentity(string @name)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<VGridSubdivisionsIdentity>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @name});
            }
        
            this.Name = @name;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class VGridSubdivisionsValue 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public VGridSubdivisionsValue(Grid1dInput @vGrid)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<VGridSubdivisionsValue>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @vGrid});
            }
        
            this.VGrid = @vGrid;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("VGrid", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Grid1dInput VGrid { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class GridlineNamesIdentity 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public GridlineNamesIdentity(double @parametrizedPosition, GridlineNamesIdentityAxis @axis)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<GridlineNamesIdentity>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @parametrizedPosition, @axis});
            }
        
            this.ParametrizedPosition = @parametrizedPosition;
            this.Axis = @axis;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("ParametrizedPosition", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ParametrizedPosition { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Axis", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public GridlineNamesIdentityAxis Axis { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class GridlineNamesValue 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public GridlineNamesValue(string @name)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<GridlineNamesValue>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @name});
            }
        
            this.Name = @name;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    public enum GridlineNamesIdentityAxis
    {
        [System.Runtime.Serialization.EnumMember(Value = @"U")]
        U = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"V")]
        V = 1,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    internal class JsonInheritanceAttribute : System.Attribute
    {
        public JsonInheritanceAttribute(string key, System.Type type)
        {
            Key = key;
            Type = type;
        }
    
        public string Key { get; }
    
        public System.Type Type { get; }
    }
}