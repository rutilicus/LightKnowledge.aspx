<%@ Page Title="タグ管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageTag.aspx.cs" Inherits="LightKnowledge.aspx.ManageTag" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="TagList" AllowPaging="true" PageSize="50" runat="server" AutoGenerateColumns="False" ItemType="LightKnowledge.aspx.Models.Tag" SelectMethod="GetTags">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="TagId" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"/>
            <asp:BoundField HeaderText="変更前タグ名" DataField="Name" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"/>
            <asp:TemplateField HeaderText="タグ名">
                <ItemTemplate>
                    <asp:TextBox ID="NewTagName" Columns="80" runat="server" Text="<%#: Item.Name %>"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="削除">
                <ItemTemplate>
                    <asp:CheckBox id="Remove" runat="server"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="UpdateBtn" runat="server" Text="変更を適用" OnClick="UpdateBtn_Click"/>
</asp:Content>
