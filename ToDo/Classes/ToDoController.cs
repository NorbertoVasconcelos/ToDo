using System;
using System.Collections.Generic;

namespace ToDo
{
	public class ToDoController : IToDoController
	{

		List<ToDoItem> toDoItems = new List<ToDoItem>();

		public List<ToDoItem> items
		{
			get
			{
				return toDoItems;
			}

			set
			{
				toDoItems = value;
			}
		}

		public ToDoController()
		{
		}

		public void deleteCompletedItems()
		{
			List<ToDoItem> completedItems = getCompleted();
			foreach (ToDoItem item in completedItems)
			{
				toDoItems.Remove(item);
			}
		}

		public void addItem(string itemName) 
		{
			ToDoItem newItem = new ToDoItem(itemName);
			toDoItems.Add(newItem);
		}

		public void deleteItem(int index) 
		{
			toDoItems.RemoveAt(index);
		}

		public void setAllItemsCompleted(bool completed)
		{
			foreach (ToDoItem item in toDoItems)
			{
				item.completed = completed;
			}
		}

		private List<ToDoItem> getCompleted()
		{
			List<ToDoItem> completedItems = new List<ToDoItem>();
			foreach (ToDoItem item in toDoItems)
			{
				if (item.completed)
				{
					completedItems.Add(item);
				}
			}
			return completedItems;
		}
	}
}
