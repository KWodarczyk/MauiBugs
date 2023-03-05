using CommunityToolkit.Maui.Views;

namespace CollectionViewWidthInPopupIssue
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var popup = new PopupView();

            this.ShowPopup(popup);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new TestPage());
        }
    }
}