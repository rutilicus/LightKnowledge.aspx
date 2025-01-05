<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditKnowledgeTag.aspx.cs" Inherits="LightKnowledge.aspx.EditKnowledgeTag" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="TitleLabel" runat="server" />
    <p>登録済みタグ</p>
    <asp:GridView ID="KnowledgeTagList" CellPadding="5" GridLines="Horizontal" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="RelationID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden">
                <ItemTemplate>
                    <asp:Label id="RelationId" Text='<%# DataBinder.Eval(Container.DataItem, "relationID") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="タグ名">
                <ItemTemplate>
                    <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "tagName") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="削除">
                <ItemTemplate>
                    <asp:CheckBox id="Remove" runat="server"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="DeleteBtn" runat="server" Text="タグ削除を適用" OnClick="DeleteBtn_Click"/>
    <p>タグを追加</p>
    <asp:DropDownList ID="AddTagDropDownList" runat="server" />
    <asp:Button ID="AddBtn" runat="server" Text="タグを追加" OnClick="AddBtn_Click" />
</asp:Content>
