using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button_Click(object sender, EventArgs e)
    {
        UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

        userStore.Context.Database.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FarmacieConnectionString"].ConnectionString;

        UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

        IdentityUser user = new IdentityUser();

        user.UserName = usertxt.Text;

        if(pwtxt.Text == confirmtxt.Text)
        {
            try
            {
                IdentityResult result = manager.Create(user, pwtxt.Text);

                if (result.Succeeded)
                {

                    UserInfo info = new UserInfo
                    {
                        Adresa = txtAdresa.Text,
                        Nume = txtNume.Text,
                        Prenume = txtPrenume.Text,
                        CodPostal = Convert.ToInt32(txtCodPostal.Text),
                        UID = user.Id
                    };

                    UserInfoModel model = new UserInfoModel();
                    model.InsertUserInfo(info);

                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                    Response.Redirect("~/Pages/Produse.aspx/");
                }
                else
                {
                    litStatus.Text = result.Errors.FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                litStatus.Text = ex.ToString();
            }
        }
        else
        {
            litStatus.Text = "Ati introdus doua parole diferite!";
        }



    }

  
}