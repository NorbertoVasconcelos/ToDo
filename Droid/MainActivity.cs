using Android.App;
using Android.Widget;
using Android.Views.InputMethods;
using Android.OS;
using System.Collections.Generic;

namespace ToDo.Droid
{
	[Activity(Theme = "@style/CustomTheme", Label = "ToDo", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		ListView listView;
		EditText editTextToDo;
		CheckBox checkBox;
		Button clearCompleted;

		BaseAdapter<ToDoItem> adapter;
		IToDoController toDoController;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Initialize ToDoController
			toDoController = new ToDoController();



			// List View
			listView = FindViewById<ListView>(Resource.Id.listview);
			adapter = new ToDoListAdapter(this, toDoController.items);
			listView.Adapter = adapter;


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

			// ClearCompleted Button
			clearCompleted = FindViewById<Button>(Resource.Id.buttonClearCompleted);
			clearCompleted.Click += delegate {
				clearCompletedItems();
			};
		}

		private void HandleEditorAction(object sender, Button.EditorActionEventArgs e)
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
			toDoController.setAllItemsCompleted(isSelected);

			closeKeyboard();
			adapter.NotifyDataSetChanged();
		}

		private void clearCompletedItems()
		{
			toDoController.deleteCompletedItems();

			closeKeyboard();
			adapter.NotifyDataSetChanged();
		}

		private void addToDoItem(string itemName)
		{
			toDoController.addItem(itemName);

			editTextToDo.Text = "";
			adapter.NotifyDataSetChanged();
		}

		private void closeKeyboard()
		{
			InputMethodManager manager = (InputMethodManager)GetSystemService(InputMethodService);
			manager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, 0);
		}
	}
}