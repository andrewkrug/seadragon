<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="Default.aspx.cs" Inherits="Seadragon.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

    <form id="pwchange" runat="server">
    <script src="Script/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="Script/jquery.password-strength.js" type="text/javascript"></script>

<script type="text/javascript">
    $(document).ready(function () {
        var myPlugin = $("[id$='NewPassword']").password_strength();

        $("[id$='SubChange']").click(function () {
            return myPlugin.metReq(); //return true or false
        });

        $("[id$='passwordPolicy']").click(function (event) {
            var width = 350, height = 300, left = (screen.width / 2) - (width / 2),
            top = (screen.height / 2) - (height / 2);
            window.open("PasswordPolicy.xml", 'Password_poplicy', 'width=' + width + ',height=' + height + ',left=' + left + ',top=' + top);
            event.preventDefault();
            return false;
        });

    });
</script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div style="height: 258px">
        <span class="style4">
        <asp:Label ID="lblStatusLit" runat="server" Text="SeaDragon Status:"></asp:Label>
        <asp:Label ID="lblStatusVal" runat="server" Text="Ready" 
            style="color: #00CC00" ></asp:Label>
        </span>
        <br />
        <br />
        <table class="style3">
            <tr>
                <td class="style5">
            <asp:Label ID="UsernameL" runat="server" Text="Username:" 
                Font-Bold="True" Font-Size="Medium" style="font-family: Georgia"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Username" runat="server" Height="25px" 
                Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-family: Georgia" class="style5">
        <asp:Label ID="OldPasswordL" runat="server" Text="Old Password:" 
                Font-Bold="True" Font-Size="Medium"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="OldPassword" runat="server" Height="25px" Width="220px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">
        <asp:Label ID="NewPasswordL" runat="server" 
                Text="New Password : " Font-Bold="True" Font-Size="Medium" 
                        style="font-family: Georgia"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="NewPassword" runat="server" Height="25px" Width="220px" 
                        TextMode="Password"></asp:TextBox>
                   
                </td>
            </tr>
            <tr>
                <td class="style5">
                    <asp:Label ID="ConfirmPasswordL1" runat="server" Text="Confirm New Password : " 
                Font-Bold="True" Font-Size="Medium" style="font-family: Georgia"></asp:Label>
                </td>
                <td>
                <asp:TextBox ID="ConfirmPassword" runat="server" Height="25px" Width="220px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td>

      
        <asp:Button ID="SubChange" runat="server" Text="Submit" 
                onclick="SubChange_Click" ViewStateMode="Disabled" CssClass="BarIndicator" />
                </td>
            </tr>
        </table>
        Password Change Status:<br />
        <br />
        <span class="style4">
        <asp:Label ID="lblStatusSecondary" runat="server" Text=""></asp:Label>
        </span>
        <br />
        <br />
        <br />
       
        Having trouble with our system?&nbsp; Run a quick health check on your password 
        here:<br />
        <a href="https://seadragon.sou.edu/Diagnose.aspx">https://seadragon.sou.edu/Diagnose.aspx</a><div id="logo">
            <span style="font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px">
            <ul style="padding-right:1em">
                <li style="padding-right:0.5em">Do not include any of the following within your 
                    password... southern, 123456, asdfgh, qwerty, changeme, or password.</li>
                <li style="padding-right:0.5em">The new password must be unique (never used before).</li>
                <li style="padding-right:0.5em">Your entire name or username cannot be in your 
                    password.</li>
                <li style="padding-right:0.5em">It must include a minimum of 8 characters.</li>
                <li style="padding-right:0.5em">The password must include:<ul 
                        style="padding-right:1em">
                    <li style="padding-right:0.5em">At least one upper case character</li>
                    <li style="padding-right:0.5em">At least one lower case character</li>
                    <li style="padding-right:0.5em">At least one numeric character (0 - 9)</li>
                    <li style="padding-right:0.5em">Please refrain from using the Symbols
                        <br />
                        !&nbsp; % @&nbsp; $&nbsp; &amp;&nbsp; &quot;&nbsp; (&nbsp; )&nbsp; ,&nbsp; &lt;&nbsp; &gt;&nbsp; `&nbsp; ;&nbsp; =&nbsp; #&nbsp; 
                        (They create problems with Banner)</li>
                    </ul>
                </li>
            </ul>
            </span></div>
    </div>
    </form>
    </asp:Content>
<asp:Content ID="PasswordStrengthPopActivator" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        .style4
        {
            font-family: Georgia;
        }
        .style5
        {
            width: 231px;
        }
    </style>
    
</asp:Content>