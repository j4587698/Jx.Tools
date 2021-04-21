using System.Threading.Tasks;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;

namespace Jx.Tools.Components
{
    public partial class ImageResizeCompenent: BootstrapComponentBase
    {
        private ElementReference Resize { get; set; }
        
        private JSInterop<ImageResizeCompenent> Interop { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                if (Interop == null)
                {
                    Interop = new JSInterop<ImageResizeCompenent>(JSRuntime);
                    await Interop.InvokeVoidAsync(this, Resize, "crop");
                }
            }
        }
    }
}