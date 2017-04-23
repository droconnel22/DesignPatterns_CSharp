using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShipBob.Domain.Manager;
using ShipBob.Domain.ViewModels;


namespace Shipbob.Web.Controllers
{
    //assuming authoirzation and authentication are outside the scope of project.
    [AllowAnonymous]
    public class OrderController : Controller
    {
        private readonly IManager shipBobManager;
      

        public OrderController(IManager manager)
        {
            this.shipBobManager = manager;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> PostOrder(OrderViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                return await this.shipBobManager.PlaceOrder(model)
                    ? (ActionResult) new HttpStatusCodeResult(HttpStatusCode.OK)
                    : new HttpStatusCodeResult(HttpStatusCode.ExpectationFailed);

            }
            catch (Exception exception)
            {
                //Log exception.Messsage, return code only reason IS NOT client business.
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetInventory()
        {
            try
            {
                return Json(await this.shipBobManager.GetInventoryAsync(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                //Log exception.Messsage, return code only reason IS NOT client business.
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }


        [HttpGet]
        public async Task<ActionResult> CheckInventory()
        {
            try
            {
                return Json(await this.shipBobManager.CheckInventoryAsync(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                //Log exception.Messsage, return code only reason IS NOT client business.
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
             
    }

    
}