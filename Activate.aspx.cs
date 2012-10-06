using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace Seadragon
{
    public partial class Activate : System.Web.UI.Page
    {
        private static readonly ILog log = LogManager.GetLogger("File");

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string user = DirMgr.isValidKey(txtGiven.Text, txtSur.Text, txtID.Text, txtDOB.Text);

                if (user.Equals(""))
                {
                    lblStatus.Text = "Could not find a matching person.";
                    lblStatus.ForeColor = System.Drawing.Color.Red;

                    log.Info(String.Format("Unable to matching person for {0} {1}", txtGiven.Text, txtSur.Text));
                    return;
                }

                if (txtPw.Text != txtConfirm.Text)
                {
                    lblStatus.Text = "New passwords do not match";
                    lblStatus.ForeColor = System.Drawing.Color.Red;                    
                    return;
                }

                string error;
                if (!DirMgr.isValidPassword(txtPw.Text, out error))
                {
                    lblStatus.Text = error;
                    lblStatus.ForeColor = System.Drawing.Color.Red;

                    log.Info(String.Format("Invalid password for {0} {1}: {2}", txtGiven.Text, txtSur.Text, error));
                    return;
                }

                DirMgr.activateAccount(user, txtPw.Text);                

                lblStatus.Text = "Account Activated.";
                lblStatus.ForeColor = System.Drawing.Color.Green;                
                lblActUser.Text = user;
                lblActMail.Text = user + "@sou.edu";

                pnlActivated.Visible = true;
                pnlForm.Visible = false;
            }
            catch (System.DirectoryServices.AccountManagement.PasswordException)
            {
                lblStatus.Text = "Password does not meet the <br />complexity requirements.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                log.Info(String.Format("Invalid password for {0} {1}", txtGiven.Text, txtSur.Text));
            }
            catch (Exception ex)
            {                
                lblStatus.Text = "An error occurred. Try again.<br />If the error persists contact the Help Desk.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                log.Error(String.Format("Problem activating account for {0} {1}", txtGiven.Text, txtSur.Text), ex);
            }
        }
    }
}