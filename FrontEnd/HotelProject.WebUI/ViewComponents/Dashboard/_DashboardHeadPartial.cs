using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardHeadPartial:ViewComponent
    {
        public IViewComponentResult Invoke()//sık kullanılan ya da belirli bir işlevi olan UI parçalarını, bağımsız ve yeniden kullanılabilir bileşenler olarak ayırarak farklı sayfalarda kolayca kullanılmasını sağlar
        {
            return View();
        }
    }
}
