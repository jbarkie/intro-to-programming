# Thursday, March 7 Notes
- Added a new `ICalculateBonusesForDeposits` interface that defines a `CalculateDepositBonusFor()` method
- Added a `StandardBonuscalculator` class that implements the `ICalculateBonusesForDeposits` interface and defines a new `CalculateBonus()` method that returns the deposited amount with an added Gold Account bonus if the criteria is met.
    - Reduces coupling- now, the bonus precentage can be changed from one place without breaking any other code
- Added test doubles (`DummyBonusCalcultor` and `StubbedBonusCalculator`) for testing if the bonus is applied correctly
    - Eventually replaced the use of these with the NSubstitute library
        - NSubstitute - .NET mocking framework used to simplify the creation of mock objects for unit testing
- Added a clock interface to our bank to add restrictions on when deposit bonuses can be applied
- Completed [TDD Kata 2](https://osherove.com/tdd-kata-2)
## Key Takeaways
- When to use `var` versus specifying the exact type?
    - `var` can only be used on local variables - within an execution context (think a method definition)
    - new .NET features - `Calculator calculator = new(null);` also allowed
- Coupling - "the strength of relationships between code modules"
    - Do changes in one place impact/break code in other places?
    - Goal - complete autonomy
        - Responsiveness to changing requirements
    - We use tests to give us feedback about hidden coupling issues
        - Intentional feedback loop that gives us clues about the evolving nature of our application
    - When the lifetime of your dependency diverges from the lifetime of your code, you have a form of coupling 
- External vs. Internal Quality 
    - External - does it do what it should?
        - Does it meet stakeholder expectations/requirements?
        - Affects customers
    - Internal - how has the system been constructed?
        - Can we move forward with the project?
        - Maintainability, portability, re-usability, readability, testability
        - Affects developers and software itself
- A class takes responsibility for a function
    - "Owns" the knowledge - state and behavior
    - Think of the Single Responsibility Principle
- Inversion of Control - AKA Dependency Inversion Principle
- Merge conflicts
    - The longer you have code separate from the main branch, the more merge conflicts you will have
        - No long-lived duplicates of the code
            - No long running branches
            - Every developer integrates **AT LEAST** once a day
            - You cannot push code that isn't covered or has failing tests
    - The more changes to a single file, the more merge conflict you'll have
- Larry Wall's 3 Virtues of a Good Programmer:
    1. Laziness (make it easy, do it fast, etc.)
    2. Impatience (not a lot of time for extraneous processes)
    3. Hubris (always thinking you can do it better than another person)