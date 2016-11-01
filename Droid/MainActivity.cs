using Android.App;
using Android.Widget;
using Android.Views.InputMethods;
using Android.OS;
using System.Collections;
using System;

namespace ToDo.Droid
{
	[Activity(Theme = "@android:style/Theme.Material.Light", Label = "ToDo", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		ListView listView;
		BaseAdapter<ToDoItem> adapter;
		EditText editTextToDo;
		ArrayList toDoItems = new ArrayList();

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			listView = FindViewById<ListView>(Resource.Id.listview); // get reference to the listview in the layout
			adapter = new ToDoListAdapter(this, toDoItems);
			listView.Adapter = adapter; // populate the listview with data


			// EditText
			editTextToDo = FindViewById<EditText>(Resource.Id.editTextToDo);
			editTextToDo.EditorAction += HandleEditorAction;


		}

		private void HandleEditorAction(object sender, EditText.EditorActionEventArgs e)
		{
			Console.WriteLine("ENTROU NESSA PORRA!");
			e.Handled = false;
			if (e.ActionId == ImeAction.Done)
			{
				Console.WriteLine("ACTION DONE");
				EditText editText = (EditText)sender;
				addToDoItem(editText.Text);
				e.Handled = true;
			}
		}

		private void addToDoItem(string itemName)
		{
			ToDoItem newItem = new ToDoItem(itemName);
			toDoItems.Add(newItem);
			adapter.NotifyDataSetChanged();
		}
	}
}