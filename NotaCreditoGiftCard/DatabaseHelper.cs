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


    /* metodo que graba en base de datos con dapper recibe estos parametros 
     * 
     *            FechaNC = getdate()
            NroNC = numerocomprobante 
            NroPVNC = 721 
            NroZ = nrozcontrolador
            FechaNCImpresora = fechacontrolador(hoy - 1)
            estos datos recibe por parametros

            update Transacciones 
            set ImpresionNC = 1, FechaNC = getdate(), NroNC = numerocomprobante, NroPVNC = 721, NroZ = nrozcontrolador, FechaNCImpresora = fechacontrolador(hoy - 1)
            where id = @id-- el id de la operación

     */

}

