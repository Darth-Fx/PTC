using PTC.Controllers;
using PTCData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTC.ModelBinder
{
    public class BaseViewModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if (modelType == typeof(BaseViewModel) || modelType.IsSubclassOf(typeof(BaseViewModel)))
            {
                var baseControl = controllerContext.Controller as BaseController;
                if (baseControl == null)
                {
                    throw new Exception("The Controller must derive from BaseController");
                }

                var instance = Activator.CreateInstance(modelType, baseControl.TrainingProductManager);
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => instance, modelType);
                return instance;
            }
            else
            {
                return base.CreateModel(controllerContext, bindingContext, modelType);
            }
        }
    }
}