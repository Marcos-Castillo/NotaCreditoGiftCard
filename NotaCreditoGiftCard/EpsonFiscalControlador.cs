using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace NotaCreditoGiftCard
{
    internal class EpsonFiscalControlador
    {

        /* -----------------------------------------------------------------------------
        Typedef from exported Prototypes of "EpsonFiscalInterface.h"
        ----------------------------------------------------------------------------- */

        /// <param name="velocidad"></param>
        /// <returns></returns>
        // ConfigurarVelocidad()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ConfigurarVelocidad(int velocidad);

        // ConfigurarPuerto()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ConfigurarPuerto(string puerto);

        // Conectar()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int Conectar();

        // Desconectar()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int Desconectar();

        // Conectar()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ReConectar();

        // Consultar()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ConsultarVersionDll(StringBuilder descripcion, int descripcion_largo_maximo, ref int mayor, ref int menor);

        // ConsultarNumeroComprobanteActual()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ConsultarNumeroComprobanteActual(StringBuilder respuesta, int respuesta_largo_maximo);

        // ConsultarTipoComprobanteActual()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ConsultarTipoComprobanteActual(StringBuilder respuesta, int respuesta_largo_maximo);


        // ImprimirCierreX() 
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ImprimirCierreX();

        // ImprimirCierreZ() 
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                               CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ImprimirCierreZ();

        // DescargarPeriodoPendiente
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                           CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int DescargarPeriodoPendiente(string directorio_de_descarga);


        // EnviarComando
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                       CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int EnviarComando(string comando);


        // ComenzarLog
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                       CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ComenzarLog(bool incluir_tramas);


        // DetenerLog
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                       CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int DetenerLog();


        // PausarLog
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                       CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int PausarLog();


        // ReanudarLog
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                       CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ReanudarLog();


        // AbrirComprobante
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                       CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int AbrirComprobante(int id_tipo_documento);


        // CerrarComprobante
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                       CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int CerrarComprobante();


        // Cancelar
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                       CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int Cancelar();


        // Descargar
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                       CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int Descargar(string desde, string hasta, string directorio_de_descarga);


        // CargarDatosCliente
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                      CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int CargarDatosCliente(string nombre_o_razon_social1, string nombre_o_razon_social2,
                                                           string domicilio1, string domicilio2, string domicilio3,
                                                           int id_tipo_documento, string numero_documento, int id_responsabilidad_iva);

        // CargarComprobanteAsociado
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                      CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int CargarComprobanteAsociado(string descripcion);


        // CargarTextoExtra
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                      CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int CargarTextoExtra(string descripcion);


        // ConConsultarDescripcionDeErrorsultar()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ConsultarDescripcionDeError(int numero_de_error, StringBuilder respuesta_descripcion, ref int respuesta_descripcion_largo_maximo);


        // ImprimirAuditoria()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ImprimirAuditoria(int id_modificador, string desde, string hasta);


        // ImprimirAuditoria()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int EstablecerCola(int numero_cola, string descripcion);

        // ImprimirItem()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ImprimirItem(int id_modificador, String descripcion, 
        String cantidad, String precio, int id_tasa_iva,int ii_id, String ii_valor, 
        int id_codigo, String codigo, String codigo_unidad_matrix,int código_unidad_medida);

        /// <summary>
        /// //////////////////////////////////////////////////////////////////
        /// </summary>


        // ConfigurarVelocidad()
       


        ///////////////////////////////////

        /* Globa variable */
        private bool _WorkThreadRunning = false;



        public void Funciona() {
            Console.WriteLine("funciona ok");
        }
        /* -----------------------------------------------------------------------------
Function: dll_version()
----------------------------------------------------------------------------- */
        public void dll_version()
        {
            const int str_len = 500;
            StringBuilder str = new StringBuilder(str_len);
            int mayor = 0;
            int menor = 0;

            /* call exported function from "EpsonFiscalInterface.h" */
            try { 
                ConsultarVersionDll(str, str_len, ref mayor, ref menor); 
            }
            catch(Exception e) {
                Console.WriteLine(e.StackTrace);
            }

            /* show */
            string msg = "-Descripción: " + str.ToString() + "  -Mayor: " + mayor.ToString() + "  -Menor: " + menor.ToString();
            Console.WriteLine(msg);
        }

        /* -----------------------------------------------------------------------------
 Function: print_X_and_Z()
 ----------------------------------------------------------------------------- */
        public void print_X_and_Z()
        {
            int error;

            /* active log */
            error = ComenzarLog(true);

            /* config */
            _config_port();

            /* real conection */
            error = Conectar();
            Console.WriteLine("Connect: " + error.ToString());

            /* print x */
            error = ImprimirCierreX();
            Console.WriteLine("Closure Cashier #1: " + error.ToString());


            /* test DLL into threads  (Remember: this DLL HL is MONO-THREAD)
               the programer must
               implemente the MUTEX  (Attention!!!) */
            _WorkThreadRunning = true;
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(WorkThreadFunction));
            thread.Start();

            /* wait */
            do
            {
                /* nothing to do */
                System.Threading.Thread.Sleep(0);

            } while (_WorkThreadRunning);


            /* download */
            //error = DescargarPeriodoPendiente(@"C:\");
            //MessageBox.Show("Download: " + error.ToString());


            /* print z */
            error = ImprimirCierreZ();
            Console.WriteLine("Closure Day: " + error.ToString());

            /* close port */
            error = Desconectar();
            Console.WriteLine("Disconect: " + error.ToString());

            /* deactive log */
            DetenerLog();
        }

        /* -----------------------------------------------------------------------------
    Function: WorkThreadFunction()
    ----------------------------------------------------------------------------- */
        public void WorkThreadFunction()
        {
            try
            {
                int error;

                /* print x */
                error = ImprimirCierreX();
                Console.WriteLine("Closure Cashier (thread number 1): " + error.ToString());
            }
            catch (Exception ex)
            {
                // log errors
            }

            /* nothing to do */
            System.Threading.Thread.Sleep(1000);

            /* flag */
            _WorkThreadRunning = false;
        }
        /* -----------------------------------------------------------------------------
Function: _config_port()
----------------------------------------------------------------------------- */
        public void _config_port()
        {
            int error;

            int tmp_baud = 9600;
 


            /* config baudrate */
            error = ConfigurarVelocidad(tmp_baud);



            /* config port */
            //ConfigurarPuerto("0");
            ConfigurarPuerto("usb:USB");
            
            //ConfigurarPuerto("lan:172.22.107.226");
        }
        /* -----------------------------------------------------------------------------
Function: get_description_error()
----------------------------------------------------------------------------- */
        public string get_description_error(int error_number)
        {
            int error = 0;
            int str_len = 1024;
            StringBuilder str = new StringBuilder(str_len);

            /* call exported function from "EpsonFiscalInterface.h" */
            error = ConsultarDescripcionDeError(error_number, str, ref str_len);

            /* show */
            string msg = "" + str.ToString();

            /* exit */
            return msg;
        }
        /* -----------------------------------------------------------------------------
         Function: test_ticket_cancel()
         ----------------------------------------------------------------------------- */
        public void test_ticket_inv_cancel()
        {
            const int DOC_TYPE_TICKET_INV = 3;
            //2 .- FACTURA B 
            //2 .- NOTA CREDITO B 
            //    error = CargarDatosCliente(,,,,,,, );
            string nombre_o_razon_social1 ="CONSUMIDOR";
            string nombre_o_razon_social2 = "FINAL";
            string domicilio1 = "R20";
            string domicilio2 = "VESTA R20";
            string domicilio3 = "";
            int id_tipo_documento = 1;
            string numero_documento =  "11111111";
            int id_responsabilidad_iva =5;

            int error = 0;
            string description = "";

            /* active log */
            error = ComenzarLog(true);

            /* config */
            _config_port();

            /* real conection */
            error = Conectar();
            Console.WriteLine("Connect: " + error.ToString());

            /* get description error */
            if (error != 0)
            {
                /* message */
                description = get_description_error(error);
                Console.WriteLine("Descripción de error: " + description);

                /* exit */
                return;
            }

            /* previous settings for ticket invoice */
            //error = CargarDatosCliente("Nombre Comprador #1", "", "Domicilio Comparador #1", "", "", 1, "3478905", 5);
            error = CargarDatosCliente(nombre_o_razon_social1, nombre_o_razon_social2, domicilio1, domicilio2, domicilio3, id_tipo_documento, numero_documento, id_responsabilidad_iva);
            error = CargarComprobanteAsociado("083-00001-00000027");

            /* open document */
            error = AbrirComprobante(DOC_TYPE_TICKET_INV);
            Console.WriteLine("AbrirComprobante: " + error.ToString());

            error = CargarTextoExtra("  ");
            Console.WriteLine("CargarTextoExtra: " + error.ToString());
            /*
            public static extern int ImprimirItem(int id_modificador, String descripcion,
String cantidad, String precio, int id_tasa_iva, int ii_id, String ii_valor,
int id_codigo, String codigo, String codigo_unidad_matrix, int código_unidad_medida);
            */
            
            const int ID_MODIFICADOR_AGREGAR = 200;//Identificador del modificador sobre el ítem:
            /*
                 200 – Agregar ítem de venta.
                 201 – Anulación del ítem de venta.
                 202 – Agregar ítem de retorno envases. (*)
                 203 – Ajuste ítem de retorno envases. (*)
                 204 - Agregar ítem de bonificación.
                 205 - Ajuste ítem de bonificación.
                 206 - Agregar ítem de descuento. (*)
                 207 - Ajuste ítem de descuento. (*)
                 208 - Agregar ítem de seña - anticipo. (*)(**)
                 209 - Ajuste ítem de seña - anticipo. (*)(**)
                 210 - Agregar ítem de descuento de seña - anticipo. (*)(**)
                 211 - Ajuste ítem de descuento de seña - anticipo. (*)(**)
            */
            string descripcion = "GIFT";//Descripción del ítem.
            string cantidad = "1.000";// Multiplicidad del ítem.Expresado bajo la siguiente precisión: “nnnnn.nnnn”. (5, 4)
            string precio = "100.0000"; // Precio unitario del ítem. Expresado bajo la siguiente precisión: “nnnnnnn.nnnn”. (7, 4)
            const int ID_TASA_IVA_21_00 = 5; //Identificador de tasa de I.V.A.: 0 - Ninguno.  1 - I.V.A.exento.  4 - I.V.A. 10.50 %.  5 - I.V.A. 21.00 %.
            const int ID_IMPUESTO_INTERNO_FIJO = 0; //0 – Ninguno.   1 - Impuesto interno fijo.  2 - Impuesto interno porcentual.
            string ii_valor = "5.0000"; // Valor del impuesto interno. Expresado bajo la siguiente precisión:  Impuesto interno fijo: “nnnnnnn.nnnn”. (7, 4)  Impuesto interno porcentual: “0.nnnnnnnn”. (0, 8)
            const int ID_CODIGO_INTERNO = 1; // Identificador del tipo de código de producto asociado al ítem:  1 - Código interno.  2 - Código matrix.
            string codigo = "."; //Valor del código (interno o matrix según campo previo).
            string codigo_unidad_matrix = ""; // Valor del código unidad matrix, según será requerido.
            const int AFIP_CODIGO_UNIDAD_MEDIDA_KILOGRAMO = 7;//Código de unidad de medida:  5 - Litros  7 - Unidad  14 - Gramo  20 - Centímetro  62 - Pack  63 - Horma 


            error = ImprimirItem(ID_MODIFICADOR_AGREGAR, descripcion, cantidad, precio, ID_TASA_IVA_21_00, ID_IMPUESTO_INTERNO_FIJO, ii_valor, ID_CODIGO_INTERNO, codigo,
                codigo_unidad_matrix, AFIP_CODIGO_UNIDAD_MEDIDA_KILOGRAMO);

            error = CargarTextoExtra("  ");
            error = CargarTextoExtra("  ");
            error = CargarTextoExtra("  ");
            error = CargarTextoExtra("  ");
            error = CargarTextoExtra("  ");
            error = CargarTextoExtra("  ");
            Console.WriteLine("CargarTextoExtra: " + error.ToString());

            /* get description error */
            description = get_description_error(error);
            Console.WriteLine("Descripción de error: " + description);

            /* cancel */
            error = Cancelar();

            /* close document | just in case */
            error = CerrarComprobante();

            /* close port */
            error = Desconectar();
            Console.WriteLine("Disconect: " + error.ToString());

            /* deactive log */
            DetenerLog();


        }
    }
}
