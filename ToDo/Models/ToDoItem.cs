using System;
namespace ToDo
{
	public struct ToDoItem
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
