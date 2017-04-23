

# Data Layer Notes

I included both using and non using patterns for the repository pattern as this can be a hot button issue with developers.

http://blog.jongallant.com/2012/10/do-i-have-to-call-dispose-on-dbcontext.html#.U9efX_ldXpo

Given this default behavior, in many real-world cases it is harmless to leave the context without disposing it and just rely on garbage collection. 

That said, there are two main reason our sample code tends to always use “using” or dispose the context in some other way: 

1. The default automatic open/close behavior is relatively easy to override: you can assume control of when the connection is opened and closed by manually opening the connection. Once you start doing this in some part of your code, then forgetting to dipose the context becomes harmful, because you might be leaking open connections. 

2. DbContext implements IDiposable following the recommended pattern, which includes exposing a virtual protected Dispose method that derived types can override if for example the need to aggregate other unmanaged resources into the lifetime of the context. 


http://structuremap.github.io/


 Database Layer, 
 
 >Used Entity Framework 6.x 
 
 >service layer
 Repostiory and Unit work pattern
 implements redis cache
 converts entitys to models.

 biz logic consumes collections.

 >Business Logic Layer
 manager? manager converts from view models to models and implements cache and rules.
 
>Data Access Layer 
Assuming MVC (Rest http tcp)


1.Get Initial inventory counts, then subsequently check.
store in local storage?

2. Place Order, including individual items, convert bundle to items,
check local cache, submit to server, then submit to service, check again then update cache and database

3. Return Updated Inventory and success or fail status.


Challenge Load Balance Items ??

Get Initial Inventory of Items
As they are used request a buffer....
Submit Order With Items Address and tracking Id.

 /// <summary>
        /// a full service should have a populated dictionary
        /// a state strategy that gets a behavior strategy
        /// A cache strategy if specified 
        /// </summary>
        /// <returns></returns>