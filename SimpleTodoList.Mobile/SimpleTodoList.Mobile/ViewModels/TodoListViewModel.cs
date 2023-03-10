using SimpleTodoList.Mobile.Models;
using SimpleTodoList.Mobile.Service;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace SimpleTodoList.Mobile.ViewModels
{
    public class TodoListViewModel : INotifyPropertyChanged
    {

        private RestService _service;
        public ObservableCollection<TodoItemDTO> TodoItems { get; set; }
        private string _newTodoInputValue { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddNewTodoItemCommand { get; set; }
        public ICommand RemoveTodoItemCommand { get; set; }
        public TodoListViewModel()
        {
            _service = new RestService();
            LoadDataFromApi();
            TodoItems = new ObservableCollection<TodoItemDTO>();
            AddNewTodoItemCommand = new Command(CreateNewTodoItem);
            RemoveTodoItemCommand = new Command(DeleteTodoItem);
        }

        public string NewTodoInputValue
        {
            get { return _newTodoInputValue; }
            set
            {
                _newTodoInputValue = value;
                OnPropertyChanged();
            }
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
            NewTodoInputValue = "";
            TodoItems.Add(todoItem);
        }

        public void LoadDataFromApi()
        {
            var url = _service.TodoUrl;
            var status = _service.client.GetStringAsync(url).Result;
            var result = JsonConvert.DeserializeObject<TodoItemDTO>(status);
            TodoItems.Add(result);  

        }
 
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
