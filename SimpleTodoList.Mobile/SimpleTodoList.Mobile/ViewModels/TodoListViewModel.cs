using SimpleTodoList.Mobile.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleTodoList.Mobile.ViewModels
{
    public class TodoListViewModel
    {
        public ObservableCollection<TodoItemDTO> TodoItems { get; set; }
        public string NewTodoInputValue { get; set; }

        public ICommand AddNewTodoItemCommand { get; set; }
        public TodoListViewModel()
        {
            TodoItems = new ObservableCollection<TodoItemDTO>();
            AddNewTodoItemCommand = new Command(CreateNewTodoItem); 
        }

        public void CreateNewTodoItem()
        {
            var todoItem = new TodoItemDTO()
            {
                Id = 1,
                Description = NewTodoInputValue,
                IsComplete = false,
                IsDeleted = false,
            }; 
            TodoItems.Add(todoItem);    
        }
    }
}
