using PTCData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTC.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController(ITrainingProductManager toiletpapermgr)
        {
            _tpmanager = toiletpapermgr;
        }

        private readonly ITrainingProductManager _tpmanager;

        public ITrainingProductManager TrainingProductManager
        {
            get
            {
                return _tpmanager;
            }
        }
    }
}