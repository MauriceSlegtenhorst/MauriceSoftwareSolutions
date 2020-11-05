using Microsoft.AspNetCore.Components;

namespace MSS.Presentation.Blazor.PWAClient.Components.Controls.TextBox
{
    public partial class MSSTextBox
    {
        [Parameter] public string Type { get; set; }
        [Parameter] public string PlaceHolderText { get; set; }
        [Parameter] public string IconCSS { get; set; }
        [Parameter] public string TextBoxCSS { get; set; }
    }
}
