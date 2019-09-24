// This code was generated by Hypar.
// Edits to this code will be overwritten the next time you run 'hypar init'.
// DO NOT EDIT THIS FILE.

using Elements;
using Elements.GeoJSON;
using Elements.Geometry;
using Hypar.Functions;
using Hypar.Functions.Execution;
using Hypar.Functions.Execution.AWS;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Site
{
    public class SiteOutputs: ResultsBase
    {
		/// <summary>
		/// Ratio of footprint area to site area.
		/// </summary>
		[JsonProperty("Lot Coverage Ratio")]
		public double LotCoverageRatio {get;}

		/// <summary>
		/// The Length
		/// </summary>
		[JsonProperty("Length")]
		public double Length {get;}

		/// <summary>
		/// The Width
		/// </summary>
		[JsonProperty("Width")]
		public double Width {get;}

		/// <summary>
		/// Site Area
		/// </summary>
		[JsonProperty("Site Area")]
		public double SiteArea {get;}

		/// <summary>
		/// Building Area
		/// </summary>
		[JsonProperty("Builing Area")]
		public double BuilingArea {get;}


        
        /// <summary>
        /// Construct a SiteOutputs with default inputs.
        /// This should be used only for testing.
        /// </summary>
        public SiteOutputs() : base()
        {

        }
        
        /// <summary>
        /// Construct a SiteOutputs specifying all inputs.
        /// </summary>
        /// <returns></returns>
        [JsonConstructor]
        public SiteOutputs(double lotcoverageratio, double length, double width, double sitearea, double builingarea): base()
        {
			this.LotCoverageRatio = lotcoverageratio;
			this.Length = length;
			this.Width = width;
			this.SiteArea = sitearea;
			this.BuilingArea = builingarea;

		}

		public override string ToString()
		{
			var json = JsonConvert.SerializeObject(this);
			return json;
		}
	}
}