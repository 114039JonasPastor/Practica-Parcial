using OrdenesDeRetiroApp.Datos.Implementacion;
using OrdenesDeRetiroApp.Datos.Interfaz;
using OrdenesDeRetiroApp.Dominio;
using OrdenesDeRetiroApp.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesDeRetiroApp.Servicios.Implemetacion
{
    public class ServicioMaterial : IServicioMaterial
    {
        private IMaterialDao dao;
        public ServicioMaterial()
        {
            dao = new MaterialDao();
        }
        public List<Material> ObtenerMateriales()
        {
            return dao.ObtenerMateriales();
        }
    }
}
