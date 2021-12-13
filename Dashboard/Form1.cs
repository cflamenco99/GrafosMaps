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
            
        }
        private void btnAgregarCiudad_Click(object sender, EventArgs e)
        {

        }
        private void btnTrazarRuta_Click(object sender, EventArgs e)
        {

        }
        private void btnMejorRuta_Click_1(object sender, EventArgs e)
        {
            //Ejemplo de uso de algoritmo
            Nodo NodoA = new Nodo() { Ciudad = "A" };
            Nodo NodoB = new Nodo() { Ciudad = "B" };
            Nodo NodoC = new Nodo() { Ciudad = "C" };
            Nodo NodoD = new Nodo() { Ciudad = "D" };

            NodoA.Caminos.Add(new Camino() { Nodo = NodoB, Distancia = 5 });
            NodoA.Caminos.Add(new Camino() { Nodo = NodoC, Distancia = 15 });
            NodoA.Caminos.Add(new Camino() { Nodo = NodoD, Distancia = 7 });
            NodoB.Caminos.Add(new Camino() { Nodo = NodoA, Distancia = 5 });
            NodoB.Caminos.Add(new Camino() { Nodo = NodoC, Distancia = 10 });
            NodoB.Caminos.Add(new Camino() { Nodo = NodoD, Distancia = 5 });
            NodoC.Caminos.Add(new Camino() { Nodo = NodoA, Distancia = 15 });
            NodoC.Caminos.Add(new Camino() { Nodo = NodoB, Distancia = 10 });
            NodoC.Caminos.Add(new Camino() { Nodo = NodoD, Distancia = 3 });
            NodoD.Caminos.Add(new Camino() { Nodo = NodoA, Distancia = 7 });
            NodoD.Caminos.Add(new Camino() { Nodo = NodoB, Distancia = 5 });
            NodoD.Caminos.Add(new Camino() { Nodo = NodoC, Distancia = 3 });

            List<Nodo> grafo = new List<Nodo>() {
                NodoA, NodoB, NodoC, NodoD
            };

            var Algoritmo = new Algoritmo(grafo, 3, NodoA);
            Algoritmo.Ejecutar();
            MessageBox.Show(Algoritmo.GetAllRutas);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Algoritmo Grafos Maps - Metaheurística
        public class Algoritmo
        {
            private List<Nodo> _grafo { get; set; }
            private int _n { get; set; }
            private Nodo _origen { get; set; }
            private List<Ruta> _soluciones { get; set; }

            public string GetAllRutas
            {
                get
                {
                    string result = "";
                    foreach (var Ruta in _soluciones)
                    {
                        foreach (var Nodo in Ruta.Nodos)
                        {
                            result += Nodo.Ciudad + ", ";
                        }
                        result += " " + Ruta.TotalDistancia + "\n";
                    }

                    return result;
                }
            }

            public Algoritmo(List<Nodo> grafo, int n, Nodo origin)
            {
                _grafo = grafo;
                _n = n;
                _origen = origin;
            }

            public void Ejecutar()
            {
                _soluciones = new List<Ruta>();
                for (int i = 0; i < _n; i++)
                {
                    _soluciones.Add(GenerarRuta());
                }
                _soluciones = _soluciones.OrderBy(d => d.TotalDistancia).ToList();
            }

            public Ruta GenerarRuta()
            {
                var solution = new Ruta();
                solution.Nodos.Add(_origen);
                Nodo current = _origen;
                for (int i = 0; i < _grafo.Count - 1; i++)
                {
                    Nodo next = null;
                    do
                    {
                        next = NextNodo(current);
                    } while (solution.Nodos.Contains(next));

                    solution.Nodos.Add(next);
                    solution.TotalDistancia += current.Caminos.Where(d => d.Nodo.Ciudad == next.Ciudad).First().Distancia;

                    current = next;
                }

                solution.Nodos.Add(_origen);
                solution.TotalDistancia += current.Caminos.Where(d => d.Nodo.Ciudad == _origen.Ciudad).First().Distancia;
                return solution;
            }

            private Nodo NextNodo(Nodo current)
            {
                int nextNodo = new Random().Next(0, _grafo.Count - 1);
                return current.Caminos[nextNodo].Nodo;
            }
        }

        public class Nodo
        {
            public string Ciudad { get; set; }
            public List<Camino> Caminos { get; set; }

            public Nodo()
            {
                Caminos = new List<Camino>();
            }
        }

        public struct Camino
        {
            public Nodo Nodo { get; set; }
            public int Distancia { get; set; }
        }

        public class Ruta
        {
            public List<Nodo> Nodos { get; set; }
            public int TotalDistancia { get; set; }

            public Ruta()
            {
                Nodos = new List<Nodo>();
                TotalDistancia = 0;
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
