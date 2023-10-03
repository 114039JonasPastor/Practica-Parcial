using OrdenesDeRetiroApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesDeRetiroApp.Servicios.Interfaz
{
    public interface IServicioOrden
    {
        bool AltaOrden(OrdenRetiro oOrden);

    }
}
