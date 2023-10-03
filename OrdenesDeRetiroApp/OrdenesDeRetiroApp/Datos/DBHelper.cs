using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesDeRetiroApp.Datos
{
    public class DBHelper
    {
        private static DBHelper instancia;
        private SqlConnection conexion;

        public DBHelper()
        {
            conexion = new SqlConnection("Data Source=DESKTOP-35MIDJI\\SQLEXPRESS;Initial Catalog=db_ordenes;Integrated Security=True");
        }
        
        public static DBHelper ObtenerInstancia()
        {
            if(instancia == null)
            {
                instancia = new DBHelper();
            }
            return instancia;
        }
        
        public SqlConnection ObtenerConexion()
        {
            return this.conexion;
        }

        public DataTable Consultar(string NombreSP)
        {
            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = NombreSP;

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());

            conexion.Close();
            return tabla;
        }

        public DataTable ConsultarConParametros(string NombreSP, List<Parametro> parametros)
        {
            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = NombreSP;
            
            comando.Parameters.Clear();
            foreach(Parametro p in parametros)
            {
                comando.Parameters.Add(p.Nombre, p.Valor);
            }

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());

            conexion.Close();
            return tabla;
        }
    }

}
