using NotaCreditoGiftCard;
using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        EpsonFiscalControlador epson = new();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1 - Realizar ticket de prueba");
            Console.WriteLine("2 - Realizar cierre 'X' y 'Z'");
            Console.WriteLine("4 - modificar Fecha Hora");
            Console.WriteLine("5 - Consultar Fecha Hora");
            Console.WriteLine("6 - Nro PV");
            Console.WriteLine("7 - Ultima NC");
            Console.WriteLine("8 - Version del dll");
            Console.WriteLine("9 - Salir");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    RealizarTicketDePrueba(epson);
                    break;
                case "2":
                    RealizarCierreXeZ(epson);
                    break;
                case "4":
                    setFechaHora(epson);

                    break;
                case "5":

                    Console.WriteLine(epson.Consultar_FechaHora());

                    break;

                case "6":

                    Console.WriteLine(epson.NumeroPuntoDeVenta());

                    break;

                case "7":

                    Console.WriteLine(epson.NumeroComprobanteUltimo("3"));

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

    static void RealizarTicketDePrueba(EpsonFiscalControlador epson)
    {
        int limiteFacturacion = 1000000;//tope de importe por factura 
        Console.WriteLine("Desea realizar ticket de prueba?");
        Console.WriteLine("Presione 'S' para continuar o cualquier tecla para cancelar");
        string a = Console.ReadLine() + "";
        if (a.ToLower() == "s")
        {
            //int[] sucursales = { 1, 3, 13, 50, 54, 110, 200, 250, 350, 370, 400, 380, 390 };
            //MODIFICACION PARA OBTENER SUCURSALES DE BBDD
            int[] sucursales = { 13 }; // para pruebas
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

                    foreach (var f in sublista)
                    {
                        int nroNC = epson.NumeroComprobanteUltimo("3");
                        string nroPVNC = epson.NumeroPuntoDeVenta();
                        int nroZ = 0000;
                        DateTime fechaNCImpresora = epson.Consultar_FechaHora();
                        dbHelper.UpdateTransaction(f.Id, DateTime.Now, nroNC, nroPVNC, nroZ, fechaNCImpresora);
                    }
                    
                }
                
                Console.WriteLine("Fecha: "+epson.Consultar_FechaHora());
                Console.WriteLine("PV: " + epson.NumeroPuntoDeVenta());
                Console.WriteLine("comprobante: " + epson.NumeroComprobanteUltimo("3"));
                Console.WriteLine("Fin sucursal " + suc);
            }

            int nroz = epson.cierreZ();
            dbHelper.UpdateZnro(DateTime.Now, nroz);
        }
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

    
}
