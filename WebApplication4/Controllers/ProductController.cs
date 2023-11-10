using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using WebApplication4.Entities;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> Products { get; set; } = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name= "Asus",
                Description= "Computer",
                Price=2900,
                Discount=10,
                ImagePath="https://5.imimg.com/data5/SELLER/Default/2022/1/VH/FF/PH/8118327/asus-rog-strix-g15-2021-g513qc-hn093t-gaming-laptop.png"
            },

            new Product
            { Id = 2,
                Name= "Hp",
                Description= "Computer",
                Price=1200,
                Discount=20,
                ImagePath="https://in-media.apjonlinecdn.com/catalog/product/5/3/533U4PA-1_T1680435823.png"
            },

            new Product
            {
                Id = 3,
                Name= "MacbookPro",
                Description= "Computer",
                Price=3000,
                Discount=10,
                ImagePath="https://www.aptronixindia.com/pub/media/catalog/product/m/b/mbp14-spacegray-select-202110-removebg-preview_2__1.png"
            },

            new Product
            {
                Id = 4,
                Name= "Lenovo",
                Description= "Computer",
                Price=1200,
                Discount=0,
                ImagePath="https://news.lenovo.com/wp-content/uploads/2021/01/Lenovo-Yoga-Slim-7i-Pro-OLED_Front_Facing_Left-e1609862029211.png"
            },

        };


        public IActionResult Index()
        {
            var vm = new ProductListViewModel
            {
                Products = Products

            };


            return View(vm);

        }
        [HttpGet]
        public IActionResult Update(int myid)
        {
            var prod = Products.SingleOrDefault(p => p.Id == myid);
            var vm = new ProductUpdateViewModel
            {
                Product = prod,
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Update(ProductUpdateViewModel vm)
        {
            var myId = 0;
            myId=Products.SingleOrDefault(p => p.Id == vm.Product.Id).Id;
            var prod = Products[--myId];
            prod.Price=vm.Product.Price;
            prod.Name = vm.Product.Name;
            prod.Description = vm.Product.Description;
            prod.Discount = vm.Product.Discount;
            prod.ImagePath = vm.Product.ImagePath;
            return RedirectToAction("index");

        }


        


        [HttpGet]
        public IActionResult Add()
        {
            var vm = new ProductAddViewModel
            {
                Product = new Product(),
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(ProductAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Products.Add(vm.Product);
                return RedirectToAction("index");
            }
            return RedirectToAction("Add");
        }



        public IActionResult Delete(int myid)
        {
            var prod = Products[--myid];
            Products.Remove(prod);
            for (int i = (myid); i < Products.Count; i++)
            {
                Products[i].Id--;
            }
            return RedirectToAction("index");
        }
    }
}
