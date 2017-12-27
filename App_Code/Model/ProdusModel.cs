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

            return produs.Name + " was succesfully inserted";
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
            p.Stoc = produs.Stoc;

            db.SaveChanges();
            return produs.Name + " was succesfully updated";

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

            return produs.Name +  "was succesfully deleted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public Produ GetProdus(int id)
    {
        try
        {
            using (FarmacieEntities db = new FarmacieEntities())
            {
                Produ produs = db.Produs.Find(id);
                return produs;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<Produ> GetAllProduse()
    {
        try
        {
            using (FarmacieEntities db = new FarmacieEntities())
            {
                List<Produ> produse = (from x in db.Produs select x).ToList();
                return produse;
            }
        }

        catch(Exception)
        {
            return null;
        }
    } 

    public List<Produ> GetProdCateg(int cat)
    {
        try
        {
            using (FarmacieEntities db = new FarmacieEntities())
            {
                List<Produ> produse = (from x in db.Produs where x.TypeID == cat select x).ToList();
                return produse;
            }
        }
        catch(Exception)
        {
            return null;
        }
    }
}