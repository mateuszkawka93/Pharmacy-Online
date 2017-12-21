﻿using Pharmacy_Online.Data_Access_Layer;
using Pharmacy_Online.Infrastructure;
using Pharmacy_Online.Models;
using Pharmacy_Online.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Pharmacy_Online.Controllers
{
    public class HomeController : Controller
    {
        private ProductsContext _db = new ProductsContext();
        // GET: Home
        public ActionResult Index()
        {
            ICacheProvider cache = new DefaultCacheProvider();

            List<Category> categories;

            if (cache.IsSet(Consts.CategoriesCacheKey))
            {
                categories = cache.Get(Consts.CategoriesCacheKey) as List<Category>;
            }
            else
            {
                categories = _db.Categories.ToList();
                cache.Set(Consts.CategoriesCacheKey, categories, 60);
            }


            List<Product> news;


            //if (cache.IsSet(Consts.NewsCacheKey))
            //{
            //    news = cache.Get(Consts.NewsCacheKey) as List<Product>;
            //}
            //else
            //{
                news = _db.Products.Where(n => !n.Hidden).OrderByDescending(a => a.AddTime).Take(3).ToList();
                cache.Set(Consts.NewsCacheKey, news, 5);
            //}

            List<Product> bestsellers;

            //if (cache.IsSet(Consts.BestsellersCacheKey))
            //{
            //    bestsellers = cache.Get(Consts.BestsellersCacheKey) as List<Product>;
            //}
            //else
            //{
                bestsellers = _db.Products.Where(b => !b.Hidden && b.Bestseller).OrderBy(a => Guid.NewGuid()).Take(3).ToList();
                cache.Set(Consts.BestsellersCacheKey, bestsellers, 5);
            //}


            var viewmodel = new HomeViewModel()
            {
                Categories = categories,
                News = news,
                Bestsellers = bestsellers
            };

            return View(viewmodel);
        }

        public ActionResult StaticPages(string name)
        {
            return View(name);
        }
    }
}