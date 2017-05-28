using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC___Atencion_a_procesos
{
    class Procesador
    {
        private int NoProceso = 0;
        public Proceso inicio { get; set; }
        public int Pen, suma;
        private Proceso final;
        private Proceso actual;
        private static Random ciclos = new Random();

        public void crearProceso()
        {
            Proceso nuevo = new Proceso();
            nuevo.nombre = Convert.ToString("Proceso " + NoProceso);
            nuevo.ciclos = ciclos.Next(4, 15);
            if (inicio == null)
            {
                inicio = nuevo;
                final = nuevo;
            }
            else
            {
                actual = inicio;
                while (actual.siguiente != null)
                {
                    actual = actual.siguiente;
                }
                actual.siguiente = nuevo;
                nuevo.anterior = actual;
                final = nuevo;
            }
            NoProceso++;
        }
        public void eliminarProceso()
        {
            if (inicio == final && inicio.ciclos == 0)
            {
                inicio = null;
                final = null;
            }
            else
            {
                if (inicio.ciclos == 0)
                {
                    inicio.siguiente.anterior = null;
                    inicio = inicio.siguiente;
                }
                else
                {
                    inicio.ciclos--;
                }
            }
        }

        public void pendientesSuma()
        {
            if (inicio == null)
            {
                Pen = 0;
                suma = 0;
            }
            else
            {
                actual = inicio;
                while (actual != null)
                {
                    Pen++;
                    suma = suma + actual.ciclos;
                    actual = actual.siguiente;
                }
            }
        }
    }
}
