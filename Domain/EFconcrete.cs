using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class EFconcrete

    {
        private Entities ctx = new Entities();

        public IEnumerable<Aircraft> GetInternalPlanes()
        {
            var sttate  = ctx.Database.Connection.State;
            var t = ctx.Aircraft.ToList();//.AsEnumerable<Aircraft>();
            return t;

        }
        public IEnumerable<Aircraft> GetPlanes { get { return ctx.Aircraft; } }

    }
}
