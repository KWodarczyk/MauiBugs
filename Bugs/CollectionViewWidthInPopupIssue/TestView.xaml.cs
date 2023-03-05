namespace CollectionViewWidthInPopupIssue;

public partial class TestView : ContentView
{

	public TestView()
	{

        InitializeComponent();

        var list1 = new List<int>();

        for (int i = 0; i < 60; i++)
        {
            list1.Add(i);
        }

        List1.ItemsSource = list1;

        var list2 = new List<int>();

        for (int i = 0; i < 60; i++)
        {
            list2.Add(i);
        }

        List2.ItemsSource = list2;

    }
}