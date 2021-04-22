using System.Threading.Tasks;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;

namespace Jx.Tools.Components
{
    public partial class ImageResizeComponent: BootstrapComponentBase
    {
        private ElementReference Resize { get; set; }
        
        [Parameter]
        public string Url { get; set; }
        
        private JSInterop<ImageResizeComponent> Interop { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (!string.IsNullOrWhiteSpace(Url))
            {
                if (Interop == null)
                {
                    Interop = new JSInterop<ImageResizeComponent>(JSRuntime);
                    await Interop.InvokeVoidAsync(this, Resize, "crop");
                }
            }
        }
    }
}