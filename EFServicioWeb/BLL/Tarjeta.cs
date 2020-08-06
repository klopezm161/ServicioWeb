using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace BLL
{
   public class Tarjeta
    {
        #region propiedades

        private string _numTarjeta;

        public string numTarjeta
        {
            get { return _numTarjeta; }
            set { _numTarjeta = value; }
        }
        private string _mes;

        public string mes
        {
            get { return _mes; }
            set { _mes = value; }
        }
        public string _anio;
        public string anio
        {
            get { return _anio; }
            set { _anio = value; }
        }
        private string _cvv;

        public string cvv
        {
            get { return _cvv; }
            set { _cvv = value; }
        }
        public string _tipoTarjeta;
        public string tipoTarjeta
        {
            get { return _tipoTarjeta; }
            set { _tipoTarjeta = value; }
        }
        private string _creditoDebito;

        public string creditoDebito
        {
            get { return _creditoDebito; }
            set { _creditoDebito = value; }
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
        public bool agregarTarjeta(string accion)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                //    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                return false;
            }
            else
            {
                if (accion.Equals("Insertar"))
                {
                    sql = "crearTarjetaFE";
                }
                ParamStruct[] parametros = new ParamStruct[6];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@numTarjeta", SqlDbType.VarChar, _numTarjeta);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@mes", SqlDbType.VarChar, _mes);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@anio", SqlDbType.VarChar, _anio);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@cvv", SqlDbType.VarChar, _cvv);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@tipo", SqlDbType.VarChar, _tipoTarjeta);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@creditoDebito", SqlDbType.VarChar, _creditoDebito);
                cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
                cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {

                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return false;
                }
                else
                {
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return true;
                }
            }
        }

        public int verificarTarjeta(string accion)
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
                    sql = "verificarTarjeta";
                }
                ParamStruct[] parametros = new ParamStruct[7];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@numTarjeta", SqlDbType.VarChar, _numTarjeta);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@mes", SqlDbType.VarChar, _mes);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@anio", SqlDbType.VarChar, _anio);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@cvv", SqlDbType.VarChar, _cvv);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@tipoTarjeta", SqlDbType.VarChar, _tipoTarjeta);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@creditoDebito", SqlDbType.VarChar, _creditoDebito);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@monto", SqlDbType.Decimal, _monto);
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
                else if (mensaje_error == "Error al ejecutar la sentencia sql, informacion adicional: -5")
                {
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return -5;
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
