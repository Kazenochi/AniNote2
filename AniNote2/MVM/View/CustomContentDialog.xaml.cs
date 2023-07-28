using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AniNote2.MVM.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomContentDialog : Page
    {
        public CustomContentDialog(string content)
        {
            this.InitializeComponent();
            this.TextContent.Text = content;
        }
    }
}
