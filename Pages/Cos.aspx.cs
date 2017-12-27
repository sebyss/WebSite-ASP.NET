using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Cos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userId = User.Identity.GetUserId();
        GetcomandaInCos(userId);
    }

    public void GetcomandaInCos(string userId)
    {
        CosModel cosModel = new CosModel();
        double subtotal = 0;

        List<Co> listaComanda = cosModel.getInCos(userId);
        CreateShopTable(listaComanda, out subtotal);

        double tva = subtotal * 0.24;
        double totalAmount = subtotal + 14.99;

        litTotal.Text = subtotal + " lei";
        litTva.Text = tva + " lei";
        litPtotal.Text = totalAmount + " lei";
    }

    public void CreateShopTable(List<Co>listaComanda, out double subTotal)
    {
        subTotal = new Double();
        ProdusModel model = new ProdusModel();

        Produ p = new Produ();


        foreach (Co cos in listaComanda)
        {
            FarmacieEntities db = new FarmacieEntities();
            Produ produs = model.GetProdus(cos.ProductID);

            Produ ps = db.Produs.Find(cos.ProductID);
            int z = Convert.ToInt32(ps.Stoc);

            ImageButton btnImage = new ImageButton
            {
                ImageUrl = string.Format("~/Img/Produse/{0}", produs.Image),
                PostBackUrl = string.Format("~/Pages/PaginaProdus.aspx?id={0}", produs.ID)
            };


            LinkButton lnkDelete = new LinkButton
            {
                PostBackUrl = string.Format("~/Pages/Cos.aspx?productId={0}", cos.ID),
                Text = "Sterge",
                ID = "del" + cos.ID
            };

            lnkDelete.Click += Delete_Item;

           

            int[] cantitate = Enumerable.Range(1, count: z).ToArray();
            DropDownList ddCantitate = new DropDownList
            {
                DataSource = cantitate,
                AppendDataBoundItems = true,
                AutoPostBack = true,
                ID = cos.ID.ToString()
            };

            ddCantitate.DataBind();
            ddCantitate.SelectedValue = cos.Amount.ToString();
            ddCantitate.SelectedIndexChanged += ddCantitate_SelectedIndexChanged;


            Table tabel = new Table { CssClass = "cartTable" };
            TableRow a = new TableRow();
            TableRow b = new TableRow();

            //====================== Pentru A========================
            TableCell a1 = new TableCell { RowSpan = 2, Width = 50 };
            TableCell a2 = new TableCell
            {
                Text = string.Format("<h4>{0}</h4><br/>{1}<br/>", produs.Name, "Cod produs: " + produs.ID),
                HorizontalAlign = HorizontalAlign.Left,
                Width = 350
            };

            TableCell a3 = new TableCell { Text = "Pret /buc.<hr/>" };
            TableCell a4 = new TableCell { Text = "Cantitate:<hr/>" };
            TableCell a5 = new TableCell { Text = "Total Produse:<hr/>" };
            TableCell a6 = new TableCell { };

            //========================Pentru B============================
            TableCell b1 = new TableCell {  };
            TableCell b2 = new TableCell { Text = produs.Price + " lei" };
            TableCell b3 = new TableCell { };
            TableCell b4 = new TableCell { Text = Math.Round((cos.Amount * produs.Price),2) +" lei"};
            TableCell b5 = new TableCell { };
            TableCell b6 = new TableCell { };


            a1.Controls.Add(btnImage);
            a6.Controls.Add(lnkDelete);
            b3.Controls.Add(ddCantitate);

            a.Cells.Add(a1);
            a.Cells.Add(a2);
            a.Cells.Add(a3);
            a.Cells.Add(a4);
            a.Cells.Add(a5);
            a.Cells.Add(a6);


            b.Cells.Add(b1);
            b.Cells.Add(b2);
            b.Cells.Add(b3);
            b.Cells.Add(b4);
            b.Cells.Add(b5);
            b.Cells.Add(b6);

            tabel.Rows.Add(a);
            tabel.Rows.Add(b);

            pnlCos.Controls.Add(tabel);

            

            

        }

        Session[User.Identity.GetUserId()] = listaComanda;
    }

    private void Delete_Item(object sender, EventArgs e)
    {
        LinkButton selectedLink = (LinkButton)sender;
        string link = selectedLink.ID.Replace("del", "");
        int cosId = Convert.ToInt32(link);

        CosModel model = new CosModel();
        model.DeleteCos(cosId);

        Response.Redirect("~/Pages/Cos.aspx");
    }

    private void ddCantitate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList selectedList = (DropDownList)sender;
        int cantitate = Convert.ToInt32(selectedList.SelectedValue);
        int cosId = Convert.ToInt32(selectedList.ID);

        CosModel model = new CosModel();
        model.updateCant(cosId, cantitate);

        Response.Redirect("~/Pages/Cos.aspx");
    }


    protected void btnCheckout_Click(object sender, EventArgs e)
    {
       
    }
}