using HotelProject.WebUI.Dtos.GuestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient("OtelApiClient");
            var responseMessage = await client.GetAsync("http://localhost:8083/api/DashboardWidgets/StaffCount");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();   
            ViewBag.staffCount = jsondata;


            var client2 = _httpClientFactory.CreateClient("OtelApiClient");
            var responseMessage2 = await client2.GetAsync("http://localhost:8083/api/DashboardWidgets/BookingCount");
            var jsondata2 = await responseMessage2.Content.ReadAsStringAsync();     
            ViewBag.bookingCount = jsondata2;

            var client3 = _httpClientFactory.CreateClient("OtelApiClient");
            var responseMessage3 = await client3.GetAsync("http://localhost:8083/api/DashboardWidgets/AppUserCount");
            var jsondata3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.appUserCount = jsondata3;

            var client4 = _httpClientFactory.CreateClient("OtelApiClient");
            var responseMessage4 = await client4.GetAsync("http://localhost:8083/api/DashboardWidgets/RoomCount");
            var jsondata4 = await responseMessage4.Content.ReadAsStringAsync();

            ViewBag.roomCount = jsondata4;


            return View();
        }
    }
}
