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
        List<Stop> stops;
        double latInicial = 3.437584;
        double lonInicial = -76.525843;
        GMapOverlay realStops;


        public Form1()
        {
            InitializeComponent();
            stops = new List<Stop>();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
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
            StreamReader reader = new StreamReader("C:/Users/DH/Desktop/datos integra/stops.csv");
            string line = reader.ReadLine();

            string las;
            string lons;

            double la;
            double lon;

            realStops = new GMapOverlay();
            int countInvalidEntries=0;
            int markers = 0;

            while (line != null)
            {
                string[] datos = line.Split(',');
                las = datos[6];
                las.Replace(',', '.');
                lons = datos[7];
                lons.Replace(',', '.');
                la = 0;
                lon = 0;
                try
                {
                    la = double.Parse(las, CultureInfo.InvariantCulture);
                    lon = double.Parse(lons, CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    countInvalidEntries++;  
                }
                try
                {
                    Stop a = new Stop(int.Parse(datos[0]), int.Parse(datos[1]), datos[2], datos[3], double.Parse(datos[6]), double.Parse(datos[7]));
                    stops.Add(a);
                }                
                catch (Exception)
                {
                    countInvalidEntries++;
                }
                
                realStops.Markers.Add(new GMarkerGoogle(new PointLatLng(lon, la),GMarkerGoogleType.blue_dot));
                line = reader.ReadLine();
                markers++;
            }
            Console.WriteLine("number of invalid coordenate entries: "+countInvalidEntries);
            reader.Close();
            gMapControl1.Overlays.Add(realStops);            
        }
    }
}
