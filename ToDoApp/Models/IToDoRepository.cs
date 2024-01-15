using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models
{
    public interface IToDoRepository
    {
        public IEnumerable<ToDo> ToDo();
        void SaveToDo(ToDo todo);
        ToDo DeleteToDo(int ToDoId);
    }
}
