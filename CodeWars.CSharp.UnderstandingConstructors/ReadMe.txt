## Creation Design Patterns

#	Abstract Factory
#	Avoiding Excess Abstractness
#	Covariance & Contra-variance
#	Substitution & Liskov Substitution - structural vs behavioral sub-typing
#	Builder Pattern
#	Calling Protocols and Builder
#	Factory Method with Lambdas (thin wrappers around more complex builders)
#	Building Complex Objects with Specification
#	Building OBject Graphs With Specification











#	Abstract Factory Principle

Object Creation is an involved process

Covariance - assigning to a variable of less derived type, returns more derived type!

strongly-typed code (gruesome and unacceptable)



Tactical Design Patterns in .net Scenarios

Managing Responsibilities   |		Control Flow		|		Creating Objects


Abstract factory - factory had a specific responsibility other than just creating objects.


Dependencies tend to leak upstream

Classes are boxed together with their dependencies via factories, so factories inject dependencies into classes to make them fully usable objects.


Abstract factory is like a big rug we can put under all the dirt (dependencies) that the concrete class depends on.



Constructing an entire object graph as one operation, use specification.

factory < builder < specification.

In all kinds of application boolean test methods appear that are really parts of little rules.

As long as they are simple, we handle them with testing methods, but not all methods are simple.

