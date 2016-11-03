using System.Collections.Generic;
using Android.Widget;
using Android.Views;
using Android.App;
using System;
namespace ToDo.Droid
{
	public class ToDoListAdapter : BaseAdapter<ToDoItem>
	{
		List<ToDoItem> items = new List<ToDoItem>();
		Activity context;

		public ToDoListAdapter(Activity activity, List<ToDoItem> items) : base()		
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
			// Bool of first time the view is created
			bool newView = false;

			// View item
			var item = (ToDoItem)items[position];

			// Views
			View listItemView = convertView; // re-use an existing view, if one is available
			if (listItemView == null) // otherwise create a new one
			{
				listItemView = context.LayoutInflater.Inflate(Resource.Layout.TodoListItem, null);
				newView = true;
			}

			// Find views
			EditText editText = listItemView.FindViewById<EditText>(Resource.Id.editTextName);
			ImageButton btnDelete = listItemView.FindViewById<ImageButton>(Resource.Id.buttonDelete);
			CheckBox checkbox = listItemView.FindViewById<CheckBox>(Resource.Id.checkBoxCompleted);

			if (newView) // Create handlers (once per view)
			{
				// Btn Delete
				btnDelete.Focusable = false;
				btnDelete.FocusableInTouchMode = false;
				btnDelete.Clickable = true;
				btnDelete.Click += (sender, e) =>
				{
					int pos = (int)btnDelete.Tag;
					Console.WriteLine(pos);
					items.RemoveAt(pos);
					NotifyDataSetChanged();
				};

				// Checkbox
				checkbox.CheckedChange += (sender, e) =>
				{
					CheckBox c = (CheckBox)sender;
					item.completed = c.Checked;
				};
			}

			// EditText
			editText.Text = item.text;

			// Checkbox
			checkbox.Checked = item.completed;

			// Btn Delete
			btnDelete.Tag = position;

			return listItemView;
		}
	}
}
