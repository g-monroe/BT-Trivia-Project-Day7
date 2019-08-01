using System;
using System.Collections.Generic;
using System.Text;
using TriviaGame.Core.Models;

namespace TriviaGame.Core.Interfaces.Engines
{
    public interface IToDoEngine
    {
        IEnumerable<ToDoEntity> GetToDos();
        ToDoEntity GetToDo(int id);
        ToDoEntity CreateToDoEntity(string title, string description, DateTime? dueDate = null);
        ToDoEntity UpdateDueDate(ToDoEntity entity, DateTime? dueDate = null);
    }
}
