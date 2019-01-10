using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Dsms.ViewModels;
using System.Threading.Tasks;

namespace Dsms.Components
{
    [ViewComponent(Name = "DME001_002")]
    public class DME001_002ViewComponent : ViewComponent
    {
        public DME001_002ViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // ビューモデルを生成する。
            DME001_002ViewModel viewModel = new DME001_002ViewModel();
            return await Task.FromResult(View(viewModel));
        }
    }
}
