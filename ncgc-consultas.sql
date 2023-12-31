SELECT TOP (1) (NUMERO_Z+1)
  FROM [integracion].[dbo].[CIERRECAJA] where PUNTOVENTA  like'%723%' and APPORIGEN = 21
   order by NUMERO_Z desc

/****** Script para el comando SelectTopNRows de SSMS  ******/
SELECT TOP (1000)*
  FROM [integracion].[dbo].[CIERRECAJA] where PUNTOVENTA  like'%723%' and APPORIGEN = 21 
 -- and NUMERO_Z = 0
   order by NUMERO_Z desc

/*

SELECT 
TICKET_INICIAL as Id, 
FECHA as Fecha, 
COD_SUCURSAL as Nrosuc, 
TOTALFACTURADO as Importe
FROM [integracion].[dbo].[CIERRECAJA] where PUNTOVENTA  like'%723%' and APPORIGEN = 21 
 
   


int Id
DateTime Fecha
string? Nrosuc
decimal Importe
*/


   /****** Script para el comando SelectTopNRows de SSMS  ******/
SELECT TOP (1000) CONCEPTO,*
  FROM [integracion].[dbo].[ITEMCIERRECAJA] where --ITEMFACTURADOS = 'NC-072300002068'
 [ITEMFACTURADOS] like'%723%' and APPORIGEN = 21 order by FECHAIMPORTACION desc
/*
declare @COD_SUCURSAL varchar(50),
    @PUNTOVENTA varchar(50),
    @NUMERO_Z int,
    @NRO_COMPROBANTE int ,
    @ITEMSFACTURADOS Varchar(50),
    @TOTALFACTURADO_NETO float

set @COD_SUCURSAL = 1;
set @PUNTOVENTA ='723'
set @NUMERO_Z =787;
set @NRO_COMPROBANTE =11;
set @ITEMSFACTURADOS = 'NC-0723-00000011';
set @TOTALFACTURADO_NETO =178

        BEGIN TRAN;

            INSERT INTO CIERRECAJA (
                COD_SUCURSAL,
                PUNTOVENTA,
                NUMERO_Z,
                TIPOCOMPROBANTE,
                TICKET_INICIAL,
                TICKET_FINAL,
                FECHA,
                NOMBRECLIENTE,
                REGIMENIVA,
                CUIT,
                ITEMSFACTURADOS,
                TOTALFACTURADO,
                ESTADO,
                FECHAIMPORTACION,
                APPORIGEN,
                PASIBLE_IIBB,
                NRO_IIBB,
                MONTOGC,
                PCICBA,
                CTACTE,
                CAE,
                FECHAVTOCAE,
                PIVA
            )
            VALUES (
                @COD_SUCURSAL,
                @PUNTOVENTA,
                @NUMERO_Z,
                'F',
                @NRO_COMPROBANTE, -- Cambiar a @NRO_COMPROBANTE
                @NRO_COMPROBANTE, -- Cambiar a @NRO_COMPROBANTE
                NULL,
                'CONSUMIDOR FINAL',
                'CF',
                0,
                @ITEMSFACTURADOS,
                (@TOTALFACTURADO_NETO * 1.21),
                1,
                NULL,
                21,
                0,
                NULL,
                '0',
                0,
                '0',
                NULL,
                NULL,
                NULL
            );

            INSERT INTO ITEMCIERRECAJA (
                ITEMFACTURADOS, 
                IMPORTE, 
                CONCEPTO, 
                ESTADO, 
                FECHAIMPORTACION, 
                APPORIGEN
            )
            VALUES (
                @ITEMSFACTURADOS, 
                @TOTALFACTURADO_NETO, 
                4, --neto
                1, 
                NULL, 
                21
            );

            INSERT INTO ITEMCIERRECAJA (
                ITEMFACTURADOS, 
                IMPORTE, 
                CONCEPTO, 
                ESTADO, 
                FECHAIMPORTACION, 
                APPORIGEN
            )
            VALUES (
                @ITEMSFACTURADOS, 
                (@TOTALFACTURADO_NETO * 0.21), 
                1, --iva
                1, 
                null, 
                21
            );

       --     COMMIT; rollback
        

		*/
/*
begin tran
delete 
--select * 
  FROM [integracion].[dbo].[ITEMCIERRECAJA] where ITEMFACTURADOS = 'NC-072300002068' 


*/--commit tran

/*
select *   FROM [integracion].[dbo].[CIERRECAJA] where ITEMSfACTURADOS = 'NC-0723-00000013' 
begin tran 
update [integracion].[dbo].[CIERRECAJA]
set fecha = '2023-12-17 00:00:00.000'
--set ITEMSfACTURADOS = 'NC-0723-00000008' 
--set TICKET_FINAL  = 09
where ITEMSfACTURADOS = 'NC-0723-00000011' 
--commit tran
*/

/*
begin tran
update [integracion].[dbo].[CIERRECAJA] 
set NUMERO_Z = 788
where PUNTOVENTA  like'%723%' and APPORIGEN = 21 
  and NUMERO_Z = 0

*/
/*
  select * from [integracion].[dbo].[ITEMCIERRECAJA]  where [ITEMFACTURADOS] like'%723%' and APPORIGEN = 21 and CONCEPTO = 1
begin tran
update [integracion].[dbo].[ITEMCIERRECAJA] 
set CONCEPTO = 1
where [ITEMFACTURADOS] like'%723%' and APPORIGEN = 21 and CONCEPTO = 5
*/ -- commit tran
/*

declare @nc varchar(50);
declare @monto float;
set @nc ='NC-0723-00000036'
set @monto = 89766.58
begin tran 
update [integracion].[dbo].[CIERRECAJA] 
set TOTALFACTURADO =@monto
where PUNTOVENTA  like'%723%' and APPORIGEN = 21 
and ITEMSFACTURADOS = @nc
update [integracion].[dbo].[ITEMCIERRECAJA] 
set IMPORTE = @monto*.82644628 
where
 [ITEMFACTURADOS] like'%723%' and APPORIGEN = 21 and ITEMFACTURADOS = @nc and CONCEPTO = 1
 update [integracion].[dbo].[ITEMCIERRECAJA] 
set IMPORTE = @monto*0.17355372
where
 [ITEMFACTURADOS] like'%723%' and APPORIGEN = 21 and ITEMFACTURADOS = @nc and CONCEPTO = 4

select *
  FROM [integracion].[dbo].[CIERRECAJA] where PUNTOVENTA  like'%723%' and APPORIGEN = 21 
and ITEMSFACTURADOS = @nc
select *
  FROM [integracion].[dbo].[ITEMCIERRECAJA] where
 [ITEMFACTURADOS] like'%723%' and APPORIGEN = 21 and ITEMFACTURADOS = @nc
 */--rollback tran --commit tran