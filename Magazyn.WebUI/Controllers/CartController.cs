using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;
using Magazyn.WebUI.Models;


namespace Magazyn.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private IOrderProcessor orderProcessor;
        private IZamowienieRepository repository2;
        private IRezerwacjeRepository repository3;

        public CartController(IProductRepository repo, IOrderProcessor proc, IZamowienieRepository repo2, IRezerwacjeRepository repo3)
        {
            repository = repo;
            orderProcessor = proc;
            repository2 = repo2;
            repository3 = repo3;
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        public ViewResult Completed()
        {

            return View();
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            Zamowienie order = new Zamowienie();

            DateTime localdate = DateTime.Now;
            decimal kwota = cart.ComputeTotalValue();


            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Koszyk jest pusty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                order.LoginID = (int)Session["userID"];
                order.Data = localdate;
                order.Cena = kwota;
                order.Complete = true;
                order.Ended = false;

                repository2.SaveZamowienie(order);



                foreach (var line in cart.Lines)
                {
                    Zamowienie orderek = repository2.Zamowienies
                        .FirstOrDefault(o => o.Data == order.Data);


                    Rezerwacje sale = new Rezerwacje();

                    sale.Cena = line.Product.Price;
                    sale.Ilosc = line.Quantity;
                    sale.ZamowienieID = orderek.ZamowienieID;
                    sale.ProductID = line.Product.ProductID;
                    sale.Complete = true;


                    Product product = repository.Products
                    .FirstOrDefault(p => p.ProductID == line.Product.ProductID);
                    int a = line.Quantity;

                    if (a > product.Total)
                    {


                        orderek.Complete = false;
                        sale.Complete = false;

                        repository2.SaveZamowienie(orderek);
                        repository3.SaveRezerwacje(sale);
                    }
                    else
                    {
                        product.Total = product.Total - a;
                        if (a > product.Warehouse1)
                        {
                            a = a - product.Warehouse1;
                            product.Warehouse1 = 0;
                            product.Warehouse2 = product.Warehouse2 - a;
                            a = 0;
                        }
                        else
                        {
                            product.Warehouse1 = product.Warehouse1 - a;
                            a = 0;
                        }

                        repository.SaveTotal(product);
                        repository3.SaveRezerwacje(sale);
                    }
                }



                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }

        }
    }
}




