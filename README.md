# Trivia Project

## Goals
- Adapt the trivia game we create on day one  
- Store questions/answers in the DB  
- Create a front end to display the questions  
- Be able to select answers and submit  
- Display results to the user  

## Stretch Goals
- Display each question 1 by 1 using React Router  
- Save results in the DB  
- Make it pretty  
- Give ability to add questions to the list  
- Create a "leaderboard"


## Running the Project
Navigate to the Web project using Visual Studio, or in the terminal.  
Start IIS Express
> Or from the terminal - `dotnet run`


---
## Structure

### Core
Models and interfaces to be used throughout the solution can be included here

### DataAccessHandlers
Anything dealing with Database access or data access from any external resource should go here, with an accompanying interface in the core project.

### Engines
Resuable chunks of business logic should go here
> Loading, Saving, Updating are usually good cases

### Managers
Larger workflow management, should make heavy use of the engine functionality you have available
> These should probably be 1-to-1 with each Controller method in the web project

### Web
Presentation layer - this contains all of your React code and your API controllers
> Goal is to keep this mostly focused on the client-side of the application, and to keep the server-side code as minimal as possible.