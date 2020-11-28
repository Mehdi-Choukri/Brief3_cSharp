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
    public partial class supprimer : System.Web.UI.Page
    {
        public static string Connection = "Data Source=DESKTOP-1A6447O;Initial Catalog=BriefCsharp;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
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
                 
                cmbID.SelectedIndex = 0;
                for (int i = 0; i < dt_combo.Rows.Count; i++)
                {
                    cmbID.Items.Add(dt_combo.Rows[i][0].ToString());
                }


                cn.Close();
            }

        }

        protected void btn_supprimer_Click(object sender, EventArgs e)
        {
            try
            {




                SqlConnection cn = new SqlConnection(Connection);
                cn.Open();
                string req = "delete apprenant where id_apprenant=" + cmbID.Text;
                SqlCommand cmd = new SqlCommand(req, cn);

                if (cmd.ExecuteNonQuery().Equals(1))
                {

                    success.Visible = true;
                    fail.Visible = false;


                }
                else
                {
                    fail.Visible = true;
                    success.Visible = false;
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }

    }
    }
