<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Search_CEP__WebForms_.Default" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Styles/Default.css" rel="stylesheet" />

    <script type="text/javascript">

        //blocked the entry of some characters
        function BlockChar(field) {
            field = document.getElementById(field);
            let Letters = /[qwertyuiopasdfghjklçzxcvbnm\b]/g
            let Symbols = /[[\]\/{}()*+?%&!?¨:.,;'"<>~=\\^$|#\b]/g
            document.getElementById(field.id).value = document.getElementById(field.id).value.replace(Letters, "");
            document.getElementById(field.id).value = document.getElementById(field.id).value.replace(Symbols, "");

            MaskCEP(field)
        }

        function MaskCEP(field) {

            let fieldFormat = document.getElementById(field.id).value + ""
            if (fieldFormat.length == 5) {
                document.getElementById(field.id).value = fieldFormat + "-"
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ContainerSearch">
        <h1>Search CEP</h1>
        <div class="ContainerSearchBar">
            <asp:TextBox ID="tbCep" runat="server" onKeyUp="BlockChar(this.id)" MaxLength="9" CssClass="SearchBar form-control" placeholder="CEP: 49010-440"></asp:TextBox>
            
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-light" />
        </div>

        <div class="ContainerResultSearch">
            <section class="input-group mb-3">
                <asp:Label ID="Label5" runat="server" Text="State" CssClass="input-group-text"></asp:Label>
                <asp:Label ID="lbState" runat="server" Text="" CssClass="form-control"></asp:Label>
            </section>

            <section class="input-group mb-3">
                <asp:Label ID="Label3" runat="server" Text="District" CssClass="input-group-text"></asp:Label>
                <asp:Label ID="lbDistrict" runat="server" Text="" CssClass="form-control"></asp:Label>
            </section>

            <section class="input-group mb-3">
                <asp:Label ID="Label7" runat="server" Text="City" CssClass="input-group-text"></asp:Label>
                <asp:Label ID="lbCity" runat="server" Text="" CssClass="form-control"></asp:Label>
            </section>

            <section class="input-group mb-3">
                <asp:Label ID="Label1" runat="server" Text="Locality" CssClass="input-group-text"></asp:Label>
                <asp:Label ID="lbLocality" runat="server" Text="" CssClass="form-control"></asp:Label>
            </section>
        </div>

        <div>
            <asp:Label ID="lbMsgError" runat="server" Text="" Visible="false" class="alert alert-danger" role="alert"></asp:Label>
        </div>
    </div>
</asp:Content>
