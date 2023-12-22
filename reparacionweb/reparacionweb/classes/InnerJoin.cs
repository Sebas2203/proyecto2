using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reparacionweb.classes
{
    public class InnerJoin
    {
        // atributos
        private static int Id;
        private static string Correo;
        private static string Clave;
        private static string Nombre;
        public static int rol;
        public static string nombrerol;


        public int GetId()
        {
            return Id;
        }

        public static string GetCorreo()
        {
            return Correo;
        }

        public static string GetNombre()
        {
            return Nombre;
        }

        public void SetID(int id)
        {
            Id = id;
        }

        public void SetNombre(string nombre)
        {
            Nombre = nombre;
        }

        public void SetClave(string clave)
        {
            Clave = clave;
        }

        public void SetCorreo(string correo)
        {
            Correo = correo;
        }
    }
}