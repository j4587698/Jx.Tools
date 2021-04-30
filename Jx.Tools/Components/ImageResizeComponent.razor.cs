using System.Threading.Tasks;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;

namespace Jx.Tools.Components
{
    public partial class ImageResizeComponent: BootstrapComponentBase
    {
        private string _url;
        
        private ElementReference Resize { get; set; }
        
        [Parameter]
        public string Url {
            get => _url;
            set
            {
                if (!string.IsNullOrWhiteSpace(_url))
                {
                    _url = value;
                    Interop.InvokeVoidAsync(this, Resize, "doCrop", "bind");
                }
                
            } 
        }
        
        private JSInterop<ImageResizeComponent> Interop { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (Interop == null)
            {
                Interop = new JSInterop<ImageResizeComponent>(JSRuntime);
                await Interop.InvokeVoidAsync(this, Resize, "crop");
            }
        }
    }
}