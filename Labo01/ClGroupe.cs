using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Labo01
{
    internal class ClGroupe
    {
        MySqlConnection cns = new MySqlConnection("server=localhost;uid=root;database=visuel");

        public void Ajouter(string Code, string Groupe)
        {
            try
            {
                string Query = "INSERT INTO tblgroupe VALUES('" + Code + "','" + Groupe + "')";
                cns.Open();
                MySqlCommand cmd = cns.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Query;
                cmd.ExecuteNonQuery();
                cns.Close();
                MessageBox.Show("Enregistrer");
            }
            catch
            {
                MessageBox.Show("Erreur de connexion");
            }

        }


        public MySqlDataReader Lister()
        {
            try
            {
                string Query = "SELECT * FROM tblgroupe";
                MySqlCommand cmd = new MySqlCommand(Query);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cns;
                cns.Open();
                MySqlDataReader Rs = cmd.ExecuteReader();
                return Rs;

            }
            catch
            {
                MessageBox.Show("Opération non effectuée!", "Lister", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }
        public MySqlDataReader Chercher(string Code)
        {
            try
            {
                string Query = "SELECT * FROM tblgroupe where code='" + Code + "'";
                MySqlCommand cmd = new MySqlCommand(Query);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cns;
                cns.Open();
                MySqlDataReader Rs = cmd.ExecuteReader();
                return Rs;
            }
            catch
            {
                MessageBox.Show("Opération non effectuée!", "Consulter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        public void Modifier(string Code, string Groupe)
        {
            try
            {
                string Query = "UPDATE tblgroupe SET groupe='" + Groupe + "' where code='" + Code + "'";
                MySqlCommand cmd = new MySqlCommand(Query);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cns;
                cns.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Opération non effectuée!", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void Suppression(string Code)
        {
            try
            {
                string Query = "DELETE FROM tblgroupe where code='" + Code + "'";
                MySqlCommand cmd = new MySqlCommand(Query);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cns;
                cns.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Opération non effectuée!", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
