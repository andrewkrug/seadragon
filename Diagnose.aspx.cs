using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace Seadragon
{
    public partial class Diagnose : System.Web.UI.Page
    {
        private static readonly ILog log = LogManager.GetLogger("File");

        protected void Button1_Click(object sender, EventArgs e)
        {
            string error;
            if (!DirMgr.isValidPassword(Password.Text, out error))
            {
                lblStatusVal.Text = "Your password is not complex enough.  Please set a complex password and try again.";
                lblStatusVal.ForeColor = System.Drawing.Color.Red;

                log.Info(String.Format("Invalid password for {0}", Username.Text));
                return;
            }

            bool showDetails = false;
            if (DirMgr.checkAD(Username.Text, Password.Text))
            {
                ADPasswdStatus.Text = "AD Password is correct.";
                ADPasswdStatus.ForeColor = System.Drawing.Color.Green;
                ADPasswdImage.ImageUrl = "~/images/GreenCheckMark.png";
                showDetails = true;
            }
            else
            {
                ADPasswdStatus.Text = "AD Password is incorrect.";
                ADPasswdStatus.ForeColor = System.Drawing.Color.Red;
                ADPasswdImage.ImageUrl = "~/images/RedCheckMark.png";
            }

           /* if (DirMgr.checkED(Username.Text, Password.Text))
            {
                EDPasswdStatus.Text = "eDirectory Password is correct.";
                EDPasswdStatus.ForeColor = System.Drawing.Color.Green;
                EDPasswdImage.ImageUrl = "~/images/GreenCheckMark.png";
                showDetails = true;
            }
            else
            {
                EDPasswdStatus.Text = "eDirectory Password is incorrect.";
                EDPasswdStatus.ForeColor = System.Drawing.Color.Red;
                EDPasswdImage.ImageUrl = "~/images/RedCheckMark.png";
            }*/

            if (Google.checkPw(Username.Text, Password.Text))
            {
                GooglePasswdStatus.Text = "Google Device Password is correct.";
                GooglePasswdStatus.ForeColor = System.Drawing.Color.Green;
                GooglePasswdImage.ImageUrl = "~/images/GreenCheckMark.png";
            }
            else
            {
                GooglePasswdStatus.Text = "Google Device Password is incorrect.";
                GooglePasswdStatus.ForeColor = System.Drawing.Color.Red;
                GooglePasswdImage.ImageUrl = "~/images/RedCheckMark.png";
            }


            if (showDetails)
            {
                TimeZoneInfo pacific = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
                
                if (AD.isEnabled(Username.Text))
                    lblEnabled.Text = "Enabled";
                else
                    lblEnabled.Text = "Disabled";

                DateTime? expiration = AD.getExpiration(Username.Text);
                if (expiration != null)
                    lblExpiration.Text = (TimeZoneInfo.ConvertTime((DateTime) expiration, pacific)).ToString();
                else
                    lblExpiration.Text = "Never";

                lblHome.Text = AD.getHome(Username.Text);

                DateTime? pwSet = AD.getLastPasswordSet(Username.Text);
                if (pwSet != null)
                    lblPwSet.Text = (TimeZoneInfo.ConvertTime((DateTime) pwSet, pacific)).ToString();
                else
                    lblPwSet.Text = "Never";
            }
       }
    }
}