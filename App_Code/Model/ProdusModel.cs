using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProdusModel
/// </summary>
public class ProdusModel
{
    public string InsertProdus(Produ produs)
    {
        try
        {
            FarmacieEntities db = new FarmacieEntities();
            db.Produs.Add(produs);
            db.SaveChanges();

            return produs.Name + "was succesfully inserted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateProduct(int id, Produ produs)
    {
        try
        {
            FarmacieEntities db = new FarmacieEntities();

        
            Produ p = db.Produs.Find(id);

            p.Name = produs.Name;
            p.Price = produs.Price;
            p.TypeID = produs.TypeID;
            p.Description = produs.Description;
            p.Image = produs.Image;

            db.SaveChanges();
            return produs.Name + "was succesfully updated";

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
            Produ produs = db.Produs.Find(id);

            db.Produs.Attach(produs);
            db.Produs.Remove(produs);
            db.SaveChanges();

            return produs.Name + "was succesfully deleted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
}