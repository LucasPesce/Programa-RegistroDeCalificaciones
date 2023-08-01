using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_2
{
    public partial class Form1 : Form
    {
        const int MAX = 10;                 // Maximo Elementos de la LISTA
        public int [] calificaciones;       // DECLARACION de la LISTA
        public int contador;                // Contador de elementos de la LISTA

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            calificaciones = new int [MAX];             // CREACION de la LISTA
            contador = 0;                               // INICIALIZACION del contador
            txtCalificacion.Text = "";
            txtCantCalificaciones.ReadOnly = true;
            txtMayorCalificacion.ReadOnly = true;
            txtMenorCalificacion.ReadOnly= true;
            txtPromedio.ReadOnly = true;

            for(int i=0; i<calificaciones.Length; i++)
            {
                calificaciones[i] = 0;
            }
        }
        private void txtCalificacion_KeyPress(object sender, KeyPressEventArgs e)       //Evento PRESIONAR TECLA
        {
            if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))       // Si no es digito ni "Back"
            {
                e.Handled = true;                                                   // No permitir el tipeo
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtCalificacion.Text) >= 1 && int.Parse(txtCalificacion.Text) <= 10)
            {
                calificaciones[contador] = int.Parse(txtCalificacion.Text);         // Cumplida la condicion, se guarda la nota en la LISTA
                contador++;                                                         // AUMENTA el contador.
                txtCalificacion.Text = "";
                txtCalificacion.Focus();
            }
            else
            {
                MessageBox.Show("Ingrese un digito entre 1 al 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCalificacion.Text = "";
            }

            if(contador == MAX)
            {
                MessageBox.Show("Se completo la capacidad de la carga de datos", "ATENCION",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnRegistrar.Enabled = false;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            int SUMA = 0;
            int calificacionMayor = calificaciones[0];
            int calificacionMenor = calificaciones[0];


            for (int i= 0; i < contador; i++)
            {
                SUMA += calificaciones[i];

                    //OBTENER LAS NOTA MAYOR Y MENOR
                    if (calificaciones[i] > calificacionMayor)
                    {
                        calificacionMayor = calificaciones[i];
                    }

                    if (calificaciones[i] < calificacionMenor)
                    {
                        calificacionMenor = calificaciones[i];
                    }
            }
            float PROMEDIO = (float)SUMA / contador;

            txtCantCalificaciones.Text = contador.ToString();           // Indica la cantidad de notas registradas            
            txtPromedio.Text = PROMEDIO.ToString("F2");                 // Indica el promedio de las notas
            txtMayorCalificacion.Text = calificacionMayor.ToString();   // Indica la mayor nota
            txtMenorCalificacion.Text = calificacionMenor.ToString();   // Indica la menor nota
        }
    }
}
