<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="UserInterface.Cart" EnableEventValidation="true" %>

<asp:Content ID="Cart" ContentPlaceHolderID="PageContent" runat="server">
    <script type="text/javascript" src="Folders/Cart.js"></script>
    <div class="container">
        <div class="row">
            <div class="col-lg-12" style="height: 50px">
                <asp:Label ID="lblState" runat="server"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div id="colProducts" class="col-md-9 column center-block">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 id="colpProductsHeader">My Cart</h3>
                    </div>
                    <div id="tabProducts" class="panel-body panel-default">
                        <asp:Table ID="asptLineaVenta" CssClass="table table-hover" runat="server">
                            <asp:TableHeaderRow ID="headProducts">
                                <asp:TableCell CssClass="active"><strong>Quantity</strong></asp:TableCell>
                                <asp:TableCell CssClass="active"><strong>Product</strong></asp:TableCell>
                                <asp:TableCell CssClass="active"><strong>Unit Price</strong></asp:TableCell>
                                <asp:TableCell CssClass="active"><strong>Subtotal</strong></asp:TableCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
                    <div class="panel-footer ">
                        <h1>Total:
                            <asp:Label ID="lblTotal" runat="server"></asp:Label></h1>
                        <div>
                            <asp:LinkButton ID="btnCarga" CssClass="btn btn-primary" runat="server" Text="Load another product" Font-Size="X-Large" OnClick="btnCarga_Click" />
                            <asp:LinkButton ID="btnBorrar" CssClass="btn btn-danger" runat="server" Text="Delete" Font-Size="X-Large" OnClick="btnBorrar_Click" />
                            <asp:LinkButton ID="btnFinalizar" CssClass="btn btn-success" runat="server" Text="Checkout" Font-Size="X-Large" OnClick="btnFinalizar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:TextBox ID="tbxLineaVenta" CssClass="hidden" runat="server" />
</asp:Content>
