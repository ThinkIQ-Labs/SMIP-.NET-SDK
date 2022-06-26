using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smip.sdk.SmipModel
{
    public class SmipEquipment : SmipThing
    {

        public List<SmipAttribute> attributes { get; set; }

        public SmipEquipment()
        {
            attributes = new List<SmipAttribute>();
        }

    }
}
