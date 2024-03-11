# Friday, March 8 Notes
- Covered access types in C# (public, private, protected)
- Learned about static types
- Discussed value types vs. reference types
- Enumerables
- Generics
- Learned the motivation for delegates
- Passing by reference in C#
- .NET Properties, Fields, and their evolution
## Key Takeaways
- Cynefin Model - for approaching complexity & confusion
    - Also look at Rich Hickey's Simple Made Easy (author of Clojure programming language)
        - Simple != Easy
        - Make your code simple - it does ONE thing
        - Simple - comes from simplex, or "one braid" on thread
        - Complex - means "many braids" or things
            - Code shouldn't be much more complicated than what's written in class, we just need more of it
        - Easy means "close at hand"
            - Simple is HARD, it is NOT easy
            - Writing good software is not "easy", but it should be "simple"
                - Abstraction, encapsulation, polymorphism
- Hypothesis Driven Development - develop, test, and rebuild a product until it's acceptable by users
    - Start small - what's the smallest unit of work you can ship to satisfy customers?
- Creating Types
    - Mostly use classes (or records, which are kind of the same)
    - Different "kinds" of classes - used to do different things
        - Entities - each instance of that object has specific identity
            - Entity Framework in .NET
        - Services - don't usually have much state, just do work
        - Values - do not have specific identity - their "value" is identity 
- Value type vs. Reference type 
    - For value types, te value is the information itself
        - Not a memory address
        - Built-in value types: int, char, float
    - For reference types, the value is a reference which may be null or may be a way of navigating to an object containing the information
        - Refers to a memory location stored in the heap
        - Built-in reference types: object, dynamic, string
- Homoiconicity - functional programming - a language is homoiconic if a program written in it can be manipulated as data using the language
- C# is a "statitcally typed classical object-oriented programming language"
- In C#, the only thing a variable can refer to is an instance of a class or a struct
    - Distinguished from other languages - e.g., JavaScript can assign functions to variables
    - Delegates - object that refers to a method of a reference type variable that can hold a reference to the methods
        - Similar to the function pointer in C/C++