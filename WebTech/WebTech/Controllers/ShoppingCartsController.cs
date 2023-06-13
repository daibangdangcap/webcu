using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTech.Models;
namespace WebTech.Controllers
{
    public class ShoppingCartsController : Controller
    {
        // GET: ShoppingCarts
        public ActionResult Index()
        {
            return View();
        }
        DBTechEntities db = new DBTechEntities();

        // GET: ShoppingCart, chuẩn bị dữ liệu cho View

        public ActionResult ShowCart()

        {

            if (Session["Cart"] == null)

                return View("ShowCart");

            Cart _cart = Session["Cart"] as Cart;
            

            return View(_cart);

        }

        // Tạo mới giỏ hàng, nguồn được lấy từ Session

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

        // Thêm sản phẩm vào giỏ hàng

        public ActionResult AddToCart(string name_pro,string username)

        {
            if (username == null) return RedirectToAction("Login","Registers");
            // lấy sản phẩm theo id

            var _pro = db.PRODUCTs.SingleOrDefault(s => s.NAME_PRO == name_pro);

            if (_pro != null)

            {

                GetCart().Add_Product_Cart(_pro);

            }

            return RedirectToAction("ShowCart", "ShoppingCarts");

        }

        // Cập nhật số lượng và tính lại tổng tiền

        public ActionResult Update_Cart_Quantity(FormCollection form)

        {

            Cart cart = Session["Cart"] as Cart;

            string id_pro = Request.Form["idPro"];

            int _quantity = int.Parse(Request.Form["carQuantity"]);

            cart.Update_quantity(id_pro, _quantity);

            return RedirectToAction("ShowCart", "ShoppingCarts");

        }

        // Xóa dòng sản phẩm trong giỏ hàng

        public ActionResult RemoveCart(string id)

        {

            Cart cart = Session["Cart"] as Cart;

            cart.Remove_CartItem(id);

            return RedirectToAction("ShowCart", "ShoppingCarts");

        }
        public PartialViewResult BagCart()

        {

            decimal total_money_item = 0;

            Cart cart = Session["Cart"] as Cart;

            if (cart != null)

                total_money_item = cart.Total_money();

            ViewBag.TotalCart = total_money_item;

            return PartialView("BagCart");

        }
        public ActionResult CheckOut(FormCollection form,string username)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                ORDERPRO _order = new ORDERPRO();
                _order.DATEORDER = DateTime.Now;
                _order.ORDER_ADDRESS = form["AddressDeliverry"];
                _order.USERNAME = username;
                _order.NAMECUSTOMER = form["NameCustomer"];
                _order.SDT = form["SDTCustomer"];
                db.ORDERPROes.Add(_order);
                decimal total = 0;
                foreach (var item in cart.Items)
                {
                    // lưu dòng sản phẩm vào chi tiết hóa đơn

                    ORDERDETAIL _order_detail = new ORDERDETAIL();
                    _order_detail.IDOrder = _order.ID_ORDER;
                    _order_detail.IDProduct = item._product.ID_PRO;
                    _order_detail.UnitPrice = (double)item._product.PRICE;
                    _order_detail.Quantity = item._quantity;
                    db.ORDERDETAILs.Add(_order_detail);
                    PRODUCT pro = db.PRODUCTs.Where(s=>s.ID_PRO==item._product.ID_PRO).FirstOrDefault();
                    pro.QUANTITY = pro.QUANTITY - item._quantity;
                    total = total + (decimal)item._product.PRICE*item._quantity;
                }
                _order.PRICE = total;
                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("CheckOut_Success", "ShoppingCarts");
            }
            catch
            {
                return Content("Có sai sót! Xin kiểm tra lại thông tin"); 
            }

        }
        public ActionResult CheckOut_Success()

        {

            return View();

        }
    }
}