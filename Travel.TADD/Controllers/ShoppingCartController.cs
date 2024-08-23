using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.TADD.Models;
namespace Travel.TADD.Controllers
{

    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        TADDEntities database = new TADDEntities();

        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
                //return RedirectToAction("ShowCart", "ShoppingCart");
                return View("EmptyCart");
            Cart _cart = Session["Cart"] as Cart;
            return View(_cart);
        }
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int id)
        {
            var _pro = database.Products.SingleOrDefault(s => s.ProductID == id);
            if (_pro != null)
            {
                GetCart().Add_Product_Cart(_pro);
            }
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult Update_Cart_Quantity(FormCollection form)
        {

            Cart cart = Session["Cart"] as Cart;

            int id_pro = int.Parse(form["idPro"]);
            int _quantity = int.Parse(form["cartQuantity"]);
            cart.update_quantity(id_pro, _quantity);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            if (cart != null)
                return View("EmptyCart");
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int total_quantity_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                total_quantity_item = cart.Total_quantity();
            ViewBag.QuantityCart = total_quantity_item;
            return PartialView("BagCart");
        }
        public ActionResult CheckOut(FormCollection form)
        {
            if (Session["Cart"] == null)
            {
                return Content("Error checkout. Hãy thêm sản phảm vào giỏ hàng...Thanks.");
            }
            else if (Session["NameUser"] == null)
                {
                    return Content("Error checkout. Hãy đăng nhập tài khoản của bạn để tiếp tục mua hàng!...Thanks.");
                }
                else
                {
                    //try
                    //{
                    Cart cart = Session["Cart"] as Cart;
                    //    OrderPro _order = new OrderPro();
                    //    _order.DateOrder = DateTime.Now;
                    //    _order.AddressDeliverry = form["AddressDelivery"];
                    //    _order.IDCus = int.Parse(form["CodeCustomer"]);
                    //    database.OrderProes.Add(_order);
                    //    foreach (var item in cart.Items)
                    //    {
                    //        OrderDetail _order_detail = new OrderDetail();
                    //        _order_detail.IDOrder = _order.ID;
                    //        _order_detail.IDProduct = item._product.ProductID;
                    //        _order_detail.UnitPrice = (double)item._product.Price;
                    //        _order_detail.Quantity = item._quantity;
                    //        database.OrderDetails.Add(_order_detail);
                    //        foreach (var p in database.Products.Where(s => s.ProductID == _order_detail.IDProduct))
                    //        {
                    //            var update_quan_pro = p.Quatity - item._quantity;
                    //            p.Quatity = update_quan_pro;
                    //        }
                    //    }
                    //database.SaveChanges();
                    cart.ClearCart();
                    return RedirectToAction("CheckOut_Success", "ShoppingCart");
                }
            
           
        }
        public ActionResult CheckOut_Success()
        {
            return View();
        }
    }

}