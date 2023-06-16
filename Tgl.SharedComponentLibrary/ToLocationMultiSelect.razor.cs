using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tgl.SharedComponentLibrary
{
    public partial class ToLocationMultiSelect
    {
        [Parameter]
        public EventCallback<string[]> OnToLocationSelected { get; set; }

        void OnToLocationSelect(ChangeEventArgs args)
        {
            OnToLocationSelected.InvokeAsync((string[]?)args.Value);
        }
    }
}
