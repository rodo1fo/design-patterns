# Samples of Design Patterns in C#
This project is based on book [Design Patterns in C#](https://www.amazon.com/Design-Patterns-Hands-Real-World-Examples/dp/1484236394)

1. Creational
    * **Singleton**: Ensure a class has only one instance, and provide a global point of access to it.

    * **Builder**:  Separate the construction of a complex object from its representation so that the same construction processes can create different representations.

    * **Prototype**: Specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.

    * **Factory**: Define an interface for creating an object, but let subclasses decide which class to instantiate. The Factory Method pattern lets a class defer instantiation to subclasses.

    * **Abstract Factory**: Provide an interface for creating families of related or dependent objects without specifying their concrete classes.

2. Structural

    * **Proxy**: Provide a surrogate or placeholder for another object to control access to it.

    * **Decorator**: Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.

    * **Adapter**: Convert the interface of a class into another interface that clients expect. The Adapter pattern lets classes work together that could not otherwise because of incompatible interfaces.

    * **Facade**: Provide a unified interface to a set of interfaces in a subsystem. Facade defines a higher-level interface that makes the subsystem easier to use.

    * **Composite**: Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly

    * **Bridge**: Decouple an abstraction from its implementation so that the two can vary independently.

3. Behavioral

    * **Visitor**: Represent an operation to be performed on the elements of an object structure. Visitor lets you define a new operation without changing the classes of the elements on which it operates.

    * **Observer**: Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.

### Differences between Adapter, Facade, Proxy

* **Adapter**: Adapts a given class/object to a new interface. The object is wrapped by a conforming adapter object and passed around. The problem we are solving here is that of non-compatible interfaces.

* **Facade**: Is more like a simple gateway to a complicated set of functionality. You make a black-box for your clients to worry less i.e. make interfaces simpler.

* **Proxy**: Provides the same interface as the proxied-for class and typically does some housekeeping stuff on its own. 
(So instead of making multiple copies of a heavy object X you make copies of a lightweight proxy P which in turn manages X and translates your calls as required.) 
You are solving the problem of the client from having to manage a heavy and/or complex object.

* **Strategy**: Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from clients that use it.

* **Template**: Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. The Template Method pattern lets subclasses redefine certain steps of an algorithm without changing the algorithm’s structure.

* **Iterator**: Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation.

* **Memento**: Without violating encapsulation, capture and externalize an object’s internal state so that the object can be restored to this state later.

* **State**: Allow an object to alter its behavior when its internal state changes. The object will appear to change its class.