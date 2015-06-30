<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="UserInterface.Catalog" EnableEventValidation="true" %>

<asp:Content ID="Catalog" ContentPlaceHolderID="PageContent" runat="server">
    <script type="text/javascript" src="Folders/Catalog.js"></script>
    <div class="container-fluid" style="min-height: 1000px">
        <div class="row">
            <div class="col-lg-12" style="height: 50px">
                <asp:Label ID="lblState" runat="server"></asp:Label>
            </div>
        </div>
        <div></div>
        <div class="row">
            <div id="colCategory" class="col-md-3 column">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3>Categories</h3>
                    </div>
                    <div class="panel-body panel-default">
                        <asp:Table ID="asptCategorias" CssClass="table table-hover" runat="server"></asp:Table>
                    </div>
                </div>
            </div>
            <div id="colProducts" class="col-md-5 column hidden">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 id="colpProductsHeader">Products</h3>
                    </div>
                    <div id="tabProducts" class="panel-body panel-default">
                        <asp:Table ID="asptProductos" CssClass="table table-hover" runat="server">
                            <asp:TableHeaderRow ID="headProducts">
                                <asp:TableCell CssClass="active"><strong>Products</strong></asp:TableCell>
                                <asp:TableCell CssClass="active"><strong>UnitPrice (Ar$)</strong></asp:TableCell>
                                <asp:TableCell CssClass="active"><strong>Stock</strong></asp:TableCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
                </div>
            </div>
            <div class="col-md-3 column">
                <div class="row">
                    <div id="colDetails" class="panel panel-primary  hidden">
                        <div class="panel-heading">
                            <h3>Product Details</h3>
                        </div>

                        <div class="panel-body">
                            <h4>
                                <label>ID: </label>
                                <span id="lblSelectedProductID"></span></h4>
                            <h4>
                                <label>Name: </label>
                                <span id="lblSelectedProductName"></span></h4>
                            <h4>
                                <label>Unit Price(Ar$): </label>
                                <span id="lblSelectedProductPrice"></span></h4>
                            <h4>
                                <label>Units in stock </label>
                                <span id="lblSelectedProductStock"></span></h4>
                            <h4>
                                <label>Supplider: </label>
                                <span id="lblSelectedProductSupplier"></span></h4>
                            <h4>
                                <label>Quantity: </label>
                                <span id="lblSelectedProductQuantity"></span></h4>
                        </div>
                        <div class="panel-footer">
                            <div class="row">
                                <div class="col-xs-4">
                                    <label style="font-size: 18px">Quantity:</label>
                                    <asp:TextBox ID="tbxQuantity" Width="100px" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-xs-3">
                                    <asp:Button ID="btnAddProduct" Text="Add to MyCart" CssClass="btn btn-info" Height="50px" Font-Size="Large" runat="server" OnClick="btnAdd_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <label id="lblErrorMessage" class="hidden" style="color: red">¡Not enough stock!</label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:TextBox ID="tbxProduct" CssClass="hidden" runat="server" />
</asp:Content>
