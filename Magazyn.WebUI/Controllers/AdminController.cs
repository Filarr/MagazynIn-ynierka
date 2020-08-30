using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;
using Magazyn.WebUI.Models;
using iTextSharp;
using iTextSharp.text.pdf;
using Rotativa;

namespace Magazyn.WebUI.Controllers
{

    public class AdminController : Controller
    {
        private IProductRepository repository;
        private ILoginRepository repository2;
        private IZamowienieRepository repository3;
        private IRezerwacjeRepository repository4;
        private IKontrahentRepository repository5;
        private ISetRepository repository6;
        private ICategoryRepository repository7;
        private IPWRepository repository8;
        private IPZRepository repository9;
        private IRWRepository repository10;
        private IRZRepository repository11;
        private IProductNameRepository repository12;
    

        public AdminController(IProductRepository repo, ILoginRepository repo2, IZamowienieRepository repo3, IRezerwacjeRepository repo4,IKontrahentRepository repo5,ISetRepository repo6, ICategoryRepository repo7, IPWRepository repo8, IPZRepository repo9, IRWRepository repo10, IRZRepository repo11, IProductNameRepository repo12) {
            repository = repo;
            repository2 = repo2;
            repository3 = repo3;
            repository4 = repo4;
            repository5 = repo5;
            repository6 = repo6;
            repository7 = repo7;
            repository8 = repo8;
            repository9 = repo9;
            repository10 = repo10;
            repository11 = repo11;
            repository12 = repo12;
        }


        public ViewResult Index() {
            return View(repository12.ProductNames);
        }

        public ViewResult Index2()
        {
            return View(repository.Products);
        }

        public ViewResult Zestaw()
        {
            return View(repository6.Sets);
        }

        public ViewResult DaneUżytkowników()
        {
            return View(repository2.Logins);
        }

        public ViewResult Zamowienia()
        {
            return View(repository3.Zamowienies);
        }

        public ViewResult Kontrahent()
        {
            return View(repository5.Kontrahents);
        }

        public ViewResult Kategorie()
        {
            return View(repository7.Categorys);
        }
     
        public ViewResult PW()
        {
            return View(repository8.PWs);
        }
        public ViewResult PZ()
        {
            return View(repository9.PZs);
        }
        public ViewResult RW()
        {
            return View(repository10.RWs);
        }
        public ViewResult RZ()
        {
            return View(repository11.RZs);
        }


        public ActionResult PrintAl()
        {
            var q = new ActionAsPdf("Index2", new { name = "Admin" }) { FileName = "ListaTowarów.pdf" };
            return q;
        }

        public ActionResult PrintAll()
        {
            var q = new ActionAsPdf("DaneUżytkowników");
            return q;
        }

        public ActionResult PrintAlll()
        {
            var q = new ActionAsPdf("Zamowienia");
            return q;
        }

        public ActionResult PrintAllll()
        {
            var q = new ActionAsPdf("Magazyn");
            return q;
        }

        public ActionResult DokumentyDrukujPZ(int PZId)
        {
            PZ abc = repository9.PZs
                .FirstOrDefault(p => p.PZID == PZId);

             return new ActionAsPdf("DokumentyPZ", abc) { FileName = "PZ.pdf" };
            
        }

        public ViewResult DokumentyPZ(int PZId)
        {
            PZ abc = repository9.PZs
               .FirstOrDefault(p => p.PZID == PZId);
            return View(abc);
        }


        public ViewResult Magazyn()
        {
            return View(repository4.Rezerwacjes);
        }


        public ViewResult Edit(int productNameId) {

            ProductName productname = repository12.ProductNames
                .FirstOrDefault(p => p.ProductNameID == productNameId);

            ViewBag.kategorie = repository7.Categorys;

            return View(productname);
        }

        public ViewResult EditKontrahent(int kontrahentId)
        {
            Kontrahent kontrahent = repository5.Kontrahents
                .FirstOrDefault(p => p.KontrahentID == kontrahentId);
            return View(kontrahent);
        }

        public ViewResult EditKategorie(int categorieId)
        {
            Category kategorie = repository7.Categorys
                .FirstOrDefault(p => p.CategoryID == categorieId);
            return View(kategorie);
        }

        public ViewResult DodawanieProduktów(int productId)
        {
            DodajProduktView dodaj = new DodajProduktView();

            dodaj.product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);


            return View(dodaj);
        }

        public ViewResult ŚciąganieProduktów(int productId)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }

  

        public ViewResult EditUser(int loginID)
        {
            Login login = repository2.Logins
                .FirstOrDefault(p => p.LoginID == loginID);
            return View(login);
        }

      

        public ViewResult BrakTowaru(int productId)
        {
            ProductName product = repository12.ProductNames
                .FirstOrDefault(p => p.ProductID == productId);

            var model = new BrakTowaruEmail();

            model.Name = product.Name;

            ViewBag.kontrahenci = repository5.Kontrahents;
  

            return View(model);
        }


        [HttpPost]
        public ActionResult DodawanieProduktów(DodajProduktView dodaj)
        {
            DateTime localdate = DateTime.Now;
            
            PZ przychodzewnetrzny = new PZ();

            
            
            repository9.SavePZ(przychodzewnetrzny);
            TempData["message"] = string.Format("Zapisano {0} ");
                return RedirectToAction("Index");
         }

        [HttpPost]
        public ActionResult CreateZestaw(DodajProduktView dodaj)
        {
            DateTime localdate = DateTime.Now;
            Product product = new Product();
            Product product1 = new Product();
            Product product2 = new Product();
            Product product3 = new Product();
            Product product4 = new Product();
            Product product5 = new Product();

            PW przychodwewmetrzny = new PW();
            RW rozchodwewnetrzny = new RW();
            Set zestaw = new Set();

            Login uzytkwonik = repository2.Logins
                .FirstOrDefault(p => p.LoginID == (int)Session["userID"]);

            if(dodaj.zestaw.Name==null|| dodaj.zestaw.ProduktName1==null)
            {
                TempData["message"] = string.Format("Błąd danych. Spróbuj ponownie {0} ", dodaj.zestaw.Name);
                return RedirectToAction("Zestaw");
            }

           


            TempData["message"] = string.Format("Zapisano {0} ");
            return RedirectToAction("Zestaw");
        }

        [HttpPost]
        public ActionResult ŚciąganieProduktów(Product product)
        {
            DateTime localdate = DateTime.Now;
            Product product2 = repository.Products
            .FirstOrDefault(p => p.ProductID == product.ProductID);

            Login uzytkwonik = repository2.Logins
               .FirstOrDefault(p => p.LoginID == (int)Session["userID"]);

            RW rozchodwewnetrzny = new RW();

           


                
                repository.SaveProduct(product2);
                repository10.SaveRW(rozchodwewnetrzny);
               
                TempData["message"] = string.Format("Zapisano {0} ", product.ProductID);

                return RedirectToAction("Index");
            
            

        }

        [HttpPost]
        public ActionResult Edit(ProductName product, HttpPostedFileBase image = null)
        {
            ViewBag.kategorie = repository7.Categorys;
            if (ModelState.IsValid) {
                Category kategorie = repository7.Categorys
                .FirstOrDefault(p => p.Name == product.Category);

                product.CategoryID = kategorie.CategoryID;
                

                if (image != null) {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository12.SaveProductName(product);
                TempData["message"] = string.Format("Zapisano {0} ", product.Name);
                return RedirectToAction("Index"); }
            else
            {
                // błąd w wartościach danych                
                return View(product);
            }
        }

         [HttpPost]
        public ActionResult EditKontrahent(Kontrahent kontrahent, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid) {
                if (image != null) {
                    kontrahent.ImageMimeType = image.ContentType;
                    kontrahent.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(kontrahent.ImageData, 0, image.ContentLength);
                }
                repository5.SaveKontrahent(kontrahent);
                TempData["message"] = string.Format("Zapisano {0} ", kontrahent.NazwaKontrahenta);
                return RedirectToAction("Kontrahent"); }
            else
            {
                // błąd w wartościach danych                
                return View(kontrahent);
            }
        }

        [HttpPost]
        public ActionResult BrakTowaru(BrakTowaruEmail formula)
        {


            Kontrahent kontrahent = repository5.Kontrahents
                .FirstOrDefault(p => p.KontrahentID ==  Int32.Parse(formula.Kontrahent));

            if (ModelState.IsValid)
            {
                BrakTowaruEmail email = new BrakTowaruEmail();

                ViewBag.kontrahenci= repository5.Kontrahents;


                email.Name = formula.Name;
                email.Ilość = formula.Ilość;
                email.Kontrahent = kontrahent.NazwaKontrahenta;
                email.emaill = kontrahent.Email;
                email.Send();

                ViewBag.Messages = "Wysłano Formularz";
                return View();
            }
            else
                return View("BrakTowaru");
        }

        [HttpPost]
        public ActionResult EditUser(Login login)
        {
            if (ModelState.IsValid)
            {
                repository2.SaveLogin(login);
                TempData["message"] = string.Format("Zapisano {0} ", login.User);
                return RedirectToAction("DaneUżytkowników");
            }
            else
            {
                // błąd w wartościach danych                
                return View(login);
            }
        }

        [HttpPost]
        public ActionResult EditKategorie(Category kategorie)
        {
            if (ModelState.IsValid)
            {
                repository7.SaveCategory(kategorie);
                TempData["message"] = string.Format("Zapisano {0} ", kategorie.Name);
                return RedirectToAction("Kategorie");
            }
            else
            {
                // błąd w wartościach danych                
                return View(kategorie);
            }
        }



        public ActionResult ActivateUser(Login login)
        {
            repository2.Active(login);
            TempData["message"] = string.Format("Aktywowano {0} ", login.User);
            return RedirectToAction("DaneUżytkowników");
        }

        public ActionResult ZakonczZamowienie(Zamowienie order)
        {
            DateTime localdate = DateTime.Now;

            

            Zamowienie zamowienie = repository3.Zamowienies
            .FirstOrDefault(p => p.ZamowienieID == order.ZamowienieID);

            Login uzytkwonik = repository2.Logins
               .FirstOrDefault(p => p.LoginID == zamowienie.LoginID);

            Login wystawaiajacy = repository2.Logins
                .FirstOrDefault(p => p.LoginID == (int)Session["userID"]);

            if (zamowienie.Complete==false)
            {
                TempData["message"] = string.Format("Skomplentuj najpierw zamówienie : ", order.ZamowienieID);
                return RedirectToAction("Zamowienia");
            }

            RZ rozchodzewnetrzny = new RZ();

            

            repository3.SaveZamowienie(zamowienie);

            repository11.SaveRZ(rozchodzewnetrzny);


            TempData["message"] = string.Format("Zakończono zamówienie {0} ", order.ZamowienieID);
            return RedirectToAction("Zamowienia");
        }

        public ActionResult Braki(Zamowienie order)
        {
            DateTime localdate = DateTime.Now;

            Zamowienie zamowienie = repository3.Zamowienies
            .FirstOrDefault(p => p.ZamowienieID == order.ZamowienieID);

            Login uzytkwonik = repository2.Logins
               .FirstOrDefault(p => p.LoginID == zamowienie.LoginID);

            var wypelniono = true;

            foreach (var item in repository4.Rezerwacjes.ToList())
            {
                if (item.ZamowienieID == order.ZamowienieID)
                {
                    if (item.Complete == false)
                    {
                        Product product = repository.Products
                        .FirstOrDefault(p => p.ProductID == item.ProductID);

                        int a = item.Ilosc;

                        if (a > product.Total)
                        {
                            wypelniono = false;
                            TempData["message"] = string.Format("Nie uzupełniono produkt ", item.ProductID);
                        }
                        else
                        {
                            product.Total = product.Total - a;
                            

                            item.Complete = true;
                            TempData["message"] = string.Format("Uzupełniono o produkt ", item.ProductID);
                            repository4.SaveRezerwacje(item);
                            repository.SaveProduct(product);
                        }
                    }
                }
            }

            if (wypelniono == true)
            {
                zamowienie.Complete = true;
                repository3.SaveZamowienie(zamowienie);
                TempData["message"] = string.Format("Zakończono zamówienie {0} ", order.ZamowienieID);
                return RedirectToAction("Zamowienia");

            }
            else
            {
                TempData["message"] = string.Format("Nie wszystkie braki zostały uzupełnione, domów towar dla zamówienia {0} ", order.ZamowienieID);
                return RedirectToAction("Zamowienia");
            }
        }


        public ActionResult DeActivateUser(Login login)
        {
            repository2.DeActive(login);
            TempData["message"] = string.Format("Deaktywowano {0} ", login.User);
            return RedirectToAction("DaneUżytkowników");
        }

        public ViewResult Create() {
            ViewBag.kategorie = repository7.Categorys;
            return View("Edit", new ProductName());
        }

        public ViewResult CreateZestaw()
        {
            DodajProduktView dodaj = new DodajProduktView
            {
                Products = repository.Products,
            };

            return View("CreateZestaw", dodaj);
        }

        public ViewResult CreateKontrahent()
        {
            return View("EditKontrahent", new Kontrahent());
        }

        public ViewResult CreateKategorie()
        {
            return View("EditKategorie", new Category());
        }

        public ViewResult CreateUser()
        {
            return View("EditUser", new Login());
        }

        [HttpPost]
        public ActionResult Delete(int productId) {
            ProductName deletedProduct = repository12.DeleteProductName(productId);
            if (deletedProduct != null) {
                TempData["message"] = string.Format("Usunięto {0}", deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteKontrahent(int kontrahentId)
        {
            Kontrahent deletedKontrahent = repository5.DeleteKontrahent(kontrahentId);
            if (deletedKontrahent != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", deletedKontrahent.NazwaKontrahenta);
            }
            return RedirectToAction("Kontrahent");
        }

        [HttpPost]
        public ActionResult DeleteKategorie(int kategorieId)
        {
            Category deletedKategorie = repository7.DeleteCategory(kategorieId);
            if (deletedKategorie != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", deletedKategorie.Name);
            }
            return RedirectToAction("Kategorie");
        }

        [HttpPost]
        public ActionResult DeleteUser(int loginId)
        {
            Login deletedUser = repository2.DeleteLogin(loginId);
            if (deletedUser != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", deletedUser.User);
            }
            return RedirectToAction("DaneUżytkowników");
        }


        [HttpPost]
        public ActionResult DeleteZestaw(int productId)
        {
            DateTime localdate = DateTime.Now;

            Login uzytkwonik = repository2.Logins
                .FirstOrDefault(p => p.LoginID == (int)Session["userID"]);

            Set zestawik = repository6.Sets
            .FirstOrDefault(p => p.ProductID == productId);

            Product product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);

            Product product1 = new Product();
            Product product2 = new Product();
            Product product3 = new Product();
            Product product4 = new Product();
            Product product5 = new Product();

            PW przychodwewmetrzny = new PW();
            RW rozchodwewnetrzny = new RW();

            

            
           
            
            
            

            repository8.SavePW(przychodwewmetrzny);
            repository10.SaveRW(rozchodwewnetrzny);

            Set deletedZestaw = repository6.DeleteZestaw(zestawik.SetID);
 
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Usunięto {0}");
            }
            return RedirectToAction("Zestaw");
        }











    }
}