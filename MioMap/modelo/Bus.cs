using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Bus
    {
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
    }
}
