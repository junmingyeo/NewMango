using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Validation
/// </summary>
public class Validation
{
    public Validation()
    {
    }

    public static bool checkconfirmPW(String Rpassword, String confirmPW)
    {
        bool bValid = true;
        if (Rpassword.Equals(confirmPW))
        {
            bValid = true;
        }
        else
        {
            bValid = false;
        }
        return bValid;
    }

    //check password
    public static bool checkpassword(String str)
    {
        bool bValid = true;

        //check that password is only between 7 digits to 13 digits
        if (str.Length < 7 || str.Length > 13)
        {
            bValid = false;
        }
        else
        {
            bValid = true;
        }

        return bValid;
    }

    //check if email contains '@'
    public static bool checkEmail(String email)
    {
        bool result = true;
        for (int i = 0; i < email.Length; i++)
        {
            if (email[i] == '@')
            {
                result = true;
                break;
            }
            else
            {
                result = false;
            }
        }

        return result;
    }
}