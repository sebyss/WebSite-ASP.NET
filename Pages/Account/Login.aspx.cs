using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

        userStore.Context.Database.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FarmacieConnectionString"].ConnectionString;

        UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

        var user = manager.Find(txtuser.Text, txtpass.Text);

        if(user != null)
        {
            var autenthicationManager = HttpContext.Current.GetOwinContext().Authentication;
            var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            autenthicationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = false
            },userIdentity);

            Response.Redirect("~/Pages/Produse.aspx/");
        }
        else
        {
            litStatus2.Text = "Nume Utilizator sau Parola Gresite !";
        }
    }
}