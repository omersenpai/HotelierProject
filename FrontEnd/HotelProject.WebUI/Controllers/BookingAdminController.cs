﻿using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        //kullanıcı etkileşimlerini yönetir ve UI ile API arasındaki veri akışını sağlar.
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("OtelApiClient");
            var responseMessage = await client.GetAsync("http://localhost:8083/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsondata);
                return View(values);
            }
            return View();
        }


        public async Task<ResultBookingDto>GetByID(int id)//metod ile id'ye göre kaydı çektim. Bu metodu diğer statü güncellemeleri için de kullanmayı hedefledim.
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:8083/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //API'den dönen yanıt bir JSON string olarak geliyor. Bu JSON verisi ReadAsStringAsync() ile bir değişkene alınıyor.
                var values = JsonConvert.DeserializeObject<ResultBookingDto>(jsonData);
                //bu işlem, JSON verisini bir C# nesnesine (yani jsonData'ya) çeviriyor.
                return values;
            }
            return null;

        }




        public async Task<IActionResult>ApprovedReservation(int id)
        {
        
            var client = _httpClientFactory.CreateClient();
            var values=await GetByID(id);
            if (values!=null)
            {
                values.Status= "Onaylandı";
                var jsonPutData=JsonConvert.SerializeObject(values);
                StringContent stringContent=new StringContent(jsonPutData, Encoding.UTF8, "application/json");
                //Bu içerik, PUT isteği olarak API'ye gönderiliyor. Buradaki PutAsync metodu, veriyi güncellemek için kullanılan HTTP isteğidir.
                var responsePutMessage = await client.PutAsync($"http://localhost:8083/api/Booking/UpdateBooking", stringContent);
                if (responsePutMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return View();


            }
         
                return View();
     
        }
    }
}