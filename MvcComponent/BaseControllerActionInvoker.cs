using System;
using System.Reflection;
using System.Web.Mvc;

namespace MvcComponent
{
    /// <summary>
    /// Creates an action invoker that checks for a default action name and invokes it either on the 
    /// controller or on its base controller
    /// </summary>
    public class BaseControllerActionInvoker : ControllerActionInvoker
    {
        private readonly Type _baseControllerType;
        private readonly string _defaultActionName;

        public BaseControllerActionInvoker(Type baseControllerType, string defaultActionName)
        {
            if (baseControllerType == null)
                throw new ArgumentNullException("baseControllerType");
            if (!typeof(IController).IsAssignableFrom(baseControllerType))
                throw new ArgumentOutOfRangeException("baseControllerType");
            if (defaultActionName == null)
                throw new ArgumentNullException("defaultActionName");

            _baseControllerType = baseControllerType;
            _defaultActionName = defaultActionName;
        }

        protected override ActionDescriptor FindAction(ControllerContext controllerContext, ControllerDescriptor controllerDescriptor, string actionName)
        {
            ActionDescriptor actionDescritor = null;
            if (actionName == _defaultActionName)
            {
                actionDescritor = FindDefaultAction(controllerContext, controllerDescriptor, actionName);
                if (actionDescritor != null)
                    return actionDescritor;
            }

            actionDescritor = base.FindAction(controllerContext, controllerDescriptor, actionName);
            if (actionDescritor == null)
            {
                actionDescritor = FindDefaultAction(controllerContext, controllerDescriptor, actionName);
            }
            return actionDescritor;
        }

        protected virtual ActionDescriptor FindDefaultAction(ControllerContext controllerContext, ControllerDescriptor controllerDescriptor, string originalActionName)
        {
            Type controllerType = controllerContext.Controller.GetType();
            bool isBaseControllerOrItsChild = _baseControllerType.IsAssignableFrom(controllerType);
            MethodInfo renderMethodInfo = null;

            // If the component inherits from the base controller and has defined a new defult action method,
            // then we have to call its method, not the one of the base controller
            bool isBaseController = controllerType == _baseControllerType;
            if (isBaseControllerOrItsChild && !isBaseController)
            {
                // Check whether the custom Render method is defined
                renderMethodInfo = controllerType.GetMethod(_defaultActionName,
                    BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            }
            if (renderMethodInfo == null)
            {
                renderMethodInfo = controllerType.GetMethod(_defaultActionName);
            }
            return new ReflectedActionDescriptor(renderMethodInfo, _defaultActionName, controllerDescriptor);
        }

        public static BaseControllerActionInvoker CreateFor<TController>(string defaultActionName)
            where TController : IController
        {
            return new BaseControllerActionInvoker(typeof(TController), defaultActionName);
        }
    }
}