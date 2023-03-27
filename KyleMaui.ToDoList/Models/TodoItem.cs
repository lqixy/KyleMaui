using System;
using SQLite;
namespace KyleMaui.ToDoList.Models
{
    public class TodoItem: ModelBase
    {
        public TodoItem()
        {
        }



        //[PrimaryKey,AutoIncrement]
        //public int Id { get; set; }

        public string Content { get; set; }
        ///// <summary>
        ///// 提醒日期 
        ///// </summary>
        //public DateTime? RemindDate { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 提醒时间 HH:mm
        /// </summary>
        public string RemindTime { get; set; }
        /// <summary>
        /// 截止日期
        /// </summary>
        public DateTime? Deadline { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DeadlineDescript
        {
            get
            {
                var now = DateTime.Now.Date;
                if (!Deadline.HasValue ||
                    (Deadline.HasValue && Deadline.Value.Date > now)) return "未来";
                 

                if (Deadline.Value.Date == now) return "今天";

                return "以前";
            }
        }

        /// <summary>
        /// 开启提醒
        /// </summary>
        public bool EnableRemind { get; set; }
        /// <summary>
        /// 重复 0:不重复 1:小时 2:日 3:周 4:月 5:年
        /// </summary>
        public Repeat Repeat { get; set; }
        /// <summary>
        /// 已完成
        /// </summary>
        public bool Finished { get; set; }

        public IEnumerable<TodoItem> ChildTask { get; set; } = Enumerable.Empty<TodoItem>();

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public string Attachment { get; set; }
        /// <summary>
        /// 是否标记
        /// </summary>
        public bool IsMark { get; set; }


        public void Marked()
        {
            this.IsMark = true;
        }
    }

    public class TodoItemGroup: List<TodoItem>
    {
        

        public TodoItemGroup(string title,List<TodoItem> items):base(items)
        {
            Title = title;
        }

        public string Title { get; private set; }

        public string IconPath { get; set; } = "down.png";

        public List<TodoItemGroup> TodoItems
        {
            get;
            private set;
        } = new List<TodoItemGroup>();

    }


    public enum Repeat
    {
        None,

        Hour,

        Day,

        Week,

        Month,

        Year
    }
}

