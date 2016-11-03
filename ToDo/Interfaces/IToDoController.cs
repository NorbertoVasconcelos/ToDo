using System;
using System.Collections.Generic;
namespace ToDo
{
	public interface IToDoController
	{
		List<ToDoItem> items { get; set; }
		void deleteCompletedItems();
		void addItem(string itemName);
		void deleteItem(int index);
		void setAllItemsCompleted(bool completed);
	}
}
