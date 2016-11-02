using System.Collections;
using Android.Widget;
using Android.Views;
using Android.App;
using System;
namespace ToDo.Droid
{
	public class ToDoListAdapter : BaseAdapter<ToDoItem>
	{
		ArrayList items = new ArrayList();
		Activity context;

		public ToDoListAdapter(Activity activity, ArrayList items) : base()		
		{
			this.items = items;
			this.context = activity;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override ToDoItem this[int position]
		{
			get 
			{
				ToDoItem item = (ToDoItem)items[position];
				return item;
			}
		}

		public override int Count
		{
			get { return items.Count; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View listItemView = convertView; // re-use an existing view, if one is available
			if (listItemView == null) // otherwise create a new one
				listItemView = context.LayoutInflater.Inflate(Resource.Layout.TodoListItem, null);

			// Populate the view with information from the item
			var item = (ToDoItem)items[position];
			listItemView.FindViewById<EditText>(Resource.Id.editTextName).Text = item.text;
			CheckBox checkbox = listItemView.FindViewById<CheckBox>(Resource.Id.checkBoxCompleted);
			//checkbox.Selected = item.completed;
			checkbox.Checked = item.completed;

			return listItemView;
		}
	}
}
