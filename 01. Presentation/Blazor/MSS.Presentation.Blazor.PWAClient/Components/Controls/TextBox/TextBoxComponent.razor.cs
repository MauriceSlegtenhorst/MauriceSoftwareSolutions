using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSS.Presentation.Blazor.PWAClient.Components.Controls.TextBox
{
    public partial class TextBoxComponent
    {
        [Parameter] public string Type { get; set; }
        [Parameter] public string PlaceHolderText { get; set; }
    }
}
