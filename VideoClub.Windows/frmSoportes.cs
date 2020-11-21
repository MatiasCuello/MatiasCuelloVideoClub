using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoClub.Entidades;
using VideoClub.Servicios;

namespace VideoClub.Windows
{
    public partial class frmSoportes : Form
    {
        public frmSoportes()
        {
            InitializeComponent();
        }
        
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private ServicioSoporte servicio;
        private List<Soporte> lista;

        private void frmSoportes_Load_1(object sender, EventArgs e)
        {
            try
            {
                servicio = new ServicioSoporte();
                lista = servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var soporte in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, soporte);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Soporte soporte)
        {
            r.Cells[cmnSoporte.Index].Value = soporte.Descripcion;
            r.Tag = soporte;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {

            frmSoportesAE frm = new frmSoportesAE();
            frm.Text = "Agregar Soporte";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Soporte soporte = frm.GetSoporte();
                    if (!servicio.Existe(soporte))
                    {
                        servicio.Agregar(soporte);
                        var r = ConstruirFila();
                        SetearFila(r, soporte);
                        AgregarFila(r);
                        MessageBox.Show("Soporte agregado", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Soporte duplicado... Alta denegada", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Soporte soporte = (Soporte)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea borrar de la lista a {soporte.Descripcion}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (!servicio.EstaRelacionado(soporte))
                        {
                            servicio.Borrar(soporte);
                            dgvDatos.Rows.Remove(r);
                            MessageBox.Show("Soporte Borrado", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Soporte con registros asociados \nBaja Denegada", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception exception)
                    {

                        MessageBox.Show(exception.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Soporte soporte = (Soporte)r.Tag;

                frmSoportesAE frm = new frmSoportesAE();
                frm.Text = "Editar Soporte";
                frm.SetSoporte(soporte);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        soporte = frm.GetSoporte();
                        if (!servicio.Existe(soporte))
                        {
                            servicio.Guardar(soporte);
                            SetearFila(r, soporte);
                            MessageBox.Show("Soporte Editado", "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Soporte Duplicado... Alta denegada", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Error",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);

                    }
                }
            }
        }
    }
}
