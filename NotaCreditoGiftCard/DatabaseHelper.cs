using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.VisualBasic;
using NotaCreditoGiftCard;

public class DatabaseHelper
{
    private readonly string connectionString = "Server=SRV-LAB3;Database=TiprePagaCompras;User Id=tprusr;Password=tpradmin123456;";

    public DatabaseHelper()
    {
    }


    public List<T> ExecuteStoredProcedure<T>(string stringValue, int intValue)
    {
        using (IDbConnection dbConnection = new SqlConnection(connectionString))
        {
            dbConnection.Open();
            string storedProcedureName = "ObtenerGift";
            var parameters = new DynamicParameters();
            parameters.Add("@fecha", stringValue);
            parameters.Add("@suc", intValue);

            return dbConnection.Query<T>(
                storedProcedureName,
                parameters,
                commandType: CommandType.StoredProcedure
            ).AsList();
        }

    }

    public int UpdateTransaction(int id, DateTime fechaNC, int nroNC, string nroPVNC, int nroZ, DateTime fechaNCImpresora)
    {
        using (IDbConnection dbConnection = new SqlConnection(connectionString))
        {
            dbConnection.Open();
            string updateQuery = @"UPDATE Transacciones
                               SET ImpresionNC = 1, FechaNC = @fechaNC, NroNC = @nroNC, NroPVNC = @nroPVNC, NroZ = @nroZ, FechaNCImpresora = @fechaNCImpresora
                               WHERE id = @id";


            return dbConnection.Execute(updateQuery, new
            {
                id,
                fechaNC,
                nroNC,
                nroPVNC,
                nroZ,
                fechaNCImpresora
            });
        }
    }


    public int UpdateZnro(DateTime diaZ, int nuevoNroZ)
    {
        using (IDbConnection dbConnection = new SqlConnection(connectionString))
        {
            dbConnection.Open();
            string updateQuery = @"
            UPDATE Transacciones
            SET 
                NroZ = @nuevoNroZ
            WHERE FechaNC > CAST(CONVERT(date, @diaZ) AS datetime) AND NroZ = 0;";

            return dbConnection.Execute(updateQuery, new
            {
                diaZ,
                nuevoNroZ
            });
        }
    }


    string sqlCierredeCaja = @"
                            UPDATE CIERRECAJA
                            SET"+
                                "COD_SUCURSAL = subquery.COD_SUCURSAL," + // Id provisto por Dinosaurio
                                "PUNTOVENTA = subquery.PUNTOVENTA," + // nro pv
                                "NUMERO_Z = subquery.NUMERO_Z,"+ // nro z
                                "TIPOCOMPROBANTE = NULL," + // Letra que identifica el tipo de comprobante que se integra. 
                                "TICKET_INICIAL = NULL," + // primer ticket de la Z integrada, en el caso de facturas nominadas el número de factura fiscal, NC ídem a facturas nominadas.
                                "TICKET_FINAL = NULL," + // ultimo ticket de la Z integrada, en el caso de facturas nominadas el número de factura fiscal, NC ídem a facturas nominadas.
                                "FECHA = NULL," + // fecha que hace referencia al día de venta. 
                                "NOMBRECLIENTE = NULL," + // en el caso de Z ‘CONSUMIDOR FINAL’, si el comprobante es nominado el nombre del cliente al que se le facturo o se le realizo la NC.
                                "REGIMENIVA = NULL," + // en el caso de las Z va CF, si es nominado va el régimen que le corresponde, ejemplo: responsable inscripto = RI
                                "CUIT = NULL," + // va en 0, si es nominado el CUIT/DNI/CUIL del cliente.
                                "ITEMSFACTURADOS = NULL," + // PK de la tabla. Dato que se utiliza para relacionar este registro con su detalle impositivo en otra tabla (itemcierrecaja). Cada sistema Retail compone este número. 
                                "TOTALFACTURADO = NULL," + // monto total de ese comprobante. En el caso de Z monto total sin contemplar facturas nominadas y notas de crédito. 
                                "ESTADO = 1," + //# 1 (siempre que integren deben venir este campo en 1 para ser procesado por nosotros)
                                "FECHAIMPORTACION = NULL," +//# NULL
                                "APPORIGEN = NULL," + // Dato provisto por Dinosaurio
                                "PASIBLE_IIBB = NULL," + // bit 0 no / 1 sí. Esto indica si se le cobra IIBB o no
                                "NRO_IIBB = NULL," + // Numero de ingresos brutos. Dato del cliente. 
                                "MONTOGC = '0'," + //#  No pasar. Default value ‘0’
                                "PCICBA = NULL," + // Tipo de percepción que se le aplica. En los casos de que no sea un comprobante nominado se debe enviar 0 como valor. 
                                "CTACTE = '0'," + //#  No pasar. Default value ‘0’
                                "CAE = NULL," + // Numero de CAE, solo aplica a facturas electrónicas. 
                                "FECHAVTOCAE = NULL," + // Fecha de vencimiento de CAE, solo aplica a facturas electrónicas.
                                "PIVA = NULL" + //  bit 0 no / 1 sí. Esto indica si se le cobra percepción IVA Productos de Consumo Masivo o no
                            @"FROM
                            (
                                SELECT TOP 1
                                    COD_SUCURSAL,
                                    PUNTOVENTA,
                                    NUMERO_Z,
                                    
                                FROM CIERRECAJA
                                ORDER BY FECHA DESC
                            ) AS subquery;
                            ";

    /*
     * 
     * COD_SUCURSAL	PUNTOVENTA	NUMERO_Z	TIPOCOMPROBANTE	TICKET_INICIAL	TICKET_FINAL	FECHA	                NOMBRECLIENTE	    REGIMENIVA	CUIT	ITEMSFACTURADOS 	TOTALFACTURADO	ESTADO	FECHAIMPORTACION	    APPORIGEN	PASIBLE_IIBB	NRO_IIBB	MONTOGC	PCICBA	CTACTE	CAE	    FECHAVTOCAE	 PIVA
        23	        619	        238	         D	            2352	        2352	        2021-11-13 00:00:00.000	CONSUMIDOR FINAL    CF	        0	    0619-D-00002352 	7900,01	        0	    2021-11-15 10:15:07.207	15	        0	            -	        0	    0	    0	    NULL	NULL	     NULL

                Cod_sucursal: Id provisto por Dinosaurio
                Puntoventa: Numero de punto de venta Fiscal, en el caso de cines se integra el número de terminal (sistema actual)  
                Numero_Z: Numero de Z fiscal.
                Tipocomprobante: Letra que identifica el tipo de comprobante que se integra. 
                Ticket_inicial: primer ticket de la Z integrada, en el caso de facturas nominadas el número de factura fiscal, NC ídem a facturas nominadas.
                Ticket_Final: ultimo ticket de la Z integrada, en el caso de facturas nominadas el número de factura fiscal, NC ídem a facturas nominadas.
                Fecha: fecha que hace referencia al día de venta. 
                Nombrecliente: en el caso de Z ‘CONSUMIDOR FINAL’, si el comprobante es nominado el nombre del cliente al que se le facturo o se le realizo la NC.
                CUIT: va en 0, si es nominado el CUIT/DNI/CUIL del cliente.
                Regimeniva: en el caso de las Z va CF, si es nominado va el régimen que le corresponde, ejemplo: responsable inscripto = RI
                Itemsfacturados: PK de la tabla. Dato que se utiliza para relacionar este registro con su detalle impositivo en otra tabla (itemcierrecaja). Cada sistema Retail compone este número. 
                Totalfacturado: monto total de ese comprobante. En el caso de Z monto total sin contemplar facturas nominadas y notas de crédito. 
                Estado: 1 (siempre que integren deben venir este campo en 1 para ser procesado por nosotros)
                Fechaimportacion: NULL
                Apporigen: Dato provisto por Dinosaurio
                Pasible_IIBB: bit 0 no / 1 sí. Esto indica si se le cobra IIBB o no
                Nro_IIBB: Numero de ingresos brutos. Dato del cliente. 
                Montogc: No pasar. Default value ‘0’
                PCICBA: Tipo de percepción que se le aplica. En los casos de que no sea un comprobante nominado se debe enviar 0 como valor. 
                CTACTE: No pasar. Default value ‘0’
                CAE: Numero de CAE, solo aplica a facturas electrónicas. 
                FECHAVTOCAE: Fecha de vencimiento de CAE, solo aplica a facturas electrónicas.
                PIVA: bit 0 no / 1 sí. Esto indica si se le cobra percepción IVA Productos de Consumo Masivo o no

     */
    string sqlItemCierredeCaja = @"
                                  UPDATE ITEMCIERRECAJA
                                    SET"+
                                        "ITEMFACTURADOS = '10-351147'," + // PK de la tabla. Campo que relaciona este registro con el cierrecaja
                                        "IMPORTE = 87.79," + // Importe desglosado por concepto impositivo (Neto 21, Neto 10.5, IVA 21, etc…)
                                        "CONCEPTO = 13," + // Dato provisto por Dinosaurio. Hace referencia al tipo de concepto impositivo.
                                        "ESTADO = 1," + //# 1 (siempre que integren deben venir este campo en 1 para ser procesado por nosotros)
                                        "FECHAIMPORTACION = NULL," + //# NULL
                                        "APPORIGEN = 10" + // Dato provisto por Dinosaurio  ??
                                    @"WHERE
                                        FECHAIMPORTACION = (SELECT MAX(FECHAIMPORTACION) FROM ITEMCIERRECAJA);
                                   ";

    /*
        ITEMFACTURADOS	    IMPORTE	        CONCEPTO	 ESTADO	FECHAIMPORTACION	        APPORIGEN
        0619-D-00002352 	1371,08	        4	         0	    2021-11-15 10:15:07.457	    15
        0619-D-00002352 	6528,93	        1	         0	    2021-11-15 10:15:07.457	    15
    
        Itemfacturados: PK de la tabla. Campo que relaciona este registro con el cierrecaja
        Importe: Importe desglosado por concepto impositivo (Neto 21, Neto 10.5, IVA 21, etc…)
        Concepto: Dato provisto por Dinosaurio. Hace referencia al tipo de concepto impositivo.

        Código	Concepto
        1	Neto 21% 
        4	IVA 21%           

        Estado: 1 (siempre que integren deben venir este campo en 1 para ser procesado por nosotros)
        Fechaimportacion: NULL
        Apporigen: Dato provisto por Dinosaurio
 

*/

}

