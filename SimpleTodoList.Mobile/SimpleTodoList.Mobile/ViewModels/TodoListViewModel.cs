using SimpleTodoList.Mobile.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleTodoList.Mobile.ViewModels
{
    public class TodoListViewModel
    {
        public ObservableCollection<TodoItemDTO> TodoItems { get; set; }
        public string NewTodoInputValue { get; set; }

        public ICommand AddNewTodoItemCommand { get; set; }
        public ICommand RemoveTodoItemCommand { get; set; } 
        public TodoListViewModel()
        {
            TodoItems = new ObservableCollection<TodoItemDTO>();
            AddNewTodoItemCommand = new Command(CreateNewTodoItem);
            RemoveTodoItemCommand = new Command(DeleteTodoItem); 
        }

        private void DeleteTodoItem(object obj)
        {

            var id = int.Parse(obj.ToString());
            var todoToDelete = TodoItems.FirstOrDefault(x => x.Id == id);
            if (todoToDelete != null)
            {
                TodoItems.Remove(todoToDelete);
            }
        }

        public void CreateNewTodoItem()
        {
            var rnd = new Random();
            var todoItem = new TodoItemDTO()
            {
                Id = rnd.Next(1, 10001),
                Description = NewTodoInputValue,
                IsComplete = false,
                IsDeleted = false,
            }; 
            TodoItems.Add(todoItem);
            NewTodoInputValue = string.Empty; 
            
        }
    }
}
