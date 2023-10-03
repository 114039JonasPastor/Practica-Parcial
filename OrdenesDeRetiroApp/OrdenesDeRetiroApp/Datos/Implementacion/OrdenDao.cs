using OrdenesDeRetiroApp.Datos.Interfaz;
using OrdenesDeRetiroApp.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesDeRetiroApp.Datos.Implementacion
{
    public class OrdenDao : IOrdenDao
    {
        private SqlConnection conexion;
        public bool Alta(OrdenRetiro oOrden)
        {
            bool resultado = true;
            SqlTransaction t = null;
            conexion = DBHelper.ObtenerInstancia().ObtenerConexion();

            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();

                SqlCommand comandoMaestro = new SqlCommand("SP_INSERTAR_ORDEN", conexion, t);
                comandoMaestro.CommandType = CommandType.StoredProcedure;
                comandoMaestro.Parameters.AddWithValue("@responsable", oOrden.Responsable);

                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@nro";
                parametro.DbType = DbType.Int32;
                parametro.Direction = ParameterDirection.Output;

                comandoMaestro.Parameters.Add(parametro);

                comandoMaestro.ExecuteNonQuery();

                int nroOrden = Convert.ToInt32(parametro.Value);

                SqlCommand comandoDetalle;
                int NumeroDetalle = 1;
                foreach (DetalleOrden DO in oOrden.ldetalle)
                {
                    comandoDetalle = new SqlCommand("SP_INSERTAR_DETALLES", conexion, t);
                    comandoDetalle.CommandType = CommandType.StoredProcedure;
                    comandoDetalle.Parameters.AddWithValue("@nro_orden", nroOrden);
                    comandoDetalle.Parameters.AddWithValue("@detalle", NumeroDetalle);
                    comandoDetalle.Parameters.AddWithValue("@codigo", DO.Material.Codigo);
                    comandoDetalle.Parameters.AddWithValue("cantidad", DO.Cantidad);

                    comandoDetalle.ExecuteNonQuery();
                    NumeroDetalle++;
                }
                t.Commit();
            }
            catch
            {
                if (t != null)
                {
                    t.Rollback();
                    resultado = false;
                }
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resultado;
        }

        public bool Baja(int nro)
        {
            throw new NotImplementedException();
        }
    }
}
