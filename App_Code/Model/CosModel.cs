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

    public string UpdateCos(int id, Co cos)
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

    public string DeleteCos(int id)
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

    public List<Co> getInCos(string userId)
    {
        FarmacieEntities db = new FarmacieEntities();
        List<Co> comanda = (from x in db.Cos
                            where x.CustomerID == userId 
                            && x.IsInCart orderby x.Date
                            select x).ToList();
        return comanda;
    }

    public List<Co> getFromCos(string userId)
    {
        try
        {
            using (FarmacieEntities db = new FarmacieEntities())
            {
                List<Co> produse = (from x in db.Cos where x.CustomerID == userId select x).ToList();
                return produse;
            }
        }

        catch (Exception)
        {
            return null;
        }
    }


    public int getTotalItems(string userId)
    {
        try
        {
            FarmacieEntities db = new FarmacieEntities();
            int cantitate = (from x in db.Cos
                             where x.CustomerID == userId
                             && x.IsInCart
                             select x.Amount).Sum();
            return cantitate;
        }
        catch
        {
            return 0;
        }
    }

    public void updateCant(int id, int cant)
    {
        FarmacieEntities db = new FarmacieEntities();
        Co cos = db.Cos.Find(id);
        cos.Amount = cant;

        db.SaveChanges();
    }

    private static Random random = new Random();
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    

    public void comandaPlatita(List<Co> coss)
    {
        FarmacieEntities db = new FarmacieEntities();

        string rand = RandomString(10);

        if (coss != null)
        {
            foreach (Co cos in coss)
            {
                Co oldCos = db.Cos.Find(cos.ID);
                oldCos.Date = DateTime.Now;
                oldCos.IsInCart = false;

                oldCos.OrderID = rand;
                Produ p = db.Produs.Find(oldCos.ProductID);

                if (oldCos.Amount <= p.Stoc)
                {
                    p.Stoc -= oldCos.Amount;
                }
                else
                {
                    throw new Exception("Eroare de stoc!");
                }

            }

            db.SaveChanges();
        }
        else
        {
            throw new Exception("Cosul este gol!");
        }
        
    }

}