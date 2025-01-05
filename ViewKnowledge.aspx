<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewKnowledge.aspx.cs" Inherits="LightKnowledge.aspx.ViewKnowledge" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>
            <asp:Label runat="server" ID="KnowledgeTitle" />
        </h1>
    </div>
    <div>
        <asp:Literal runat="server" ID="Description" Mode="PassThrough" />
    </div>
    <div>
        <p>タグ一覧</p>
        <asp:GridView ID="TagList" ShowHeader="False" GridLines="None" runat="server" AutoGenerateColumns="False" ItemType="LightKnowledge.aspx.Models.Tag" SelectMethod="GetTags">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="TagId" DataNavigateUrlFormatString="~/List/Tag/{0}" DataTextField="Name" DataTextFormatString="{0}" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
