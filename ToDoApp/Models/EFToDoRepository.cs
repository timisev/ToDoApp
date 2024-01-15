

namespace ToDoApp.Models
{
    public class EFToDoRepository : IToDoRepository
    {
        private ApplicationDbContext _context;

        public EFToDoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
         
        public IEnumerable<ToDo> ToDo() => _context.ToDo;
          
        public void SaveToDo(ToDo todo)
        {
            if (todo.Id == 0)
            {
                _context.ToDo.Add(todo);
            }
            else
            {
                ToDo dbEntry = _context.ToDo.FirstOrDefault(t => t.Id == todo.Id);
                if(dbEntry != null)
                {
                    dbEntry.Name = todo.Name;
                    dbEntry.Text = todo.Text;
                }
            }
            _context.SaveChanges();
        }

        public ToDo DeleteToDo(int ToDoId)
        {
            ToDo dbEntry = _context.ToDo.FirstOrDefault(t => t.Id == t.Id);
            
            if (dbEntry != null)
            {
                _context.ToDo.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
