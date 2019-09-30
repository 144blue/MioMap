using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Bus
    {
<<<<<<< HEAD
        private string Latitud;
        private string Longitud;
        private string BusId;

        public Bus(string latitud, string longitud, string busId)
        {
            Latitud = latitud;
            Longitud = longitud;
            BusId = busId;
        }

        public string Latitud1 { get => Latitud; set => Latitud = value; }
        public string Longitud1 { get => Longitud; set => Longitud = value; }
        public string BusId1 { get => BusId; set => BusId = value; }
=======
        private String busId;
        private Hashtable ubicationTime;

        public Bus(string busId)
        {
            this.BusId = busId;
            UbicationTime = new Hashtable();
            
        }

        public string BusId { get => busId; set => busId = value; }
        public Hashtable UbicationTime { get => ubicationTime; set => ubicationTime = value; }
>>>>>>> 8fe756e87b90266898da2e1142bfda621c17112a
    }
}
