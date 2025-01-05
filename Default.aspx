<%@ Page Title="新着ナレッジ一覧" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LightKnowledge.aspx.Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>新着ナレッジ一覧</p>
    <asp:GridView ID="NewKnowledge" ShowHeader="False" GridLines="None" runat="server" AutoGenerateColumns="False" ItemType="LightKnowledge.aspx.Models.Knowledge" SelectMethod="GetNewKnowledge">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="KnowledgeId" DataNavigateUrlFormatString="~/View/{0}" DataTextField="Title" DataTextFormatString="{0}" />
        </Columns>
    </asp:GridView>
</asp:Content>
