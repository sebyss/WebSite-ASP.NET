using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CosModel
/// </summary>
public class CosModel
{
    public string InsertProdus(Co cos)
    {
        try
        {
            FarmacieEntities db = new FarmacieEntities();
            db.Cos.Add(cos);
            db.SaveChanges();

            return cos.Date + "was succesfully inserted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateProduct(int id, Co cos)
    {
        try
        {
            FarmacieEntities db = new FarmacieEntities();


            Co p = db.Cos.Find(id);

            p.Date = cos.Date;
            p.CustomerID = cos.CustomerID;
            p.Amount = cos.Amount;
            p.IsInCart = cos.IsInCart;
            p.ProductID = cos.ProductID;

            db.SaveChanges();
            return cos.Date + "was succesfully updated";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeleteProduct(int id)
    {
        try
        {
            FarmacieEntities db = new FarmacieEntities();
            Co cos = db.Cos.Find(id);

            db.Cos.Attach(cos);
            db.Cos.Remove(cos);
            db.SaveChanges();

            return cos.Date + "was succesfully deleted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
}