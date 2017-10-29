using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace AirPlaneMVVM.Model
{
    static class EntityObservable
    {

         static  public  ObservableCollection<Aircraft> AirCrafts;
        static EntityObservable()
        {
            AirCrafts = new ObservableCollection<Aircraft> {
                new Aircraft { AircraftID = 1, Name ="Test", Category = "dsd", Description = "dwsdw" },
                new Aircraft { AircraftID = 12, Name = "test2", Category = "dsd2", Description = "dwsdw2" } };//new EFconcrete().GetPlanes);
            
        }

    }
}
