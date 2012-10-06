using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace Seadragon
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static readonly ILog log = LogManager.GetLogger("File");
        
        protected void SubChange_Click(object sender, EventArgs e)
        {
            if (NewPassword.Text != ConfirmPassword.Text)
            {
                lblStatusVal.Text = "New passwords do not match";
                lblStatusVal.ForeColor = System.Drawing.Color.Red;                              
                return;
            }     
       
            string error;
            if (!DirMgr.isValidPassword(NewPassword.Text, out error))                 
            {
                lblStatusVal.Text = error;
                lblStatusVal.ForeColor = System.Drawing.Color.Red;

                log.Info(String.Format("Invalid password for {0}", Username.Text));
                return;
            }

            // Only set the Google password if the password length is at least 8 characters
            Boolean setGoogle = true;
            if (NewPassword.Text.Length < 8)
            {
                setGoogle = false;
                lblStatusSecondary.ForeColor = System.Drawing.Color.Red;
                lblStatusSecondary.Text = "Google device password NOT set must be greater than 8 characters";
            }
            else
                lblStatusSecondary.Text = "";
            
            Boolean sync = false;
            if (DirMgr.checkPw(Username.Text, OldPassword.Text))
            {
                try
                {                                        
                    if (sync)                                 
                        DirMgr.changePw(Username.Text, OldPassword.Text, NewPassword.Text);                    
                    else                                            
                        DirMgr.setPw(Username.Text, NewPassword.Text);

                    if (setGoogle)
                    {
                        log.Debug(String.Format("Setting Google password for user {0}", Username.Text));
                        Google.setPw(Username.Text, NewPassword.Text);
                    }
                    
                    lblStatusVal.Text = "OK. New Password Set<br />";
                    lblStatusVal.ForeColor = System.Drawing.Color.Green;
                }
                catch (System.DirectoryServices.AccountManagement.PasswordException)
                {
                    lblStatusVal.Text = "Password does not meet the <br />complexity requirements.";
                    lblStatusVal.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                catch (Exception ex)
                {
                    lblStatusVal.Text = "Something went wrong.<br />Please contact the Help Desk<br />552-6900";
                    lblStatusVal.ForeColor = System.Drawing.Color.Red;

                    log.Error("Problem resetting password for " + Username.Text);
                    log.Error(ex);
                }                
            }
            else
            {
                lblStatusVal.Text = "Incorrect old password";
                lblStatusVal.ForeColor = System.Drawing.Color.Red;

                log.Info(String.Format("Incorrect old password for {0}", Username.Text));
            }
        }
    
    }
}