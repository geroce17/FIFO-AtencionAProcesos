using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LC___Atencion_a_procesos
{
    public partial class Form1 : Form
    {
        static Random probabilidad = new Random();
        Procesador procesador = new Procesador();
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdLaunch_Click(object sender, EventArgs e)
        {
            int R, cont = 1, empty = 0;

            while (cont <= 200)
            {
                R = probabilidad.Next(1, 5);
                if (procesador.inicio != null)
                    procesador.eliminarProceso();
                if (R == 4)
                    procesador.crearProceso();
                if(procesador.inicio==null)
                    empty++;
                cont++;
            }
            procesador.pendientesSuma();
            txtMostrar.Text = "Ciclos vacios: " + empty + "\r\n" + "Procesos pendientes: " + procesador.Pen + "\r\n" + "Ciclos restantes: " + procesador.suma;
            empty = 0;
            procesador.Pen = 0;
            procesador.suma = 0;
            procesador = new Procesador();
        }
    }
}
