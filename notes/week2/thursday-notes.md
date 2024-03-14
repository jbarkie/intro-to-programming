# Thursday, March 14 Notes

- Added extra selectors to our Counter feature in our frontend project to dynamically display whether the current count is even, odd, and what the value would be if incremented or decremented by the current interval value.
- Refined JSON response body for getting all Todos items
  - Priority enum converted from integer values to corresponding string ("High, Low")
  - Null properties omitted from response body
- Add Todos state
  - If list is empty - indicate to user
  - Define state with selectors to return TodosList
- Used `ng generate environments` to generate Production and Development environment URLs that can be referenced for making API calls, etc.
- Refined CreateTodosResponse JSON body so that
- Added validation to "Description" input field
  - Reactive forms
- Added a cancellation token to GET /todos so that our SQL query is only executed once for multiple requests made at the same time
  - Efficiency / performance / redundancy
- `mergeMap()` versus `switchMap()`
- `upsertOne()` - insert if it doesn't already exist, else, update existing reference
- Added effects & actions to update state accordingly and make API calls when a new user wants to add a Todo item, mark a Todo item as complete
  - Also to fetch all corresponding Todo items when the application starts or refreshes
    - Handle loading state - use an indicator instead of a modal/error dialogue that indicates to user that their list is empty
      - Creates further confusion

## Jeff's Notes

- Add some JSON options on our API for the status.
- Get our Angular Application using our API
- Creating our state for the Todo List
- Selecting the State
- Adding Effects 
    - When the application starts, load our TODO list. - urls,
 environments, CORS 
    - Get it into the state.
- Adding new Todos 
    - Update our form to allow an optional due date
- Marking Complete, Incomplete
