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
    public partial class frmLocalidadesAE : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ServicioProvincia servicioProvincia = new ServicioProvincia();
            var listaProvincia = servicioProvincia.GetLista();
            var defultProvincia = new Provincia
            {
                ProvinciaId = 0,
                NombreProvincia = "<Seleccionar Provincia>"
            };
            listaProvincia.Insert(0, defultProvincia);
            ProvinciaComboBox.DataSource = listaProvincia;
            ProvinciaComboBox.DisplayMember = "NombreProvincia";
            ProvinciaComboBox.ValueMember = "ProvinciaId";
            ProvinciaComboBox.SelectedIndex = 0;
            if (localidad!=null)
            {
                LocalidadTextBox.Text = localidad.NombreLocalidad;
                ProvinciaComboBox.SelectedValue = localidad.Provincia.ProvinciaId;
            }

        }
        private Localidad localidad;

        public frmLocalidadesAE()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (localidad==null)
                {
                    localidad = new Localidad();
                }
                localidad.NombreLocalidad = LocalidadTextBox.Text;
                localidad.Provincia = (Provincia)ProvinciaComboBox.SelectedItem;
                DialogResult = DialogResult.OK; 

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(LocalidadTextBox.Text) && string.IsNullOrWhiteSpace(LocalidadTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(LocalidadTextBox, "Ingrese el nombre de la localidad");
            }
            if (ProvinciaComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(ProvinciaComboBox, "Seleccione una provincia");
            }
            return valido;
        }

        public Localidad GetLocalidad()
        {
            return localidad;
        }

        public void SetLocalidad(Localidad localidad)
        {
            this.localidad = localidad;
        }

        private void frmLocalidadesAE_Load(object sender, EventArgs e)
        {

        }
    }
}
