using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Org.BouncyCastle.Utilities;



namespace Labo01
{
    internal class ClLogin
    {

        MySqlConnection cns = new MySqlConnection("server=localhost;uid=root;database=visuel");

        public void Ajouter(string NomComplet, string Username, string Password, string DateNaissance, string Sexe, string Mobile, string Email, string Niveau, string Specialite)
        {
            try
            {
                string Query = "INSERT INTO tbllogin (nomcomplet,login,Password,datenaissance,sexe,mobile,email,niveau,specialite) VALUES ('" + NomComplet + "','" + Username + "','" + Password + "','" + DateNaissance+ "','" + Sexe + "','" + Mobile + "','" + Email + "','" + Niveau + "','" + Specialite + "')";
                MySqlCommand cmd = new MySqlCommand(Query);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cns;
                cns.Open();

             

                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Opération non effectuée!", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Modifier(string Login, string Pwd)
        {
            try
            {
                string Query = "UPDATE tbllogin SET login='" + Login + "' where Password='" + Pwd + "'";
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

        public void Suppression(string Id)
        {
            try
            {
                string Query = "DELETE FROM tbllogin where Id='" + Id + "'";
                MySqlCommand cmd = new MySqlCommand(Query);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cns;
                cns.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Opération non effectuée!", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public MySqlDataReader Consulter()
        {
            try
            {
                string Query = "SELECT * FROM tbllogin ORDER BY login";
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

        public MySqlDataReader Lister()
        {
            try
            {
                string Query = "SELECT * FROM tbllogin";
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

        public MySqlDataReader Chercher(string Login)
        {
            try
            {
                string Query = "SELECT * FROM tbllogin where login like '%" + Login + "%'";
                MySqlCommand cmd = new MySqlCommand(Query);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cns;
                cns.Open();
                MySqlDataReader Rs = cmd.ExecuteReader();
                return Rs;
            }
            catch
            {
                MessageBox.Show("Opération non effectuée!", "Chercher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        public bool Authentification(string Login, string Pwd)
        {
            try
            {
                bool Result = false;
                string Query = "SELECT * FROM tbllogin WHERE login='" + Login + "' AND Password='" + Pwd + "'";
                MySqlCommand cmd = new MySqlCommand(Query);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cns;
                cns.Open();
                MySqlDataReader Rs = cmd.ExecuteReader();
                if (Rs.HasRows) Result = true;
                cns.Close();
                return Result;
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Authentification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;   
            }
        }
    }
}
