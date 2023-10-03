using OrdenesDeRetiroApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesDeRetiroApp.Datos.Interfaz
{
    public interface IMaterialDao
    {
        List<Material> ObtenerMateriales();
    }
}
