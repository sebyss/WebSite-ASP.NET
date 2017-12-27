using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AddProdus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetImg();

            
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Completare(id);
            }
        }
     

    }

    private void Completare(int id)
    {
        
        ProdusModel produsModel = new ProdusModel();
        Produ produs = produsModel.GetProdus(id);

        
        textdescriere.Text = produs.Description;
        txtnume.Text = produs.Name;
        txtpret.Text = produs.Price.ToString();
        textStoc.Text = produs.Stoc.ToString();

        
        dropimg.SelectedValue = produs.Image;
        categdrop.SelectedValue = produs.TypeID.ToString();
    }



    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Dropimg_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void GetImg()
    {
        try
        {
            string[] img = Directory.GetFiles(Server.MapPath("~/Img/Produse"));

            ArrayList imglist = new ArrayList();

            foreach (string imga in img)
            {
                string imgName = imga.Substring(imga.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                imglist.Add(imgName);

                dropimg.DataSource = imglist;
                dropimg.AppendDataBoundItems = true;
                dropimg.DataBind();

            }
        }

        catch(Exception e)
        {
            lblprod.Text = e.ToString();
        }
    }

    private Produ CreateProdus()
    {
        Produ produs = new Produ();
        produs.Name = txtnume.Text;
        produs.Price = Convert.ToDouble(txtpret.Text);
        produs.TypeID = Convert.ToInt32(categdrop.SelectedValue);
        produs.Description = textdescriere.Text;
        produs.Image = dropimg.SelectedValue;
        produs.Stoc = Convert.ToInt32(textStoc.Text);

        return produs;

    }

    protected void Realizprod_Click(object sender, EventArgs e)
    {
        ProdusModel produsModel = new ProdusModel();
        Produ produs = CreateProdus();

        
        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            
            int id = Convert.ToInt32(Request.QueryString["id"]);
            lblprod.Text = produsModel.UpdateProduct(id, produs);
        }
        else
        {
            
            lblprod.Text = produsModel.InsertProdus(produs);
        }


    }
}