<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="UserInterface.Cart" EnableEventValidation="true" %>


<asp:Content ID="Cart" ContentPlaceHolderID="PageContent" runat="server">
    <script>
        $(document).ready(function () {


            $('.lineaVenta').click(function () {
                $('.lineaVenta').removeClass('info');
                $(this).addClass('info');
                $('#PageContent_tbxLineaVenta').val($(this).attr('id'));
            })

            $('#PageContent_LinkCatalogo').click(function () {
                $('body').fadeOut('fast');
            })
        });

    </script>
    <div class="container-fluid">
        <div class="row">
            <div class="jumbotron" style="background-color: #205db2">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 style="color: white"><span class="glyphicon glyphicon-shopping-cart"></span>Carrito</h1>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div id="colProducts" class="col-md-9 column center-block">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 id="colpProductsHeader">Mi carrito</h3>
                    </div>
                    <div id="tabProducts" class="panel-body panel-default">
                        <asp:Table ID="asptLineaVenta" CssClass="table table-hover" runat="server">
                            <asp:TableHeaderRow ID="headProducts">
                                <asp:TableCell CssClass="active"><strong>Cantidad</strong></asp:TableCell>
                                <asp:TableCell CssClass="active"><strong>Producto</strong></asp:TableCell>
                                <asp:TableCell CssClass="active"><strong>Precio Unitario</strong></asp:TableCell>
                                <asp:TableCell CssClass="active"><strong>Subtotal</strong></asp:TableCell>

                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <h1>Total: <asp:Label ID="lblTotal" runat="server"></asp:Label></h1>
        </div>
        <div class="row">
            <div>
                <asp:LinkButton ID="btnCarga" CssClass="btn btn-primary" runat="server" Text="Cargar otro producto" Font-Size="X-Large" OnClick="btnCarga_Click"/>
                <asp:LinkButton ID="btnBorrar" CssClass="btn btn-danger" runat="server" Text="Borrar" Font-Size="X-Large" OnClick="btnBorrar_Click"/>
                <asp:LinkButton ID="btnFinalizar" CssClass="btn btn-success" runat="server" Text="Finalizar Venta" Font-Size="X-Large" OnClick="btnFinalizar_Click"/>
            </div>
    </div>
    </div>
    <asp:TextBox ID="tbxLineaVenta" CssClass="hidden" runat="server" />
</asp:Content>
