using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirBusWPF.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<List<Aircraft>, Exception> callback)
        {
            // Use this to connect to the actual data service
            string title1 = null;
            //Domain.Class1 cl1 = new Domain.Class1();

            var ctx = new EFconcrete();
          var planes  =   ctx.GetPlanes;
            var planesIn = ctx.GetInternalPlanes();


          var result = (from x in (new EFconcrete().GetPlanes) where x.EngineCnt == 2 select x).ToList();

           
            foreach (var s in result)
            {
                var item = s;
                title1 += s.EngineCnt;

              //  var item = new Airplane() { Engines = "2", Name = 2 };
            callback(result, null);
            }
        }
    }
}