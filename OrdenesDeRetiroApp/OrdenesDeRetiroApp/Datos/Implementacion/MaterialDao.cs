using OrdenesDeRetiroApp.Datos.Interfaz;
using OrdenesDeRetiroApp.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesDeRetiroApp.Datos.Implementacion
{
    public class MaterialDao : IMaterialDao
    {
        public List<Material> ObtenerMateriales()
        {
            List<Material> lista = new List<Material>();
            DataTable tabla = DBHelper.ObtenerInstancia().Consultar("SP_CONSULTAR_MATERIALES");

            Material auxiliar = null;

            foreach(DataRow row in tabla.Rows)
            {
                int Codigo = (int)row["codigo"];
                string Nombre = row["nombre"].ToString();
                double Stock = Convert.ToDouble(row["stock"].ToString());

                auxiliar = new Material(Codigo, Nombre, Stock);

                lista.Add(auxiliar);
            }
            return lista;
        }
    }
}
