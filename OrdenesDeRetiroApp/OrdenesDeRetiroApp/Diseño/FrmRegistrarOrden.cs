using OrdenesDeRetiroApp.Dominio;
using OrdenesDeRetiroApp.Servicios.Implemetacion;
using OrdenesDeRetiroApp.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenesDeRetiroApp.Diseño
{
    public partial class FrmRegistrarOrden : Form
    {
        IServicioMaterial ServMaterial = null;
        IServicioOrden ServOrden = null;
        OrdenRetiro nueva;
        public FrmRegistrarOrden()
        {
            InitializeComponent();
            ServOrden = new ServicioOrden();
            ServMaterial = new ServicioMaterial();
            nueva = new OrdenRetiro();
        }

        private void FrmRegistrarOrden_Load(object sender, EventArgs e)
        {
            CargarDatos();
            cmbMaterial.SelectedIndex = -1;
            nudCantidad.Value = 0;
            txtResponsable.Text = String.Empty;
        }

        private void CargarDatos()
        {
            cmbMaterial.DataSource = ServMaterial.ObtenerMateriales();
            cmbMaterial.ValueMember = "codigo";
            cmbMaterial.DisplayMember = "nombre";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(cmbMaterial.SelectedIndex == -1)
            {
                MessageBox.Show("Debe de seleccionar un material", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(nudCantidad.Value == 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach(DataGridViewRow row in dgvOrden.Rows)
            {
                if (row.Cells["ColMaterial"].Value.ToString().Equals(cmbMaterial.Text))
                {
                    MessageBox.Show("Este material ya fue agregado","Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            Material m = (Material)cmbMaterial.SelectedItem;
            int cantidad = (int)nudCantidad.Value;
            DetalleOrden detalle = new DetalleOrden(cantidad, m);

            nueva.AgregarDetalle(detalle);

            dgvOrden.Rows.Add(new object[] {m.Codigo, m.Nombre, m.Stock, cantidad});
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Esta seguro de que quiere cancelar la operacion?","Cancelar",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int stock = 0;
            int cantidad = 0;
            foreach(DataGridViewRow row in dgvOrden.Rows)
            {
                stock = Convert.ToInt32(row.Cells["ColStock"].Value.ToString());
                cantidad = Convert.ToInt32(row.Cells["ColCantidad"].Value.ToString());
                if(stock < cantidad)
                {
                    MessageBox.Show("No hay suficiente stock para este material", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            if(dgvOrden.Rows.Count == 0)
            {
                MessageBox.Show("Debe de agregar al menos un detalle", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtResponsable.Text == String.Empty)
            {
                MessageBox.Show("Debe de ingresar Responsable", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            GrabarOrden();
        }

        private void GrabarOrden()
        {
            nueva.Fecha = dtpFecha.Value;
            nueva.Responsable = txtResponsable.Text;
            if (ServOrden.AltaOrden(nueva))
            {
                MessageBox.Show("Se ha podido registrar la orden ", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se ha podido registrar la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Limpiar()
        {
            txtResponsable.Text = String.Empty;
            cmbMaterial.SelectedIndex = -1;
            nudCantidad.Value = 0;
            dgvOrden.Rows.Clear();
            dtpFecha.Value = DateTime.Today;
        }

        private void dgvOrden_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvOrden.CurrentCell.ColumnIndex == 4)
            {
                nueva.QuitarDetalle(dgvOrden.CurrentRow.Index);
                dgvOrden.Rows.RemoveAt(dgvOrden.CurrentRow.Index);
            }
        }
    }
}
