using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smip.sdk.SmipModel
{
    public class SmipQuantity : SmipThing
    {
        public List<SmipMeasurementUnit> measurementUnits { get; set; }
        public SmipQuantity()
        {
            measurementUnits = new List<SmipMeasurementUnit>();
        }
    }
}
