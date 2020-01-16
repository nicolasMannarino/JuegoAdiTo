using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JuegoPrueba
{
    public partial class Form1 : Form
    {
        int nivel = 0;
        int intentos = 0;
        int monedas = 0;

        readonly string[] palabrasAAdivinarSinEspacios = {
                                       "ELHOMBREARAÑA",//1
                                       "CAPITANAMERICA",//2
                                       "JUEGODETRONOS",//3
                                       "LOSJUEGOSDELHAMBRE",//4
                                       "ELSEÑORDELOSANILLOS",//5
                                       "RAPIDOYFURIOSO",//6
                                       "ELLOBODEWALLSTREET",//7
                                       "IRONMAN",//8
                                       "HIGHSCHOOLMUSICAL",//9
                                       "TOYSTORY"//10
                                      };
        readonly string[] palabrasAAdivinarConEspacios = 
                                    {
                                       "EL HOMBRE ARAÑA",//1
                                       "CAPITAN AMERICA",//2
                                       "JUEGO DE TRONOS",//3
                                      "LOS JUEGOS DEL HAMBRE",//4
                                       "EL SEÑOR DE LOS ANILLOS",//5
                                       "RAPIDO Y FURIOSO",//6
                                       "EL LOBO DE WALL STREET",//7
                                       "IRON MAN",//8
                                       "HIGH SCHOOL MUSICAL",//9
                                       "TOY STORY"//10
                                      };
        readonly string[] LetrasAUsarPorPeliculaDesordenadas =
                                       {
                                       "ELHOMBREARAÑAJGLLRTU",//1
                                       "CAPITANAMERICAAPHTYUR",//2
                                       "JUEGODETRONOSAVBLRUTR",//3
                                       "LOSJUEGOSDELHAMBREHUTREWSGHF",//4
                                       "ELSEÑORDELOSANILLOSAMREICFGTJ",//5
                                       "RAPIDOYFURIOSOUMLOPQR",//6
                                       "ELLOBODEWALLSTREETAJLMNTHRLMJH",//7
                                       "IRONMANAJLPT",//8
                                       "HIGHSCHOOLMUSICALALPRQOTHY",//9
                                       "TOYSTORYPUAN"//10
                                       };

        int posicionEnPalabraConcatenada = 0;
        readonly int CaracteresPorRenglon = 11;
        char[] palabraConcatenadaDeBotonesDeRespuesta;
        char[] PrimeraPosicionLibrePlantillaDeRespuesta;
        string intentosFallados;
        string monedasActuales;
        string letrasQueQuedanParaUsarOrdenadas;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void PonerImagenRespuestaYLetrasSegunNivel()//FUNCION PRINCIPAL
        {

            letras.Controls.Clear();
            respuesta.Controls.Clear();
            PonerVisibleImagenRespuestaYLetras();
            letras.Enabled = true;
            
            if (nivel >= palabrasAAdivinarSinEspacios.Length)
            {
                nivel = 0;
                monedas = 0;
            }
            //LetrasAUsarSegunNivel = LetrasAUsarPorPeliculaDesordenadas[nivel];
            //letras.Select();

            //Poner label Nivel
            EscribirMonedasNivelActual();

            //Poner label Nivel
            EscribirLabelNivelActual();

            //Poner label IntentosFallidos
            EscribirLabelIntentosFallidos();

            //Poner imagen segun nivel
            CargarImagenSegunNivel();

            //ciclo que carga las letras en un flowlayout --> letras
            letrasQueQuedanParaUsarOrdenadas = new string(LetrasAUsarPorPeliculaDesordenadas[nivel].OrderBy(x => x).ToArray());
            CargarPlantillaDeLetras();

            //ciclo que construye la plantilla de la respuesta en el flowlayout-->respuesta
            PrimeraPosicionLibrePlantillaDeRespuesta = new char[palabrasAAdivinarSinEspacios[nivel].Length];
            palabraConcatenadaDeBotonesDeRespuesta = new char[palabrasAAdivinarSinEspacios[nivel].Length];
            ConstruirPlantillaDeRespuesta();


        }

        private void PonerVisibleImagenRespuestaYLetras()
        {
            Multijugador.Visible = false;
            BotonPlay.Visible = false;
            letras.Visible = true;
            respuesta.Visible = true;
            picImagen.Visible = true;
        }

         private void PonerFocoEnPrimeraPosicion()
         {
             var btn = letras.Controls.Find(letrasQueQuedanParaUsarOrdenadas[0].ToString(), true).FirstOrDefault() as Button;
             btn.Focus();
         }

        private void CargarImagenSegunNivel()
        {
            string nombreDeLaImagen = "imagen" + (nivel + 1) + ".png";
            //string dirpath = Directory.GetCurrentDirectory();
            //string rutaDoc = Path.Combine(Application.StartupPath+nombreDeLaImagen);
            //string filePath = AppDomain.CurrentDomain.BaseDirectory + nombreDeLaImagen;
            var rootDirectory = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\");
            picImagen.Image = Image.FromFile(System.IO.Path.Combine(rootDirectory, nombreDeLaImagen));
        }
        //
        //(@"D:\Escritorio\JuegoPrueba\JuegoPrueba\Resources\" + nombreDeLaImagen + ".png");
        private void EscribirMonedasNivelActual()
        {
            MonedasImagen.Visible = true;
            monedasActuales = "Monedas: " + monedas;
            monedasLabel.Text = monedasActuales;
            monedasLabel.Visible = true;
        }
        private void EscribirLabelNivelActual()
        {
            string nivelActual = "Nivel: " + (nivel + 1);
            nivelLabel.Text = nivelActual;
            nivelLabel.Visible = true;
        }

        private void EscribirLabelIntentosFallidos()
        {
            intentosFallados = "Intentos: " + intentos;
            intentosFallidosLabel.Text = intentosFallados;
            intentosFallidosLabel.Visible = true;
        }

        private void CargarPlantillaDeLetras()
        {
            string letrasParaUsarOrdenadas = new string(LetrasAUsarPorPeliculaDesordenadas[nivel].OrderBy(x => x).ToArray());
            foreach (var caracter in letrasParaUsarOrdenadas)
            {
                Button btnLetra = new Button();
                btnLetra.Tag = "";
                btnLetra.Text = caracter.ToString();
                btnLetra.Width = 50;
                btnLetra.Height = 30;
                btnLetra.Click += PonerLetraEnPlantillaDeRespuestaConMouse;
                btnLetra.KeyPress += PonerLetraEnPlantillaDeRespuestaConTeclado;
                btnLetra.ForeColor = Color.White;
                btnLetra.Font = new Font(btnLetra.Font.Name, 12, FontStyle.Bold);
                btnLetra.BackgroundImageLayout = ImageLayout.Center;
                btnLetra.BackColor = Color.Black;
                btnLetra.Name = caracter.ToString();
                letras.Controls.Add(btnLetra);
                PonerFocoEnPrimeraPosicion();
            }
        }

        private void ConstruirPlantillaDeRespuesta()
        {
            
            int posicionEnElRenglon = 0;
            
            int posicionDeLetraEnPlantillaDeRespuesta = 1;

            string[] palabrasPorSeparado = palabrasAAdivinarConEspacios[nivel].Split(' ');
            foreach (var palabra in palabrasPorSeparado)
            {
                if (palabra.Length <= (CaracteresPorRenglon - posicionEnElRenglon))
                {
                    AgregarBotonParaLetrasYEspacio(ref posicionEnElRenglon, ref posicionDeLetraEnPlantillaDeRespuesta, palabra);
                }
                else
                {
                    posicionEnElRenglon = AgregarEspaciosAlFinalDelRenglon(posicionEnElRenglon);
                    AgregarBotonParaLetrasYEspacio(ref posicionEnElRenglon, ref posicionDeLetraEnPlantillaDeRespuesta, palabra);
                }
            }
        }

        private int AgregarEspaciosAlFinalDelRenglon(int posicionEnElRenglon)
        {
            int i;
            for (i = 0; i < (CaracteresPorRenglon - posicionEnElRenglon); i++)
            {
                var caracterEspacioAlFinal = new Button();
                CrearEspacioEnPlantillaDeRespuesta(caracterEspacioAlFinal);
                AgregarCaracterSiempreQueNoSeaEspacioAlPrincipioDelRenglon(posicionEnElRenglon, ' ', caracterEspacioAlFinal);
            }
            posicionEnElRenglon = 0;
            return posicionEnElRenglon;
        }

        private void AgregarBotonParaLetrasYEspacio(ref int posicionEnElRenglon, ref int posicionDeLetraEnPlantillaDeRespuesta, string palabra)
        {
            AgregarBotonParaLetras(ref posicionEnElRenglon, ref posicionDeLetraEnPlantillaDeRespuesta, palabra);
            posicionEnElRenglon = AgregarBotonParaEspacio(posicionEnElRenglon);
        }

        private int AgregarBotonParaEspacio(int posicionEnElRenglon)
        {
            var caracterEspacioUI = new Button();
            CrearEspacioEnPlantillaDeRespuesta(caracterEspacioUI);
            posicionEnElRenglon++;
            AgregarCaracterSiempreQueNoSeaEspacioAlPrincipioDelRenglon(posicionEnElRenglon, ' ', caracterEspacioUI);
            return posicionEnElRenglon;
        }

        private void AgregarBotonParaLetras(ref int posicionEnElRenglon, ref int posicionDeLetraEnPlantillaDeRespuesta, string palabra)
        {
            foreach (var caracter in palabra)
            {
                var caracterUI = new Button();
                CrearLetraEnPlantillaDeRespuesta(caracterUI, posicionDeLetraEnPlantillaDeRespuesta,DevolverLetraAPlantillaDeLetras);
                posicionDeLetraEnPlantillaDeRespuesta++;
                respuesta.Controls.Add(caracterUI);
                posicionEnElRenglon++;
            }
        }
        private void AgregarCaracterSiempreQueNoSeaEspacioAlPrincipioDelRenglon(int posicionEnElRenglon, char caracter, Button caracterUI)
        {
            if (caracter != ' ' || !EsPrincipioDeRenglon(posicionEnElRenglon))
                respuesta.Controls.Add(caracterUI);
        }

        private bool EsPrincipioDeRenglon(int posicionEnElRenglon)
        {
            return posicionEnElRenglon == 12;
        }

        private static void CrearLetraEnPlantillaDeRespuesta(Button caracterUI, int posicionEnPlantillaDeRespuesta, EventHandler DevolverLetraAPlantillaDeLetras)
        {
            caracterUI.ForeColor = Color.Black;
            caracterUI.Text = "-";
            caracterUI.Font = new Font(caracterUI.Font.Name, 10, FontStyle.Bold);
            caracterUI.BackColor = Color.White;
            caracterUI.FlatStyle = FlatStyle.Flat;
            caracterUI.Click += DevolverLetraAPlantillaDeLetras;
            caracterUI.Width = 30;
            caracterUI.Height = 30;
            caracterUI.Name = $"posicion{posicionEnPlantillaDeRespuesta}";
           
        }

        private static void CrearEspacioEnPlantillaDeRespuesta(Button caracterUI)
        {
            caracterUI.ForeColor = Color.Black;
            caracterUI.BackColor = Color.Black;
            caracterUI.FlatStyle = FlatStyle.Flat;
            caracterUI.Width = 30;
            caracterUI.Height = 30;
            caracterUI.Enabled = false;
        }

         void DevolverLetraAPlantillaDeLetras(object sender, EventArgs e)
        {
            var btn = letras.Controls.Find(((Button)sender).Name, true).First() as Button;
            btn.Text = ((Button)sender).Text;

            letrasQueQuedanParaUsarOrdenadas = letrasQueQuedanParaUsarOrdenadas.Insert(1, ((Button)sender).Text);
            letrasQueQuedanParaUsarOrdenadas = new string(letrasQueQuedanParaUsarOrdenadas.ToString().OrderBy(x => x).ToArray());

            btn.Name = ((Button)sender).Text;
            btn.Enabled = true;
            ((Button)sender).Text = "-";

            string posicion = ((Button)sender).Name.Replace("posicion", "");
            PrimeraPosicionLibrePlantillaDeRespuesta[Convert.ToInt32(posicion)-1]='\0';
            posicionEnPalabraConcatenada--;
            PonerFocoEnPrimeraPosicion();
        }
        void PonerLetraEnPlantillaDeRespuestaConMouse(object sender, EventArgs e)
        {
            
            var btn = (Button)sender;
            btn.Enabled = false;

            int cant = VerPrimeraPosiciónLibrePlantillaRespuesta();

            var primeraLetraDisponibleEnRespuesta = respuesta.Controls.Find("posicion" + (cant+1), true).FirstOrDefault() as Button;
            PrimeraPosicionLibrePlantillaDeRespuesta[cant] = Convert.ToChar(((Button)sender).Text); 
            primeraLetraDisponibleEnRespuesta.Text = ((Button)sender).Text;

            btn.Name = "posicion" + (cant + 1);

            char letraUsada = primeraLetraDisponibleEnRespuesta.Text[0];
            palabraConcatenadaDeBotonesDeRespuesta[cant] = letraUsada;

            Regex regex = new Regex(letraUsada.ToString());
            letrasQueQuedanParaUsarOrdenadas = regex.Replace(letrasQueQuedanParaUsarOrdenadas, "", 1);

            posicionEnPalabraConcatenada++;


            if (posicionEnPalabraConcatenada >= palabrasAAdivinarSinEspacios[nivel].Length)
            {
                posicionEnPalabraConcatenada = 0;
                ComparacionEntrePalabraAAdivinarYLetrasUsadasParaRespuesta();
            }
        }
        void PonerLetraEnPlantillaDeRespuestaConTeclado(object sender, EventArgs e)
        {
            char LetraSeleccionada = ((KeyPressEventArgs)e).KeyChar;
            int cant = VerPrimeraPosiciónLibrePlantillaRespuesta();

            if(LetraSeleccionada == (char)08 && posicionEnPalabraConcatenada != 0)
            {
                DevolverLetraAPlantillaDeLetras(respuesta.Controls.Find("posicion" + (cant), true).FirstOrDefault(), e);
            }
            if (letrasQueQuedanParaUsarOrdenadas.Contains(LetraSeleccionada.ToString().ToUpper()))
            {
                var primeraLetraDisponibleEnRespuesta = respuesta.Controls.Find("posicion" + (cant + 1), true).FirstOrDefault() as Button;
                PrimeraPosicionLibrePlantillaDeRespuesta[cant] = Convert.ToChar(((Button)sender).Text);
                primeraLetraDisponibleEnRespuesta.Text = LetraSeleccionada.ToString().ToUpper();

                char letraUsada = primeraLetraDisponibleEnRespuesta.Text[0];
                palabraConcatenadaDeBotonesDeRespuesta[cant] = letraUsada;

                posicionEnPalabraConcatenada++;
                var btn = letras.Controls.Find(LetraSeleccionada.ToString().ToUpper(), true).FirstOrDefault() as Button;
                btn.Name = "posicion" + (cant + 1);
                btn.Enabled = false;


                Regex regex = new Regex(letraUsada.ToString());
                letrasQueQuedanParaUsarOrdenadas = regex.Replace(letrasQueQuedanParaUsarOrdenadas, "", 1);
            }

            if (posicionEnPalabraConcatenada >= palabrasAAdivinarSinEspacios[nivel].Length)
            {
                posicionEnPalabraConcatenada = 0;
                ComparacionEntrePalabraAAdivinarYLetrasUsadasParaRespuesta();
            }
        }

        private int VerPrimeraPosiciónLibrePlantillaRespuesta()
        {
            int cant = 0;
            while (PrimeraPosicionLibrePlantillaDeRespuesta[cant].CompareTo('\0') != 0)
                cant++;
            return cant;
        }

        private void ComparacionEntrePalabraAAdivinarYLetrasUsadasParaRespuesta()
        {
            if (palabraConcatenadaDeBotonesDeRespuesta.SequenceEqual(palabrasAAdivinarSinEspacios[nivel]))
            {
                nivel++;
                intentos = 0;
                monedas+=4;
            }
            else
            {
                intentos++;
                intentosFallados = "Intentos: " + intentos;
                intentosFallidosLabel.Text = intentosFallados;
            }
            
            PonerImagenRespuestaYLetrasSegunNivel();
        }

        private void BotonPlay_Click(object sender, EventArgs e)
        {
            PonerImagenRespuestaYLetrasSegunNivel();
        }
    }
}