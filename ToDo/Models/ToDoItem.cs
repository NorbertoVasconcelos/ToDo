using System;
namespace ToDo
{
	public class ToDoItem
	{
		public string text;
		public bool completed;
		public bool active;

		public ToDoItem(string text)
		{
			this.text = text;
			this.completed = false;
			this.active = false;
		}
	}
}
