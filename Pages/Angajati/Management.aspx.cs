using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Angajati_Management : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ListProd_RowEditing(object sender, GridViewEditEventArgs e)
    {
       GridViewRow tab = listProd.Rows[e.NewEditIndex];

        int tabId = Convert.ToInt32(tab.Cells[1].Text);

        Response.Redirect("~/Pages/Angajati/AddProdus.aspx?id=" + tabId);
            
    }

    protected void listProd_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}