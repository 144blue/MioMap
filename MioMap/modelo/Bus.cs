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
        //private Thread sincro;
        private double posX;
        private double posY;
        private GenericTime time;
        


        public Bus(string busId, GenericTime time)
        {
            this.BusId = busId;
            this.time = time;
            UbicationTime = new Hashtable();
        }

        public string BusId { get => busId; set => busId = value; }
        public Hashtable UbicationTime { get => ubicationTime; set => ubicationTime = value; }
        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }
        //public Thread Sincro { get => sincro; set => sincro = value; }
        public GenericTime Time { get => time; set => time = value; }

        public void trmove()
        {
            
            if (ubicationTime.ContainsKey(time.generateDataTime()))
            {
                
                Ubication temporal = (Ubication)UbicationTime[Time.generateDataTime()];
                this.PosX = Convert.ToDouble(temporal.Posx);
                this.PosY = Convert.ToDouble(temporal.Posy);
                time.passSecond();
                Console.WriteLine("contais ubication in: " +time.generateDataTime()+posX+"//"+PosY);
                Thread.Sleep(200);
                
            }

            Console.WriteLine("busThreatAlive");
           
        }

        //public void move()
        //{
        //    sincro = new Thread(new ThreadStart(trmove));
        //    sincro.Start();
        //}


    }
}
