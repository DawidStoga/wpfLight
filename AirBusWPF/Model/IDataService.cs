using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirBusWPF.Model
{
    public interface IDataService
    {
        void GetData(Action<List<Aircraft>, Exception> callback);
    }
}
