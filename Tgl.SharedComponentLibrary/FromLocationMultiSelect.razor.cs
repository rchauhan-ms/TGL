using Microsoft.AspNetCore.Components;

namespace Tgl.SharedComponentLibrary
{
    public partial class FromLocationMultiSelect
    {
        [Parameter]
        public EventCallback<string[]> OnFromLocationSelected { get; set; }

        void OnFromLocationSelect(ChangeEventArgs args)
        {
            OnFromLocationSelected.InvokeAsync((string[]?)args.Value);
        }
    }
}
