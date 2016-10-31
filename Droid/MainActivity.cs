using Android.App;
using Android.Widget;
using Android.OS;

namespace ToDo.Droid
{
	[Activity(Theme = "@android:style/Theme.Material.Light", Label = "ToDo", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		ListView listView;
		ToDoItem[] toDoItems = new ToDoItem[5];

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			listView = FindViewById<ListView>(Resource.Id.listview); // get reference to the listview in the layout


			// Dummy test Data
			for (int i = 0; i < 5; i++)
			{
				toDoItems[i] = new ToDoItem("Test");
			}

			listView.Adapter = new ToDoListAdapter(this, toDoItems); // populate the listview with data
		}
	}
}