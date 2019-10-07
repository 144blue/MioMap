using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using modelo;
using System;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;

namespace MioMap
{
    public partial class Form1 : Form
    {
        //Hashtable stops;
        //Hashtable stations;
        // Hashtable bus1;
        Managment model;
        double latInicial = 3.437584;
        double lonInicial = -76.525843;
        GMapOverlay timeBusStatus;
        GMapOverlay onlyStops;
        GMapOverlay onlyStations;
        const string ABSOLUTE_PATH = "C:/Users/juanm/Downloads/stops.csv";
        GroupBox options;
        //System.Timers.Timer clock;
        //GenericTime realTime;
  
        

        public Form1()
        {
            InitializeComponent();
            //stops = new Hashtable();
            //stations = new Hashtable();
            model = new Managment();
            options = new GroupBox();
            timeBusStatus = new GMapOverlay();
            onlyStations = new GMapOverlay();
            onlyStops = new GMapOverlay();
           
            //bus1 = new Hashtable();
            //realTime = new GenericTime(2019,5,10,39,9,25);
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
     
            Console.WriteLine("form1_load");


            //moveBuses();
            printStops();
            printStations();
            
            clockView.Text = model.RealTime.Hour + ":" + model.RealTime.Minute + ":" + model.RealTime.Second;
        }

        public void watch()
        {
            
        }

        public void printStops()
        {
            ICollection keys = model.Stops.Keys;

            foreach(String a in keys)
            {          

                double la = double.Parse(((Stop)(model.Stops[a])).Gps_Y, CultureInfo.InvariantCulture);
                double lon = double.Parse(((Stop)(model.Stops[a])).Gps_X, CultureInfo.InvariantCulture);
                onlyStops.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), GMarkerGoogleType.blue_dot));
            }
            
        }

        public void printStations()
        {
            ICollection keys = model.Stations.Keys;
            foreach (String a in keys)
            {
                double la = double.Parse(((Stop)(model.Stations[a])).Gps_Y, CultureInfo.InvariantCulture);
                double lon = double.Parse(((Stop)(model.Stations[a])).Gps_X, CultureInfo.InvariantCulture);
                onlyStations.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), GMarkerGoogleType.green_dot));
            }
            
        }

        

        private void rbTodo_CheckedChanged(object sender, EventArgs e)
        {
            gMapControl1.Overlays.Clear();
            gMapControl1.Overlays.Add(onlyStations);
            gMapControl1.Overlays.Add(onlyStops);
        }

        //public void moveBuses()
        //{
        //    ICollection keys = model.Bus1.Keys;
        //    foreach (String a in keys)
        //    {
             

        //        ((Bus)(model.Bus1[a])).move();

        //    }
        //}.UbicationTime[])

        public void printBuses()
        {
            ICollection keys = model.Bus1.Keys;
            foreach (String a in keys)
            {
                if (((Bus)(model.Bus1[a])).UbicationTime.ContainsKey(model.RealTime.generateDataTime()))
                {
                    Ubication inTimeubication = (Ubication)((Bus)(model.Bus1[a])).UbicationTime[model.RealTime.generateDataTime()];
                    double la = double.Parse(inTimeubication.Posx);
                    double lon = double.Parse(inTimeubication.Posy);
                    GMapMarker marker = new GMarkerGoogle(new PointLatLng(la, lon), GMarkerGoogleType.green_dot);
                    marker.ToolTipText = a;
                    marker.Size = new System.Drawing.Size(20,20);
                    timeBusStatus.Markers.Add(marker);
                    gMapControl1.Overlays.Add(timeBusStatus);
                    Console.WriteLine("paint coordenate: " +la+"::::::"+lon);
                }
                
           

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            gMapControl1.Overlays.Clear();
            printBuses();
            

            timer1.Start();
            button2.Enabled = false;

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //gMapControl1.Overlays.Clear();
            //timeBusStatus.Clear();
           
            model.RealTime.passSecond();
            clockView.Text = model.RealTime.Hour + ":" + model.RealTime.Minute + ":" + model.RealTime.Second;
            printBuses();
            

        }
    }
}
