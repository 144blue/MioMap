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
        GMarkerGoogle stopsMG;
        double latInicial = 3.437584;
        double lonInicial = -76.525843;

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

            StreamReader reader = new StreamReader("stops.csv");
            string line = reader.ReadLine();

            string las;
            string lons;

            double la;
            double lon;

            while (line != null)
            {
                string[] datos = line.Split(',');

                las = datos[6];
                las.Replace(',', '.');
                lons = datos[7];
                lons.Replace(',', '.');
                
                la = double.Parse(las, CultureInfo.InvariantCulture);
                lon = double.Parse(lons, CultureInfo.InvariantCulture);


                Stop a = new Stop(int.Parse(datos[0]), int.Parse(datos[1]), datos[2], datos[3], double.Parse(datos[6]), double.Parse(datos[7]));
                stops.Add(a);

                line = reader.ReadLine();
            }
            reader.Close();
        }
    }
}
