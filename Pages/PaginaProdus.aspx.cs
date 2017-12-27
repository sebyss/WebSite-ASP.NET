using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_PaginaProdus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        afisare();
    }

    private void afisare()
    {
        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"])){

            int id = Convert.ToInt32(Request.QueryString["id"]);

            ProdusModel produsModel = new ProdusModel();
            Produ produs = produsModel.GetProdus(id);

            

            lblPret.Text = "Pret: " + produs.Price  + "lei";
            lblTitlu.Text = produs.Name;
            lblDescriere.Text = produs.Description;
            lblCodProd.Text = id.ToString();
            imgProdus.ImageUrl = "~/Img/Produse/" + produs.Image;

            if(produs.Stoc == 0)
            {
                disponibilitate.Text = "Stoc Epuizat!";
                disponibilitate.ForeColor = Color.Red;
                addCos.Visible = false;
            }
            else
            {
                disponibilitate.Text = "In Stoc!";
                disponibilitate.ForeColor = Color.Green;
            }

            int[] cantitate = Enumerable.Range(1, 20).ToArray();
            Cantitate.DataSource = cantitate;
            Cantitate.AppendDataBoundItems = true;
            Cantitate.DataBind();

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            string clientID = Context.User.Identity.GetUserId();

            if (clientID != null)
            {

                int id = Convert.ToInt32(Request.QueryString["id"]);
                int cant = Convert.ToInt32(Cantitate.SelectedValue);

                Co cos = new Co
                {
                    Amount = cant,
                    CustomerID = clientID,
                    Date = DateTime.Now,
                    IsInCart = true,
                    ProductID = id
                    
                };

                CosModel model = new CosModel();
                lblMesaj.Text = model.InsertProdus(cos);
            }
            else
            {
                lblMesaj.Text = "Pentru a plasa o comanda trebuie sa fiti Inregistrat!";
            }

        }
    }
}