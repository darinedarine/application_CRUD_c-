using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labo01
{
    public partial class MenuPrincipale : Form
    {
        public MenuPrincipale()
        {
            InitializeComponent();
        }

        private void bt_Specialite_Click(object sender, EventArgs e)
        {
            frmSpecialite spec = new frmSpecialite();
            spec.Show();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void bt_Etudiant_Click(object sender, EventArgs e)
        {
            GestionEtudiant etudiant = new GestionEtudiant();
            etudiant.Show();
        }

        private void bt_Groupe_Click(object sender, EventArgs e)
        {

        }

        private void bt_Groupe_Click_1(object sender, EventArgs e)
        {
            frmGroupe gr = new frmGroupe();
            gr.Show();
        }
    }
}
