<%@ Page Title="ナレッジ管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageKnowledge.aspx.cs" Inherits="LightKnowledge.aspx.ManageKnowledge" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="KnowledgeList" ShowHeader="False" CellPadding="5" GridLines="Horizontal" AllowPaging="true" PageSize="50" runat="server" AutoGenerateColumns="False" ItemType="LightKnowledge.aspx.Models.Knowledge" SelectMethod="GetKnowledge">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="KnowledgeId" DataNavigateUrlFormatString="~/Edit/{0}" DataTextField="Title" DataTextFormatString="{0}" />
            <asp:HyperLinkField DataNavigateUrlFields="KnowledgeId" DataNavigateUrlFormatString="~/ManageResource/{0}" Text="リソース編集" />
            <asp:HyperLinkField DataNavigateUrlFields="KnowledgeId" DataNavigateUrlFormatString="~/EditKnowledgeTag/{0}" Text="タグ編集" />
            <asp:HyperLinkField DataNavigateUrlFields="KnowledgeId" DataNavigateUrlFormatString="~/DeleteKnowledge/{0}" Text="削除" />
        </Columns>
    </asp:GridView>
</asp:Content>
