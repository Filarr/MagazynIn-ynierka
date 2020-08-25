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
        private IOrderRepository repository3;
        private ISaleRepository repository4;
        private IPartnerRepository repository5;
        private ISetRepository repository6;
        private IMMRepository repository7;
        private IPWRepository repository8;
        private IPZRepository repository9;
        private IRWRepository repository10;
        private IRZRepository repository11;
    

        public AdminController(IProductRepository repo, ILoginRepository repo2, IOrderRepository repo3, ISaleRepository repo4,IPartnerRepository repo5,ISetRepository repo6, IMMRepository repo7, IPWRepository repo8, IPZRepository repo9, IRWRepository repo10, IRZRepository repo11) {
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
        }


        public ViewResult Index() {
            return View(repository.Products);
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
            return View(repository3.Orders);
        }

        public ViewResult Partner()
        {
            return View(repository5.Partners);
        }

        public ViewResult MM()
        {
            return View(repository7.MMs);
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
        public ActionResult DokumentyDrukujMM(int MMId)
        {
            MM abc = repository7.MMs
                .FirstOrDefault(p => p.MMID == MMId);

            return new ActionAsPdf("DokumentyMM", abc) { FileName = "MM.pdf" };

        }

        public ViewResult DokumentyMM(int MMId)
        {
            MM abc = repository7.MMs
                .FirstOrDefault(p => p.MMID == MMId);
            return View(abc);
        }


        public ViewResult DokumentyPZ(int PZId)
        {
            PZ abc = repository9.PZs
               .FirstOrDefault(p => p.PZID == PZId);
            return View(abc);
        }


        public ViewResult Magazyn()
        {
            return View(repository4.Sales);
        }


        public ViewResult Edit(int productId) {

            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

      
            return View(product);
        }

        public ViewResult EditPartner(int partnerId)
        {
            Partner partner = repository5.Partners
                .FirstOrDefault(p => p.PartnerID == partnerId);
            return View(partner);
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

        public ViewResult PrzesuniecieMagazynowe(int productId)
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
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);


            var model = new BrakTowaruEmail();

            model.Name = product.Name;

            return View(model);
        }


        [HttpPost]
        public ActionResult DodawanieProduktów(DodajProduktView dodaj)
        {
            DateTime localdate = DateTime.Now;
            Product product2 = repository.Products
            .FirstOrDefault(p => p.Name == dodaj.product.Name);

            PZ przychodzewnetrzny = new PZ();

            Login uzytkwonik = repository2.Logins
                .FirstOrDefault(p => p.LoginID == (int)Session["userID"]);

            if (dodaj.przychodZewnetrzny.Magazyn.Equals("Magazyn 1"))
            {
                var nowa_sredniacena = ((product2.Total * product2.Price) + (dodaj.product.Total * dodaj.przychodZewnetrzny.Cena)) / (product2.Total + dodaj.product.Total);
                product2.Warehouse1 = product2.Warehouse1 + dodaj.product.Total;
                product2.Total = product2.Total + dodaj.product.Total;
                product2.Price = nowa_sredniacena;
            }
            else if (dodaj.przychodZewnetrzny.Magazyn.Equals("Magazyn 2"))
            {
                var nowa_sredniacena = ((product2.Total * product2.Price) + (dodaj.product.Total * dodaj.przychodZewnetrzny.Cena)) / (product2.Total + dodaj.product.Total);
                product2.Warehouse1 = product2.Warehouse2 + dodaj.product.Total;
                product2.Total = product2.Total + dodaj.product.Total;
                product2.Price = nowa_sredniacena;
            }
            else
            {
                TempData["message"] = string.Format("Błąd danych. Spróbuj ponownie {0} ", dodaj.product.Name);
                return RedirectToAction("Index");
            }

            przychodzewnetrzny.Wystawiajacy = uzytkwonik.User;
            przychodzewnetrzny.Miesiac = localdate.Month;
            przychodzewnetrzny.Rok = localdate.Year;
            przychodzewnetrzny.Adres = dodaj.przychodZewnetrzny.Adres;
            przychodzewnetrzny.Miasto = dodaj.przychodZewnetrzny.Miasto;
            przychodzewnetrzny.KodPocztowy = dodaj.przychodZewnetrzny.KodPocztowy;
            przychodzewnetrzny.DataWystawienia = localdate;
            przychodzewnetrzny.Ilosc = dodaj.product.Total;
            przychodzewnetrzny.Kontrahent = dodaj.przychodZewnetrzny.Kontrahent;
            przychodzewnetrzny.Produkt = dodaj.product.Name;
            przychodzewnetrzny.Cena = dodaj.przychodZewnetrzny.Cena;
            przychodzewnetrzny.CenaCalkowita = dodaj.przychodZewnetrzny.Cena * dodaj.product.Total;
            przychodzewnetrzny.Magazyn = dodaj.przychodZewnetrzny.Magazyn;


            repository.SaveProduct(product2);
            repository9.SavePZ(przychodzewnetrzny);
            TempData["message"] = string.Format("Zapisano {0} ", dodaj.product.Name);
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

            product.Category = "Zestaw";
            product.Description = "Zestaw produktów:";
            product.Name = dodaj.zestaw.Name;
            product.Price = 0;
            product.Total = dodaj.product.Total;
            product.Warehouse1 = dodaj.product.Total;
            product.Warehouse2 = 0;

            rozchodwewnetrzny.DataWystawienia = localdate;
            rozchodwewnetrzny.Miesiac = localdate.Month;
            rozchodwewnetrzny.Rok = localdate.Year;
            rozchodwewnetrzny.Wystawiajacy = uzytkwonik.Name;
            rozchodwewnetrzny.CenaCalkowita = 0;
            

            przychodwewmetrzny.DataWystawienia = localdate;
            przychodwewmetrzny.Magazyn = "Magazyn 1";
            przychodwewmetrzny.Miesiac = localdate.Month;
            przychodwewmetrzny.Rok = localdate.Year;
            przychodwewmetrzny.Wystawiajacy = uzytkwonik.Name;
            przychodwewmetrzny.Produkt = dodaj.zestaw.Name;
            przychodwewmetrzny.Ilosc = dodaj.product.Total;
            przychodwewmetrzny.CenaCalkowita = 0;

            zestaw.Name = dodaj.zestaw.Name;
            zestaw.ProduktName1 = dodaj.zestaw.ProduktName1;
            zestaw.ProduktName2 = dodaj.zestaw.ProduktName2;
            zestaw.ProduktName3 = dodaj.zestaw.ProduktName3;
            zestaw.ProduktName4 = dodaj.zestaw.ProduktName4;
            zestaw.ProduktName5 = dodaj.zestaw.ProduktName5;





            product1 = repository.Products
                    .FirstOrDefault(p => p.Name == dodaj.zestaw.ProduktName1);
            product2 = repository.Products
                .FirstOrDefault(p => p.Name == dodaj.zestaw.ProduktName2);
            product3 = repository.Products
                .FirstOrDefault(p => p.Name == dodaj.zestaw.ProduktName3);
            product4 = repository.Products
                    .FirstOrDefault(p => p.Name == dodaj.zestaw.ProduktName4);
            product5 = repository.Products
                    .FirstOrDefault(p => p.Name == dodaj.zestaw.ProduktName5);

           if(product1.Total < dodaj.product.Total)
            {
                TempData["message"] = string.Format("Nie wystarczająco produktów na magazynie {0} ", dodaj.zestaw.ProduktName1);
                return RedirectToAction("Zestaw");
            }
            else
            {
                var z = dodaj.product.Total;
                product1.Total -= dodaj.product.Total;
                if(product1.Warehouse1<z)
                {
                    z -= product1.Warehouse1;
                    product1.Warehouse1 = 0;
                    product1.Warehouse2 -= z;
                }
                else
                {
                    product1.Warehouse1 -= z;
                }
                rozchodwewnetrzny.CenaCalkowita += product1.Price * dodaj.product.Total;
                rozchodwewnetrzny.Produkty += product1.Name + "\t" + product1.Price + "\n";
                product.Description += product1.Name + ",";
                repository.SaveProduct(product1);
            }

           if(product2 != null)
            {
                if (product2.Total < dodaj.product.Total)
                {
                    TempData["message"] = string.Format("Nie wystarczająco produktów na magazynie {0} ", dodaj.zestaw.ProduktName2);
                    return RedirectToAction("Zestaw");
                }
                else
                {
                    var z = dodaj.product.Total;
                    product2.Total -= dodaj.product.Total;
                    if (product2.Warehouse1 < z)
                    {
                        z -= product1.Warehouse1;
                        product2.Warehouse1 = 0;
                        product2.Warehouse2 -= z;
                    }
                    else
                    {
                        product2.Warehouse1 -= z;
                    }
                    rozchodwewnetrzny.CenaCalkowita += product2.Price * dodaj.product.Total;
                    rozchodwewnetrzny.Produkty += product2.Name + "\t" + product2.Price + "\n";
                    product.Description += product2.Name + ",";
                    repository.SaveProduct(product2);
                }

            }

            if (product3 != null)
            {
                if (product3.Total < dodaj.product.Total)
                {
                    TempData["message"] = string.Format("Nie wystarczająco produktów na magazynie {0} ", dodaj.zestaw.ProduktName3);
                    return RedirectToAction("Zestaw");
                }
                else
                {
                    var z = dodaj.product.Total;
                    product3.Total -= dodaj.product.Total;
                    if (product3.Warehouse1 < z)
                    {
                        z -= product1.Warehouse1;
                        product3.Warehouse1 = 0;
                        product3.Warehouse2 -= z;
                    }
                    else
                    {
                        product3.Warehouse1 -= z;
                    }
                    rozchodwewnetrzny.CenaCalkowita += product3.Price * dodaj.product.Total;
                    rozchodwewnetrzny.Produkty += product3.Name + "\t" + product3.Price +"\n";
                    product.Description += product3.Name + ",";
                    repository.SaveProduct(product3);
                }

            }

            if (product4 != null)
            {
                if (product4.Total < dodaj.product.Total)
                {
                    TempData["message"] = string.Format("Nie wystarczająco produktów na magazynie {0} ", dodaj.zestaw.ProduktName4);
                    return RedirectToAction("Zestaw");
                }
                else
                {
                    var z = dodaj.product.Total;
                    product4.Total -= dodaj.product.Total;
                    if (product4.Warehouse1 < z)
                    {
                        z -= product1.Warehouse1;
                        product4.Warehouse1 = 0;
                        product4.Warehouse2 -= z;
                    }
                    else
                    {
                        product4.Warehouse1 -= z;
                    }
                    rozchodwewnetrzny.CenaCalkowita += product4.Price * dodaj.product.Total;
                    rozchodwewnetrzny.Produkty += product4.Name + "\t" + product4.Price + "\n";
                    product.Description += product4.Name + ",";
                    repository.SaveProduct(product4);
                }

            }

            if (product5 != null)
            {
                if (product5.Total < dodaj.product.Total)
                {
                    TempData["message"] = string.Format("Nie wystarczająco produktów na magazynie {0} ", dodaj.zestaw.ProduktName5);
                    return RedirectToAction("Zestaw");
                }
                else
                {
                    var z = dodaj.product.Total;
                    product5.Total -= dodaj.product.Total;
                    if (product5.Warehouse1 < z)
                    {
                        z -= product1.Warehouse1;
                        product5.Warehouse1 = 0;
                        product5.Warehouse2 -= z;
                    }
                    else
                    {
                        product5.Warehouse1 -= z;
                    }
                    rozchodwewnetrzny.CenaCalkowita += product5.Price * dodaj.product.Total;
                    rozchodwewnetrzny.Produkty += product5.Name + "\t" + product5.Price + "\n";
                    product.Description += product5.Name + ",";
                    repository.SaveProduct(product5);
                }

            }

            przychodwewmetrzny.CenaCalkowita = rozchodwewnetrzny.CenaCalkowita;
            product.Price = rozchodwewnetrzny.CenaCalkowita / dodaj.product.Total;
            zestaw.Cena = product.Price;

            repository.SaveProduct(product);
            
            

            zestaw.ProductID = product.ProductID;
            repository8.SavePW(przychodwewmetrzny);
            repository10.SaveRW(rozchodwewnetrzny);
            repository6.SaveSet(zestaw);


            TempData["message"] = string.Format("Zapisano {0} ", dodaj.product.Name);
            return RedirectToAction("Zestaw");
        }


        [HttpPost]
        public ActionResult PrzesuniecieMagazynowe(Product product)
        {
            DateTime localdate = DateTime.Now;
            Product product2 = repository.Products
            .FirstOrDefault(p => p.ProductID == product.ProductID);

            Login uzytkwonik = repository2.Logins
                .FirstOrDefault(p => p.LoginID == (int)Session["userID"]);


            MM dokumentprzesuniecia = new MM();
            dokumentprzesuniecia.Wystawiajacy = uzytkwonik.User;
            dokumentprzesuniecia.Miesiac = localdate.Month;
            dokumentprzesuniecia.Rok = localdate.Year;
            dokumentprzesuniecia.DataWystawienia = localdate;
            dokumentprzesuniecia.NazwaProduktu = product.Name;


            if (product.Warehouse1 == 0 && product.Warehouse2 == 0)
            {
                TempData["message"] = string.Format("Błąd danych. Spróbuj ponownie {0} ", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                if (product2.Total != (product.Warehouse1 + product.Warehouse2))
                {
                    TempData["message"] = string.Format("Błąd danych. Spróbuj ponownie {0} ", product.Name);
                    return RedirectToAction("Index");
                }
                else
                {
                    if (product.Warehouse1 > product2.Warehouse1)
                    {
                        int z = product2.Warehouse1-product.Warehouse1 ;
                        dokumentprzesuniecia.MagazynPrzyjmujacy = "Magazyn 1";
                        dokumentprzesuniecia.MagazynWydajacy = "Magazyn 2";
                        dokumentprzesuniecia.Ilosc = z;
                    } else
                        if (product.Warehouse2 > product2.Warehouse2)
                            {
                                 int z = product.Warehouse2 - product2.Warehouse2;
                                 dokumentprzesuniecia.MagazynPrzyjmujacy = "Magazyn 2";
                                 dokumentprzesuniecia.MagazynWydajacy = "Magazyn 1";
                                 dokumentprzesuniecia.Ilosc = z;
                            }
                            else
                                {
                                TempData["message"] = string.Format("Błąd danych. Spróbuj ponownie {0} ", product.Name);
                                return RedirectToAction("Index");
                                }



                    product2.Warehouse1 = product.Warehouse1;
                    product2.Warehouse2 = product.Warehouse2;
                    repository7.SaveMM(dokumentprzesuniecia);
                    repository.SaveProduct(product2);
                    TempData["message"] = string.Format("Zapisano {0} ", product.Name);
                    return RedirectToAction("Index");
                }
            }
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

            rozchodwewnetrzny.DataWystawienia = localdate;
            rozchodwewnetrzny.Miesiac = localdate.Month;
            rozchodwewnetrzny.Rok = localdate.Year;
            rozchodwewnetrzny.Wystawiajacy = uzytkwonik.User;
            rozchodwewnetrzny.Produkty = product.Name + "\t" +(product.Warehouse1+product.Warehouse2);
            rozchodwewnetrzny.CenaCalkowita = product.Price * (product.Warehouse1 + product.Warehouse2);

            if (product.Warehouse1 == 0 && product.Warehouse2 == 0)
            {
                TempData["message"] = string.Format("Błąd danych. Spróbuj ponownie {0} ", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                if(product.Warehouse1!=0)
                {
                    if(product.Warehouse1>product2.Warehouse1)
                    {
                        TempData["message"] = string.Format("Błąd danych. Spróbuj ponownie {0} ", product.Name);
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        product2.Warehouse1 -= product.Warehouse1;
                        product2.Total -= product.Warehouse1;
                        
                    }
                }

                if(product.Warehouse2!=0)
                {

                    if (product.Warehouse2 > product2.Warehouse2)
                    {
                        TempData["message"] = string.Format("Błąd danych. Spróbuj ponownie {0} ", product.Name);
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        product2.Warehouse2 -= product.Warehouse2;
                        product2.Total -= product.Warehouse2;
                    }
                }


                product2.Total = product2.Warehouse1 + product2.Warehouse2;
                repository.SaveProduct(product2);
                repository10.SaveRW(rozchodwewnetrzny);
               
                TempData["message"] = string.Format("Zapisano {0} ", product.Name);

                return RedirectToAction("Index");
            }
            

        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid) {
                if (image != null) {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("Zapisano {0} ", product.Name);
                return RedirectToAction("Index"); }
            else
            {
                // błąd w wartościach danych                
                return View(product);
            }
        }

         [HttpPost]
        public ActionResult EditPartner(Partner partner, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid) {
                if (image != null) {
                    partner.PartnerImageMimeType = image.ContentType;
                    partner.PartnerImageData = new byte[image.ContentLength];
                    image.InputStream.Read(partner.PartnerImageData, 0, image.ContentLength);
                }
                repository5.SavePartner(partner);
                TempData["message"] = string.Format("Zapisano {0} ", partner.Name);
                return RedirectToAction("Partner"); }
            else
            {
                // błąd w wartościach danych                
                return View(partner);
            }
        }

        [HttpPost]
        public ActionResult BrakTowaru(BrakTowaruEmail formula)
        {
         

            if (ModelState.IsValid)
            {
                BrakTowaruEmail email = new BrakTowaruEmail();

                email.Name = formula.Name;
                email.Ilość = formula.Ilość;
                email.Kontrahent = formula.Kontrahent;
                email.email = formula.email;
                email.Send();

                ViewBag.Messages = "Wysłano Formularz";
                return View("BrakTowaru");
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

        public ActionResult ActivateUser(Login login)
        {
            repository2.Active(login);
            TempData["message"] = string.Format("Aktywowano {0} ", login.User);
            return RedirectToAction("DaneUżytkowników");
        }

        public ActionResult ZakonczZamowienie(Order order)
        {
            DateTime localdate = DateTime.Now;

            Order zamowienie = repository3.Orders
            .FirstOrDefault(p => p.OrderID == order.OrderID);

            Login uzytkwonik = repository2.Logins
               .FirstOrDefault(p => p.LoginID == zamowienie.LoginID);

            Login wystawaiajacy = repository2.Logins
                .FirstOrDefault(p => p.LoginID == (int)Session["userID"]);

            if (zamowienie.Complete==false)
            {
                TempData["message"] = string.Format("Skomplentuj najpierw zamówienie : ", order.OrderID);
                return RedirectToAction("Zamowienia");
            }

            RZ rozchodzewnetrzny = new RZ();

            rozchodzewnetrzny.CenaCalkowita = zamowienie.Amount;
            rozchodzewnetrzny.DataWystawienia = zamowienie.Data;
            rozchodzewnetrzny.DataSprzedazy = localdate;
            rozchodzewnetrzny.Miesiac = localdate.Month;
            rozchodzewnetrzny.Rok = localdate.Year;
            rozchodzewnetrzny.Kupujacy = uzytkwonik.User;
            rozchodzewnetrzny.Wystawiajacy = wystawaiajacy.User;


            foreach (var item in repository4.Sales)
             {
                    if (item.OrderID == order.OrderID)
                         {
                            rozchodzewnetrzny.Produkty += item.ProductName + "," + item.Quantity + "," + item.Price + "\n";
                         }
             }

            zamowienie.Ended = true;

            repository3.SaveOrder(zamowienie);

            repository11.SaveRZ(rozchodzewnetrzny);


            TempData["message"] = string.Format("Zakończono zamówienie {0} ", order.OrderID);
            return RedirectToAction("Zamowienia");
        }

        public ActionResult Braki(Order order)
        {
            DateTime localdate = DateTime.Now;

            Order zamowienie = repository3.Orders
            .FirstOrDefault(p => p.OrderID == order.OrderID);

            Login uzytkwonik = repository2.Logins
               .FirstOrDefault(p => p.LoginID == zamowienie.LoginID);

            var wypelniono = true;

            foreach (var item in repository4.Sales.ToList())
            {
                if (item.OrderID == order.OrderID)
                {
                    if (item.Complete == false)
                    {
                        Product product = repository.Products
                        .FirstOrDefault(p => p.ProductID == item.ProductID);

                        int a = item.Quantity;

                        if (a > product.Total)
                        {
                            wypelniono = false;
                            TempData["message"] = string.Format("Nie uzupełniono produkt ", item.ProductName);
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

                            item.Complete = true;
                            TempData["message"] = string.Format("Uzupełniono o produkt ", item.ProductName);
                            repository4.SaveSale(item);
                            repository.SaveProduct(product);
                        }
                    }
                }
            }

            if (wypelniono == true)
            {
                zamowienie.Complete = true;
                repository3.SaveOrder(zamowienie);
                TempData["message"] = string.Format("Zakończono zamówienie {0} ", order.OrderID);
                return RedirectToAction("Zamowienia");

            }
            else
            {
                TempData["message"] = string.Format("Nie wszystkie braki zostały uzupełnione, domów towar dla zamówienia {0} ", order.OrderID);
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
            return View("Edit", new Product());
        }

        public ViewResult CreateZestaw()
        {
            DodajProduktView dodaj = new DodajProduktView
            {
                Products = repository.Products,
            };

            return View("CreateZestaw", dodaj);
        }

        public ViewResult CreatePartner()
        {
            return View("EditPartner", new Partner());
        }

        public ViewResult CreateUser()
        {
            return View("EditUser", new Login());
        }

        [HttpPost]
        public ActionResult Delete(int productId) {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null) {
                TempData["message"] = string.Format("Usunięto {0}", deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeletePartner(int partnerId)
        {
            Partner deletedPartner = repository5.DeletePartner(partnerId);
            if (deletedPartner != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", deletedPartner.Name);
            }
            return RedirectToAction("Partner");
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

            rozchodwewnetrzny.DataWystawienia = localdate;
            rozchodwewnetrzny.Miesiac = localdate.Month;
            rozchodwewnetrzny.Rok = localdate.Year;
            rozchodwewnetrzny.Wystawiajacy = uzytkwonik.User;
            rozchodwewnetrzny.CenaCalkowita = product.Price*product.Total;
            rozchodwewnetrzny.Produkty = product.Name;


            przychodwewmetrzny.DataWystawienia = localdate;
            przychodwewmetrzny.Magazyn = "Magazyn 1";
            przychodwewmetrzny.Miesiac = localdate.Month;
            przychodwewmetrzny.Rok = localdate.Year;
            przychodwewmetrzny.Wystawiajacy = uzytkwonik.Name;
            przychodwewmetrzny.Produkt = "";
            przychodwewmetrzny.Ilosc = product.Total;
            przychodwewmetrzny.CenaCalkowita = product.Price*product.Total;


            product1 = repository.Products
                   .FirstOrDefault(p => p.Name == zestawik.ProduktName1);
            product2 = repository.Products
                .FirstOrDefault(p => p.Name == zestawik.ProduktName2);
            product3 = repository.Products
                .FirstOrDefault(p => p.Name == zestawik.ProduktName3);
            product4 = repository.Products
                    .FirstOrDefault(p => p.Name == zestawik.ProduktName4);
            product5 = repository.Products
                    .FirstOrDefault(p => p.Name == zestawik.ProduktName5);


            var ilosc = product.Total;

            if (zestawik.ProduktName1 !=null)
            {
                product1.Total += product.Total;
                product1.Warehouse1 += product.Total;
                przychodwewmetrzny.Produkt += product.Name + "\t" + ilosc + "\n";
                repository.SaveProduct(product1);
            }

            if (zestawik.ProduktName2 != null)
            {
                product2.Total += product.Total;
                product2.Warehouse1 += product.Total;
                przychodwewmetrzny.Produkt += product.Name + "\t" + ilosc + "\n";
                
                repository.SaveProduct(product2);
            }

            if (zestawik.ProduktName3 != null)
            {
                product3.Total += product.Total;
                product3.Warehouse1 += product.Total;
                przychodwewmetrzny.Produkt += product.Name + "\t" + ilosc + "\n";
                
                repository.SaveProduct(product3);
            }
            if (zestawik.ProduktName4 != null)
            {
                product4.Total += product.Total;
                product4.Warehouse1 += product.Total;
                przychodwewmetrzny.Produkt += product.Name + "\t" + ilosc + "\n";
                repository.SaveProduct(product4);
            }
            if (zestawik.ProduktName5 != null)
            {
                product5.Total += product.Total;
                product5.Warehouse1 += product.Total;
                przychodwewmetrzny.Produkt += product.Name + "\t" + ilosc + "\n";
                repository.SaveProduct(product5);
            }

            
           
            
            
            

            repository8.SavePW(przychodwewmetrzny);
            repository10.SaveRW(rozchodwewnetrzny);

            Set deletedZestaw = repository6.DeleteZestaw(zestawik.SetID);
 
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", deletedProduct.Name);
            }
            return RedirectToAction("Zestaw");
        }











    }
}