<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchHistory.aspx.cs" Inherits="Search_CEP__WebForms_.SearchHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Styles/StylesSearchHistory.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ContainerHistory">        
        <asp:GridView runat="server" ID="gvSearchHistory" class="table table-dark table-striped" ></asp:GridView>
    </div>
</asp:Content>
