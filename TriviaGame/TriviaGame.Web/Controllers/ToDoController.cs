using Microsoft.AspNetCore.Mvc;
using TriviaGame.Core.Interfaces.Managers;

namespace TriviaGame.Web.Controllers
{
    [Route("api/todos")]
    public class ToDoController : Controller
    {
        private readonly IToDoManager _toDoManager;
        public ToDoController(IToDoManager toDoManager)
        {
            _toDoManager = toDoManager;
        }

        [HttpGet]
        public IActionResult GetTodos()
        {
            return Json(_toDoManager.GetToDos());
        }
    }
}
