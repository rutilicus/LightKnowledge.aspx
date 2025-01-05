<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="LightKnowledge.aspx.Search" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>検索</p>
    <asp:TextBox ID="SearchText" runat="server" />
    <asp:Button ID="SearchBtn" runat="server" Text="検索" OnClick="SearchBtn_Click" />
</asp:Content>
