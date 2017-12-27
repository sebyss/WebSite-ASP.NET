using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Produse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        afisare();
    }

    private void afisare()
    {
        ProdusModel produsModel = new ProdusModel();
        List<Produ> list = produsModel.GetAllProduse();

        if(list != null)
        {
            foreach(Produ produs in list)
            {
                Panel produsePnl = new Panel();
                ImageButton imageButton = new ImageButton();
                produsePnl.BorderColor = Color.AliceBlue;

                Label lblNume = new Label();
                Label lblPret = new Label();

                produsePnl.BorderStyle = BorderStyle.Groove;
                produsePnl.BorderColor = Color.LightSkyBlue;

                imageButton.ImageUrl = "~/Img/Produse/" + produs.Image;
                imageButton.CssClass = "imgProdus";
                imageButton.PostBackUrl = "~/Pages/PaginaProdus.aspx?id=" + produs.ID;

                lblNume.Text = produs.Name;
                lblNume.CssClass = "numeProd";

                lblPret.Text = produs.Price + "lei";
                lblPret.CssClass = "produsPret";


                produsePnl.Controls.Add(imageButton);
                produsePnl.Controls.Add(new Literal { Text = "<br /" });
                produsePnl.Controls.Add(lblNume);
                produsePnl.Controls.Add(new Literal { Text = "<br /" });
                produsePnl.Controls.Add(lblPret);

                pnlProduse.Controls.Add(produsePnl);

            }

        }

        else
        {
            pnlProduse.Controls.Add(new Literal { Text = "Nu exista produse !" });
        }
    }
}