using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ProdusTipModel model = new ProdusTipModel();
        ProdusTip pt = CreateTipProdus();

        afisare.Text = model.InsertProdusTip(pt);

    }

    private ProdusTip CreateTipProdus()
    {
        ProdusTip p = new ProdusTip();
        p.Name = TextBox1.Text;

        return p;
    }
}