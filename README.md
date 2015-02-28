# ASP.NET MVC Component
A component-oriented project template for Visual Studio, based on the template for ASP.NET MVC.

## The Problem
If you have encountered any of these problems, then probably you would want to structure your files in the project in a different way:
- Controllers grow indefinitely
- Models, view, and controllers are **coupled** and typically you would want to fidn the model fo the view and maybe change it. But thsi change should be propagated from the controller. In a big project this can get messy.
- You have a lot of views (partial counts as well) and it becomes hard to keep track of them

## The Solution
A simple solution to this growing mess could be restructing the solution. Instead of keeping models, views, and controllers separated, we should keep them close to each other, because they are **related**.

In this template you use the same elements (i.e., models, views, and controllers), but structured in a different way. Instead of working with raw controllers, we have two options: ``PageController`` and ``ComponentController``.

The template provides a "root" folder, called *Pages*. You create a separate folder for each general page you have in your application: f.x., Home, Account, Statistics. Sometimes you need to share elements across pages and you can use the *special page*, called Shared. Each page can contain ``PageController``s, views and components. For each component you should also create a separate folder, f.x. NavigationBar, SearchMenu, ProfileWatch. If you want to share components between pages, you should place them in the Shared folder instead.

### Pages
Pages correspond to your "raw" controllers. One page can contain many subpages, i.e. different action methods. The base class for pages is ``PageController``. Each ``PageController`` contains a method, called ``Index()``. You can have other methods as well, but this one is requried.

You can have pages without an explicit controller, i.e. only with a view. In this case the raw ``PageController`` will be used.

### Components
Components are created using the base class ``ComponentController``, which define a must-to-have method ``Render()``. Components are rendered using ``Html.RenderPartial()`` helper which is wrapped in a method, called ``Html.Component("Name")``.

You can have components without an explicit controller, i.e. only with a view. In this case the raw ``ComponentController`` will be used.

# How to install
You can open the solution using Visual Studio and then from the menu, you can choose *Export Template...*

# Feedback
Please, do shre your thoughts, ideas, and questions. Send me a pull request if you want to change anything.
