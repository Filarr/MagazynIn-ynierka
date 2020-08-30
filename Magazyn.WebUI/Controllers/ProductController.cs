using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;
using Magazyn.WebUI.Models;
using Rotativa;

namespace Magazyn.WebUI.Controllers
{
    public class ProductController : Controller
    {
        
        private IProductRepository repository;
        private ILoginRepository repository2;
        private IZamowienieRepository repository3;
        private IKontrahentRepository repository5;

        public int PageSize = 5;
        public ProductController(IProductRepository productRepository, ILoginRepository loginRepository, IZamowienieRepository orderRepository, IKontrahentRepository kontrahentRepository)
        {
            this.repository = productRepository;
            this.repository2 = loginRepository;
            this.repository3 = orderRepository;
            this.repository5 = kontrahentRepository;
        }
        
        public ViewResult List(string category, int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Products.Count() :
                    repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        




        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null) {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else {
                return null;
            }


        }

        public FileContentResult KontrahentGetImage(int kontrahentId)
        {
            Kontrahent prod = repository5.Kontrahents.FirstOrDefault(p => p.KontrahentID == kontrahentId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }

        }

        public PartialViewResult ListaKontrahentow()
        {

            KontrahentListViewModel model = new KontrahentListViewModel
            {
                Kontrahents = repository5.Kontrahents
            };


            return PartialView("ListaKontrahentow",model);
        }

        public ViewResult Formularz()
        {
            return View("Formularz");
        }

        public ViewResult PanelUżytkownika()
        {
            return View("PanelUżytkownika");
        }

        public ViewResult TwojeZamowienia()
        {
            return View(repository3.Zamowienies);
        }

       

        [HttpPost]
        public ActionResult Formularz(FormularzEmail formula)
        {
            if (ModelState.IsValid)
            {
                FormularzEmail email = new FormularzEmail();
                email.To = "mateuszklos95@gmail.com";
                email.Email = formula.Email;
                email.Name = formula.Name.ToString();
                email.Surname = formula.Surname;
                email.Message = formula.Message;
                email.Send();

                ViewBag.Messages = "Wysłano Formularz";
                return View("Formularz");
            }
            else
                ViewBag.Messages = "Nie wysłano formularza, sprawdź poprawność danych albo spróbuj później";
                return View("Formularz");
        }
    }
}