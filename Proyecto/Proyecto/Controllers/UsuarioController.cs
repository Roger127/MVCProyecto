using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Controllers
{
    public class UsuarioController : Controller
    {

        public ActionResult Registrar()
        {
            Usuario obj = new Usuario();
            obj.Nombre= Convert.ToString(Request.Form["VNombre"]);
            obj.Apellido = Convert.ToString(Request.Form["VApellido"]);
            obj.Correo = Convert.ToString(Request.Form["VCorreo"]);
            obj.NombreUsuario = Convert.ToString(Request.Form["VNombreUsuario"]);
            obj.Contrasenia = Convert.ToString(Request.Form["VContrasenia"]);


            SqlConnection Conn;
            String OrderSql;
            Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Roger\\Documentos\\VisualStudio\\proyectoASP\\BD_proyecto_post.mdf;Integrated Security=True;Connect Timeout=30";

            try
            {
                Conn.Open();
                OrderSql = String.Format("INSERT INTO Usuarios(nombre, apellido, correo, nombreusuario, contrsenia) VALUES('{0}','{1}','{2}','{3}','{4}')", 
                    obj.Nombre, obj.Apellido, obj.Correo, obj.NombreUsuario, obj.Contrasenia);
                SqlCommand cmd = new SqlCommand(OrderSql, Conn);
                cmd.ExecuteNonQuery();

                Conn.Close();

            }
            catch (Exception ex1)
            {
               
            }


            return View(obj);
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }
    }
}