using Microsoft.AspNetCore.Mvc.ModelBinding;
using SampleCommerce.Models;

namespace SampleEcommerce.Utilities
{
    public class ControllerUtilities
    {
        public static void ModelStateErrorBind(Result result, ModelStateDictionary modelState)
        {
            if (result.ErrorMessages.Any())
            {
                foreach (var error in result.ErrorMessages)
                {
                    modelState.AddModelError("", error);
                }

            }
        }
    }
}
