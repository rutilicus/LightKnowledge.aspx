<%@ Page Title="ナレッジ編集" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditKnowledge.aspx.cs" Inherits="LightKnowledge.aspx.EditKnowledge" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <p>ナレッジ名</p>
        <asp:TextBox ID="KnowledgeTitle" Columns="80" runat="server"></asp:TextBox>
    </div>
    <div>
        <p>ナレッジ本文</p>
        <asp:TextBox ID="KnowledgeText" TextMode="MultiLine" Columns="80" Rows="20" runat="server"></asp:TextBox>
    </div>
    <asp:Button ID="EntryBtn" runat="server" Text="登録" OnClick="EntryBtn_Click" />
</asp:Content>
