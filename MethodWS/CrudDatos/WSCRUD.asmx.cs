using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;

namespace MethodWS.CrudDatos
{
    /// <summary>
    /// Descripción breve de WSCRUD
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSCRUD : System.Web.Services.WebService
    {

        [WebMethod]
        public string Entrada(int Matricula)
        {


            try
            {
                string timeIn = DateTime.Now.ToString("HH:mm:ss");
                string timeout = DateTime.Now.ToString("HH:mm:ss"); // Puedes modificar esto según tus necesidades
                string datein = DateTime.Now.ToString("yyyy-MM-dd");


                string sql;
                SqlCommand mysmd = new SqlCommand();
                SqlDataReader reader;
                SqlConnection conexion = new SqlConnection("Data Source=MANUEL_AG; Initial Catalog=Servicio; User ID=sa;Password=aaa;Encrypt=False");
                conexion.Open();
                sql = "INSERT INTO [dbo].[ServiceData]([Matricula],[TimeIn],[TimeOut],[Date]) VALUES(" + Matricula + ",'" + timeIn + "','" + timeout + "','" + datein + "')";
                mysmd.CommandText = sql;
                mysmd.Connection = conexion;
                reader = mysmd.ExecuteReader();
                conexion.Close();
                return "Hora de entrada iniciada";

            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }
        }
        [WebMethod]
        public string Salida(int Matricula)
        {

            try
            {
                string timeIn = DateTime.Now.ToString("HH:mm:ss");
                string timeout = DateTime.Now.ToString("HH:mm:ss"); // Puedes modificar esto según tus necesidades
                string datein = DateTime.Now.ToString("yyyy-MM-dd");


                string sql;
                SqlCommand mysmd = new SqlCommand();
                SqlDataReader reader;
                SqlConnection conexion = new SqlConnection("Data Source=MANUEL_AG; Initial Catalog=Servicio; User ID=sa;Password=aaa;Encrypt=False");
                conexion.Open();
                sql = "UPDATE [dbo].[ServiceData] SET [TimeOut] = '" + timeout + "' WHERE [Matricula] = " + Matricula + " AND [Date] = '" + datein + "' AND [TimeOut] = [TimeIn] ";
                mysmd.CommandText = sql;
                mysmd.Connection = conexion;
                reader = mysmd.ExecuteReader();
                conexion.Close();
                return "Hora de salida Registrada";

            }
            catch (Exception ex)
            {
                return (ex.ToString());

            }
        }
        [WebMethod]

        public string registar(int matricula, string nombre, string apaterno, string amaterno, int carrera, int cuatri, string finicio, string ffin)
        {
            try
            {


                string sql;
                SqlCommand mysmd = new SqlCommand();
                SqlDataReader reader;
                SqlConnection conexion = new SqlConnection("Data Source=MANUEL_AG; Initial Catalog=Servicio; User ID=sa;Password=aaa;Encrypt=False");
                conexion.Open();
                sql = "INSERT INTO[dbo].[StudentData]([Matricula], [Name], [PLastName], [MLastName], [IdCarrera], [Cuatrimestre], [FechaInicio], [FechaFin]) VALUES(" + matricula + ",'" + nombre + "','" + apaterno + "','" + amaterno + "'," + carrera + "," + cuatri + ",'" + finicio + "','" + ffin + "')";
                mysmd.CommandText = sql;
                mysmd.Connection = conexion;
                reader = mysmd.ExecuteReader();
                conexion.Close();
                return "Alumno registrado Registrada";


            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }

        }
        [WebMethod]
        public string updatesql(string nombre, string apaterno, string amaterno, int carrera, int cuatri, string finicio, string ffin, int matricula)
        {
            try
            {
                string sql;
                SqlCommand mysmd = new SqlCommand();
                SqlDataReader reader;
                SqlConnection conexion = new SqlConnection("Data Source=MANUEL_AG; Initial Catalog=Servicio; User ID=sa;Password=aaa;Encrypt=False");
                conexion.Open();
                sql = "UPDATE [dbo].[StudentData] SET [Name] = '" + nombre + "', [PLastName] = '" + apaterno + "', [MLastName] ='" + amaterno + "', [IdCarrera] = " + carrera + ", [Cuatrimestre] = " + cuatri + ", [FechaInicio] = '" + finicio + "', [FechaFin] = '" + ffin + "' WHERE [Matricula] =" + matricula;
                mysmd.Connection = conexion;
                reader = mysmd.ExecuteReader();
                conexion.Close();
                return "Datos del Alumno modificados ";
              
            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }
        }
        [WebMethod]
        public string Deletedatos(int matricula)
        {
            try
            {
                string sql;
                SqlCommand mysmd = new SqlCommand();
                SqlDataReader reader;
                SqlConnection conexion = new SqlConnection("Data Source=MANUEL_AG; Initial Catalog=Servicio; User ID=sa;Password=aaa;Encrypt=False");
                conexion.Open();
                sql = "DELETE FROM [dbo].[StudentData] WHERE [Matricula] = " + matricula; 
                reader = mysmd.ExecuteReader();
                conexion.Close();
                return "Datos del Alumno modificados ";

            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }
        }
    }
}