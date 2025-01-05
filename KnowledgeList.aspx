<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KnowledgeList.aspx.cs" Inherits="LightKnowledge.aspx.KnowledgeList" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="TitleLabel" runat="server" />
    <asp:GridView ID="KnowledgeListView" ShowHeader="False" CellPadding="5" GridLines="None" AllowPaging="true" PageSize="50" runat="server" AutoGenerateColumns="False" ItemType="LightKnowledge.aspx.Models.Knowledge" SelectMethod="GetKnowledge">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="KnowledgeId" DataNavigateUrlFormatString="~/View/{0}" DataTextField="Title" DataTextFormatString="{0}" />
        </Columns>
    </asp:GridView>
</asp:Content>
