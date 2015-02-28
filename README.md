# ASP.NET MVC Component
A component-oriented project template for Visual Studio, based on the template for ASP.NET MVC.

## The Problem
If you have encountered any of these problems, then probably you would want to structure your files in the project in a different way:
- Controllers grow indefinitely
- Models, view, and controllers are **coupled** and typically you would want to fidn the model fo the view and maybe change it. But thsi change should be propagated from the controller. In a big project this can get messy.
- You have a lot of views (partial counts as well) and it becomes hard to keep track of them

## The Solution
A simple solution to this growing mess could be restructing the solution. Instead of keeping models, views, and controllers separated, we should keep them close to each other, because they are **related**.


