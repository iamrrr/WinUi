using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using Windows.Storage.Pickers;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ImageViewer
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public ImagesRepo ImagesRepo { get; } = new();
        public MainWindow()
        {
            this.InitializeComponent();
            this.Title = "My Image VIewer";
            //string folderPath = @"D:\Marriage\Bapi Bhai Pics";
            //ImagesRepo.GetImages(folderPath);
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            FolderPicker browser = new FolderPicker();
            browser.FileTypeFilter.Add("*");

            var handle = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WinRT.Interop.InitializeWithWindow.Initialize(browser, handle);

            var folder = await browser.PickSingleFolderAsync();
            if(folder != null)
            {
                ImagesRepo.GetImages(folder.Path);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var imageInfo = (sender as Button)?.DataContext as ImageInfo;
            if(imageInfo != null)
            {
                var newWindow = new ImagePopup();
                newWindow.Title = imageInfo.Name;
                newWindow.SetPopupImage(new BitmapImage(new Uri(imageInfo.FullName, UriKind.Absolute)));
                newWindow.Activate();
            }
            // C# code to create a new window
            
            
        }
    }
}
