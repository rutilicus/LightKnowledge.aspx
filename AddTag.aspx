<%@ Page Title="タグの追加" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTag.aspx.cs" Inherits="LightKnowledge.aspx.AddTag" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>タグ名</p>
    <asp:TextBox ID="TagName" Columns="80" runat="server"></asp:TextBox>
    <asp:Button ID="EntryBtn" runat="server" Text="登録" OnClick="EntryBtn_Click" />
</asp:Content>
