using System;
using AirBusWPF.Model;
using Domain;
using System.Collections.Generic;

namespace AirBusWPF.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<List<Aircraft>, Exception> callback)
        {
            // Use this to create design time data

            var item = new List<Aircraft>() { new Aircraft{ AircraftID = 2, Name = "Airbus", EngineCnt = 2 } };
            callback(item, null);
        }
    }
}