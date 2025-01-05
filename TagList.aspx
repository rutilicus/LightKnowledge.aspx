<%@ Page Title="タグ一覧" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TagList.aspx.cs" Inherits="LightKnowledge.aspx.TagList" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>タグ一覧</p>
    <asp:GridView ID="TagListView" ShowHeader="False" CellPadding="5" GridLines="None" runat="server" AutoGenerateColumns="False" ItemType="LightKnowledge.aspx.Models.Tag" SelectMethod="GetTag">
    <Columns>
        <asp:HyperLinkField DataNavigateUrlFields="TagId" DataNavigateUrlFormatString="~/List/Tag/{0}" DataTextField="Name" DataTextFormatString="{0}" />
    </Columns>
    </asp:GridView>
</asp:Content>
