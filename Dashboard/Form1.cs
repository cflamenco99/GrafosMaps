using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using static Dashboard.Form1.Grafo;

namespace Dashboard
{
    public partial class Form1 : Form
    {
        #region Metodos Generales
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        double LatInicial = 15.489376;
        double LngInicial = -87.993609;
        Grafo G = new Grafo();
        public List<Vertice> ciudadesList = new List<Vertice>();
        public List<Rutas> rutasList = new List<Rutas>();

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnMapas.Height;
            pnlNav.Top = btnMapas.Top;
            pnlNav.Left = btnMapas.Left;
            btnMapas.BackColor = Color.FromArgb(46, 51, 73);

            //Creando las dimensiones del GMAPCONTROL(herramienta)
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(LatInicial, LngInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 11;
            gMapControl1.AutoScroll = true;

            //Inicializar grafo
            G.Inicializa();

            //Vertices pre-cargados
            G.InsertaVertice("SPS", "15.489376,-87.993609");
            G.InsertaVertice("VILLANUEVA", "15.3175553,-87.9907499");
            G.InsertaVertice("PROGRESO", "15.4156355,-87.8642911");
            G.InsertaVertice("TGU", "14.0839962,-87.2399922");
            G.InsertaVertice("TELA", "15.7716615,-87.5342203");

            G.InsertaVertice("PUERTO CORTES", "15.8312096,-87.9440977");
            G.InsertaVertice("COLON", "15.7780954,-87.6584023");
            G.InsertaVertice("CHOLOMA", "15.5953142,-87.9908587");

            //Aristas pre-cargadas
            InsertarAristaEnGrafo("SPS", "VILLANUEVA", 500);
            InsertarAristaEnGrafo("SPS", "PROGRESO", 600);
            InsertarAristaEnGrafo("VILLANUEVA", "TGU", 300);
            InsertarAristaEnGrafo("PROGRESO", "TGU", 300);

            //Actualizar mapa
            ActualizarMapa();

            //Actualizar ciudades
            ActualizarCiudades();

            //Actualizar los combo box
            ActualizarComboBox();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void btnDashbord_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnMapas.Height;
            pnlNav.Top = btnMapas.Top;
            pnlNav.Left = btnMapas.Left;
            btnMapas.BackColor = Color.FromArgb(46, 51, 73);
        }
        private void btnDashbord_Leave(object sender, EventArgs e)
        {
            btnMapas.BackColor = Color.FromArgb(24, 30, 54);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }     
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }        
        private void btnAgregarCiudad_Click(object sender, EventArgs e)
        {
            if(G.ObtenerTotalVertices() >= 10)
            {
                MessageBox.Show("Se ha alcanzado el limite de 10 vertices permitido.");
                return;
            }

            if(txtNombreCiudad.Text == "")
            {
                MessageBox.Show("Debes ingresar un nombre para la ciudad.");
                return;
            }

            if (txtCoordenadasCiudad.Text == "")
            {
                MessageBox.Show("Debes ingresar una coordenada para la ciudad.");
                return;
            }

            G.InsertaVertice(txtNombreCiudad.Text, txtCoordenadasCiudad.Text);
            ActualizarMapa();
            ActualizarCiudades();
            ActualizarComboBox();

            txtNombreCiudad.Text = "";
            txtCoordenadasCiudad.Text = "";
        }
        private void btnTrazarRuta_Click(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "") 
            {
                MessageBox.Show("Debes ingresar un precio para la ruta.");
                return;
            }
            string nombreCiudadOrigen = cmbCiudadOrigenRutas.Text;
            string nombreCiudadDestino = cmbCiudadDestinoRutas.Text;            
            InsertarAristaEnGrafo(nombreCiudadOrigen, nombreCiudadDestino, Convert.ToInt32(txtPrecio.Text));
            txtPrecio.Text = "";
        }
        private void btnMejorRuta_Click_1(object sender, EventArgs e)
        {
            string nombreCiudadOrigen = cmbCiudadOrigen.Text;
            string nombreCiudadDestino = cmbCiudadDestino.Text;
            G.PrimeroMejor(G.GetVertice(nombreCiudadOrigen), G.GetVertice(nombreCiudadDestino));
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void ActualizarMapa()
        {
            //Actualizar vertices marcados en el mapa
            if (!G.Vacio())
            {
                Vertice aux;
                double coordenadaX;
                double coordenadaY;
                aux = G.h;
                while (aux.sig != null)
                {
                    //Marcador
                    markerOverlay = new GMapOverlay(aux.nombre);
                    coordenadaX = Convert.ToDouble(aux.coordenada.Split(',')[0]);
                    coordenadaY = Convert.ToDouble(aux.coordenada.Split(',')[1]);
                    marker = new GMarkerGoogle(new PointLatLng(coordenadaX, coordenadaY), GMarkerGoogleType.blue);
                    markerOverlay.Markers.Add(marker);//Agregamos al mapa
                    //agregamos un tooltip de texto a los marcadores
                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    marker.ToolTipText = string.Format("{0}:\n Latitud:{1}\n Longitud:{2}", aux.nombre, coordenadaX, coordenadaY);
                    //ahora agregamos el mapa y el marcador al control map
                    gMapControl1.Overlays.Add(markerOverlay);
                    aux = aux.sig;
                }
                if (aux != null) 
                {
                    //Marcador
                    markerOverlay = new GMapOverlay(aux.nombre);
                    coordenadaX = Convert.ToDouble(aux.coordenada.Split(',')[0]);
                    coordenadaY = Convert.ToDouble(aux.coordenada.Split(',')[1]);
                    marker = new GMarkerGoogle(new PointLatLng(coordenadaX, coordenadaY), GMarkerGoogleType.blue);
                    markerOverlay.Markers.Add(marker);//Agregamos al mapa
                                                      //agregamos un tooltip de texto a los marcadores
                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    marker.ToolTipText = string.Format("{0}:\n Latitud:{1}\n Longitud:{2}", aux.nombre, coordenadaX, coordenadaY);
                    //ahora agregamos el mapa y el marcador al control map
                    gMapControl1.Overlays.Add(markerOverlay);
                }
                //Actulizar el mapa
                gMapControl1.Zoom = gMapControl1.Zoom + 1;
                gMapControl1.Zoom = gMapControl1.Zoom - 1;
            }
        }
        public void ActualizarCiudades() 
        {
            //Actualizar ciudades ingresadas en memoria
            if (!G.Vacio())
            {
                Vertice aux;
                aux = G.h;
                while (aux.sig != null)
                {
                    if (!ciudadesList.Contains(aux))
                    {
                        ciudadesList.Add(aux);
                    }
                    
                    aux = aux.sig;
                }
                if (aux != null && !ciudadesList.Contains(aux)) {
                    ciudadesList.Add(aux);
                }
            }
        }
        public void ActualizarComboBox() 
        {
            cmbCiudadOrigenRutas.Items.Clear();
            cmbCiudadDestinoRutas.Items.Clear();
            cmbCiudadOrigen.Items.Clear();
            cmbCiudadDestino.Items.Clear();

            foreach (Vertice ciudad in ciudadesList)
            {
                cmbCiudadOrigenRutas.Items.Add(ciudad.nombre);
                cmbCiudadDestinoRutas.Items.Add(ciudad.nombre);
                cmbCiudadOrigen.Items.Add(ciudad.nombre);
                cmbCiudadDestino.Items.Add(ciudad.nombre);
            }

            cmbCiudadOrigenRutas.SelectedIndex = 0;
            cmbCiudadDestinoRutas.SelectedIndex = 0;
            cmbCiudadOrigen.SelectedIndex = 0;
            cmbCiudadDestino.SelectedIndex = 0;
        }
        public void InsertarAristaEnGrafo(string nombreCiudadOrigen, string nombreCiudadDestino, int precio) 
        {
            //Proceso de insercion y actualizacion de listas
            Vertice ciudadOrigen = G.GetVertice(nombreCiudadOrigen);
            Vertice ciudadDestino = G.GetVertice(nombreCiudadDestino);
            G.InsertaArista(ciudadOrigen, ciudadDestino, precio);
            rutasList.Add(new Rutas(G.GetVertice(nombreCiudadOrigen), G.GetVertice(nombreCiudadDestino), precio));

            //Crear ruta en el mapa
            GMapOverlay Poligono = new GMapOverlay(string.Format("{0}-{1}", nombreCiudadOrigen, nombreCiudadDestino));

            List<PointLatLng> puntos = new List<PointLatLng>();
            //variables para almacenar los datos
            double lng, lat;
            //agregamos los datos del grid
            lat = Convert.ToDouble(ciudadOrigen.coordenada.Split(',')[0]);
            lng = Convert.ToDouble(ciudadOrigen.coordenada.Split(',')[1]);
            puntos.Add(new PointLatLng(lat, lng));

            lat = Convert.ToDouble(ciudadDestino.coordenada.Split(',')[0]);
            lng = Convert.ToDouble(ciudadDestino.coordenada.Split(',')[1]);
            puntos.Add(new PointLatLng(lat, lng));

            GMapPolygon PuntosRuta = new GMapPolygon(puntos, string.Format("RUTA-{0}-{1}", nombreCiudadOrigen, nombreCiudadDestino));
            Poligono.Polygons.Add(PuntosRuta);
            gMapControl1.Overlays.Add(Poligono);

            //Actulizar el mapa
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;
        }
        public class Rutas 
        {
            public Rutas(Vertice origen, Vertice destino, int precio)
            {
                Origen = origen;
                Destino = destino;
                Precio = precio;
            }
            public Vertice Origen { get; set; }
            public Vertice Destino { get; set; }
            public int Precio { get; set; }
        }
        #endregion        

        #region Algoritmo Grafos Maps - Ejercicios de Clase
        public class Grafo
        {
            public Vertice h;
            public class Vertice
            {
                public Vertice sig;
                public Arista ady;
                public string nombre = "";
                public string coordenada = "";
            }
            public class Arista
            {
                public Arista sig;
                public Vertice ady;
                public int peso;
            }            
            public void Inicializa()
            {
                h = null;
            }
            public bool Vacio()
            {
                return h == null;
            }
            public Vertice GetVertice(string nombre)
            {
                Vertice aux;
                aux = h;
                while (aux != null)
                {
                    if (aux.nombre == nombre)
                    {
                        return aux;
                    }
                    aux = aux.sig;
                }
                return null;
            }
            public void InsertaArista(Vertice origen, Vertice destino, int peso)
            {
                Arista nueva = new Arista();
                nueva.peso = peso;
                nueva.sig = null;
                nueva.ady = null;

                Arista aux;
                aux = origen.ady;

                if (aux == null)
                {
                    origen.ady = nueva;
                    nueva.ady = destino;
                }
                else
                {
                    while (aux.sig != null)
                    {
                        aux = aux.sig;
                    }
                    aux.sig = nueva;
                    nueva.ady = destino;
                }
            }
            public void InsertaVertice(string nombre, string coordenada)
            {
                Vertice nuevo = new Vertice();
                nuevo.nombre = nombre;
                nuevo.coordenada = coordenada;
                nuevo.sig = null;
                nuevo.ady = null;

                if (Vacio())
                {
                    h = nuevo;
                }
                else
                {
                    Vertice aux;
                    aux = h;
                    while (aux.sig != null)
                    {
                        aux = aux.sig;
                    }
                    aux.sig = nuevo;
                }
            }
            public int ObtenerTotalVertices()
            {
                int total = 1;
                if (Vacio())
                {
                    total = 0;
                }
                else
                {
                    Vertice aux;
                    aux = h;
                    while (aux.sig != null)
                    {
                        aux = aux.sig;
                        total += 1;
                    }
                }
                return total;                    
            }
            public void PrimeroMejor(Vertice origen, Vertice destino)
            {
                string mejorRuta = "";
                int CostoActual, band, band2 = 0;
                Vertice VerticeActual, DestinoActual;
                Arista aux;
                List<Pair<Vertice, int>> ListaCostos = new List<Pair<Vertice, int>>();
                List<Pair<Vertice, int>> ListaOrdenada = new List<Pair<Vertice, int>>();
                Stack<Pair<Vertice, Vertice>> pila = new Stack<Pair<Vertice, Vertice>>();
                List<Pair<Vertice, int>>.Enumerator i,j;
                ListaCostos.Add(new Pair<Vertice,int>(origen,0));
                ListaOrdenada.Add(new Pair<Vertice, int>(origen, 0));

                while (ListaOrdenada.Count > 0)
                {
                    VerticeActual = ListaOrdenada.First().first;
                    CostoActual = ListaOrdenada.First().second;

                    ListaOrdenada.RemoveAll(x=> x.first == VerticeActual && x.second == CostoActual);

                    if (VerticeActual == destino)
                    {
                        band2 = 1;
                        DestinoActual = destino;
                        while (pila.Count > 0)
                        {
                            mejorRuta += DestinoActual.nombre + "<-";
                            Console.Write(DestinoActual.nombre);
                            Console.Write("<-");
                            //while (pila.Count > 0 && pila.Peek().first != DestinoActual)
                            //{
                            //    
                            //}
                            if (pila.Count > 0)
                            {
                                DestinoActual = pila.Peek().first;
                            }
                            pila.Pop();
                        }
                        mejorRuta += origen.nombre;
                        break;
                    }
                    aux = VerticeActual.ady;
                    while (aux != null)
                    {
                        band = 0;
                        CostoActual = CostoActual + aux.peso;
                        for (i = ListaCostos.GetEnumerator(); i.MoveNext();)
                        {
                            if (aux.ady == i.Current.first)
                            {
                                band = 1;
                                if (CostoActual < i.Current.second)
                                {                                    
                                    i.Current.second = CostoActual;
                                    for (j = ListaOrdenada.GetEnumerator(); j.MoveNext();)
                                    {
                                        if (j.Current.first == aux.ady)
                                        {
                                            j.Current.second = CostoActual;
                                        }
                                    }
                                    pila.Push(new Pair<Vertice, Vertice>(VerticeActual, aux.ady));
                                    CostoActual = CostoActual - aux.peso;
                                }
                            }
                        }
                        if (band == 0)
                        {
                            ListaCostos.Add(new Pair<Vertice, int>(aux.ady, CostoActual));
                            ListaOrdenada.Add(new Pair<Vertice, int>(aux.ady, CostoActual));
                            if (pila.Count() == 0)
                            {
                                pila.Push(new Pair<Vertice, Vertice>(VerticeActual, aux.ady));
                            }
                            else 
                            {
                                if (VerticeActual != pila.Last().first)
                                {
                                    pila.Push(new Pair<Vertice, Vertice>(VerticeActual, aux.ady));
                                }
                            }  
                            CostoActual = CostoActual - aux.peso;
                        }
                        aux = aux.sig;
                    }
                }
                if (band2 == 0)
                {
                    Console.Write("No hay una ruta entre esos dos vertices");
                    Console.Write("\n");
                }
                MessageBox.Show(mejorRuta);
            }
            public class Pair<T, U>
            {
                public Pair()
                {
                }
                public Pair(T first, U second)
                {
                    this.first = first;
                    this.second = second;
                }
                public T first { get; set; }
                public U second { get; set; }
            };
        }
        #endregion
    }
}
