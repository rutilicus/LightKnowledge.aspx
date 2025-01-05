<%@ Page Title="設定" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="LightKnowledge.aspx.Config" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>設定</p>
    <div>
        <p>サイト名</p>
        <asp:TextBox ID="SiteName" runat="server" />
    </div>
    <asp:Button ID="SetBtn" runat="server" Text="適用" OnClick="SetBtn_Click" />
</asp:Content>
