using DatosConexion.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace DatosConexion.Accesos
{
    public class UsuariosDA
    {
        readonly string cadena = "Server=localhost; Port=3306; Database=programacionejercicio; Uid=root; Pwd=Paola_2001_20;";


        MySqlConnection conn;
        MySqlCommand cmd;

        public Usuarios Login(string codigo, string clave)
        {
            Usuarios user = null;

            try
            {
                string sql = "SELECT * FROM usuarios WHERE Codigo = @Codigo AND Clave = @Clave;";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Clave", clave);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = new Usuarios();
                    user.Codigo = reader[0].ToString();
                    user.Nombre = reader[1].ToString();
                    user.Edad = reader[2].ToString();
                    user.Rol = reader[3].ToString();
                    user.Profesion = reader[4].ToString();
                    user.Estado = Convert.ToBoolean(reader[5]);
                    user.Clave = reader[6].ToString();


                }
                reader.Close();
                conn.Close();



            }
            catch (Exception ex)
            {

            }
            return user;

        }

        public DataTable ListarUsuarios()
        {
            DataTable listaUsuariosDT = new DataTable();

            try
            {
                string sql = "SELECT * FROM usuarios;";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                listaUsuariosDT.Load(reader);
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
            }
            return listaUsuariosDT;
        }

        public bool InsertarUsuarios(Usuarios usuario)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO usuarios VALUES (@Codigo, @Nombre, @Edad, @Rol, @Profesion, @Estado, @Clave);";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Codigo", usuario.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Edad", usuario.Edad);
                cmd.Parameters.AddWithValue("@Rol", usuario.Rol);
                cmd.Parameters.AddWithValue("@Profesion", usuario.Profesion);
                cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                
                cmd.ExecuteNonQuery();
                inserto = true;

                conn.Close();
            }
            catch (Exception)
            {
            }
            return inserto;
        }

        public bool ModificarUsuario(Usuarios usuario)
        {
            bool modifico = false;
            try
            {
                string sql = "UPDATE usuario SET Codigo = @Codigo, Nombre = @Nombre, Edad = @Edad, Rol = @Rol, Profesion = @Profesion, Estado = @Estado, Clave = @Clave WHERE Codigo = @Codigo;";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Codigo", usuario.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Edad", usuario.Edad);
                cmd.Parameters.AddWithValue("@Rol", usuario.Rol);
                cmd.Parameters.AddWithValue("@Profesion", usuario.Profesion);
                cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);

                cmd.ExecuteNonQuery();
                modifico = true;
                conn.Close();
            }
            catch (Exception)
            {
            }
            return modifico;
        }

        public bool EliminarUsuario(string codigo)
        {
            bool elimino = false;
            try
            {
                string sql = "DELETE FROM usuarios WHERE Codigo = @Codigo;";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Codigo", codigo);

                cmd.ExecuteNonQuery();
                elimino = true;
                conn.Close();
            }
            catch (Exception)
            {
            }
            return elimino;
        }
    }
}
