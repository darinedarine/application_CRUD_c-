using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Labo01
{
    public partial class frmGroupe : Form
    {
        public void list_groupe()
        {
            ClGroupe Spt = new ClGroupe();
            MySqlDataReader Rs;
            Rs = Spt.Lister();
            DataTable dt = new DataTable();
            dt.Load(Rs);
            List_Groupe.DataSource = dt;

        }

        public frmGroupe()
        {
            InitializeComponent();
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            string xCode, xGroupe;
            xCode = txt_Code.Text;
            xGroupe = txt_Groupe.Text;
            if (!string.IsNullOrEmpty(xCode) && xGroupe != "")
            {
                ClGroupe Spt = new ClGroupe();
                Spt.Ajouter(xCode, xGroupe);
                list_groupe();
            }
        }

        private void frmGroupe_Load(object sender, EventArgs e)
        {
            list_groupe();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            list_groupe();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String xCode;
            xCode = txt_Code.Text;

            ClGroupe Spt = new ClGroupe();
            MySqlDataReader Rs;
            Rs = Spt.Chercher(xCode);
            DataTable dt = new DataTable();
            dt.Load(Rs);
            List_Groupe.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String xCode;
            xCode = txt_Code.Text;

            ClGroupe Spt = new ClGroupe();
            Spt.Suppression(xCode);
            list_groupe();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string xCode, xSpecialite;
            xCode = txt_Code.Text;
            xSpecialite = txt_Groupe.Text;

            ClGroupe Spt = new ClGroupe();
            Spt.Modifier(xCode, xSpecialite);
            list_groupe();
        }
    }
}
