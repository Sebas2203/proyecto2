using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reparacionweb.classes
{
    public class InicioSesion
    {
        //atributos
        private static int id;
        private static string Clave;
        private static string Correo;
        private static string Nombre;

        //constructor para inicializar las variavles
        public InicioSesion(string clave, string correo, string nombre)
        {
            Clave = clave;
            Correo = correo;
            Nombre = nombre;
        }
        
        //getter = mostrar los atributos (funcion -return)
        //setter = asignar valores a los atributos (procedimientos -void)

        //get - set clave
        public static string GetClave()
        {
            return Clave;
        }
        public static void SetClave(string clave)
        {
            Clave = clave;
        }

        //get - set correo 
        public static string GetCorreo()
        {
            return Correo;
        }
        public static void SetCorreo(string correo)
        {
            Correo = correo;
        }

        //get - set nombre
        public static string GetNombre()
        {
            return Nombre;
        }
        public static void SetNombre(string nombre)
        {
            Nombre = nombre;
        }
    }
}