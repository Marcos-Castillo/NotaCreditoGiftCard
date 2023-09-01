using NotaCreditoGiftCard;

Console.WriteLine("Iniciando impresion Nota de credito");

EpsonFiscalControlador epson = new();
epson.Funciona();
epson.dll_version();
Console.WriteLine("Desea realizar tiket de prueba?");
Console.WriteLine("presione 'S' para continuar o cualquier tecla para cancelar");
string a = "";
a= Console.ReadLine() +"";
if (a.ToLower()=="s")
{
    epson.test_ticket_inv_cancel();
}
Console.WriteLine("Desea realizar cierre 'X' y 'Z'?");
Console.WriteLine("presione 'S' para continuar o cualquier tecla para cancelar");
a = "";
a = Console.ReadLine() + "";
if (a.ToLower() == "s")
{
    epson.print_X_and_Z();
}

