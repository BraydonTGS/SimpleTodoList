namespace SimpleTodoList.Mobile.Models
{
    public class TodoItemDTO
    {
        public int Id { get; set; } 
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public bool IsDeleted { get; set; }
    }
}
