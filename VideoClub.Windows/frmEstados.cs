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
    public partial class frmEstados : Form
    {
        public frmEstados()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private ServicioEstado servicio;
        private List<Estado> lista;
        private void frmEstados_Load(object sender, EventArgs e)
        {
            try
            {
                servicio = new ServicioEstado();
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
            foreach (var estado in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, estado);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Estado estado)
        {
            r.Cells[cmnEstado.Index].Value = estado.Descripcion;
            r.Tag = estado;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmEstadoAE frm = new frmEstadoAE();
            frm.Text = "Agregar Estado";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Estado estado = frm.GetEstado();
                    if (!servicio.Existe(estado))
                    {
                        servicio.Agregar(estado);
                        var r = ConstruirFila();
                        SetearFila(r, estado);
                        AgregarFila(r);
                        MessageBox.Show("Estado agregado", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Estado duplicado... Alta denegada", "Error",
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
                Estado estado = (Estado)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea borrar de la lista a {estado.Descripcion}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (!servicio.EstaRelacionado(estado))
                        {
                            servicio.Borrar(estado);
                            dgvDatos.Rows.Remove(r);
                            MessageBox.Show("Estado Borrado", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Estado con registros asociados \nBaja Denegada", "Error",
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
                Estado estado = (Estado)r.Tag;

                frmEstadoAE frm = new frmEstadoAE();
                frm.Text = "Editar Estado";
                frm.SetEstado(estado);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        estado = frm.GetEstado();
                        if (!servicio.Existe(estado))
                        {
                            servicio.Guardar(estado);
                            SetearFila(r, estado);
                            MessageBox.Show("Estado Editado", "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Estado Duplicado... Alta denegada", "Error",
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
