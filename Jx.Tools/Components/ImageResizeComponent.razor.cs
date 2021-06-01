using System.Threading.Tasks;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;

namespace Jx.Tools.Components
{
    public partial class ImageResizeComponent: BootstrapComponentBase
    {
        private string _url;

        private int _width;

        private int _height;

        private bool _isModify;
        
        private ElementReference Resize { get; set; }
        
        [Parameter]
        public string Url {
            get => _url;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _url = value;
                    _isModify = true;
                }
                
            } 
        }

        public int Width
        {
            get => _width;
            set
            {
                if (value > 0)
                {
                    _width = value;
                    _isModify = true;
                }
            }
        }

        private JSInterop<ImageResizeComponent> Interop { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            Interop ??= new JSInterop<ImageResizeComponent>(JSRuntime);

            if (_isModify)
            {
                await Interop.InvokeVoidAsync(this, Resize, "crop", new { Url = _url });
            }
        }
    }
}