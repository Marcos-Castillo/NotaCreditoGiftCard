using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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


        // EstablecerCola()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int EstablecerCola(int numero_cola, string descripcion);

        // ImprimirItem()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ImprimirItem(int id_modificador, String descripcion,
        String cantidad, String precio, int id_tasa_iva, int ii_id, String ii_valor,
        int id_codigo, String codigo, String codigo_unidad_matrix, int código_unidad_medida);

        // ConsultarNumeroComprobanteUltimo()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ConsultarNumeroComprobanteUltimo(string tipo_de_comprobante, StringBuilder respuesta, int respuesta_largo_maximo);


        // [out] String respuesta, int respuesta_largo_maximo


        // ConsultarNumeroPuntoDeVenta()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ConsultarNumeroPuntoDeVenta([Out] StringBuilder respuesta, int respuesta_largo_maximo);



        // ConsultarFechaHora()
        [DllImport("EpsonFiscalInterface.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int ConsultarFechaHora([Out] StringBuilder respuesta, int respuesta_largo_maximo);

        // EstablecerFechaHora()
        [DllImport("EpsonFiscalInterface.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int EstablecerFechaHora(String fecha_hora);



     



        /// <summary>
        /// ///////////
        /// </summary>

        /* Globa variable */
        private bool _WorkThreadRunning = false;

        Dictionary<string, string[]> datosSuc = new Dictionary<string, string[]>
{
    { "1", new string[] { "1", "RB", "Super AV" } },
    { "3", new string[] { "3", "RB", "Vesta AV" } },
    { "13", new string[] { "13", "RB", "Karmia AV" } },
    { "50", new string[] { "50", "R20", "Ruta 20" } },
    { "54", new string[] { "54", "R20", "Vesta R20" } },
    { "110", new string[] { "110", "ML", "Leticia" } },
    { "200", new string[] { "200", "CVL", "Circunvalación" } },
    { "250", new string[] { "250", "SAL", "Salsipuedes" } },
    { "350", new string[] { "350", "60C", "60 Cuadras" } },
    { "370", new string[] { "370", "AG", "Alta Gracia" } },
    { "400", new string[] { "400", "COC", "Colonia Caroya" } },
    { "380", new string[] { "380", "TLH", "Tadicor Las Heras" } },
    { "390", new string[] { "390", "TSM", "Tadicor San Martin" } }
};

        /* -----------------------------------------------------------------------------
        Function: EstablecerFechaHora()
        ----------------------------------------------------------------------------- */
        public int setFechaHora(string tipo_de_comprobante)
        {
            _config_port();
            Conectar();
            int result = EstablecerFechaHora("");
            Desconectar();
            return result;
        }

        /* -----------------------------------------------------------------------------
        Function: ConsultarFechaHora()
        ----------------------------------------------------------------------------- */
        public DateTime Consultar_FechaHora()
        {
            // Declarar una cadena para recibir la respuesta
            StringBuilder respuesta = new StringBuilder(256); // Ajusta el tamaño máximo según tus necesidades
            _config_port();
            // Conectar
            Conectar();

            try
            {
                // Llamar a la función ConsultarFechaHora
                ConsultarFechaHora(respuesta, respuesta.Capacity);


                // Valor obtenido de la impresora fiscal
                string valorImpresora = respuesta.ToString();
                // Extraer partes
                int día = int.Parse(valorImpresora.Substring(0, 2));
                int mes = int.Parse(valorImpresora.Substring(2, 2));
                int año = int.Parse(valorImpresora.Substring(4, 2));
                int hora = int.Parse(valorImpresora.Substring(7, 2));
                int minuto = int.Parse(valorImpresora.Substring(9, 2));
                int segundo = int.Parse(valorImpresora.Substring(11, 2));

                // Construir objeto DateTime
                DateTime fechaNCImpresora = new DateTime(2000 + año, mes, día, hora, minuto, segundo);

                return fechaNCImpresora;
            }
            catch (Exception)
            {
            }

            Desconectar();

            return new DateTime(2000,1,1);
        }

        /* -----------------------------------------------------------------------------
        Function: ConsultarNumeroComprobanteUltimo()
        ----------------------------------------------------------------------------- */
        public int NumeroComprobanteUltimo(string tipo_de_comprobante)
        {
            const int DOC_TYPE_TICKET = 3;
            const int DOC_TYPE_DNF = 21;

            int error;
            int nro = 0;

            /* active log */
            error = ComenzarLog(true);

            /* config */
            _config_port();

            /* real conection */
            error = Conectar();
            //Console.WriteLine("Connect: " + error.ToString());

            /* open document dnf */
            AbrirComprobante(DOC_TYPE_TICKET);

            /* !!! TEST !!! */
            nro = get_current_document();

            Cancelar();
            /* close document */
            CerrarComprobante();

            /* close port */
            error = Desconectar();
            //Console.WriteLine("Disconect: " + error.ToString());

            /* deactive log */
            DetenerLog();
            
            return --nro;

            }
        int get_current_document()
            {
            const int str_len = 500;
            StringBuilder str = new StringBuilder(str_len);

            /* call exported function from "EpsonFiscalInterface.h" */
            int error = ConsultarNumeroComprobanteActual(str, str_len);

            /* show */
            string msg = "-Error: " + error.ToString() + Environment.NewLine + Environment.NewLine + "-Num.Doc: ";
            int numero = 0;
            numero = int.Parse(str.ToString());
            //Console.WriteLine(msg);



            /* call exported function from "EpsonFiscalInterface.h" */
            error = ConsultarTipoComprobanteActual(str, str_len);

            /* show */
            msg = "-Error: " + error.ToString() + Environment.NewLine + Environment.NewLine + "-Tipo.Doc: " + str.ToString();
            //Console.WriteLine(msg);

            return numero;
            }
        /* -----------------------------------------------------------------------------
        Function: Auditoria()
        ----------------------------------------------------------------------------- */
        public int Auditoria()
        {
            _config_port();
            Conectar();
            const int respuesta_largo_maximo = 255; // Ajusta la longitud máxima según tus necesidades.
            StringBuilder respuesta = new StringBuilder(respuesta_largo_maximo);
            int result = ImprimirAuditoria(501, DateTime.Now.AddDays(0).ToString("ddMMyy"), DateTime.Now.AddDays(-1).ToString("ddMMyy"));
            Desconectar();
            return result;
        }

        /* -----------------------------------------------------------------------------
        Function: cierreZ()
        ----------------------------------------------------------------------------- */
        public int cierreZ()
        {
            _config_port();
            Conectar();
            int result = ImprimirCierreZ();
            Desconectar();
            return result;
        }


        /* -----------------------------------------------------------------------------
        Function: NumeroPuntoDeVenta()
        ----------------------------------------------------------------------------- */
        public string NumeroPuntoDeVenta()
        {
            _config_port();
            Conectar();
            const int respuesta_largo_maximo = 255; // Ajusta la longitud máxima según tus necesidades.
            StringBuilder respuesta = new StringBuilder(respuesta_largo_maximo);
            int result = ConsultarNumeroPuntoDeVenta(respuesta, respuesta_largo_maximo);
            Desconectar();
            return respuesta.ToString();
            
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
            try
            {
                ConsultarVersionDll(str, str_len, ref mayor, ref menor);
            }
            catch (Exception e)
            {
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
                        Console.WriteLine("nro cierre  Z Closure Day: " + error.ToString());

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
            catch (Exception)
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
        public void test_ticket_inv_cancel(List<GiftData> lista)
            {
            try
                {
                Desconectar();
                string[] sucursal = null;


                if (datosSuc.ContainsKey(lista[0].Nrosuc))
                    {
                    sucursal = (datosSuc[lista[0].Nrosuc]).ToArray();

                    }
                else
                    {
                    Console.WriteLine("No se encontró una sucursal. " + lista[0].Nrosuc);
                    }


                const int tipo_comprobante = 3;
                /*
                 Identificador del tipo de comprobante:
                 1 – Tique.
                 2 – Tique factura A/B/C/M.
                 3 – Tique nota de crédito, tique nota crédito A/B/C/M.
                 4 – Tique nota de débito A/B/C/M.
                 21 – Documento no fiscal homologado genérico.
                 22 – Documento no fiscal homologado de uso interno.
                 */
                string nombre_o_razon_social1 = "CONSUMIDOR";
                string nombre_o_razon_social2 = "FINAL";
                string domicilio1 = "Suc " + sucursal[0];
                string domicilio2 = "Suc " + sucursal[1];
                string domicilio3 = sucursal[2];
                int id_tipo_documento = 1;
                string numero_documento = "11111111";
                int id_responsabilidad_iva = 5;

                int error = 0;
                string description = "";

                /* active log */
                error = ComenzarLog(true);

                /* config */
                _config_port();
                try
                    {


                    /* real conection */
                    error = Conectar();


                    /* get description error */
                    if (error != 0)
                        {
                        /* message */
                        description = get_description_error(error);


                        /* exit */
                        return;
                        }

                    /* previous settings for ticket invoice */
                    //error = CargarDatosCliente("Nombre Comprador #1", "", "Domicilio Comparador #1", "", "", 1, "3478905", 5);
                    error = CargarDatosCliente(nombre_o_razon_social1, nombre_o_razon_social2, domicilio1, domicilio2, domicilio3, id_tipo_documento, numero_documento, id_responsabilidad_iva);
                    //error = CargarComprobanteAsociado("083-00001-00000027");

                    /* open document */
                    error = AbrirComprobante(tipo_comprobante);

                    DatabaseHelper.NroNc = get_current_document();
                    error = CargarTextoExtra("  ");
                    //impresion 
                    /*
                     * 
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
                    foreach (var item in lista)
                        {
                        bool seAnula = lista.Any(otherItem => otherItem != item && otherItem.Importe == -item.Importe);

                        string descripcion = "GIFT";//Descripción del ítem.
                        string cantidad = "1.000";// Multiplicidad del ítem.Expresado bajo la siguiente precisión: “nnnnn.nnnn”. (5, 4)
                        string precio = item.Importe + "00"; // Precio unitario del ítem. Expresado bajo la siguiente precisión: “nnnnnnn.nnnn”. (7, 4)
                        const int ID_TASA_IVA_21_00 = 5; //Identificador de tasa de I.V.A.: 0 - Ninguno.  1 - I.V.A.exento.  4 - I.V.A. 10.50 %.  5 - I.V.A. 21.00 %.
                        const int ID_IMPUESTO_INTERNO_FIJO = 0; //0 – Ninguno.   1 - Impuesto interno fijo.  2 - Impuesto interno porcentual.
                        string ii_valor = "5.0000"; // Valor del impuesto interno. Expresado bajo la siguiente precisión:  Impuesto interno fijo: “nnnnnnn.nnnn”. (7, 4)  Impuesto interno porcentual: “0.nnnnnnnn”. (0, 8)
                        const int ID_CODIGO_INTERNO = 1; // Identificador del tipo de código de producto asociado al ítem:  1 - Código interno.  2 - Código matrix.
                        string codigo = "."; //Valor del código (interno o matrix según campo previo).
                        string codigo_unidad_matrix = ""; // Valor del código unidad matrix, según será requerido.
                        const int AFIP_CODIGO_UNIDAD_MEDIDA_KILOGRAMO = 7;//Código de unidad de medida:  5 - Litros  7 - Unidad  14 - Gramo  20 - Centímetro  62 - Pack  63 - Horma 


                        error = ImprimirItem(ID_MODIFICADOR_AGREGAR, descripcion, cantidad, precio, ID_TASA_IVA_21_00, ID_IMPUESTO_INTERNO_FIJO, ii_valor, ID_CODIGO_INTERNO, codigo,
                            codigo_unidad_matrix, AFIP_CODIGO_UNIDAD_MEDIDA_KILOGRAMO);

                        }
                    error = CargarTextoExtra("  ");
                    error = CargarTextoExtra("  ");
                    error = CargarTextoExtra("  ");
                    error = CargarTextoExtra("  ");
                    error = CargarTextoExtra("  ");
                    error = CargarTextoExtra("  ");


                    /* get description error */
                    description = get_description_error(error);


                    }
                catch (Exception) { }
                finally
                    {

                    /* cancel */
                    //error = Cancelar();//comentado en prod

                    /* close document | just in case */
                    error = CerrarComprobante();

                    /* close port */
                    Desconectar();


                    /* deactive log */
                    DetenerLog();
                    }

                }
            catch (Exception)
                {
                Desconectar();
                }

            }
        /* -----------------------------------------------------------------------------
 Function: test_ticket_cancel()
 ----------------------------------------------------------------------------- */
        public void test_ticket_cf(List<GiftData> lista)
            {
            try
                {
                Desconectar();
                string[] sucursal = null;


                if (datosSuc.ContainsKey(lista[0].Nrosuc))
                    {
                    sucursal = (datosSuc[lista[0].Nrosuc]).ToArray();

                    }
                else
                    {
                    Console.WriteLine("No se encontró una sucursal. " + lista[0].Nrosuc);
                    }


                const int tipo_comprobante = 2;
                /*
                 Identificador del tipo de comprobante:
                 1 – Tique.
                 2 – Tique factura A/B/C/M.
                 3 – Tique nota de crédito, tique nota crédito A/B/C/M.
                 4 – Tique nota de débito A/B/C/M.
                 21 – Documento no fiscal homologado genérico.
                 22 – Documento no fiscal homologado de uso interno.
                 */
                string nombre_o_razon_social1 = "CONSUMIDOR";
                string nombre_o_razon_social2 = "FINAL";
                string domicilio1 = "Suc " + sucursal[0];
                string domicilio2 = "Suc " + sucursal[1];
                string domicilio3 = sucursal[2];
                int id_tipo_documento = 1;
                string numero_documento = "11111111";
                int id_responsabilidad_iva = 5;

                int error = 0;
                string description = "";

                /* active log */
                error = ComenzarLog(true);

                /* config */
                _config_port();
                try
                    {


                    /* real conection */
                    error = Conectar();


                    /* get description error */
                    if (error != 0)
                        {
                        /* message */
                        description = get_description_error(error);


                        /* exit */
                        return;
                        }

                    /* previous settings for ticket invoice */
                    //error = CargarDatosCliente("Nombre Comprador #1", "", "Domicilio Comparador #1", "", "", 1, "3478905", 5);
                    error = CargarDatosCliente(nombre_o_razon_social1, nombre_o_razon_social2, domicilio1, domicilio2, domicilio3, id_tipo_documento, numero_documento, id_responsabilidad_iva);
                    //error = CargarComprobanteAsociado("083-00001-00000027");

                    /* open document */
                    error = AbrirComprobante(tipo_comprobante);

                    DatabaseHelper.NroNc = get_current_document();
                    error = CargarTextoExtra("  ");
                    //impresion 
                    /*
                     * 
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
                    foreach (var item in lista)
                        {
                        bool seAnula = lista.Any(otherItem => otherItem != item && otherItem.Importe == -item.Importe);

                        string descripcion = "GIFT";//Descripción del ítem.
                        string cantidad = "1.000";// Multiplicidad del ítem.Expresado bajo la siguiente precisión: “nnnnn.nnnn”. (5, 4)
                        string precio = item.Importe + "00"; // Precio unitario del ítem. Expresado bajo la siguiente precisión: “nnnnnnn.nnnn”. (7, 4)
                        const int ID_TASA_IVA_21_00 = 5; //Identificador de tasa de I.V.A.: 0 - Ninguno.  1 - I.V.A.exento.  4 - I.V.A. 10.50 %.  5 - I.V.A. 21.00 %.
                        const int ID_IMPUESTO_INTERNO_FIJO = 0; //0 – Ninguno.   1 - Impuesto interno fijo.  2 - Impuesto interno porcentual.
                        string ii_valor = "5.0000"; // Valor del impuesto interno. Expresado bajo la siguiente precisión:  Impuesto interno fijo: “nnnnnnn.nnnn”. (7, 4)  Impuesto interno porcentual: “0.nnnnnnnn”. (0, 8)
                        const int ID_CODIGO_INTERNO = 1; // Identificador del tipo de código de producto asociado al ítem:  1 - Código interno.  2 - Código matrix.
                        string codigo = "."; //Valor del código (interno o matrix según campo previo).
                        string codigo_unidad_matrix = ""; // Valor del código unidad matrix, según será requerido.
                        const int AFIP_CODIGO_UNIDAD_MEDIDA_KILOGRAMO = 7;//Código de unidad de medida:  5 - Litros  7 - Unidad  14 - Gramo  20 - Centímetro  62 - Pack  63 - Horma 


                        error = ImprimirItem(ID_MODIFICADOR_AGREGAR, descripcion, cantidad, precio, ID_TASA_IVA_21_00, ID_IMPUESTO_INTERNO_FIJO, ii_valor, ID_CODIGO_INTERNO, codigo,
                            codigo_unidad_matrix, AFIP_CODIGO_UNIDAD_MEDIDA_KILOGRAMO);

                        }
                    error = CargarTextoExtra("  ");
                    error = CargarTextoExtra("  ");
                    error = CargarTextoExtra("  ");
                    error = CargarTextoExtra("  ");
                    error = CargarTextoExtra("  ");
                    error = CargarTextoExtra("  ");


                    /* get description error */
                    description = get_description_error(error);


                    }
                catch (Exception) { }
                finally
                    {

                    /* cancel */
                    //error = Cancelar();//comentado en prod

                    /* close document | just in case */
                    error = CerrarComprobante();

                    /* close port */
                    Desconectar();


                    /* deactive log */
                    DetenerLog();
                    }

                }
            catch (Exception)
                {
                Desconectar();
                }

            }
        }
}
