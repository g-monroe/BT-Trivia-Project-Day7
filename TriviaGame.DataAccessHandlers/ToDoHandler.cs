using TriviaGame.Core.Interfaces.DataAccessHandlers;
using TriviaGame.Core.Models;
using TriviaGame.DataAccessHandlers.Infrastructure;

namespace TriviaGame.DataAccessHandlers
{
    public class ToDoHandler : BaseHandler<ToDoEntity>, IToDoHandler
    {
        public ToDoHandler(TriviaGameContext context) : base(context)
        {
        }

        // Any additional custom methods can go here
    }
}
