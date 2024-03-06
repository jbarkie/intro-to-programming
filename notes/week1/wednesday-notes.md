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