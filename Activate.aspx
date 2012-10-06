<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Activate.aspx.cs" Inherits="Seadragon.Activate" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="en-US" xml:lang="en-US">

<head runat="server">
<title>Activate Your Network Account</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style type="text/css">
        body {
	        color: #444444;
	        font-family: Arial, Helvetica, sans-serif;
	        background: white url(App_Themes/Default/header_background.png) repeat-x center top;
        }
        wrapper 
        {
            background-color: White;
            border: 1px solid black;
            width: 70%;
        }
        .PaddUl
        {
            font-family: "Gill Sans MT";
        }
        .style3
        {
            height: 50px;
            width: 379px;
        }
        #activate
        {
            height: 19px;
        }
        .style4
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            height: 26px;
        }
        .style5
        {
            height: 50px;
            width: 203px;
        }
        .style8
        {
            height: 62px;
            width: 231px;
            font-size: large;
        }
        .style9
        {
            font-size: medium;
        }
        .style10
        {
            font-family: "Gill Sans MT";
            font-size: medium;
            text-align: right;
        }
        .style11
        {
            height: 50px;
            font-size: large;
            width: 171px;
            text-align: right;
        }
        .style13
        {
            font-family: "Gill Sans MT";
            font-size: medium;
        }
        .style14
        {
            font-family: "Gill Sans MT";
        }
        .style16
        {
            height: 107px;
            }
        .style19
        {
            padding-left: 220px;
            font-family: "Gill Sans MT";
        }
        .style20
        {
            text-align: center;
            font-size: large;
        }
        .style21
        {
            color: #800000;
            font-size: x-large;
        }
        .style23
        {
            height: 50px;
            width: 196px;
            text-align: right;
        }
        .style30
        {
            font-family: "Gill Sans MT";
            font-size: medium;
            height: 26px;
        }
        .style32
        {
            width: 234px;
            height: 68px;
        }
        .style33
        {
            width: 34px;
            height: 32px;
        }
        .style34
        {
            font-family: "Gill Sans MT";
            font-size: medium;
            height: 84px;
        }
        .style35
        {
            font-family: "Gill Sans MT";
            font-size: large;
            text-align: right;
        }
        .style36
        {
            font-family: "Gill Sans MT";
            font-size: large;
            height: 26px;
            text-align: right;
        }
        .style37
        {
            font-family: "Gill Sans MT";
            font-size: 4em;
            text-align: right;
        }
        .style38
        {
            height: 80px;
        }
    </style>
</head>

<body>
<form id="activate" runat="server">      
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div class="style20">
            <span class="style14">
            <span class="style21">
            <img alt="" class="style33" src="img/logo_color_seadragon_90.png" />Seadragon : Network Account 
            Activation&nbsp;&nbsp;&nbsp;
            <br />
            </span></span>

  <script src="Script/jquery-1.4.4.min.js" type="text/javascript"></script>
  <script src="Script/jquery.password-strength.js" type="text/javascript"></script>
  <script type="text/javascript">
      $(document).ready(function () {
          var myPlugin = $("[id$='txtPw']").password_strength();

          //$("[id$='btnSubmit']").click(function () {
              //return myPlugin.metReq(); //return true or false
          //});

          $("[id$='passwordPolicy']").click(function (event) {
              var width = 350, height = 300, left = (screen.width / 2) - (width / 2),
            top = (screen.height / 2) - (height / 2);
              window.open("PasswordPolicy.xml", 'Password_poplicy', 'width=' + width + ',height=' + height + ',left=' + left + ',top=' + top);
              event.preventDefault();
              return false;
          });

      });
</script>
    </div>
    <div align="center">
    <asp:Label ID="lblStatus" runat="server" 
                Text="" 
                ForeColor="#009933" CssClass="style37"></asp:Label>
    </div>
    <asp:Panel ID="pnlForm" runat="server" Visible="True">
    <table align="center" 
      style="border: 2px solid #CCCCCC; width: 931px; height: 385px; font-family: 'Gill Sans MT'; background-color: #FFFFFF;" 
      frame="border" cellpadding="5px" dir="ltr">
    <tr>
        <td class="style16" colspan="4">
  <p>
      <span class="style13">
            <span class="style14">
        <span class="style21">
      <img alt="" class="style32" src="img/customLogo.png" /></span></span>
      </span>
</p>
            <p>
                <span class="style13">To activate your network account we need to confirm your identity. Each field is required.
      </span> <br class="style13" /> 
      <span class="style13">Once you submit the form you will be given your account name.</span></p>
        </td>
    </tr>
    <tr>
        <td class="style23">
            <span class="style8">First Name:</span></td>
        <td class="style5">
            <asp:TextBox ID="txtGiven" runat="server" autocomplete="off" 
                Height="20px" Width="200px" CssClass="style10" Font-Size="Medium"></asp:TextBox>
            <br class="style10" />
        </td>
        <td class="style11" valign="middle">
            Birth date:<br />
            </td>
        <td class="style3">
            <asp:TextBox ID="txtDOB" runat="server" autocomplete="off" Height="20px" 
                Width="200px" CssClass="style10" Font-Size="Medium"></asp:TextBox>
            <asp:CalendarExtender ID="txtDOB_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtDOB" DefaultView="Years" >
            </asp:CalendarExtender>
            <br class="style10" />
        </td>
    </tr>
        <tr>
            <td class="style23">
                <span class="style9"><span class="style35">Last Name:</span></span></td>
            <td class="style5">
                <asp:TextBox ID="txtSur" runat="server" autocomplete="off" CssClass="style10" 
                    Font-Size="Medium" Height="20px" Width="200px"></asp:TextBox>
            </td>
            <td class="style11" valign="middle">
                SSN or SOU ID:</td>
            <td class="style3">
                <asp:TextBox ID="txtID" runat="server" autocomplete="off" CssClass="style10" 
                    Font-Size="Medium" Height="20px" MaxLength="11" Width="200px"></asp:TextBox>
                <asp:MaskedEditExtender ID="txtID_MaskedEditExtender" runat="server" 
                    AutoComplete="False" ClearTextOnInvalid="True" CultureAMPMPlaceholder="" 
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                    ErrorTooltipEnabled="True" Mask="999-99-9999" TargetControlID="txtID">
                </asp:MaskedEditExtender>
            </td>
        </tr>
    <tr>
        <td class="style34" colspan="4">
            <span style="FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; ">
            <p>
                <strong>Password Policy:</strong></p>
            </span>
            <span style="FONT-SIZE: 13px">
            <ul class="style19">
                <li style="PADDING-RIGHT: 0.5em">Do not include any of the following within your 
                    password... southern, 123456, asdfgh, qwerty, changeme, or password.</li>
                <li style="PADDING-RIGHT: 0.5em">The new password must be unique (never used 
                    before).</li>
                <li style="PADDING-RIGHT: 0.5em">Your entire name or username cannot be in your 
                    password.</li>
                <li style="PADDING-RIGHT: 0.5em">It must include a minimum of 8 characters.</li>
                <li style="PADDING-RIGHT: 0.5em">The password must include:
                    <ul style="PADDING-RIGHT: 1em">
                        <li style="PADDING-RIGHT: 0.5em">At least one upper case character</li>
                        <li style="PADDING-RIGHT: 0.5em">At least one lower case character</li>
                        <li style="PADDING-RIGHT: 0.5em">At least one numeric character (0 - 9)</li>
                        <li>Please refrain from using the Symbols
                            <br />
                            ! % @ $ &amp; &quot; ( ) , &lt; &gt; ` ; = # (They create problems with Banner)</li>
                    </ul>
                </li>
            </ul>
            </span></td>
    </tr>
    <tr>
        <td class="style36">
            Set Password:<br />
            <br />
            Confirm Password:</td>
        <td class="style30">
            <asp:TextBox ID="txtPw" runat="server" TextMode="Password" autocomplete="off" 
                Height="20px" Width="200px" CssClass="style10"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" 
                autocomplete="off" Height="20px" Width="200px" CssClass="style10"></asp:TextBox>
        </td>
        <td class="style4" colspan="2">
            </td>
    </tr>
    <tr>
        <td colspan="2" class="style38">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                onclick="btnSubmit_Click" CssClass="style10" Font-Size="Medium" Height="54px" 
                style="text-align: center" Width="276px" />
            <br />
            <font color="red">* By activating your account you are agreeing to abide by the 
            Acceptable Use Policy.<a href="AcceptableUse.aspx" target="_blank"> See 
            Acceptable Use Policy?</a></font></td>
        <td colspan="2" class="style38">
        </asp:Panel>

<asp:Panel ID="pnlActivated" runat="server" Visible="False" CssClass="style10">
<li class="style20"><span class="style14">Your username is
    <asp:Label ID="lblActUser" runat="server" Font-Bold="True"></asp:Label></span></li>
    <li class="style20">Your e-mail address is
        <asp:Label ID="lblActMail" runat="server" Font-Bold="True"></asp:Label>
    </li>
    </span>
    <br />
    </li>
    <li class="style20"><font size="large"><a href="http://my.sou.edu" target="_blank">Go To MySOU</a></font></li>
    </span>
</asp:Panel>

        </td>
    </tr>
</form>

</form>

</form>

</body>

</html>
