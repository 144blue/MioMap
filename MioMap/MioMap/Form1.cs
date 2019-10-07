using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using modelo;
using InputKey;
namespace MioMap
{
    public partial class Form1 : Form
    {
     
        Managment model;
        double latInicial = 3.437584;
        double lonInicial = -76.525843;
        GMapOverlay realStops;
        GMapOverlay onlyStops;
        GMapOverlay onlyStations;
        GroupBox options;
        GMapOverlay onlyBus ;
        int vel = 1;



        public Form1()
        {
            InitializeComponent();
            model = new Managment();
            options = new GroupBox();
            realStops = new GMapOverlay();
            onlyStations = new GMapOverlay();
            onlyStops = new GMapOverlay();
            onlyBus = new GMapOverlay();
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
            gMapControl1.Zoom = 12;
            gMapControl1.AutoScroll = true;
            gMapControl1.ShowCenter = false;


           // timer1.Start();

            printStops();
            printStations();
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



        String idBus;
        private void Button2_Click(object sender, EventArgs e)
        {
            onlyBus.Markers.Clear();

             idBus = InputDialog.mostrar("Escriba el id del bus");
            if (idBus!=null) {
                timer2.Enabled = true;
            }
        }

     
        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            model.RealTime.passSecond();
            UbicationTime.Text = model.RealTime.generateDataTime();
            printAllMoveBus(model.RealTime.generateDataTime());
            Thread.Sleep(1000);
            gMapControl1.Overlays.Clear();
            onlyBus.Markers.Clear();


        }

        public void printAllMoveBus(String date)
        {

            ICollection keys = model.Bus1.Keys;

            foreach (String actual in keys)
            {
                Bus busActual = (Bus)model.Bus1[actual];
                ICollection keysut = busActual.UbicationTime.Keys;
         
                if (busActual.UbicationTime.ContainsKey(date))
                {
                    double la = double.Parse(((Ubication)busActual.UbicationTime[date]).Latitud);
                    double lon = double.Parse(((Ubication)busActual.UbicationTime[date]).Longitud);
                //    Console.WriteLine(busActual.BusId + "  ::::::  "+ la+"   "+ lon);

                         onlyBus.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), GMarkerGoogleType.blue_dot));
                
                }

                
            }
         //   Console.WriteLine("agrego los makers");
            gMapControl1.Overlays.Add(onlyBus);
            gMapControl1.Refresh();

        }



    

        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
         
        }

        

        private void Button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
          
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            model.RealTime.passSecond();
            UbicationTime.Text = model.RealTime.generateDataTime();
            prinMoveOneBus(model.RealTime.generateDataTime(), idBus);

        }
        private void prinMoveOneBus(string date, string idBus)
        {
            //    Console.WriteLine(model.Bus1.ContainsKey(idBus));

            if (model.Bus1.ContainsKey(idBus))
            {
                Bus busActual = (Bus)model.Bus1[idBus];
                if (busActual.UbicationTime.ContainsKey(date))
                {
                    double la = double.Parse(((Ubication)busActual.UbicationTime[date]).Latitud);
                    double lon = double.Parse(((Ubication)busActual.UbicationTime[date]).Longitud);
                    //     Console.WriteLine(busActual.BusId + "  ::::::  " + la + "   " + lon);

                    onlyBus.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), GMarkerGoogleType.blue_dot));

                }
                gMapControl1.Overlays.Add(onlyBus);
                gMapControl1.Refresh();
            }

            gMapControl1.Overlays.Clear();

        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            gMapControl1.Overlays.Clear();
            onlyBus.Markers.Clear();

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Interval -= 100;
                timer2.Interval -= 100;
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("velocidad maxima");

            }



            Console.WriteLine(timer1.Interval);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (timer1.Interval >= 1000 || timer2.Interval >= 1000)
            {
                MessageBox.Show("velocidad minima");
            }
            else
            {
                timer1.Interval += 100;
                timer2.Interval += 100;
            }
          
            Console.WriteLine(timer1.Interval);
        }
    }

      
    
}
