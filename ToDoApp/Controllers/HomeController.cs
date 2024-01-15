using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class HomeController : Controller
    {
        private IToDoRepository _repository;

        public HomeController(IToDoRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index()
        {
            return View(_repository.ToDo());
        }
         
        public IActionResult Edit(ToDo todo)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveToDo(todo); 
                TempData["message"] = $"Edit";
                return RedirectToAction("Index");
            }
            else
            {
                return View(todo);
            }
        }

        public IActionResult Delete(int id)
        {
            ToDo deleteToDo = _repository.DeleteToDo(id);
            if(deleteToDo != null)
            {
                TempData["message"] = $"{deleteToDo.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
