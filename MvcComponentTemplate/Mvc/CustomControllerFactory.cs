using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace MvcComponentTemplate.Mvc
{
    /// <summary>
    /// If one wants to create a page or component just with a view (i.e. with no controller attached),
    /// we use the default controllers to render the view
    /// </summary>
    public class CustomControllerFactory : IControllerFactory
    {
        private readonly OverridenDefaultControllerFactory _innerFactory;

        public CustomControllerFactory()
        {
            _innerFactory = new OverridenDefaultControllerFactory();
        }

        public virtual Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            return _innerFactory.GetControllerType(requestContext, controllerName);
        }

        public virtual IController CreateController(RequestContext requestContext, string controllerName)
        {
            bool isChildAction = requestContext.RouteData.DataTokens.ContainsKey("ParentActionViewContext");
            Type controllerType = GetControllerType(requestContext, controllerName);
            if (controllerType == null)
            {
                controllerType = _innerFactory.GetControllerType(requestContext, isChildAction ? "Component" : "Page");
            }
            return _innerFactory.GetControllerInstance(requestContext, controllerType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return ((IControllerFactory)_innerFactory).GetControllerSessionBehavior(requestContext, controllerName);
        }

        public virtual void ReleaseController(IController controller)
        {
            _innerFactory.ReleaseController(controller);
        }

        /// <summary>
        /// By default, <see cref="DefaultControllerFactory"/> only exposes <see cref="IControllerFactory.CreateController"/> which throws an exception
        /// if the controller is not found. Since we want to try creating a controller, and then fall back to <see cref="PageController"/> or
        /// <see cref="ComponentController"> if one isn't found, this nested class changes the visibility of <see cref="DefaultControllerFactory"/>'s
        /// internal methods in order to not have to rely on a try-catch.
        /// </summary>
        /// <remarks></remarks>
        internal class OverridenDefaultControllerFactory : DefaultControllerFactory
        {
            public new IController GetControllerInstance(RequestContext requestContext, Type controllerType)
            {
                return base.GetControllerInstance(requestContext, controllerType);
            }

            public new Type GetControllerType(RequestContext requestContext, string controllerName)
            {
                if (string.IsNullOrWhiteSpace(controllerName))
                {
                    return null;
                }
                return base.GetControllerType(requestContext, controllerName);
            }
        }
    }
}