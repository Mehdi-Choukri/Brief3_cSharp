using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Brief3_cSharp
{
    public partial class Lister : System.Web.UI.Page
    {
        public static string connection = "Data Source=DESKTOP-1A6447O;Initial Catalog=BriefCsharp;Integrated Security=True";


        public void ChargeDGV(string choix)
        {
            string req;
            if (choix != "Tous les specialitées")
            {

                req = "select * from apprenant where choix = '" + choix + "'";

            }
            else
            {
                req = "select * from apprenant ";
            }
            SqlConnection cn = new SqlConnection(connection);
            cn.Open();
            SqlCommand cmd = new SqlCommand(req, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            cn.Close();

            label_nbr.Text = dt.Rows.Count.ToString();
        }
        public void remplir_grille()
        {
            SqlConnection cn = new SqlConnection(connection);
            string req = "select * from apprenant";
            cn.Open();
            SqlCommand cmd = new SqlCommand(req, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            cn.Close();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
               

                remplir_grille();
                 
                SqlConnection cn = new SqlConnection(connection);
                cn.Open();
                string req_combo = "select DISTINCT choix from apprenant";
                SqlCommand cmd_combo = new SqlCommand(req_combo, cn);
                SqlDataReader dr_combo = cmd_combo.ExecuteReader();
                DataTable dt_combo = new DataTable();
                dt_combo.Load(dr_combo);
                cmbSpecialite.Items.Add("Tous les specialitées");
                cmbSpecialite.SelectedIndex = 0;
                for (int i = 0; i < dt_combo.Rows.Count; i++)
                {
                    cmbSpecialite.Items.Add(dt_combo.Rows[i][0].ToString());
                }


                cn.Close();


            }
        }

        protected void cmbSpecialite_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargeDGV(cmbSpecialite.Text);
        }
    }
}