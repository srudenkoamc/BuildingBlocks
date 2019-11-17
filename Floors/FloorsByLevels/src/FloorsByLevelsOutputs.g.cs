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

namespace FloorsByLevels
{
    public class FloorsByLevelsOutputs: ResultsBase
    {
		/// <summary>
		/// Aggregate area of all floors.
		/// </summary>
		[JsonProperty("Total Area")]
		public double TotalArea {get;}

		/// <summary>
		/// Quantity of floors.
		/// </summary>
		[JsonProperty("Floor Quantity")]
		public double FloorQuantity {get;}


        
        /// <summary>
        /// Construct a FloorsByLevelsOutputs with default inputs.
        /// This should be used for testing only.
        /// </summary>
        public FloorsByLevelsOutputs() : base()
        {

        }


        /// <summary>
        /// Construct a FloorsByLevelsOutputs specifying all inputs.
        /// </summary>
        /// <returns></returns>
        [JsonConstructor]
        public FloorsByLevelsOutputs(double totalarea, double floorquantity): base()
        {
			this.TotalArea = totalarea;
			this.FloorQuantity = floorquantity;

		}

		public override string ToString()
		{
			var json = JsonConvert.SerializeObject(this);
			return json;
		}
	}
}