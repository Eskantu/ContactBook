﻿using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Core.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IConnection _connection;
        public GenericRepository(IConnection connection)
        {
            _connection = connection;
            if (_connection.Connect() == false)
                throw new Exception("Error al conectar con servidor");
        }

        public string Error { get; private set; }

        public T Create(SpParametros parametros)
        {
            T entidad;
            try
            {
                using (IDataReader reader = _connection.ExecuteQuery(CrearComando(parametros)) as IDataReader)
                {
                    List<T> result = reader.Select(r => CrearEntidad(r, typeof(T))).ToList();
                    entidad = result[0];
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                entidad = null;
            }
            return entidad;
        }

        private T CrearEntidad(IDataReader data, Type tipoDato)
        {
            T entidad;
            PropertyInfo[] properties = tipoDato.GetProperties();
            entidad = (T)Activator.CreateInstance(tipoDato);
            properties.ToList().ForEach(property =>
            {
                property.SetValue(entidad, data[property.Name] == DBNull.Value ? null : data[property.Name]);
            });
            return entidad;
        }
        private Y CrearModelo<Y>(IDataReader data, Type tipoDato)
        {
            Y entidad;
            PropertyInfo[] properties = tipoDato.GetProperties();
            entidad = (Y)Activator.CreateInstance(tipoDato);
            properties.ToList().ForEach(property =>
            {
                property.SetValue(entidad, data[property.Name] == DBNull.Value ? null : data[property.Name]);
            });
            return entidad;
        }

        public bool Delete(SpParametros parametros)
        {
            bool result = false;
            try
            {
                result = _connection.ExecuteNoQuery(CrearComando(parametros)) > 0;
            }
            catch (Exception ex)
            {
                Error = ex.Message;

            }
            return result;
        }

        public bool Update(SpParametros parametros)
        {
            bool result = false;
            try
            {
                result = _connection.ExecuteNoQuery(CrearComando(parametros)) > 0;
            }
            catch (Exception ex)
            {
                Error = ex.Message;

            }
            return result;
        }

        private string CrearComando(SpParametros parametros)
        {
            string comando = $"{parametros.Nombre} ";
            parametros.Parametros.ForEach(item =>
            {
                comando += $"{item.Key}={item.Value},";
            });
            return comando.Substring(0, comando.Length - 1);
        }

        public List<T> Read(SpParametros parametros)
        {
            List<T> data;
            using (IDataReader reader = _connection.ExecuteQuery(CrearComando(parametros)) as IDataReader)
            {
                data = reader.Select(r => CrearEntidad(r, typeof(T))).ToList();
                reader.Close();
            }
            return data;
        }

        public List<Y> Query<Y>(SpParametros parametros)
        {
            List<Y> data;
            using (IDataReader reader = _connection.ExecuteQuery(CrearComando(parametros)) as IDataReader)
            {
                data = reader.Select(r => CrearModelo<Y>(r, typeof(Y))).ToList();
                reader.Close();
            }
            return data;
        }

        ~GenericRepository()
        {
            if (_connection.Disconnect() == false)
                throw new Exception("Error al desconectar con servidor");
        }
    }
}
