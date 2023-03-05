using CommunityToolkit.Maui.Views;

namespace MauiTest;

public partial class PopupView : Popup
{
	public PopupView()
	{

        //double dispalyHeight = (DeviceDisplay.Current.MainDisplayInfo.Height / DeviceDisplay.Current.MainDisplayInfo.Density) * 0.6;
        //double displayWidth = (DeviceDisplay.Current.MainDisplayInfo.Width / DeviceDisplay.Current.MainDisplayInfo.Density) * 0.8;
        //Size = new Size(displayWidth, dispalyHeight);

        InitializeComponent();

        //popupGrid.WidthRequest = displayWidth;

    }
}