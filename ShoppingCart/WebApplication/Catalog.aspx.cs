using BussinessLogic;
using BussinessLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace UserInterface
{
    public partial class Catalog : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Categoria> categorias = CategoryLogic.GetCategorias();
            List<Producto> productos = ProductLogic.GetListaProductos();
            string state= (string)Session["state"];


            if (state == "modified")
            {
                lblState.CssClass = "modified";
                Session["state"] = "unmodified";
            }
            else if (state == "inputError")
            {
                lblState.CssClass = "inputError";
                Session["state"] = "unmodified";
            }


            try
            {
                foreach (Categoria categoria in categorias)
                {
                    TableRow row = new TableRow();
                    row.ID = categoria.CategoryID.ToString();
                    row.CssClass = "category";

                    TableCell name = new TableCell();
                    name.Text = categoria.CategoryName;
                    row.Cells.Add(name);

                    asptCategorias.Rows.Add(row);

                }

                foreach (Producto producto in productos)
                {
                    TableRow row = new TableRow();
                    row.CssClass = CategoryLogic.GetCategoria(producto.CategoryID).CategoryName.Replace(" ", "_").Replace("/", "_") + " product";

                    TableCell id = new TableCell();
                    id.Text = producto.ProductID.ToString();
                    id.CssClass = "hidden";
                    row.Cells.Add(id);

                    TableCell name = new TableCell();
                    name.Text = producto.ProductName;
                    row.Cells.Add(name);

                    TableCell price = new TableCell();
                    price.Text = decimal.Round(producto.UnitPrice, 2).ToString();
                    row.Cells.Add(price);

                    TableCell stock = new TableCell();
                    if (Session["myCart"] == null)
                    {
                        stock.Text = producto.UnitsInStock.ToString();
                    }
                    else
                    {
                        List<LineaVenta> carrito = (List<LineaVenta>)Session["myCart"];
                        foreach (LineaVenta lineaVenta in carrito)
                        {
                            if (producto.ProductID == lineaVenta.ProductId)
                            {
                                stock.Text = (producto.UnitsInStock - lineaVenta.Quantity).ToString();
                            }
                            else
                            {
                                stock.Text = producto.UnitsInStock.ToString();
                            }
                        }
                    }
                    row.Cells.Add(stock);

                    TableCell supplier = new TableCell();
                    supplier.Text = SupplierLogic.GetSupplierName(producto.SupplierID);
                    supplier.CssClass = "hidden";
                    row.Cells.Add(supplier);

                    TableCell quantityPerUnit = new TableCell();
                    quantityPerUnit.Text = producto.QuantityPerUnit;
                    quantityPerUnit.CssClass = "hidden";
                    row.Cells.Add(quantityPerUnit);

                    asptProductos.Rows.Add(row);
                }
            }
            catch (NullReferenceException)
            {
                lblState.CssClass = "dbConnectionError";
            }

        }            

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            List<LineaVenta> carrito= new List<LineaVenta>();

            LineaVenta nuevaLineaVenta = new LineaVenta();
            LineaVenta antiguaLineaVenta = null;
            Session["state"] = "modified";
            try
            {

                nuevaLineaVenta.ProductId = int.Parse(this.tbxProduct.Text);
                nuevaLineaVenta.Quantity = int.Parse(this.tbxQuantity.Text);
   

                if (!(Session["myCart"] == null))
                {
                    carrito = (List<LineaVenta>)Session["myCart"];
                }
                foreach (LineaVenta lineaVenta in carrito)
                {
                    if (nuevaLineaVenta.ProductId == lineaVenta.ProductId)
                    {
                        nuevaLineaVenta.Quantity += lineaVenta.Quantity;
                        antiguaLineaVenta = lineaVenta;
                    }
                }
                if (nuevaLineaVenta.Quantity < ProductLogic.GetProducto(nuevaLineaVenta.ProductId).UnitsInStock)
                {
                    if (antiguaLineaVenta != null)
                    {
                        carrito.Remove(antiguaLineaVenta);
                    }
                    carrito.Add(nuevaLineaVenta);
                    Session["myCart"] = carrito;
                }
                else
                {
                    Session["state"] = "inputError";
                }
                Response.Redirect("~/Catalog.aspx");
            }
            catch (FormatException)
            {
                Session["state"] = "inputError";
                Response.Redirect("/Catalog.aspx");
            }    
        }
    }
}