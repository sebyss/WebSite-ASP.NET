using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Success : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Co> cos = (List<Co>)Session[User.Identity.GetUserId()];

        CosModel model = new CosModel();
          try
            {
              model.comandaPlatita(cos);
              eroare.Text = "Success! Comanda dvs. va ajunge in termend de 14 zile.";

            }
            catch
            {
              eroare.Text = "Cantitatea dorita este indisponibila";
            }
          

        Session[User.Identity.GetUserId()]=null;
    }
}