using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesDeRetiroApp.Dominio
{
    public class OrdenRetiro
    {
        public int NroOrden
        {
            get; set;
        }
        public DateTime Fecha
        {
            get; set;
        }
        public string Responsable
        {
            get; set;
        }
        public List<DetalleOrden> ldetalle
        {
            get; set;
        }

        public OrdenRetiro()
        {
            ldetalle = new List<DetalleOrden>();
        }

        public override string ToString()
        {
            return "Numero de orden: " + NroOrden;
        }

        public void AgregarDetalle(DetalleOrden detalle)
        {
            ldetalle.Add(detalle);
        }
        public void QuitarDetalle(int nro)
        {
            ldetalle.RemoveAt(nro);
        }
    }
}
