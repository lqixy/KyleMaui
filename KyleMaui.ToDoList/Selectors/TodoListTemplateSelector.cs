using System;
namespace KyleMaui.ToDoList.Selectors
{
    public class TodoListTemplateSelector: DataTemplateSelector
    {
        public TodoListTemplateSelector()
        {
        }

        public DataTemplate Before { get; set; }
        public DataTemplate Future { get; set; }
        public DataTemplate Today { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var todo = item as TodoItem;
            var now = DateTime.Now.Date;
            if (todo.Deadline < now)
                return Before;
            else if (todo.Deadline > now)
                return Future;

            return Today;
        }
    }
}

