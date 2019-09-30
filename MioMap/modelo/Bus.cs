using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Bus
    {
        private String busId;
        private Hashtable ubicationTime;

        public Bus(string busId)
        {
            this.BusId = busId;
            UbicationTime = new Hashtable();
            
        }

        public string BusId { get => busId; set => busId = value; }
        public Hashtable UbicationTime { get => ubicationTime; set => ubicationTime = value; }
    }
}
