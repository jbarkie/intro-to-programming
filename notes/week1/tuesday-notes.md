# Tuesday, March 5 Notes
- Reviewed Monday's class
- Added Postgres database to Todos web API
- Added new POST request to add new Todo item
- Added new GET request to fetch all stored Todos
- Created new unit test project
- Learned Test-Driven Development
## Key Takeaways
- `??` operator in C# = null coalescing operator
- "The bad news is you’re falling through the air, nothing to hang on to, no parachute. The good news is, there’s no ground."
- "Ask the duck" - "Rubber Ducky Coding"
- Unit tests should run fast - think a minute or less
    - Never deployed to production - just enough to determine whether code can be shipped
- TDD:
    1. Write a meaningfully failing test
    2. Write just enough code to pass the test
    3. Re-factor
- Fact vs. Theory - when and why?
## Possible Questions You Should be Able to Answer after Day 1
- What is .NET? What is .NET Core?
    - .NET is a framework for software development on the Windows platform.
    - .NET Core is xplat .NET - it is a subset of .NET Framework (doesn't have everything), but most of what you'd need.
    - .NET Core is open source. On Github. 
    - Supports multiple programming languages, the most common BY FAR is C#, but also VB.NET, C++, F#
    - C# - It is a "Classical Object-Oriented Programming Language"
- What is a "Web API" (or a RESTful API, or an HTTP API, all the same) any why do we create them?
    - We are going to build a service that a lot of developers already know the basics of interacting with.
        - Common - and just about any piece of software can use this service, because EVERYTHING nearly can do HTTP.
        - Why do we do this at all?
            - Distributed applications
            - Distributing knowledge
                - You may be on a team that builds the service that knows how to do something CRUCIAL to the business.
                - You work with the business people, are responsive to their needs.
                - Anyone else in the company that wants to do thing "X" (your thing) HAS to go through your service to do it.
                - But they don't have to (*and shouldn't*) know how it works, because that will change at a different rate than the
                    code they are working on.
                - Late-Bound means "only verified at run time"
                - Early-Bound means "verified at compile time"
- Why do we, as developers, write automated tests for our code?
    - "Developer" - tests we write as we write the application.
        - They are either "white box" or "gray box" tests which mean
            - They know how the code is written.
    - Show our *understading* of the business requirement.
    - We stink at doing complex steps reliably and repeatedly.
    - Some tests have to test a lot of stuff in sort of a speculative way.
    - To design our application from the perspective of the user of that code.
- What is a "Project Reference" in Visual Studio?
    - A project reference is to *another* project in the same solution so that the project referencing the other project
      can use the types in the referenced project.

- What is NuGet?
    - It is the package manager for .NET stuff - it is early bound, you can update and redeploy as you see fit,
    however, to publisher of that package cannot force you to update.
- Please note: Nobody is expecting you to answer questions like "What is the method on the web application you use to tell routing how to handle a GET (or POST, etc.) request at runtime? Or anyting about the C# stuff at all yet.
