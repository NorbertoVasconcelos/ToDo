using System;
using Android.Widget;
using Android.Views;
using Android.App;
namespace ToDo.Droid
{
	public class ToDoListAdapter : BaseAdapter<ToDoItem>
	{
		ToDoItem[] items;
		Activity context;

		public ToDoListAdapter(Activity activity, ToDoItem[] items) : base()		
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
			get { return items[position]; }
		}

		public override int Count
		{
			get { return items.Length; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View listItemView = convertView; // re-use an existing view, if one is available
			if (listItemView == null) // otherwise create a new one
				listItemView = context.LayoutInflater.Inflate(Resource.Layout.TodoListItem, null);

			// Populate the view with information from the item
			var item = items[position];
			listItemView.FindViewById<EditText>(Resource.Id.editTextName).Text = item.text;
			listItemView.FindViewById<CheckBox>(Resource.Id.checkBoxCompleted).Selected = item.completed;
			return listItemView;
		}
	}
}
