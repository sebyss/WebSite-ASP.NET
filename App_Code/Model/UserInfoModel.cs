using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserInfoModel
/// </summary>
public class UserInfoModel
{
    public UserInfo GetUserInformation(string uid)
    {
        FarmacieEntities db = new FarmacieEntities();
        UserInfo info = (from x in db.UserInfoes where x.UID == uid select x).FirstOrDefault();

        return info;
    }

    public void InsertUserInfo(UserInfo info)
    {
        FarmacieEntities db = new FarmacieEntities();
        db.UserInfoes.Add(info);
        db.SaveChanges();


    }
}