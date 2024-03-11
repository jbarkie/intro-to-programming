# Monday, March 11 Notes

- Discussed history of the web and web development
  - Flash, Chrome, HTML, JavaScript
  - Then came HTML5 with the DOM and frameworks like AngularJS and React
  - AngularJS -> upgraded to Angular 2 which was completely different
    - AngularJS built on JS while next iterations built on TS
- Learned how to use NPM
  - `package.json` is the equivalent of a .csproj file in a .NET project
    - Lists dependencies needed for a given project
- Created new Angular project using the Angular CLI
- Set up Tailwind CSS in Angular project
- Added daisyUI to project
- Updated formatting settings
  - Prettier - a reccomended workspace extension
  - Auto format on save
- Learned general organization/structure of Angular apps
- Added some new components to our Todo List
  - Learned how routing works
  - Learned where and how to use signals
  - Learned how to conditionally render and apply classes to markup
  - Learned how to create reactive forms and use form groups/controls
  - Learned EventEmitter, Inputs, and Outputs

## Key Takeaways

- TypeScript
  - "Superset of JavaScript" - compiled to JavaScript
  - Nothing can run TS natively
- In general, .NET properties should:
  - not throw exceptions
  - not involve "compute" - no Async stuff
  - return the same value for every "get" after it's set
- Google's Angular team forked TypeScript repo from Microsoft to add things like attributes
  - Eventually merged into the main branch and adopted as part of the language
