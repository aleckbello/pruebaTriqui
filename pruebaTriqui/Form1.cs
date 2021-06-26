using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaTriqui
{
    public partial class Form1 : Form
    {

        string jugadorX = "";
        string jugadorO = "";
        bool cambio = true;
        int empate = 0;
        int ganadasX = 0;
        int ganadasO = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OnOffBtn(false);//cuando inicie el programa los btn se desactiven
        }

        private void OnOffBtn(bool onoff)
        {
            a1.Enabled = onoff;
            a2.Enabled = onoff;
            a3.Enabled = onoff;
            b1.Enabled = onoff;
            b2.Enabled = onoff;
            b3.Enabled = onoff;
            c1.Enabled = onoff;
            c2.Enabled = onoff;
            c3.Enabled = onoff;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Ingresar();// cuando se de inicio sale el metodo iniciar que va a comprobar los datos introducidos
        }

        private void Ingresar()
        {


            if (rbtnUser1X.Checked)//para que los 2 no puedan seleccionar x  sino 1 x y otro o
            {

                jugadorX = lblUser1.Text;
                jugadorO = lblUser2.Text;
                rbtnUser2O.Checked = true;
                rbtnUser1O.Enabled = false;// porque ya se selecciono la X y la O se desactiva
                rbtnUser2X.Enabled = false;
                PlayGame();
            }

            if (rbtnUser1O.Checked)
            {
                jugadorX = lblUser2.Text;
                jugadorO = lblUser1.Text;
                rbtnUser2X.Checked = true;
                rbtnUser1X.Enabled = false;
                rbtnUser2O.Enabled = false;
                PlayGame();
            }

            if (rbtnUser1X.Checked == false && rbtnUser1O.Checked == false) //ningun jugaodr selecciono ninguna letra
            {

                MessageBox.Show("El jugador debe seleccionar una letra", "Vuelve a escoger la letra", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private void PlayGame()
        {


            lblUserPunto1.Visible = true;
            lblUserPuntos2.Visible = true;

            groupBox1.Text = "Marcador";

            btnLimpiar.Visible = true;// cuando comience el juego se muestre ya que esta en false
            btnReiniciar.Visible = true;
            btn_Salir.Visible = true;

            btnIniciar.Visible = false;//los text box  y el btniniciar desaparescan cuando inicie el juego


            MessageBox.Show("Empieza " + jugadorX, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            OnOffBtn(true);// cuando comience el juego todos los botones se activen
        }

        private void ButtonsClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;//crear un objeto b representa a todos los botones
            if (cambio) //cada vez que se tecle una letra sera x o o
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            cambio = !cambio;
            b.Enabled = false;//si se select x o o se desactivan el otro
            Partida();

        }



        private void Partida()
        {
            if ((a1.Text == a2.Text) & (a2.Text == a3.Text) && (!a1.Enabled))
            {
                Validacion(a1);
            }
            else if ((b1.Text == b2.Text) & (b2.Text == b3.Text) && (!b1.Enabled))
            {
                Validacion(b1);
            }
            else if ((c1.Text == c2.Text) & (c2.Text == c3.Text) && (!c1.Enabled))
            {
                Validacion(c1);
            }

            if ((a1.Text == b1.Text) & (b1.Text == c1.Text) && (!a1.Enabled))
            {
                Validacion(a1);
            }
            else if ((a2.Text == b2.Text) & (b2.Text == c2.Text) && (!a2.Enabled))
            {
                Validacion(a2);
            }
            else if ((a3.Text == b3.Text) & (b3.Text == c3.Text) && (!a3.Enabled))
            {
                Validacion(a3);
            }

            if ((a1.Text == b2.Text) & (b2.Text == c3.Text) && (!a1.Enabled))
            {
                Validacion(a1);
            }
            else if ((a3.Text == b2.Text) & (b2.Text == c1.Text) && (!a3.Enabled))
            {
                Validacion(a3);
            }

            empate++;
            if (empate == 9)
            {
                MessageBox.Show("Es un empate", "Empate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                OnOffBtn(true);// cuando haya un empate llos botones se activen nuevamente
                empate = 0;
            }
        }
        public void Validacion(Button b)
        {
            empate = -1;

            if (b.Text == "X")
            {
                MessageBox.Show("Gana " + jugadorX, "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ganadasX++;
            }
            else if (b.Text == "O")
            {
                MessageBox.Show("Gana " + jugadorO, "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ganadasO++;
            }

            if (rbtnUser1X.Checked && rbtnUser2O.Checked)
            {
                lblUserPunto1.Text = ganadasX.ToString();
                lblUserPuntos2.Text = ganadasO.ToString();
            }
            if (rbtnUser1O.Checked && rbtnUser2X.Checked)
            {
                lblUserPuntos2.Text = ganadasX.ToString();
                lblUserPunto1.Text = ganadasO.ToString();
            }

            Limpiar();
            OnOffBtn(true);
        }

        private void Limpiar()
        {
            a1.Text = "";
            a2.Text = "";
            a3.Text = "";
            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            c1.Text = "";
            c2.Text = "";
            c3.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();//se añade el metodo limpiar
            OnOffBtn(true);//hacer que los btn se activen
            empate = 0;//empate valga 0

        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {

            Limpiar();
            OnOffBtn(false);
            btnLimpiar.Visible = false;
            btnReiniciar.Visible = false;
            btn_Salir.Visible = false;
            btnIniciar.Visible = true;




            jugadorX = "";
            jugadorO = "";
            ganadasX = 0;
            ganadasO = 0;
            cambio = true;

            lblUserPunto1.Text = 0.ToString();
            lblUserPuntos2.Text = 0.ToString();



            rbtnUser1O.Enabled = true;
            rbtnUser2X.Enabled = true;
            rbtnUser1X.Enabled = true;
            rbtnUser2O.Enabled = true;

            rbtnUser1X.Checked = false;
            rbtnUser1O.Checked = false;
            rbtnUser2X.Checked = false;
            rbtnUser2O.Checked = false;

            lblUserPunto1.Visible = false;
            lblUserPuntos2.Visible = false;


        }

        

    }
}
