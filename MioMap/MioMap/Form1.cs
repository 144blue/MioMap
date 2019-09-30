using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using modelo;

namespace MioMap
{
    public partial class Form1 : Form
    {
        HashSet<Stop> stops;
        HashSet<Stop> stations;
        double latInicial = 3.437584;
        double lonInicial = -76.525843;
        GMapOverlay realStops;
        GMapOverlay onlyStops;
        GMapOverlay onlyStations;
        const string ABSOLUTE_PATH = "C:/Users/juanm/Downloads/stops.csv";
        GroupBox options;

        public Form1()
        {
            InitializeComponent();
            stops = new HashSet<Stop>();
            stations = new HashSet<Stop>();
            options = new GroupBox();
            realStops = new GMapOverlay();
            onlyStations = new GMapOverlay();
            onlyStops = new GMapOverlay();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gMapControl1.Overlays.Clear();
            gMapControl1.Overlays.Add(onlyStations);
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gMapControl1.Overlays.Clear();
            gMapControl1.Overlays.Add(onlyStops);
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void GMapControl1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(latInicial, lonInicial);
            gMapControl1.MinZoom = 0; 
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;
            gMapControl1.ShowCenter = false;

            
            //DO NOT PUT CSV IN PROYECT FOLDER, USE ABSOLUTE PATH
            //StreamReader reader = new StreamReader("stops.csv");
            //THIS IS MY ABSOLUTE PATH 144BLUE, USE YOUR OWN PATH B****
            Console.WriteLine("to read file");
            StreamReader reader = new StreamReader(ABSOLUTE_PATH);
            string line = reader.ReadLine();

            string las;
            string lons;

            double la;
            double lon;

            
            int countInvalidEntries=0;
            int markers = 0;

            while (line != null)
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
                    if(a.ShortName.Contains("7-ago") || a.ShortName.Contains("ALA") ||
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
                        stations.Add(a);
                    } else
                    {
                        stops.Add(a);
                    }
                    
                }                
                catch (Exception)
                {
                    countInvalidEntries++;
                }

                line = reader.ReadLine();
                markers++;
            }
            Console.WriteLine("number of invalid coordenate entries: "+countInvalidEntries);
            reader.Close();

            printStops();
            printStations();
        }

        public void printStops()
        {
            foreach(Stop a in stops)
            {
                
                double la = double.Parse(a.Gps_Y, CultureInfo.InvariantCulture);
                double lon = double.Parse(a.Gps_X, CultureInfo.InvariantCulture);
                onlyStops.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), GMarkerGoogleType.blue_dot));
            }
            
        }

        public void printStations()
        {
            foreach (Stop a in stations)
            {
                double la = double.Parse(a.Gps_Y, CultureInfo.InvariantCulture);
                double lon = double.Parse(a.Gps_X, CultureInfo.InvariantCulture);
                onlyStations.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), GMarkerGoogleType.green_dot));
            }
            
        }

        

        private void rbTodo_CheckedChanged(object sender, EventArgs e)
        {
            gMapControl1.Overlays.Clear();
            gMapControl1.Overlays.Add(onlyStations);
            gMapControl1.Overlays.Add(onlyStops);
        }

        public void createPolygon(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Blue, 2);
            Point p1 = new Point();
        }
    }
}
