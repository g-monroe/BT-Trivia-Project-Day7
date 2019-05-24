# Trivia Project

## Goals
- Adapt the trivia game we create on day one  
- Store questions/answers in the DB  
- Create a front end to display the questions  
- Be able to select answers and submit  
- Display results to the user  

## Possible Next Steps (Be creative)
- Display each question 1 by 1 using React Router  
- Save results in the DB  
- Make it pretty  
- Give ability to add questions to the list  
- Create a "leaderboard"


## Running the Project
Open the solution file.   
Build  
Run "Update-Database"  
In the `TriviaGame.Web/ClientApp` folder, `npm install`  
Start IIS Express. (This will automatically run `npm start` for you)  


---
## Structure

### Core
Models and interfaces to be used throughout the solution can be included here

### DataAccessHandlers
Anything dealing with Database access or data access from any external resource should go here, with an accompanying interface in the core project.

### Engines
Resuable chunks of business logic should go here, with an accompanying interface in the core project.
> Loading, Saving, Updating are usually good cases

### Managers
Larger workflow management, should make heavy use of the engine functionality you have available
Add an accompanying interface in the core project.
> These should probably be 1-to-1 with each Controller method in the web project

### Web
Presentation layer - this contains all of your React code and your API controllers
> Goal is to keep this mostly focused on the client-side of the application, and to keep the controllers as minimal as possible.

---
## Other Notes

### Dependency Injection
DI is mananged at each level. Look at the `Infrastructure/Configuration.cs` file that exists in each project that will be using DI. This is done to better separate the layers.

### Static
Don't use static methods with DI. It doesn't work. In .NET, it's better to make it an instance class or method, until it needs to be a static one, rather than the other way around.
