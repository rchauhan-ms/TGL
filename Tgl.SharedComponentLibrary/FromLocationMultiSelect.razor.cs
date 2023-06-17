using Microsoft.AspNetCore.Components;

namespace Tgl.SharedComponentLibrary
{
    public partial class FromLocationMultiSelect
    {
        //[Parameter]
        //public EventCallback<string[]> OnFromLocationSelected { get; set; }
        
        //[Parameter]
        //public string[] SelectedLocations { get; set; } = new string[] { };
        //void OnFromLocationSelect(ChangeEventArgs args)
        //{
        //    OnFromLocationSelected.InvokeAsync((string[]?)args.Value);
        //}

        [Parameter]
        public string[] FromLocationSelected { get; set; }
    }
}
