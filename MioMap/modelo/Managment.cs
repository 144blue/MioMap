using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Managment
    {


        Hashtable stops;
        Hashtable stations;
        Hashtable bus1;
        GenericTime realTime;

        public Managment()
        {
            Stops = new Hashtable();
            Stations = new Hashtable();
            Bus1 = new Hashtable();
            RealTime = new GenericTime(2019, 5, 10, 39, 9, 25);
            Console.WriteLine("initilized menthods in managment");
            loadStops();
            readBuss();
        }

        public Hashtable Stops { get => stops; set => stops = value; }
        public Hashtable Stations { get => stations; set => stations = value; }
        public Hashtable Bus1 { get => bus1; set => bus1 = value; }
        public GenericTime RealTime { get => realTime; set => realTime = value; }

        private void loadStops()
        {
           

            //DO NOT PUT CSV IN PROYECT FOLDER, USE ABSOLUTE PATH
            StreamReader reader = new StreamReader("C:/Users/DH/Desktop/datos integra/stops.csv");

            Console.WriteLine("to read file");
            //StreamReader reader = new StreamReader(ABSOLUTE_PATH);
            string line = reader.ReadLine();

            string las;
            string lons;

            double la;
            double lon;


            int countInvalidEntries = 0;
            int markers = 0;



            while (line != null && countInvalidEntries < 100)
            {
                string[] datos = line.Split(',');
                las = datos[6];
                las.Replace(',', '.');
                lons = datos[7];
                lons.Replace(',', '.');
                //la = 0;
                //lon = 0;
                //try
                //{
                //    la = double.Parse(lons, CultureInfo.InvariantCulture);
                //    lon = double.Parse(las, CultureInfo.InvariantCulture);
                //}
                //catch (Exception)
                //{
                //    countInvalidEntries++;
                //}
                try
                {
                    //  Stop Id,             Plan Version,      Short Name, Long Name,        Gps x,                 Gps Y
                    Stop a = new Stop(int.Parse(datos[0]), int.Parse(datos[1]), datos[2], datos[3], datos[6], datos[7]);
                    if (a.ShortName.Contains("7-ago") || a.ShortName.Contains("ALA") ||
                        a.ShortName.Contains("AMAN") || a.ShortName.Contains("ATG") ||
                        a.ShortName.Contains("CHIM") || a.ShortName.Contains("C.PALOS") ||
                        a.ShortName.Contains("MELEN") || a.ShortName.Contains("ESTAD") ||
                        a.ShortName.Contains("FATI") || a.ShortName.Contains("FLOR") ||
                        a.ShortName.Contains("FRAY") || a.ShortName.Contains("HORMI") ||
                        a.ShortName.Contains("L.AME") || a.ShortName.Contains("LIDO") ||
                        a.ShortName.Contains("MANZA") || a.ShortName.Contains("MZAN") ||
                        a.ShortName.Contains("N.LATIR") || a.ShortName.Contains("PAM") ||
                        a.ShortName.Contains("PTCU") || a.ShortName.Contains("PILO") ||
                        a.ShortName.Contains("CAY") || a.ShortName.Contains("PLATO") ||
                        a.ShortName.Contains("POPU") || a.ShortName.Contains("PRAD") ||
                        a.ShortName.Contains("PRIMI") || a.ShortName.Contains("REFU") ||
                        a.ShortName.Contains("SALO") || a.ShortName.Contains("SAN") ||
                        a.ShortName.Contains("SNT") || a.ShortName.Contains("ST.") ||
                        a.ShortName.Contains("STRO") || a.ShortName.Contains("SUC") ||
                        a.ShortName.Contains("CALS") || a.ShortName.Contains("PCO") ||
                        a.ShortName.Contains("T.C-") || a.ShortName.Contains("TEQU") ||
                        a.ShortName.Contains("A.SAN") || a.ShortName.Contains("TCAL") ||
                        a.ShortName.Contains("TMEN") || a.ShortName.Contains("TOR") ||
                        a.ShortName.Contains("UDP") || a.ShortName.Contains("UNIV") ||
                        a.ShortName.Contains("VERS") || a.ShortName.Contains("CONQ") ||
                        a.ShortName.Contains("CALD") || a.ShortName.Contains("CAP") ||
                        a.ShortName.Contains("CEN") || a.ShortName.Contains("CHAP") ||
                         a.ShortName.Contains("RIO") || a.ShortName.Contains("ERMI") ||
                        a.ShortName.Contains("BELA") || a.ShortName.Contains("BUIT") ||
                        a.ShortName.Contains("TREB") || a.ShortName.Contains("TRON") ||
                        a.ShortName.Contains("VLN") || a.ShortName.Contains("VIC") ||
                        a.ShortName.Contains("VIP"))
                    {
                        if (!Stations.ContainsKey(datos[0]))
                        {
                            Stations.Add(datos[0], a);
                        }
                    }
                    else
                    {
                        if (!Stops.ContainsKey(datos[0]))
                        {
                            Stops.Add(datos[0], a);
                        }
                    }

                }
                catch (Exception)
                {
                    countInvalidEntries++;
                }

                line = reader.ReadLine();
                markers++;
            }
            Console.WriteLine("number of invalid coordenate entries: " + countInvalidEntries);
            reader.Close();


        }


        public void readBuss()
        {
            bus1 = new Hashtable();


            //DO NOT PUT CSV IN PROYECT FOLDER, USE ABSOLUTE PATH
            StreamReader reader = new StreamReader("C:/Users/DH/Desktop/datos integra/DATAGRAMS.csv");

           
            string line = reader.ReadLine();

            string las;
            string lons;

            double la;
            double lon;

            

            int countInvalidEntries = 0;

            int max = 0;

            while (line != null && max < 100)
            {
                string[] datos = line.Split(',');
                las = datos[4];
                las.Insert(2, ",");
                lons = datos[5];
                lons.Insert(3, ",");
                String[] timeDate = datos[10].Split(' ');

                try
                {        

                    if (!bus1.ContainsKey(datos[11]))
                    {
                        Bus a = new Bus();
                        Ubication u = new Ubication(las, lons);


                        a.UbicationTime.Add(timeDate[1], u);
                        bus1.Add(datos[11], a);

                    }
                    else
                    {
                        Bus temporal = (Bus)bus1[datos[11]];
                        temporal.UbicationTime.Add(timeDate[1], new Ubication(las, lons));

                    }

                }
                catch (Exception)
                {
                    countInvalidEntries++;
                }

                line = reader.ReadLine();
                max++;
            }
            Console.WriteLine("number of invalid coordenate entries of datagrams: " + countInvalidEntries);
            reader.Close();

        }

    }
            

        


    
}
