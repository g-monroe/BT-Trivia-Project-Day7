using System;
using System.Collections.Generic;
using System.Text;
using TriviaGame.Core.Models;

namespace TriviaGame.Core.Interfaces.Managers
{
    public interface IToDoManager
    {
        IEnumerable<ToDoEntity> GetToDos();
        ToDoEntity AddNewToDo(string title, string description, DateTime? dueDate = null);
        ToDoEntity UpdateDueDate(int id, DateTime? dueDate = null);
    }
}
