<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageResource.aspx.cs" Inherits="LightKnowledge.aspx.ManageResource" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="TitleLabel" runat="server" />
    <p>アップロード済リソース一覧</p>
    <asp:GridView ID="FileList" runat="server" GridLines="Horizontal" CellPadding="5" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="リソース名">
                <ItemTemplate>
                    <a href='<%# $"/Resources/{Convert.ToInt32(RouteData.Values["id"])}/{DataBinder.Eval(Container.DataItem, "fileName")}" %>'><%# DataBinder.Eval(Container.DataItem, "fileName") %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# $"/DeleteResource/{Convert.ToInt32(RouteData.Values["id"])}/{DataBinder.Eval(Container.DataItem, "fileName")}" %>'>削除</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <p>リソースアップロード</p>
    <div>
        <asp:FileUpload ID="UploadFile" runat="server" />
    </div>
    <asp:Button ID="UploadBtn" runat="server" OnClick="UploadBtn_Click" Text="アップロード" />
</asp:Content>
