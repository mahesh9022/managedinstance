//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace managedsql
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehicleTemperature
    {
        public long VehicleTemperatureID { get; set; }
        public string VehicleRegistration { get; set; }
        public int ChillerSensorNumber { get; set; }
        public System.DateTime RecordedWhen { get; set; }
        public decimal Temperature { get; set; }
        public bool IsCompressed { get; set; }
        public string FullSensorData { get; set; }
        public byte[] CompressedSensorData { get; set; }
    }
}
