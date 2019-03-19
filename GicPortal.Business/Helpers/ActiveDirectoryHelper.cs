using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;

namespace GicPortal.Helpers
{
    public class ActiveDirectoryHelper
    {


        String adPath = "LDAP://uzval.com";

        String DomainName = "uzval";

        public bool IsAuthenticated(string adPath, string domain, string username, string pwd)

        {

            string wholeString = username;

            string firstBit = wholeString.Split(‘@’)[0];

            username = firstBit;

            string domainAndUsername = domain + @”\” +username;

            DirectoryEntry entry = new DirectoryEntry(adPath, domainAndUsername, pwd);

            try

            {

                //Bind to the native AdsObject to force authentication.

                object obj = entry.NativeObject;

                DirectorySearcher search = new DirectorySearcher(entry);

                search.Filter = “(SAMAccountName =” +username + “)”;

                //UserId

                search.PropertiesToLoad.Add(“SAMAccountName”);

                //CN or Display Name

                search.PropertiesToLoad.Add(“cn”);

                //Status

                search.PropertiesToLoad.Add(“userAccountControl”);

                SearchResult result = search.FindOne();

                if (null == result)

                {

                    return false;

                }

                else

                {

                    Session[“ADUserID”] = string.Empty;

                    Session[“ADUserName”] = string.Empty;

                    Session[“ADuserAccountControl”] = string.Empty;

                    //ADUser UserId

                    Session[“ADUserID”] = result.Properties[“SAMAccountName”][0];

                    //AD UserName

                    Session[“ADUserName”] = result.Properties[“cn”][0];
                    //AD ENABLE/DISABLE Status Flag

                    Session[“ADuserAccountControl”] = Convert.ToString(result.Properties[“userAccountControl”][0]);
                    //User Account Control values

                    //Allow all these ID’s to login- 512,544,4096,66048,590336,532480

                    //512 – Enable Account

                    //514 – Disable account

                    //544 – Account Enabled – Require user to change password at first logon

                    //4096 – Workstation/server

                    //66048 – Enabled, password never expires

                    //590336 – Enabled, User Cannot Change Password, Password Never Expires

                    //66050 – Disabled, password never expires

                    //262656 – Smart Card Logon Required

                    //532480 – Domain controller

                }

            }

            catch (Exception ex)

            {

                return false;

                //throw new Exception(“Error authenticating user. ” + ex.Message);

            }

            return true;

        }
    }


}