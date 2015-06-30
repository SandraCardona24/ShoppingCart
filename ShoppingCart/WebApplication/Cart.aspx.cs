using BussinessLogic;
using BussinessLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserInterface.CurrencyConvertorService;

namespace UserInterface
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            decimal totalAr = 0;
            CurrencyConvertorSoapClient client = new CurrencyConvertorSoapClient();
            double usdCurrency =  client.ConversionRate(Currency.ARS, Currency.USD);
            string state=(string)Session["state"];

            if (state == "deleteError")
            {
                lblState.CssClass = "deleteError";
                Session["state"] = "unmodified";
            }
            else if (state == "purchaseCompleted") 
            {
                lblState.CssClass = "purchaseCompleted";
                Session["state"] = "unmodified";
            }
            try
            {
                if (!(Session["myCart"] == null))
                {
                    foreach (LineaVenta lineaVenta in (List<LineaVenta>)Session["myCart"])
                    {

                        Producto producto = ProductLogic.GetProducto(lineaVenta.ProductId);

                        TableRow row = new TableRow();
                        row.ID = producto.ProductID.ToString();
                        row.CssClass = "lineaVenta";

                        TableCell quantity = new TableCell();
                        quantity.Text = lineaVenta.Quantity.ToString();
                        row.Cells.Add(quantity);

                        TableCell name = new TableCell();
                        name.Text = producto.ProductName;
                        row.Cells.Add(name);

                        TableCell price = new TableCell();
                        price.Text = "$ " + decimal.Round(producto.UnitPrice, 2).ToString();
                        row.Cells.Add(price);

                        TableCell subtotal = new TableCell();
                        subtotal.Text = "$ " + decimal.Round((producto.UnitPrice * lineaVenta.Quantity), 2).ToString();
                        row.Cells.Add(subtotal);

                        asptLineaVenta.Rows.Add(row);
                        totalAr += producto.UnitPrice * lineaVenta.Quantity;
                    }
                }
                lblTotal.Text = "AR$ " + decimal.Round(totalAr, 2).ToString() + " (US$ " + decimal.Round((totalAr * (decimal)usdCurrency), 2).ToString() + ")";
            }
            catch (NullReferenceException)
            {
                lblState.CssClass = "dbConnectionError";
            }
            
        }

        protected void btnCarga_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Catalog.aspx");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {

                LineaVenta lineaVentaEliminada = new LineaVenta();
                if (tbxLineaVenta.Text != "")
                {
                    int idLinea = int.Parse(tbxLineaVenta.Text.Replace("PageContent_", ""));
                    List<LineaVenta> carrito = (List<LineaVenta>)Session["myCart"];
                    foreach (LineaVenta lineaVenta in carrito)
                    {
                        if (lineaVenta.ProductId == idLinea)
                        {
                            lineaVentaEliminada = lineaVenta;
                        }
                    }
                    carrito.Remove(lineaVentaEliminada);
                    if (carrito.Count == 0)
                    {
                        Session["myCart"] = null;

                    }
                    else
                    {
                        Session["myCart"] = carrito;
                    }
                }
                else
                {
                    Session["state"] = "deleteError";
 
                }
            Response.Redirect("~/Cart.aspx");
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {

            List<LineaVenta> carrito = (List<LineaVenta>)Session["myCart"];
            lblState.CssClass = "purchaseCompleted";
            Producto producto;
            try{
                    foreach (LineaVenta lineaVenta in carrito)
                    {
                        try 
                        {	        
                        producto = ProductLogic.GetProducto(lineaVenta.ProductId);
                        producto.UnitsInStock = (short)(producto.UnitsInStock - lineaVenta.Quantity);
                        ProductLogic.Update(producto);	
                        }
                        catch (NullReferenceException)
                        {
                            lblState.CssClass = "dbConnectionError" ;
                        }
                    }
                    Session["myCart"] = null;
                    Response.Redirect("~/Catalog.aspx");
                }
                catch (NullReferenceException)
                {
                    lblState.CssClass = "invalidAction";
                }
        }
    }
}