using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Net.Http.Formatting;

namespace AngularQuiz.Web.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class UserDataOnlyAttribute : Attribute, IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            if (controllerSettings == null)
            {
                throw new ArgumentNullException("controllerSettings");
            }

            if (controllerDescriptor == null)
            {
                throw new ArgumentNullException("controllerDescriptor");
            }
 
            controllerSettings.Formatters.Clear();
            var jsonFormatter = new JsonMediaTypeFormatter();
            jsonFormatter.SerializerSettings.ContractResolver = new UserDataOnlyContractResolver();
            jsonFormatter.Indent = true;
            controllerSettings.Formatters.Add(jsonFormatter);
        }
    }
}