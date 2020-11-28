using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Brief3_cSharp
{
    public partial class modifier : System.Web.UI.Page
    {
        public static string Connection = "Data Source=DESKTOP-1A6447O;Initial Catalog=BriefCsharp;Integrated Security=True";

        public bool valider()
        {
            Regex rx_name = new Regex("^[a-zA-Z ]{3,}$");
            Regex rx_phone = new Regex("^[0][5-7][0-9]{8}$");
            Regex rx_mail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex rx_ADR = new Regex("^[a-zA-Z 0-9 -_ ]{10,}$");

            if ((rx_name.IsMatch(input_nom.Value)) && (rx_name.IsMatch(input_prenom.Value)) && (rx_phone.IsMatch(input_telephone.Value)) && (rx_mail.IsMatch(input_email.Value)) && (rx_ADR.IsMatch(input_adresse.Value)))
            {

                return true;
            }

            return false;
        }
        public void chargerDonnée(string id)
        {
            if(id != "Selectionner un identifiant")
            {

             
            SqlConnection cn = new SqlConnection(Connection);
            cn.Open();
            string req = "select * from apprenant where id_apprenant="+id;
            SqlCommand cmd = new SqlCommand(req, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            input_nom.Value = dt.Rows[0][1].ToString();
            input_prenom.Value = dt.Rows[0][2].ToString();
            input_email.Value = dt.Rows[0][3].ToString();
            input_telephone.Value = dt.Rows[0][4].ToString();
            input_adresse.Value = dt.Rows[0][5].ToString();
            cmbPays.Text = dt.Rows[0][6].ToString();
            cmbVille.Text = dt.Rows[0][7].ToString();
            cmbSpecialite.Text = dt.Rows[0][8].ToString();
            string dbDate = dt.Rows[0][9].ToString();
            string jour = dbDate.Substring(0, 2);
            string mois = dbDate.Substring(3, 2);
            string annee = dbDate.Substring(6, 4);
 
            Calendar1.TodaysDate = new DateTime(int.Parse(annee), int.Parse(mois), int.Parse(jour));


            }


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
            if (!Page.IsPostBack)
            {
                success.Visible = false;
                fail.Visible = false;
                SqlConnection cn = new SqlConnection(Connection);
                cn.Open();
                string req_combo = "select DISTINCT id_apprenant from apprenant";
                SqlCommand cmd_combo = new SqlCommand(req_combo, cn);
                SqlDataReader dr_combo = cmd_combo.ExecuteReader();
                DataTable dt_combo = new DataTable();
                dt_combo.Load(dr_combo);
                cmbID.Items.Add("Selectionner un identifiant");
                 cmbID.SelectedIndex = 0;
                for (int i = 0; i < dt_combo.Rows.Count; i++)
                {
                    cmbID.Items.Add(dt_combo.Rows[i][0].ToString());
                }

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


                cn.Close();
            }

        }

        protected void cmbPays_SelectedIndexChanged(object sender, EventArgs e)
        {
            chargerPays((cmbPays.Text));

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (valider())
            {
                SqlConnection cn = new SqlConnection(Connection);
                cn.Open();

                string CorrectDateFormat = Calendar1.SelectedDate.Year + "-" + Calendar1.SelectedDate.Month + "-" + Calendar1.SelectedDate.Day;
                string req = "update apprenant set nom='" + input_nom.Value + "' , prenom='" + input_prenom.Value + "' ,email= '" + input_email.Value + "',telephone='" + input_telephone.Value + "',adresse='" + input_adresse.Value + "',pays='" + cmbPays.Text + "',ville='" + cmbVille.Text + "',choix='" + cmbSpecialite.Text + "',date_naissance='" + CorrectDateFormat + "' where id_apprenant=" + cmbID.Text;
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

        protected void cmbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            chargerDonnée(cmbID.Text);
        }
    }
}