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
    public partial class frmProvincias : Form
    {
        public frmProvincias()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private ServicioProvincia servicio;
        private List<Provincia> lista;
        private void frmProvincias_Load(object sender, EventArgs e)
        {
            try
            {
                servicio = new ServicioProvincia();
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
            foreach (var provincia in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, provincia);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r); 
        }

        private void SetearFila(DataGridViewRow r, Provincia provincia)
        {
            r.Cells[cmnProvincia.Index].Value = provincia.NombreProvincia;
            r.Tag = provincia;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmProvinciasAE frm = new frmProvinciasAE();
            frm.Text = "Agregar Provincia";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Provincia provincia = frm.GetProvincia();
                    if (!servicio.Existe(provincia))
                    {
                        servicio.Agregar(provincia);
                        var r = ConstruirFila();
                        SetearFila(r, provincia);
                        AgregarFila(r);
                        MessageBox.Show("Provincia agregada", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Provincia duplicada... Alta denegada", "Error",
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
                Provincia provincia = (Provincia)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea borrar de la lista a {provincia.NombreProvincia}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (!servicio.EstaRelacionado(provincia))
                        {
                            servicio.Borrar(provincia);
                            dgvDatos.Rows.Remove(r);
                            MessageBox.Show("Provincia Borrada", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Provincia con registros asociados \nBaja Denegada", "Error",
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
                Provincia provincia = (Provincia)r.Tag;
                
                frmProvinciasAE frm = new frmProvinciasAE();
                frm.Text = "Editar Provincia";
                frm.SetProvincia(provincia);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        provincia = frm.GetProvincia();
                        if (!servicio.Existe(provincia))
                        {
                            servicio.Guardar(provincia);
                            SetearFila(r, provincia);
                            MessageBox.Show("Provincia Editada", "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Provincia Duplicado... Alta denegada", "Error",
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
