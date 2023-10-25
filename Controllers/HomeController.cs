using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Inventory is the goods or materials a business intends to sell to customers for profit. Inventory management, a critical element of the supply chain, is the tracking of inventory from manufacturers to warehouses and from these facilities to a point of sale. \nThe basic steps of inventory management include: Purchasing inventory: Ready-to-sell goods are purchased and delivered to the warehouse or directly to the point of sale.\r\nStoring inventory: Inventory is stored until needed. Goods or materials are transferred across your fulfillment network until ready for shipment.\r\nProfiting from inventory: The amount of product for sale is controlled. Finished goods are pulled to fulfill orders. Products are shipped to customers.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}