using Microsoft.EntityFrameworkCore;
using TriviaGame.Core.Interfaces.DataAccessHandlers;
using TriviaGame.Core.Models;

namespace TriviaGame.DataAccessHandlers
{
    public class ToDoHandler : BaseHandler<ToDoEntity>, IToDoHandler
    {
        public ToDoHandler(DbContext context) : base(context)
        {
        }

        // Any additional custom methods can go here
    }
}
