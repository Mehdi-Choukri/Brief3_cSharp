using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Brief3_cSharp
{
    public partial class ajouter : System.Web.UI.Page
    {
        string connection = "Data Source=DESKTOP-1A6447O;Initial Catalog=BriefCsharp;Integrated Security=True";
 
        public bool valider()
        {
            Regex rx_name = new Regex("^[a-zA-Z ]{3,}$");
            Regex rx_phone = new Regex("^[0][5-7][0-9]{8}$");
            Regex rx_mail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex rx_ADR = new Regex("^[a-zA-Z 0-9 -_ ]{10,}$");

            if ((rx_name.IsMatch(input_nom.Value)) && (rx_name.IsMatch(input_prenom.Value)) && (rx_phone.IsMatch(input_telephone.Value)) && (rx_mail.IsMatch(input_email.Value)) && (rx_ADR.IsMatch(input_adresse.Value)) )
            {
                 
                return true;
            }

            return false;
        }

        public void chargerPays(string pays)
        {
            cmbVille.Items.Clear();


            if (pays == "Maroc")
            {

                string[] ville = new string[] { "Rabat", "Eljadida", "Casablanca", "Tanger" };
                for (int i = 0; i < ville.Length; i++)
                {
                    cmbVille.Items.Add(ville[i]);
                }


            }
            else if (pays == "France")
            {

                string[] ville = new string[] { "Paris", "Lyon", "Marseille", "Nice" };
                for (int i = 0; i < ville.Length; i++)
                {
                    cmbVille.Items.Add(ville[i]);
                }

            }
            else
            {

                string[] ville = new string[] { "Washinton DC", "New York", "Chicago", "Miami" };
                for (int i = 0; i < ville.Length; i++)
                {
                    cmbVille.Items.Add(ville[i]);
                }

            }
            cmbVille.SelectedIndex = 0;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                cmbPays.Items.Add("Selectionner un pays");
                cmbPays.Items.Add("Maroc");
                cmbPays.Items.Add("France");
                cmbPays.Items.Add("USA");
                cmbPays.SelectedIndex = 0;

                cmbSpecialite.Items.Add("C#");
                cmbSpecialite.Items.Add("JEE");
                cmbSpecialite.Items.Add("Front-end & Back-end");

                cmbSpecialite.SelectedIndex = 0;
                success.Visible = false;
                fail.Visible = false;

            }

            

        }

        protected void cmbPays_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            chargerPays((cmbPays.Text));
  

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(valider())
            {
                SqlConnection cn = new SqlConnection(connection);
                cn.Open();

                string CorrectDateFormat = Calendar1.SelectedDate.Year + "-" + Calendar1.SelectedDate.Month + "-" + Calendar1.SelectedDate.Day;
               string req = "insert into apprenant (nom,prenom,email,telephone,adresse,pays,ville,choix,date_naissance) values ('" + input_nom.Value + "','" + input_prenom.Value + "','" + input_email.Value + "','" + input_telephone.Value + "','" + input_adresse.Value + "','" + cmbPays.Text + "','" + cmbVille.Text + "','" + cmbSpecialite.Text + "','" + CorrectDateFormat + "')";
                SqlCommand cmd = new SqlCommand(req, cn);

                if (cmd.ExecuteNonQuery().Equals(1))
                {

                    success.Visible = true;
                    fail.Visible = false;
                }
                else
                {
                    fail.Visible = true;
                }

                cn.Close();
            }
            else
            {
                fail.Visible = true;
                success.Visible = false;
            }
        }
    }
}