using MF0493_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MF0493_3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var datos = EmpresaManager.getAll();


                this.GridView1.DataSource = datos;
                this.GridView1.DataBind();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow r = this.GridView1.Rows[e.NewEditIndex];
            string dato = r.Cells[0].Text;
            Session.Add("empresa", dato);
            Response.Redirect("edit.aspx");
        }
    }
}