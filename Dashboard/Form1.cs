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

namespace Dashboard
{
    public partial class Form1 : Form
    {
        #region Metodos Generales
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        PointLatLng inicio;
        PointLatLng final;
        double LatInicial = 15.489376;
        double LngInicial = -87.993609;

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnMapas.Height;
            pnlNav.Top = btnMapas.Top;
            pnlNav.Left = btnMapas.Left;
            btnMapas.BackColor = Color.FromArgb(46, 51, 73);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Creando las dimensiones del GMAPCONTROL(herramienta)
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(LatInicial, LngInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;

            //Marcador
            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.blue);
            markerOverlay.Markers.Add(marker);//Agregamos al mapa

            //agregamos un tooltip de texto a los marcadores
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("Ubicación:\n Latitud:{0}\n Longitud:{1}", LatInicial, LngInicial);

            //ahora agregamos el mapa y el marcador al control map
            gMapControl1.Overlays.Add(markerOverlay);
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
        private void btnMejorRuta_Click(object sender, EventArgs e)
        {
            //Ejemplo de uso de algoritmo
            Node NodeA = new Node() { City = "A" };
            Node NodeB = new Node() { City = "B" };
            Node NodeC = new Node() { City = "C" };
            Node NodeD = new Node() { City = "D" };

            NodeA.Ways.Add(new Way() { Node = NodeB, Distance = 5 });
            NodeA.Ways.Add(new Way() { Node = NodeC, Distance = 15 });
            NodeA.Ways.Add(new Way() { Node = NodeD, Distance = 7 });
            NodeB.Ways.Add(new Way() { Node = NodeA, Distance = 5 });
            NodeB.Ways.Add(new Way() { Node = NodeC, Distance = 10 });
            NodeB.Ways.Add(new Way() { Node = NodeD, Distance = 5 });
            NodeC.Ways.Add(new Way() { Node = NodeA, Distance = 15 });
            NodeC.Ways.Add(new Way() { Node = NodeB, Distance = 10 });
            NodeC.Ways.Add(new Way() { Node = NodeD, Distance = 3 });
            NodeD.Ways.Add(new Way() { Node = NodeA, Distance = 7 });
            NodeD.Ways.Add(new Way() { Node = NodeB, Distance = 5 });
            NodeD.Ways.Add(new Way() { Node = NodeC, Distance = 3 });

            List<Node> graph = new List<Node>() {
                NodeA, NodeB, NodeC, NodeD
            };

            var algorithm = new Algorithm(graph, 3, NodeA);
            algorithm.Run();
            MessageBox.Show(algorithm.GetAllRoutes);
        }
        private void btnAgregarCiudad_Click(object sender, EventArgs e)
        {

        }
        private void btnTrazarRuta_Click(object sender, EventArgs e)
        {

        }
        private void btnMejorRuta_Click_1(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Algoritmo Grafos Maps - Metaheurística
        public class Algorithm
        {
            private List<Node> _graph { get; set; }
            private int _n { get; set; }
            private Node _origin { get; set; }
            private List<Route> _solutions { get; set; }

            public string GetAllRoutes
            {
                get
                {
                    string result = "";
                    foreach (var route in _solutions)
                    {
                        foreach (var node in route.Nodes)
                        {
                            result += node.City + ", ";
                        }
                        result += " " + route.TotalDistance + "\n";
                    }

                    return result;
                }
            }

            public Algorithm(List<Node> graph, int n, Node origin)
            {
                _graph = graph;
                _n = n;
                _origin = origin;
            }

            public void Run()
            {
                _solutions = new List<Route>();
                for (int i = 0; i < _n; i++)
                {
                    _solutions.Add(Generate());
                }
                _solutions = _solutions.OrderBy(d => d.TotalDistance).ToList();
            }

            public Route Generate()
            {
                var solution = new Route();
                solution.Nodes.Add(_origin);
                Node current = _origin;
                for (int i = 0; i < _graph.Count - 1; i++)
                {
                    Node next = null;
                    do
                    {
                        next = NextNode(current);
                    } while (solution.Nodes.Contains(next));

                    solution.Nodes.Add(next);
                    solution.TotalDistance += current.Ways.Where(d => d.Node.City == next.City).First().Distance;

                    current = next;
                }

                solution.Nodes.Add(_origin);
                solution.TotalDistance += current.Ways.Where(d => d.Node.City == _origin.City).First().Distance;
                return solution;
            }

            private Node NextNode(Node current)
            {
                int nextNode = new Random().Next(0, _graph.Count - 1);
                return current.Ways[nextNode].Node;
            }
        }

        public class Node
        {
            public string City { get; set; }
            public List<Way> Ways { get; set; }

            public Node()
            {
                Ways = new List<Way>();
            }
        }

        public struct Way
        {
            public Node Node { get; set; }
            public int Distance { get; set; }
        }

        public class Route
        {
            public List<Node> Nodes { get; set; }
            public int TotalDistance { get; set; }

            public Route()
            {
                Nodes = new List<Node>();
                TotalDistance = 0;
            }
        }


        #endregion

        #region Algoritmo Grafos Maps - Ejercicios de Clase
        public class Grafo
        {
            public class Vertice
            {
                public Vertice sig;
                public Arista ady;
                public string nombre = "";

            }
            public class Arista
            {
                public Arista sig;
                public Vertice ady;
                public int peso;
            }

            public Vertice h;
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
            public void InsertaVertice(string nombre)
            {
                Vertice nuevo = new Vertice();
                nuevo.nombre = nombre;
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
            public void PrimeroMejor(Vertice origen, Vertice destino)
            {
                //int CostoActual;
                //int band;
                //int band2 = 0;
                //Vertice VerticeActual;
                //Vertice DestinoActual;
                //Arista aux;
                //LinkedList<Tuple<Vertice, int>> ListaCostos = new LinkedList<Tuple<Vertice, int>>();
                //LinkedList<Tuple<Vertice, int>> ListaOrdenada = new LinkedList<Tuple<Vertice, int>>();
                //Stack<Tuple<Vertice, Vertice>> pila = new Stack<Tuple<Vertice, Vertice>>();
                //LinkedList<Tuple<Vertice, int>>.Enumerator i;
                //LinkedList<Tuple<Vertice, int>>.Enumerator j;

                //ListaCostos.AddLast(VerticeCosto(origen, 0));
                //ListaOrdenada.AddLast(VerticeCosto(origen, 0));
                //while (ListaOrdenada.Count > 0)
                //{
                //    VerticeActual = ListaOrdenada.First.Value.first;
                //    CostoActual = ListaOrdenada.First.Value.second;
                //    ListaOrdenada.RemoveFirst();
                //    if (VerticeActual == destino)
                //    {
                //        band2 = 1;
                //        DestinoActual = destino;
                //        while (pila.Count > 0)
                //        {
                //            Console.Write(DestinoActual.nombre);
                //            Console.Write("<-");
                //            while (pila.Count > 0 && pila.Peek().second != DestinoActual)
                //            {
                //                pila.Pop();
                //            }
                //            if (pila.Count > 0)
                //            {
                //                DestinoActual = pila.Peek().first;
                //            }
                //        }
                //        break;
                //    }
                //    aux = VerticeActual.ady;
                //    while (aux != null)
                //    {
                //        band = 0;
                //        CostoActual = CostoActual + aux.peso;
                //        for (i = ListaCostos.GetEnumerator(); i.MoveNext();)
                //        {
                //            if (aux.ady == i.first)
                //            {
                //                band = 1;
                //                if (CostoActual < i.second)
                //                {
                //                    i.Current.second = CostoActual;
                //                    for (j = ListaOrdenada.GetEnumerator(); j.MoveNext();)
                //                    {
                //                        if (j.first == aux.ady)
                //                        {
                //                            j.Current.second = CostoActual;
                //                        }
                //                    }
                //                    pila.Push(VerticeVertice(VerticeActual, aux.ady));
                //                    CostoActual = CostoActual - aux.peso;
                //                }
                //            }
                //        }
                //        if (band == 0)
                //        {
                //            ListaCostos.AddLast(VerticeCosto(aux.ady, CostoActual));
                //            ListaOrdenada.AddLast(VerticeCosto(aux.ady, CostoActual));
                //            pila.Push(VerticeVertice(VerticeActual, aux.ady));
                //            CostoActual = CostoActual - aux.peso;
                //        }
                //        aux = aux.sig;
                //    }
                //}
                //if (band2 == 0)
                //{
                //    Console.Write("No hay una ruta entre esos dos vertices");
                //    Console.Write("\n");
                //}
            }
            public class Pair<T, U>
            {
                public Pair()
                {
                }
                public Pair(T first, U second)
                {
                    this.First = first;
                    this.Second = second;
                }
                public T First { get; set; }
                public U Second { get; set; }
            };
        }
        #endregion
    }
}
