using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoClub.Windows
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void archivosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tspProvincias_Click(object sender, EventArgs e)
        {
            frmProvincias frm = new frmProvincias();
            frm.ShowDialog(this);
        }

        private void tspLocalidades_Click(object sender, EventArgs e)
        {
           
            frmLocalidades frm = frmLocalidades.GetInstancia();
            
            frm.Show();
        }

        private void tspSoportes_Click(object sender, EventArgs e)
        {
            frmSoportes frm = new frmSoportes();
            frm.ShowDialog(this);
        }

        private void tspEstados_Click(object sender, EventArgs e)
        {
            frmEstados frm = new frmEstados();
            frm.ShowDialog(this);
        }
    }
}
