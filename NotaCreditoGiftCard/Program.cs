using NotaCreditoGiftCard;
using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
     static bool isRunning = true;
    static void Main()
    {

        EpsonFiscalControlador epson = new();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1 - Realizar ticket de nc gift");
            Console.WriteLine("2 - Realizar cierre 'X' y 'Z'");
            Console.WriteLine("4 - cual es mi z");
            Console.WriteLine("5 - Consultar Fecha Hora");
            Console.WriteLine("6 - Nro PV");
            Console.WriteLine("7 - Realizar ticket de nc gift AUTO");
            Console.WriteLine("8 - Version del dll");
            Console.WriteLine("9 - Salir");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    RealizarTicketDeNC(epson);
                    break;
                case "2":
                    RealizarCierreXeZ(epson);
                    Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine(obtenernroz());


                    break;
                case "5":

                    Console.WriteLine(epson.Consultar_FechaHora());

                    break;

                case "6":

                    Console.WriteLine(epson.NumeroPuntoDeVenta());

                    break;

                case "7":
                    ProgramLoop(epson);
                    break;

                case "8":
                 
                    epson.dll_version();
                    
                    break;
                case "9":
                    Console.WriteLine("Saliendo del programa.");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
            Console.WriteLine("presione enter para continuar...");
            Console.ReadLine();
        }
    }

    static void RealizarTicketDeNC(EpsonFiscalControlador epson)
    {
        int limiteFacturacion = 1000000;//tope de importe por factura 
        Console.WriteLine("Desea realizar ticket de NC?");
        Console.WriteLine("Presione 'S' para continuar o cualquier tecla para cancelar");
        string a = Console.ReadLine() + "";
        if (a.ToLower() == "s")
        {
            int[] sucursales = { 1, 3, 13, 50, 54, 110, 200, 250, 350, 370, 400, 380, 390 };//prod
            //MODIFICACION PARA OBTENER SUCURSALES DE BBDD
            //int[] sucursales = { 1 }; // para pruebas
            DatabaseHelper dbHelper = new DatabaseHelper();
            int diasDesface = 1;
         
            foreach (var suc in sucursales)
            {
                Console.WriteLine("Inicio sucursal " + suc);
               
                string Fecha = DateTime.Now.AddDays(-diasDesface).ToString("yyyyMMdd");
                
                List<GiftData> lista = dbHelper.ExecuteStoredProcedure<GiftData>(Fecha, suc);
                List<List<GiftData>> sublistas = new List<List<GiftData>>();
                decimal acumulado = 0;
                int currentIndex = 0;

                while (currentIndex < lista.Count)
                {
                    List<GiftData> sublistaTemporal = new List<GiftData>();
                    decimal sublistaAcumulada = 0;

                    for (; currentIndex < lista.Count; currentIndex++)
                    {
                        GiftData item = lista[currentIndex];
                        if (sublistaAcumulada + item.Importe > limiteFacturacion)
                        {
                            break;
                        }

                        sublistaTemporal.Add(item);
                        sublistaAcumulada += item.Importe;
                    }

                    sublistas.Add(sublistaTemporal);
                }

                foreach (var sublista in sublistas)
                {
                    epson.test_ticket_inv_cancel(sublista);
                    int nroNC = DatabaseHelper.NroNc;
                    string nroPVNC = epson.NumeroPuntoDeVenta();
                    int nroZ = DatabaseHelper.NroZ;
                    DateTime fechaNCImpresora = epson.Consultar_FechaHora();

                    foreach (var f in sublista)
                    {
                        
                        //dbHelper.UpdateTransaction(f.Id, DateTime.Now, nroNC, nroPVNC, nroZ, fechaNCImpresora);///guardar transaccion
                        dbHelper.UpdateTransactionxgift(f.Id, DateTime.Now, nroNC, nroPVNC, nroZ, fechaNCImpresora);///guardar transaccion
                    }
                    // Sumar todos los importes en la lista
                    decimal sumaImportes = sublista.Sum(giftData => giftData.Importe);

               
                dbHelper.InsertCierreCaja(
                    suc.ToString(),
                    nroPVNC,
                    nroZ,
                    nroNC,
                    "NC-" + "0723" + "-" + nroNC.ToString().PadLeft(8, '0'), 
                    sumaImportes,
                    fechaNCImpresora.Date
                    );



                }
                
                Console.WriteLine("Fecha: "+epson.Consultar_FechaHora());
                Console.WriteLine("PV: " + epson.NumeroPuntoDeVenta());
                Console.WriteLine("comprobante: " + DatabaseHelper.NroNc);
                Console.WriteLine("Fin sucursal " + suc);
            }

            epson.cierreZ();
            int nroz = obtenernroz(); 
            Console.WriteLine("numero de z generado "+nroz);
            dbHelper.UpdateZnro(nroz);
            dbHelper.UpdateZnroGift(DateTime.Now, nroz);
            }
    }


    static void ProgramLoop(EpsonFiscalControlador epson)
        {
        Console.WriteLine("Desea realizar NC en automático?");
        Console.WriteLine("Presione 'S' para continuar o cualquier tecla para cancelar");
        string a = Console.ReadLine() + "";
        if (a.ToLower() == "s")
            {
            ScheduleDailyExecution(epson);

            // Espera para que el programa no termine inmediatamente
            Console.WriteLine("Esperando la ejecución diaria a las 10 AM. Presiona 'q' y Enter para salir.");

            // Espera hasta que el usuario presione 'q'
            while (isRunning)
                {
                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                    {
                    isRunning = false;
                    }
                }
            }
        }

    static void ScheduleDailyExecution(EpsonFiscalControlador epson)
        {
        int hour = 10;
        // Obtiene la fecha y hora actual
        DateTime now = DateTime.Now;

        // Calcula la fecha y hora de la próxima ejecución a la hora especificada
        DateTime nextExecutionTime = now.Hour < hour
            ? new DateTime(now.Year, now.Month, now.Day, hour, 0, 0)
            : new DateTime(now.Year, now.Month, now.Day, hour, 0, 0).AddDays(1);

        // Calcula el tiempo hasta la próxima ejecución
        TimeSpan timeUntilNextExecution = nextExecutionTime - now;

        // Crea un temporizador para ejecutar la función diariamente a la hora especificada
        Timer timer = new Timer(state => RealizarTicketDeNCauto(epson), null, timeUntilNextExecution, TimeSpan.FromHours(24));
        }

    static void RealizarTicketDeNCauto(EpsonFiscalControlador epson)
        {
        Console.WriteLine("Imprimiendo nc..");
        
        int limiteFacturacion = 1000000;//tope de importe por factura 
            int[] sucursales = { 1, 3, 13, 50, 54, 110, 200, 250, 350, 370, 400, 380, 390 };//prod
            //MODIFICACION PARA OBTENER SUCURSALES DE BBDD
            //int[] sucursales = { 1 }; // para pruebas
            DatabaseHelper dbHelper = new DatabaseHelper();
            int diasDesface = 1;

            foreach (var suc in sucursales)
                {
                Console.WriteLine("Inicio sucursal " + suc);

                string Fecha = DateTime.Now.AddDays(-diasDesface).ToString("yyyyMMdd");
                Console.WriteLine("Corresponden al dia " + Fecha);
                List<GiftData> lista = dbHelper.ExecuteStoredProcedure<GiftData>(Fecha, suc);
                List<List<GiftData>> sublistas = new List<List<GiftData>>();
                decimal acumulado = 0;
                int currentIndex = 0;

                while (currentIndex < lista.Count)
                    {
                    List<GiftData> sublistaTemporal = new List<GiftData>();
                    decimal sublistaAcumulada = 0;

                    for (; currentIndex < lista.Count; currentIndex++)
                        {
                        GiftData item = lista[currentIndex];
                        if (sublistaAcumulada + item.Importe > limiteFacturacion)
                            {
                            break;
                            }

                        sublistaTemporal.Add(item);
                        sublistaAcumulada += item.Importe;
                        }

                    sublistas.Add(sublistaTemporal);
                    }

                foreach (var sublista in sublistas)
                    {
                    epson.test_ticket_inv_cancel(sublista);
                    int nroNC = DatabaseHelper.NroNc;
                    string nroPVNC = epson.NumeroPuntoDeVenta();
                    int nroZ = DatabaseHelper.NroZ;
                    DateTime fechaNCImpresora = epson.Consultar_FechaHora();

                    foreach (var f in sublista)
                        {

                        dbHelper.UpdateTransactionxgift(f.Id, DateTime.Now, nroNC, nroPVNC, nroZ, fechaNCImpresora);///guardar transaccion
                        }
                    // Sumar todos los importes en la lista
                    decimal sumaImportes = sublista.Sum(giftData => giftData.Importe);


                    dbHelper.InsertCierreCaja(
                        suc.ToString(),
                        nroPVNC,
                        nroZ,
                        nroNC,
                        "NC-" + "0723" + "-" + nroNC.ToString().PadLeft(8, '0'),
                        sumaImportes,
                        fechaNCImpresora.Date
                        );



                    }

                Console.WriteLine("Fecha: " + epson.Consultar_FechaHora());
                Console.WriteLine("PV: " + epson.NumeroPuntoDeVenta());
                Console.WriteLine("comprobante: " + DatabaseHelper.NroNc);
                Console.WriteLine("Fin sucursal " + suc);
                }

            epson.cierreZ();
            int nroz = obtenernroz();
            Console.WriteLine("numero de z generado " + nroz);
            dbHelper.UpdateZnro(nroz);
            dbHelper.UpdateZnroGift(DateTime.Now, nroz);
            
        }

    static void RealizarCierreXeZ(EpsonFiscalControlador epson)
    {
        Console.WriteLine("Desea realizar cierre 'X' y 'Z'?");
        Console.WriteLine("Presione 'S' para continuar o cualquier tecla para cancelar");
        string a = Console.ReadLine() + "";
        if (a.ToLower() == "s")
        {
            epson.print_X_and_Z();
        }
    }
    static void setFechaHora(EpsonFiscalControlador epson)
    {
        Console.WriteLine("Desea modificar Fecha Hora");
        Console.WriteLine("se debe cargar con el formato 'ddmmyyTHHmmss'");
        string fechausuario= "" + Console.ReadLine();
        Console.WriteLine("la fecha ingresada es "+ fechausuario);
        Console.WriteLine("Presione 'S' para continuar o cualquier tecla para cancelar");
        string a = Console.ReadLine() + "";
        if (a.ToLower() == "s")
        {
                    epson.setFechaHora(fechausuario);
        }
    }

    static int obtenernroz() {
        DatabaseHelper db =new();
        int result = db.obtenerZ();
        return result;
     }

    static void RealizarTicketAnulacionDeNC(EpsonFiscalControlador epson)
        {
        //int limiteFacturacion = 1000000;//tope de importe por factura 
        Console.WriteLine("Desea realizar ticket de Anulacion?");
        Console.WriteLine("Presione 'S' para continuar o cualquier tecla para cancelar");
        string a = Console.ReadLine() + "";
        if (a.ToLower() == "s")
            {
            //int[] sucursales = { 1, 3, 13, 50, 54, 110, 200, 250, 350, 370, 400, 380, 390 };//prod
            //MODIFICACION PARA OBTENER SUCURSALES DE BBDD
            int[] sucursales = { 1 }; // para pruebas
            DatabaseHelper dbHelper = new DatabaseHelper();
            //int diasDesface = 1;

            foreach (var suc in sucursales)
                {
                Console.WriteLine("Inicio sucursal ");

                //string Fecha = DateTime.Now.AddDays(-diasDesface).ToString("yyyyMMdd");

                List<GiftData> lista = dbHelper.consultarLIstFacturados<GiftData>();//<<<<< obtiene los datos del store
                int i = 0;
                foreach (var sublista in lista)
                    {
                    epson.test_ticket_cf(new List<GiftData> {sublista} );//anulado para test
                        
                    int nroNC = DatabaseHelper.NroNc;
                    string nroPVNC = epson.NumeroPuntoDeVenta();
                    int nroZ = DatabaseHelper.NroZ;
                    DateTime fechaNCImpresora = epson.Consultar_FechaHora();


                    // Sumar todos los importes en la lista
                    //decimal sumaImportes = sublista.Importe;

                    
                    dbHelper.InsertCierreCaja(
                        suc.ToString(),
                        nroPVNC,
                        nroZ,
                        nroNC,
                        "TF-" + "0723" + "-" + nroNC.ToString().PadLeft(8, '0'),
                        sublista.Importe,
                        fechaNCImpresora.Date
                        );

                        

                    }

                Console.WriteLine("Fecha: " + epson.Consultar_FechaHora());
                Console.WriteLine("PV: " + epson.NumeroPuntoDeVenta());
                Console.WriteLine("Fin sucursales " );
                }

            epson.cierreZ();
            int nroz = obtenernroz();
            Console.WriteLine("numero de z generado " + nroz);
            dbHelper.UpdateZnro(nroz);//anulado para test
            //dbHelper.UpdateZnroGift(DateTime.Now, nroz);//anulado para test
            }
        }
    }
