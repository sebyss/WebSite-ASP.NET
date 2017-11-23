using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProdusTipsTipModel
/// </summary>
public class ProdusTipModel
{
    public string InsertProdusTip(ProdusTip produstip)
    {
        try
        {
            FarmacieEntities db = new FarmacieEntities();
            db.ProdusTips.Add(produstip);
            db.SaveChanges();

            return produstip.Name + " was succesfully inserted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateProdusTip(int id, ProdusTip produstip)
    {
        try
        {
            FarmacieEntities db = new FarmacieEntities();


            ProdusTip p = db.ProdusTips.Find(id);

            p.Name = produstip.Name;

            db.SaveChanges();
            return produstip.Name + " was succesfully updated";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeleteProdusTipct(int id)
    {
        try
        {
            FarmacieEntities db = new FarmacieEntities();
            ProdusTip produstip = db.ProdusTips.Find(id);

            db.ProdusTips.Attach(produstip);
            db.ProdusTips.Remove(produstip);
            db.SaveChanges();

            return produstip.Name + " was succesfully deleted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
}