using PTCData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTC.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ITrainingProductManager tpm) : base(tpm)
        {}
        public ActionResult Index()
        {
            TrainingProductViewModel vm = new TrainingProductViewModel(base.TrainingProductManager);
            vm.HandleRequest();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(TrainingProductViewModel vm)
        {

           vm.IsValid = ModelState.IsValid;

            vm.HandleRequest();
            if (vm.IsValid)
            {
                ModelState.Clear();
            }
            else
            {
                foreach(KeyValuePair<string,string> error in vm.ValidationErrors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }
            }
            return View(vm);
        }
    }
}