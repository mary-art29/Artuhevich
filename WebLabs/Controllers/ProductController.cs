using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebLabs.DAL.Entities;
using WebLabs.Extensions;
using WebLabs.Models;
using WebLabs.DAL.Data;
using Microsoft.Extensions.Logging;

namespace WebLabs.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        int _pageSize;
        private ILogger _logger;
        public ProductController(ApplicationDbContext context,
        ILogger<ProductController> logger)
        {
            _pageSize = 3;
            _context = context;
            _logger = logger;
        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var dishesFiltered = _context.Dishes
            .Where(d => !group.HasValue || d.DishGroupId ==
            group.Value);
            _logger.LogInformation($"info: group={group}, page={pageNo}");
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.DishGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;
            var items = _context.DishGroups
            .Skip((pageNo - 1) * _pageSize)
            .Take(_pageSize)
            .ToList();
            //return View(items);
            //return View(ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize));
            if (Request.IsAjaxRequest())
                return PartialView("_ListPartial",
                ListViewModel<Dish>.GetModel(dishesFiltered,
                pageNo, _pageSize));
            return View(ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize));
        }
        /// <summary>
        /// Инициализация списков
        /// </summary>
        
        
    }
}