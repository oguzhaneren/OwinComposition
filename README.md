# Owin Composition Example 

```csharp
var context1 = new BoundedContext1.Context();
var context2 = new BoundedContext2.Context();


using (WebApp.Start("http://localhost:8001", app =>
{
    app.Map("/context1", appBuilder => context1.RegisterApp(appBuilder));
    app.Map("/context2", appBuilder => context2.RegisterApp(appBuilder));
}))
{

    Console.ReadLine();
}
```
