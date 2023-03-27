using System;
using SQLite;
namespace KyleMaui.ToDoList.Models
{
    public class ModelBase
    {
        public ModelBase()
        {
        }

        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
    }
}

