using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;

namespace modelo
{
    public class Bus
    {
        private String busId;
        private Hashtable ubicationTime;
        private Thread sincro;
        private double posX;
        private double posY;
        private String time;
        


        public Bus(string busId, String time)
        {
            this.BusId = busId;
            this.time = time;
            UbicationTime = new Hashtable();
        }

        public string BusId { get => busId; set => busId = value; }
        public Hashtable UbicationTime { get => ubicationTime; set => ubicationTime = value; }
        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }
        public Thread Sincro { get => sincro; set => sincro = value; }
        public string Time { get => time; set => time = value; }

        public void trmove()
        {

            this.PosX = Convert.ToDouble(((Ubication)UbicationTime[Time]).Posx);
            this.PosY = Convert.ToDouble(((Ubication)UbicationTime[Time]).Posy);
           
        }

        public void move()
        {
            sincro = new Thread(new ThreadStart(trmove));
            sincro.Start();
        }


    }
}
