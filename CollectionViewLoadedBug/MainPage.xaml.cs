namespace CollectionViewLoadedBug
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void mycollectionview_Loaded(object sender, EventArgs e)
        {

            var h1 = mycollectionview.Height;
            var h2 = mycollectionview.DesiredSize.Height;
            var h3 = mycollectionview.Frame.Height;


            var numberOfVisibleItems = ((IElementController)mycollectionview).LogicalChildren.Count;
        }
    }
}