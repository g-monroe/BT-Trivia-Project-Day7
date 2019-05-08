using System;
using System.Collections.Generic;
using TriviaGame.Core.Interfaces.Engines;
using TriviaGame.Core.Interfaces.Managers;
using TriviaGame.Core.Models;

namespace TrivaGame.Managers
{
    public class ToDoManager : IToDoManager
    {
        private readonly IToDoEngine _toDoEngine;
        public ToDoManager(IToDoEngine toDoEngine)
        {
            _toDoEngine = toDoEngine;
        }

        public ToDoEntity AddNewToDo(string title, string description, DateTime? dueDate = null)
        {
            return _toDoEngine.CreateToDoEntity(title, description, dueDate);
        }

        public IEnumerable<ToDoEntity> GetToDos()
        {
            return _toDoEngine.GetToDos();
        }

        public ToDoEntity UpdateDueDate(int id, DateTime? dueDate = null)
        {
            var entity = _toDoEngine.GetToDo(id);
            return _toDoEngine.UpdateDueDate(entity, dueDate);
        }
    }
}
