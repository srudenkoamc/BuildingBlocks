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

namespace ProgramByCSV
{
    public class ProgramByCSVOutputs: ResultsBase
    {
		/// <summary>
		/// Quantity of Room Definitions supplied to the model.
		/// </summary>
		[JsonProperty("Room Definition Quantity")]
		public double RoomDefinitionQuantity {get;}

		/// <summary>
		/// Quantity of Rooms which can be derived from the Room Definitions.
		/// </summary>
		[JsonProperty("Room Quantity")]
		public double RoomQuantity {get;}

		/// <summary>
		/// Aggregate area of all Room Definitions.
		/// </summary>
		[JsonProperty("Aggregate Program Area")]
		public double AggregateProgramArea {get;}



        /// <summary>
        /// Construct a ProgramByCSVOutputs with default inputs.
        /// This should be used for testing only.
        /// </summary>
        public ProgramByCSVOutputs() : base()
        {

        }


        /// <summary>
        /// Construct a ProgramByCSVOutputs specifying all inputs.
        /// </summary>
        /// <returns></returns>
        [JsonConstructor]
        public ProgramByCSVOutputs(double roomDefinitionQuantity, double roomQuantity, double aggregateProgramArea): base()
        {
			this.RoomDefinitionQuantity = roomDefinitionQuantity;
			this.RoomQuantity = roomQuantity;
			this.AggregateProgramArea = aggregateProgramArea;

		}

		public override string ToString()
		{
			var json = JsonConvert.SerializeObject(this);
			return json;
		}
	}
}