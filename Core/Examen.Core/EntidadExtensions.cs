using ContactBook.Core.COMMON.Enumeraciones;
using ContactBook.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ContactBook.Core
{
    public static class EntidadExtensions
    {
        public static SpParametros CrearParametros<T>(this T entidad, Accion accion)
        {
            Type type = typeof(T);
            string sp = $"Sp{type.Name}";
            List<PropertyInfo> properties = type.GetProperties().ToList();
            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@Opcion", accion == Accion.Crear ? 1 : 2));
            foreach (PropertyInfo item in properties)
            {
                parametros.Add(new KeyValuePair<string, object>($"@{item.Name}", item.GetValue(entidad)));
            }
            return new SpParametros(sp, parametros);
        }
    }
}
