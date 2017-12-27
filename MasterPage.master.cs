using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var user = Context.User.Identity;

        if (user.IsAuthenticated)
        {

            litStatus.Text = Context.User.Identity.Name;

            login.Visible = false;
            register.Visible = false;

            logout.Visible = true;
            litStatus.Visible = true;

            Management.Visible = false;

            CosModel model = new CosModel();
            string userId = HttpContext.Current.User.Identity.GetUserId();
            litStatus.Text = string.Format("{0} ({1})", Context.User.Identity.Name +" / COS", model.getTotalItems(userId));

            if(Context.User.Identity.Name == "Admin")
            {
                Management.Visible = true;
                account.Visible = false;
            }
            else
            {
                Management.Visible = false;
                account.Visible = true;
            }

        }
        else
        {
            litStatus.Text = Context.User.Identity.Name;

            login.Visible = true;
            register.Visible = true;

            logout.Visible = false;
            litStatus.Visible = false;

            Management.Visible = false;
            account.Visible = true;

        }
    }

    protected void logout_Click(object sender, EventArgs e)
    {

        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        authenticationManager.SignOut();

        Response.Redirect("~/Pages/Produse.aspx/");

    }

}
