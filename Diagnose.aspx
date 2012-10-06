<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeBehind="Diagnose.aspx.cs" Inherits="Seadragon.Diagnose" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style5
        {
            height: 137px;
            text-align: center;
            width: 315px;
        }
        .style9
        {
            height: 137px;
            width: 413px;
            text-align: center;
        }
        .style10
        {
            height: 170px;
            width: 223px;
        }
        .style12
        {
            width: 541px;
            text-align: center;
            font-weight: 700;
        }
        .style15
        {
            width: 413px;
        }
        .style16
        {
            width: 541px;
            text-align: left;
        }
        .style17
        {
            height: 137px;
            text-align: left;
            width: 223px;
        }
        .style18
        {
            width: 541px;
            text-align: center;
        }
        .style19
        {
            font-family: Georgia;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <form id="form1" runat="server">
    <br />
    <table class="style1" width="640px">
        <tr>
            <td class="style10" rowspan="6">
                <strong>Seadragon
    
    <asp:Label ID="lblStatusVal" runat="server" Text="Ready" ForeColor="#009933"></asp:Label>

                <br />
                <br />
                <br />
                Username :</strong>
    <asp:TextBox ID="Username" runat="server" Height="31px" Width="221px"></asp:TextBox>
                <br />
                <br />
                <strong>Password :</strong>&nbsp;
    <asp:TextBox ID="Password" runat="server"
                    TextMode="Password" Height="31px" Width="221px"></asp:TextBox>
    
                <br />
                <br />
    <asp:Button ID="Submit" runat="server" onclick="Button1_Click" Text="Submit" 
                    style="text-align: right" />
    
            </td>
            <td class="style12">
                <strong>Other Helpful Diagnostic Information</strong></td>
            <td class="style15">
            </td>
        </tr>
        <tr>
            <td class="style16">
                Account Expriration Date:</td>
            <td class="style15">
                <asp:Label ID="lblExpiration" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style16">
                AD Enabled Status:</td>
            <td class="style15">
                <asp:Label ID="lblEnabled" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style16">
                Home Directory Path:</td>
            <td class="style15">
                <asp:Label ID="lblHome" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style16">
                Last Known Password Set:</td>
            <td class="style15">
                <asp:Label ID="lblPwSet" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style12">
                &nbsp;</td>
            <td class="style15">
            </td>
        </tr>
        <tr>
            <td class="style17">
                <span class="style19"><em>Note: Google Account Status is only required to return 
                green if you&#39;re using a Smart Phone, IMAP Client or other service like Google 
                Notifier</em></span><strong>.<br />
                <br />
                <br />
                </strong>
            </td>
            <td class="style18">
                <strong>Google Account Status</strong><br />
                <asp:Label ID="GooglePasswdStatus" runat="server" ForeColor="#0066FF" 
                    Text="Standing By"></asp:Label>
                <br />
                <asp:Image ID="GooglePasswdImage" runat="server" 
                    ImageUrl="images/BlueCheckMark.png" />
            </td>
            <td class="style9">
                <strong>Active Directory Account Status</strong><br />
                <asp:Label ID="ADPasswdStatus" runat="server" ForeColor="#0066FF" 
                    Text="Standing By"></asp:Label>
                <br />
                <asp:Image ID="ADPasswdImage" runat="server" 
                    ImageUrl="images/BlueCheckMark.png" />
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    <br />

    </form>

</asp:Content>
