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
            
            if (!(Session["carrito"]==null))
            {
                foreach(LineaVenta lineaVenta in (List<LineaVenta>)Session["carrito"])
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
                    price.Text = "$ "+ decimal.Round(producto.UnitPrice,2).ToString();
                    row.Cells.Add(price);

                    TableCell subtotal = new TableCell();
                    subtotal.Text = "$ "+ (producto.UnitPrice * lineaVenta.Quantity).ToString();
                    row.Cells.Add(subtotal);

                    asptLineaVenta.Rows.Add(row);
                    totalAr += producto.UnitPrice * lineaVenta.Quantity;
                }              
                
                
            }
            lblTotal.Text = "AR$ " + decimal.Round(totalAr,2).ToString() + " (US$ " + decimal.Round((totalAr * (decimal)usdCurrency), 2).ToString() + ")";
        }

        protected void btnCarga_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Catalog.aspx");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {

                LineaVenta lineaVentaEliminada = new LineaVenta();

                int idLinea = int.Parse(tbxLineaVenta.Text.Replace("PageContent_", ""));
                List<LineaVenta> carrito = (List<LineaVenta>)Session["carrito"];
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
                    Session["carrito"] = null;

                }
                else
                {
                    Session["carrito"] = carrito;
                }
            Response.Redirect("~/Cart.aspx");
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            List<LineaVenta> carrito = (List<LineaVenta>)Session["carrito"];
            Producto producto;
            foreach (LineaVenta lineaVenta in carrito)
            {
                producto= ProductLogic.GetProducto(lineaVenta.ProductId);
                producto.UnitsInStock = (short)(producto.UnitsInStock -lineaVenta.Quantity);
                ProductLogic.Update(producto);
            }
            Session["carrito"] = null;
            Response.Redirect("~/Catalog.aspx");
        }
    }
}