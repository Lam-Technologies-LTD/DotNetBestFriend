# Dot Net Best Friend

This is a set of APIs for developers to help validate data and build their .NET 8 onwards apps.

# Technologies & Dependencies

.NET 8 & 9 Class Library

C# 12 & 13

# Depreciated Versions

.NET 5, 6 & 7

I've decided to omit these because ideally we should be keeping on top of the upgrades or sticking to the LTS releases as much as possible.

# Brief description of the preceding technologies

.NET Framework, Core and Xamarin are the most popular technologies used for developing websites and apps. All three major technologies can be programmed in C#, F# and Visual Basic.

.NET Standard is a class library to share common logic among each of the three aforementioned technologies without needing to write the code again. Just create the library, stick the code in, build it as a package, publish the package and then download it into your app and...voilà!

# Brief description of the technologies used in this package

Framework and Core has now been merged into a single unified platform as .NET. The point of this is to unite the technologies under one ultimate framework so developers can essentially build what they want using one platform instead of a horrific mix of technologies, which can get expensive to maintain as newer technologies emerges.

.NET 6 (No Longer Supported) is the long term supported iteration of the .NET technologies because MS has planned for every even number to be supported long term with every other year to be a minor increment of features. Iterates on .NET 5 features by increasing processing time, introducing .NET MAUI (Xamarin's replacement), WinForms support and language specific features such as DateOnly.

.NET 7 (No Longer Supported) was launched on 8th November 2022 with performance improvements, native AOT compilation, improved ARM and HTTP/3 support.

.NET 8 is the second of the LTS release following the .NET 5 rebranding with further performance improvements, expanded JSON serialization, container size reduction, etc.

.NET 9 continues the trend of huge performance improvements, especially for LINQ.

# The purpose of this package

The purpose of this package is to provide a set of simple extension methods for .NET 6 and 7+ developers. 

The library offers convenience for small little coding nuisances by preventing some very common null errors that developers often forget to implement because Microsoft has yet to add these null checks into each of the 3 supported languages themselves or in the Common Intermediate Language.

Ideally, if you have to write a piece of logic more than once, it's best to create a small method that does the same thing and make it accessible anywhere in the app for future use.

# The main philosophy of this package

The most important lesson I've learnt as a programmer is to: Build your tools before you build the app. 

Understand what data will be going in and out of the app, then set a standard for the app to follow in order to prevent crashing or unintended effects.

The standards needs to cover: error checking, exception handling, data converting, shared classes and business logic.

I've modelled the philosophy from experiences at my previous jobs, where more senior devs would program the libraries for everyone to use. At one company I worked for, I've managed to program four generations of a .NET Standard API for my colleagues to quickly connect their .NET Core apps to our WCF services.

Each generation became more efficient as I honed my software development abilities and expanded the toolset to include the same extension methods found in this project.

# An example of how useful this toolset can be

A common root cause of programs crashing is because it's trying to read or manipulate null data. Developers can overlook the possibility that a null object or value has been returned because something has gone wrong in the logic and it leads to the program not functioning properly. 

Most users are NOT computer programmers, so they are unlikely to understand why the program has froze or an error page is shown.

Let's use a generic list in C# as an example... (Note that this also applies to Visual Basic and F# too)

```
List<string> test = null;

if (test.Any())
{
  
}
```

So I've declared a variable called "test" and it will hold a list of strings, BUT I haven't instantiated it yet. Then I'm trying to use the "Any" extension method in System.Linq, to see if list actually has something inside.

Guaranteed, an exception will be thrown because you're trying to trigger a method for an object that hasn't even come into existence yet. 

It's like trying ask your unborn baby to help you with your tax returns, the baby hasn't arrived yet neither does it know how to file taxes!

So what exactly can be done about this? You can do it this way...

```
List<string> test = null;

if (test != null && test.Any()) // << OK!
{
  
}
```

But then you'd have to write that if statement every time you create a list and need to check something inside of it. 

However, a sensible developer would have done this...

```
List<string> test = new List<string>(); // << Great!

if (test.Any()) // << OK!
{
  
}
```

The trouble comes when you send over the list from layer to layer, such as from a REST service to the client app; it's considered good practice to return it as an IEnumerable in order give the developer flexibility in converting it over into a list with a simple .ToList() or IQueryable using .AsQueryable().

Some developers, myself included, prefer to return null if something has gone seriously wrong or if nothing is found during in the REST service call because every time we instantiate an object, we are allocation space in the heap which goes to waste if we're not using it. I know C# has automatic garbage collection, but it's up to the individual to decide what gets passed back to the client app.

You can't use a null-conditional on the object because it'll result in a syntax error because you're not allowed to use a method for a nullable reference, just the properties only.

```
List<string> test = null;

if (test?.Any()) // << Syntax Error!
{
  
}

if ((bool)test?.Any()) // << Can't do it that way either, believe me I've tried!
{

}
```

You can do it this way...but you won't be able to do that with IEnumerable or ICollection

```
List<string> test = null;

if (test?.Count > 0) // << That's fine
{
  
}

IEnumerable<string> test2 = null;

if (test2?.Count() > 0) // << Syntax Error!
{
  
}
```

OR...you can use an IEnumerable extension method I've created to check if the collection is null before checking if it has something inside. 

Anything that derives from IEnumerable (such as a List, IList, ICollection, IOrderedEnumerable) can use that extension method too, further proving the main philosophy of building your dev tools before building your app.

```
List<string> test = null;

if (test.IsNotNullOrEmpty()) // << Will not throw an error! xD
{
  
}
```

By bringing in the DotNetBestFriend namespace, you now have some access to the IsNotNullOrEmpty method, which can save your behind if you use frequently use collections.

# What APIs are available?

So far I've added helpers for the most frequently used data types from the various projects I've worked on over the years:

* String
* Value Types
* Reference Types
* DateTime
* Enum
* ICollection
* IDictionary
* IEnumerable
* IList
* StringBuilder
