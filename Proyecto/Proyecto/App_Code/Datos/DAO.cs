using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAO
/// </summary>
public class DAO
{

    //funcion login
    public DataTable login1(E_login log)
    {
        DataTable validacion = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuarios.f_usuarios", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_usuario", NpgsqlDbType.Text).Value = log.User;
            dataAdapter.SelectCommand.Parameters.Add("_clave", NpgsqlDbType.Text).Value = log.Clave;

            conection.Open();
            dataAdapter.Fill(validacion);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return validacion;
    }
    // funcion para insertar los datos del registro del usario
    public DataTable Insertar_usuario(E_registro_login registro)
    {
        DataTable insertar = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuarios.f_insert_login", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_nombre_usuario", NpgsqlDbType.Text).Value = registro.Nombre;
            dataAdapter.SelectCommand.Parameters.Add("_apellido_usuario", NpgsqlDbType.Text).Value = registro.Apellido;
            dataAdapter.SelectCommand.Parameters.Add("_user_name", NpgsqlDbType.Text).Value = registro.Username;
            dataAdapter.SelectCommand.Parameters.Add("_contrasena", NpgsqlDbType.Text).Value = registro.Contrasena;
            dataAdapter.SelectCommand.Parameters.Add("_correo_usuario", NpgsqlDbType.Text).Value = registro.Correo;
            dataAdapter.SelectCommand.Parameters.Add("_id_rol", NpgsqlDbType.Integer).Value =registro.Rol;
            conection.Open();
            dataAdapter.Fill(insertar);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return insertar;
    }
    
}