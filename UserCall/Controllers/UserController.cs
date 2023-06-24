using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserCall.Models;

namespace UserCall.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7223/api");
        HttpClient client;
        public UserController()
        {
            client= new HttpClient();
            client.BaseAddress = baseAddress;
        }
        
        public IActionResult Index()
        {
            List<UserViewModel> modelList= new List<UserViewModel>();
            //apiye ulaştık get metodu çalıştı.Geriye status code ve datalar döndürür.
            HttpResponseMessage response=client.GetAsync(client.BaseAddress+"/UserApi").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                //json formatında veriyi okuduk data da json veri var.
                modelList=JsonConvert.DeserializeObject<List<UserViewModel>>(data);
                //json formatındaki data yı deserilize ettik (UserViewModel'e)
            }
            return View(modelList);
        }
    }
}
