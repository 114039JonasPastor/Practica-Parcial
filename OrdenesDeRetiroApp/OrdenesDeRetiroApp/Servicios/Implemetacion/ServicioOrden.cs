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
    public class ServicioOrden : IServicioOrden
    {
        private IOrdenDao dao;
        public ServicioOrden()
        {
            dao = new OrdenDao();
        }

        public int AltaOrden(OrdenRetiro oOrden)
        {
            return dao.Alta(oOrden);
        }
    }
}
