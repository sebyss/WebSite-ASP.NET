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
        getImg();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void dropimg_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void getImg()
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

    private Produ createProdus()
    {
        Produ produs = new Produ();
        produs.Name = txtnume.Text;
        produs.Price = Convert.ToDouble(txtpret.Text);
        produs.TypeID = Convert.ToInt32(categdrop.SelectedValue);
        produs.Description = textdescriere.Text;
        produs.Image = dropimg.SelectedValue;

        return produs;

    }

    protected void realizprod_Click(object sender, EventArgs e)
    {
        ProdusModel prodMod = new ProdusModel();
        Produ produs = createProdus();

        lblprod.Text = prodMod.InsertProdus(produs);
    }
}