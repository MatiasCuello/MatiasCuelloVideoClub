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
    public partial class frmLocalidades : Form
    {
        private static frmLocalidades instancia = null;
        public static frmLocalidades GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new frmLocalidades();
                instancia.FormClosed += from_Closed;
            }
            return instancia;
        }

        private static void from_Closed(object sender, FormClosedEventArgs e)
        {
            instancia = null;
        }

        private frmLocalidades()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private List<Localidad> lista;
        private ServicioLocalidad servicio;

        private void frmLocalidades_Load(object sender, EventArgs e)
        {
            try
            {
                servicio = new ServicioLocalidad();
                lista = servicio.GetLocalidades();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var localidad in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, localidad);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Localidad localidad)
        {
            r.Cells[cmnLocalidad.Index].Value = localidad.NombreLocalidad;
            r.Cells[cmnProvincia.Index].Value = localidad.Provincia.NombreProvincia;
            r.Tag = localidad;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmLocalidadesAE frm = new frmLocalidadesAE();
            frm.Text = "Nueva Localidad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.OK)
            {
                try
                {
                    Localidad localidad = frm.GetLocalidad();
                    if (!servicio.Existe(localidad))
                    {
                        servicio.Agregar(localidad);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, localidad);
                        AgregarFila(r);
                        MessageBox.Show("Localidad agregada", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {

                        MessageBox.Show("Localidad duplicada\nAlta Denegada", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Localidad localidad = (Localidad)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea borrar de la lista a {localidad.NombreLocalidad}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (!servicio.EstaRelacionado(localidad))
                        {
                            servicio.Borrar(localidad);
                            dgvDatos.Rows.Remove(r);
                            MessageBox.Show("Localidad Borrada", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Localidad con registros asociados \nBaja Denegada", "Error",
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
            if (dgvDatos .SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Localidad localidad = (Localidad)r.Tag;
                
                frmLocalidadesAE frm = new frmLocalidadesAE();
                frm.Text = "Editar Localidad";
                frm.SetLocalidad(localidad);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        localidad = frm.GetLocalidad();

                        if (!servicio.Existe(localidad))
                        {
                            servicio.Agregar(localidad);
                            SetearFila(r, localidad);
                            MessageBox.Show("Localidad editada", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {


                            MessageBox.Show("Localidad Duplicado \nModificacion Denegada", "Error",
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
    }
}
