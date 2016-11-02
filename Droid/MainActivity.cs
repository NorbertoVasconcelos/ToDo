using Android.App;
using Android.Widget;
using Android.Views.InputMethods;
using Android.OS;
using System.Collections;

namespace ToDo.Droid
{
	[Activity(Theme = "@android:style/Theme.Material.Light", Label = "ToDo", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		ListView listView;
		BaseAdapter<ToDoItem> adapter;
		EditText editTextToDo;
		CheckBox checkBox;
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

			// CheckBox
			checkBox = FindViewById<CheckBox>(Resource.Id.checkBoxSelectAll);
			checkBox.CheckedChange += (sender, e) =>
			{
				CheckBox c = (CheckBox)sender;
				selectAll(c.Checked);
			};
		}

		private void HandleCheckBoxAction(object sender, CheckBox.EditorActionEventArgs e)
		{
			CheckBox c = (CheckBox)sender;
			selectAll(c.Checked);
			e.Handled = true;
		}

		private void HandleEditorAction(object sender, EditText.EditorActionEventArgs e)
		{
			e.Handled = false;
			if (e.ActionId == ImeAction.Done)
			{
				EditText editText = (EditText)sender;
				addToDoItem(editText.Text);
				e.Handled = true;
			}
		}

		private void selectAll(bool isSelected)
		{
			closeKeyboard();
			foreach (ToDoItem item in toDoItems)
			{
				item.completed = isSelected;
			}
			adapter.NotifyDataSetChanged();
		}

		private void addToDoItem(string itemName)
		{
			editTextToDo.Text = "";
			ToDoItem newItem = new ToDoItem(itemName);
			toDoItems.Add(newItem);
			adapter.NotifyDataSetChanged();
		}

		private void closeKeyboard()
		{
			InputMethodManager manager = (InputMethodManager)GetSystemService(InputMethodService);
			manager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, 0);
		}
	}
}