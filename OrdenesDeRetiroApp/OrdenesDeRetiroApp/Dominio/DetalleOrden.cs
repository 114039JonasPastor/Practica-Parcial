using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesDeRetiroApp.Dominio
{
    public class DetalleOrden
    {
        public int Cantidad
        {
            get; set;
        }
        public Material Material
        {
            get; set;
        }

        public DetalleOrden(int cantidad, Material material)
        {
            this.Cantidad = cantidad;
            this.Material = material;
        }

        public override string ToString()
        {
            return "Cantidad: " + Cantidad + " - Material: " + Material.ToString();
        }
    }
}
