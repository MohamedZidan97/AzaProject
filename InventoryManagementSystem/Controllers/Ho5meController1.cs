﻿using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class Ho5meController1 : Controller
    {
        public class add
        {
            public int id { get; set; }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
