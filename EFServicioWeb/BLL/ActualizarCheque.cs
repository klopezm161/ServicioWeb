using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Newtonsoft.Json;
namespace BLL
{
   public class ActualizarCheque
    {
        #region propiedades

        private string _cheque;

        public string cheque
        {
            get { return _cheque; }
            set { _cheque = value; }
        }
        private string _cuenta;

        public string cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }

        private decimal _monto;

        public decimal monto
        {
            get { return _monto; }
            set { _monto = value; }
        }



        #endregion

        #region variables privadas
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region metodos
    

        public int modificarCheque(string accion)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return 5;
            }
            else
            {
                if (accion.Equals("Actualizar"))
                {
                    sql = "actualizarMontoCuenta";
                }
                ParamStruct[] parametros = new ParamStruct[3];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@numCheque", SqlDbType.VarChar, _cheque);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@cuenta", SqlDbType.VarChar, _cuenta);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@monto", SqlDbType.Decimal, _monto);
                cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
                cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
                if (mensaje_error == "Error al ejecutar la sentencia sql, informacion adicional: -1")
                {
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return -1;
                }
                else if (mensaje_error == "Error al ejecutar la sentencia sql, informacion adicional: -2")
                {
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return -2;
                }
                else if (mensaje_error == "Error al ejecutar la sentencia sql, informacion adicional: -3")
                {
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return -3;
                }
                else
                {
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return 0;
                }
            }
        }


        #endregion
    }
}
