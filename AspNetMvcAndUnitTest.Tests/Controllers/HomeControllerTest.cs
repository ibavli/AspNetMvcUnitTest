using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AspNetMvcAndUnitTest;
using AspNetMvcAndUnitTest.Controllers;
using static AspNetMvcAndUnitTest.Controllers.HomeController;

namespace AspNetMvcAndUnitTest.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        HomeController controller;
        [TestInitialize]
        public void Initialize()
        {
            controller = new HomeController();
        }

        [TestMethod]
        public void Index()
        {
            // Act
            ViewResult result = controller.Index() as ViewResult;

            string isim = result.ViewBag.isim;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }




        /*
         Assert.AreEqual (Eşitlik Testi)
         */
        [TestMethod]
        public void TestAreEqual_FarkliTur()
        {
            int islemSonucu = 10;
            decimal olmasiBeklenen = 10;
            Assert.AreEqual(islemSonucu, olmasiBeklenen);
        }

        [TestMethod]
        public void TestAreEqual_AyniTur()
        {
            int islemSonucu = 10;
            int olmasiBeklenen = 10;
            Assert.AreEqual(islemSonucu, olmasiBeklenen);
        }





        /*
         Assert.AreNotEqual (Eşitsizlik Testi)
             */
        [TestMethod]
        public void TestAreNotEqual()
        {
            int islemSonucu = 10;
            int olmasiBeklenen = 20;
            Assert.AreNotEqual(islemSonucu, olmasiBeklenen);
        }




        /*
         Assert.AreSame (Aynılık Testi)
         Parametredeki değerlerin aynı olmasına bakar. Eğer aynı ise test başarılıdır. Aynı olması koşulu, değer olarak değil, gerçekte değişkenlerin aynı olması (değişkenlerin bellekte tutulan adreslerinin aynı olması) durumudur. Aşağıdaki gibi bir dizi atamasında, değerler atanmaz, bellekte tutulan adresleri atanır. Böylelikle notlar dizisinde yapılan bir değişiklik, aynı yere bakan dizi2 dizisinde de yapılmış gibi görünür. Fakat değişkenlerde bu durum böyle değildir. Her değişken bellekte farklı bir yer tutmaktadır.
         */
        [TestMethod]
        public void TestAreSame_Dizi()
        {
            int[] dizi1 = { 10, 20, 30, 40, 50 };
            int[] dizi2 = dizi1;
            Assert.AreSame(dizi1, dizi2);
        }

        [TestMethod]
        public void TestAreSame_Degisken()
        {
            int islemSonucu = 10;
            int olmasiBeklenen = islemSonucu;
            Assert.AreSame(islemSonucu, olmasiBeklenen);
        }


        /*
         Assert.AreNotSame (Aynı olmama testi)
             */
        [TestMethod]
        public void TestAreNotSame_Degisken()
        {
            int islemSonucu = 10;
            int olmasiBeklenen = islemSonucu;
            Assert.AreNotSame(islemSonucu, olmasiBeklenen);
        }

        [TestMethod]
        public void TestAreNotSame_Dizi()
        {
            int[] dizi1 = { 10, 20, 30, 40, 50 };
            int[] dizi2 = dizi1;
            Assert.AreNotSame(dizi1, dizi2);
        }


        //Testi hatalı olarak döndürür.
        [TestMethod]
        public void TestFail()
        {
            Assert.Fail();
        }



        //Assert.IsFalse (Değerin false olma testi)
        [TestMethod]
        public void TestIsFalse()
        {
            bool sonuc = false;
            Assert.IsFalse(sonuc);
        }


        //Assert.IsTrue (Değerin true olma testi)
        [TestMethod]
        public void TestIsTrue()
        {
            bool sonuc = true;
            Assert.IsTrue(sonuc);
        }



        //Assert.IsNull (Değerin null olma testi)
        [TestMethod]
        public void TestIsNull()
        {
            bool? sonuc = null;
            Assert.IsNull(sonuc);
        }



        //Assert.IsNotNull (Değerin null olmama testi)
        [TestMethod]
        public void TestIsNotNull()
        {
            bool sonuc = true;
            Assert.IsNotNull(sonuc);
        }


        //View'a gönderilen modele erişim
        [TestMethod]
        public void Ogrenci_KayitVarMi()
        {
            var sonuc = controller.OgrenciMetod1(1) as ViewResult;

            var ogrenci = (OgrenciModel)sonuc.ViewData.Model;

            Assert.AreEqual("ali", ogrenci.Ad);
        }


        //View'dan farklı bir view'a yönlendirme RedirectToAction durumuna erişim
        [TestMethod]
        public void Ogrenci_RedirectToActionVarMi()
        {
            var sonuc = controller.OgrenciMetod2(-1) as RedirectToRouteResult;

            Assert.AreEqual(sonuc.RouteValues["action"], "Index");
        }


        //View ismine erişim
        [TestMethod]
        public void Sayfa1_ViewName()
        {
            var sonuc = controller.Sayfa1() as ViewResult;

            Assert.AreEqual(sonuc.ViewName, "Sayfa2");
        }



        //Action'ın Model'inin veri türüne erişim
        [TestMethod]
        public void OgrenciModelListesi()
        {
            var sonuc = controller.ListeOgrenciModel() as ViewResult;

            Assert.IsInstanceOfType(sonuc.Model, typeof(List<OgrenciModel>));
        }



        //Bu iki test aynı metod için geçerlidir. Sonuca göre sayfa döndürür.
        [TestMethod]
        public void Ogrenci_VeriTuru_RedirectToRouteResult()
        {
            Assert.IsInstanceOfType(controller.OgrenciMetod2(-1), typeof(RedirectToRouteResult));
        }
        [TestMethod]
        public void Ogrenci_VeriTuru_ViewResult()
        {
            Assert.IsInstanceOfType(controller.OgrenciMetod2(1), typeof(ViewResult));
        }


        [TestMethod]
        public void OgrenciJson_Test()
        {
            var ogrenci = controller.JsonOgrenci();
            var sonuc = ogrenci.Data as OgrenciModel;
            var olmasıGereken = new OgrenciModel
            {
                Id = 1,
                Ad = "ali",
                Soyad = "veli"
            };
            Assert.AreEqual(sonuc.Id, olmasıGereken.Id);
            Assert.AreEqual(sonuc.Ad, olmasıGereken.Ad);
            Assert.AreEqual(sonuc.Soyad, olmasıGereken.Soyad);
        }
    }
}
