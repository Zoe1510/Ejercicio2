using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_DFDaCSharp
{
    class Program
    {
        /* EJERCICIO2

         CAPTURAR:
         *  EL NOMBRE DEL VENDEDOR, 
         *  el número de identificación y 
         *  el valor mensual de ventas. 

         LIQUIDAR LA COMISIÓN DE VENTA DE ACUERDO A LO SIGUIENTE:
         * Si la venta es menor a 1500000 no hay comisión.
         * Si la venta está entre 1500000 y 3500000 la comisión es del 5%. 
         * Si es mayor 3500000 y 7000000 la comisión es del 10%, 
         * si la venta está entre 7000000 y 15000000 la comisión será del 20% y 
         * si es mayor del 15000000 la comisión será del 30%. 

         SE DEBE IMPRIMIR UN REPORTE FINAL CON: 
         * Nombre del vendedor, 
         * número de identificación, 
         * ventas realizadas, 
         * comisión, 
         * valor descuento de eps, (El descuento eps y pensión se aplica por el salario mínimo legal vigente más la comisión. )
         * pensión, 
         * subsidio de transporte (El subsidio de transporte aplicara su valor si Y solo si el salario mínimo legal vigente MÁS comisión es menor a 2 salarios mínimos legales vigentes.)
         * total a pagar.
         * 
         * 

        */

        static void Main(string[] args)
        {
            /*--------------------variables------------------ */
            int minimo = 781242;
            string nombreVendedor = "";
            string nroID ="";
            int valorventas = 0;
            double comision = 0, eps=0,pension=0, transporte=0, totalpagar=0;

            Console.Title = "CÁLCULO DE COMISIÓN POR VENTAS"; //lo que aparecerá en la barra superior de la ventana
            Console.SetWindowSize(75, 30); //establece columnas y filas

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            /*--------------------INTRODUCIR DATOS Y LEERLOS------------------ */
            Console.WriteLine(" _________________________________________________________________________ ");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|--------------POR FAVOR INTRODUZCA LOS SIGUIENTES DATOS:-----------------|");
            Console.WriteLine("|_________________________________________________________________________|");
            Console.WriteLine("                                                                           ");
            Console.Write(" ---------------Introduzca su nombre: ");
            nombreVendedor = Console.ReadLine();
            Console.Write(" ---------------Introduzca número de identificación: ");
            nroID = Console.ReadLine();
            Console.Write(" ---------------Introduzca el valor MENSUAL de las ventas: ");
            valorventas = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("                                                                           ");
            if (valorventas == 0)
            {
                //aqui no hay comision
                comision = 0;

            }else if(valorventas<0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" _________________________________________________________________________ ");
                Console.WriteLine("|                                                                         |");
                Console.WriteLine("|-ERROR: EL VALOR DE VENTAS NO PUEDE SER NEGATIVO. EL PROGRAMA FINALIZARÁ-|");
                Console.WriteLine("|_________________________________________________________________________|");
                Console.WriteLine("                                                                           ");
            }else if(valorventas< 1500000)
            {
                //aqui no hay comision
                comision = 0;
            }
            else if(valorventas< 3500000)
            {
                //comision del 5%
                comision = valorventas * 0.05;
            }
            else if (valorventas < 7000000)
            {
                //comision del 10%
                comision = valorventas * 0.10;
            }
            else if (valorventas < 15000000)
            {
                //comision del 20%
                comision = valorventas * 0.20;
            }
            else if(valorventas > 15000000)
            {
                //comision del 30%
                comision = valorventas * 0.30;
            }

            pension = (minimo + comision)*0.04;
            eps = pension;

            if (minimo + comision < 2 * minimo)
            {
                //recibe subsidio
                transporte = 88211;
            }else
            {
                //no recibe subsidio transporte
                transporte = 0;
            }

            totalpagar = minimo + comision + transporte - pension - eps;

            /*------imprimir resultados--------*/
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            //Console.Clear();
            Console.WriteLine(" _________________________________________________________________________ ");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|---- DATOS DEL VENDEDOR -------------------------------------------------|");
            Console.WriteLine("|_________________________________________________________________________|");
            Console.WriteLine("|                                   ||                                    |");
            Console.WriteLine("|--------- NOMBRE VENDEDOR -------- ||           " + nombreVendedor + "                           ");
            Console.WriteLine("|--------- N°CED. VENDEDOR -------- ||           " + nroID +          "                           ");
            Console.WriteLine("|___________________________________||____________________________________|");
            //Console.WriteLine("|                                                                         |");
            
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|_________________________________________________________________________|");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|---- FACTURA DEL VENDEDOR -----------------------------------------------|");
            Console.WriteLine("|_________________________________________________________________________|");
            Console.WriteLine("|                                   ||                                    |");
            Console.WriteLine("|               RAZÓN               ||                TOTAL               |");
            Console.WriteLine("|___________________________________||____________________________________|");
            Console.WriteLine("|                                   ||                                        "); 
            Console.WriteLine("|-------- VENTAS MENSUALES -------- ||           " + valorventas.ToString() + "                            ");
            Console.WriteLine("|-------- COMISIÓN ---------------- ||           " + comision.ToString() +    "                               ");
            Console.WriteLine("|-------- DESCUENTO EPS ----------- ||           " + eps.ToString() +         "                               ");
            Console.WriteLine("|-------- DESCUENTO PENSIÓN ------- ||           " + pension.ToString() +     "                               ");
            Console.WriteLine("|-------- SUBSIDIO TRANSP. -------- ||           " + transporte.ToString() +  "                               ");
            Console.WriteLine("|___________________________________||____________________________________|");
            Console.WriteLine("|                                   ||                                    |");
            Console.WriteLine("|--------- TOTAL A PAGAR ---------- ||           " + totalpagar + "                             ");
            Console.WriteLine("|___________________________________||____________________________________|");
            Console.WriteLine("                                                                           ");
            Console.ResetColor();
            Console.ReadKey(true);
        }
    }
}
