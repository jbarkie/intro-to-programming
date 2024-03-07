# Wednesday, March 6 Notes
- Reviewed Tuesday's class
- Added custom exception types to Bank project and refactored a new Guard method that allowed our failing tests on overdrafting/withdrawing a negative amount to pass 
- Created new StringCalculator project for pair programming [TDD kata](https://osherove.com/tdd-kata-1)
## Key Takeaways
- Value Types - actual value is on the stack
    - defined using a 'struct' in C#
- Reference Types - actual value is on the heap
    - defined using a Class (or record)
- "Never type Private, always refactor to it"
- "Guard" clause - method that doesn't return anything, validates a condition and immediately stops program execution if not met
    - `GuardTransactionAmount()` used to throw `InvalidTransactionAmountException` if amount to deposit/withdraw is less than or equal to 0
- When refactoring - reduce the time spent making a failing test pass as much as possible
- Kent Beck's Four Rules of Simple Design - "Make it right, then make it good"
    1. Passes the Tests - it does what it's supposed to do
    2. Reveals Intention - another trained developer can make meaning of your code
        - "We don't write code for computers, we write code for other people."
    3. No Duplication - Keep your code DRY (don't repeat yourself)
    4. Fewest Number of Elements - minimize amount of code written, especially variables, loops, etc.
        - Bugs scale linearly with the number of lines of code
- Unit tests:
    - Restricted in what they actually test
    - Test a single unit of code in isolation from any dependencies that have a different rate of change than the unit of code we're testing
    - Cannot touch or use:
        - Databases
        - File Systems
        - Clocks
        - Networks
## Jeff's Notes
1. Containers - We just started, but what did we use them for?
    - To run software we don't have on our machine - we used it for Postgres and Adminer (database and admin tool)
    - What are some benefits of running software in a container for development work?
        - Dev/Prod parity. We want to run the same things our app will use in each environment. 
    - What is that `docker-compose.yml` file doing?
        - Easy way to start up multiple containers at the same time.
2. HTTP - 
    - What is a "resource"
        - A meaningful thing we want to expose from our API
    - What are the key HTTP methods? What are there *semantics* (i.e. what are you saying to the user of your API when your resource implements each of the HTTP methods)?
        - In the notes
    - What is a "representation" in HTTP?
        - A "point in time" snapshot of the resource in a particular format (e.g. JSON, XML, etc.)
3. Unit Testing
    - What is Unit Testing? (What is the "unit")?
        - Usually a method - in isolation from it's dependencies.
    - Is Unit Testing *enough*?
        - No. We need to test WITH the dependencies in place.
    - What is Test-Driven-Development (TDD)?
        - What is the "form" of TDD? (what are the steps)
            - RED->GREEN->Refactor->Repeat
    - In .NET why do we:
        - Put our tests in a separate project from the code under test (known as the "System Under Test", or *yech* "SUT")
            - To keep testing concerns out of our code.
            - To run them in CI
        - Why do we keep our Unit Tests separate from other kinds of tests?
            - To run them at different "stages" of our CI
            - To optimize fast running Unit Tests from other slower tests.