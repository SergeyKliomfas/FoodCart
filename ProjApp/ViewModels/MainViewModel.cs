using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using ImageExample.Helpers;
using Newtonsoft.Json.Linq;
using ProjApp.Views;

namespace ProjApp.ViewModels;

public class MainViewModel
{
    private const string Url2 = "https://world.openfoodfacts.net/api/v2/product/3017624010701?fields=product_name,nutrition_grades,allergens,image_front_url";
    private const string Url1 = "https://world.openfoodfacts.net/api/v2/product/8076809513753?fields=product_name,nutrition_grades,allergens,image_front_url,image_url";
    private static readonly Product _prod1 = new Product(Url1);
    
    
    public String Prod1Name
    {
        get
        {
            return _prod1.name;
        }
    }
    
    public String Prod1Nut
    {
        get
        {
            return _prod1.nutriscore_grade;
        }
    }
    
    public String Prod1Aller
    {
        get
        {
            return _prod1.allergens;
        }
    }
    public Task<Bitmap?> ImageFromWebsite { get; } = ImageHelper.LoadFromWeb(new Uri(_prod1.image_url));
    
    
/*private Product ReturnProductInfo(string url)
    {
        Product prod = new Product();
        var request = new GetRequest(url);
        request.Run();
        var response = request.Response;
        JObject json = JObject.Parse(response);

        var product = json["product"];
        var _name = product["product_name"];
        var _nut = product["nutriscore_grade"];
        var _allergens = product["allergens"];
        var _image = product["image_front_url"];
        
        prod.name = _name.ToString();
        prod.nutriscore_grade = _nut.ToString();
        prod.allergens = _allergens.ToString();
        prod.image_url = _image.ToString();
        
        return prod;
    }
*/
}

/*
using System;
   using System.Collections.Generic;
   using System.Net;
   using System.Net.Http;
   using System.Threading.Tasks;
   using Avalonia.Media;
   using Newtonsoft.Json.Linq;
   using ProjApp.Views;
   
   namespace ProjApp.ViewModels;
   
   public class MainViewModel
   {
   public string Prod
   {
   get
   {
   return ReturnString();
   }
   set
   {
   
   }
   }
   
   public string ReturnString()
   {
   var request = new GetRequest("https://world.openfoodfacts.net/api/v2/product/3017624010701?fields=product_name,nutrition_grades,allergens");
   request.Run();
   
   var response = request.Response;
   
   JObject json = JObject.Parse(response);
   
   var product = json["product"];
   var tmp = product["product_name"];
   
   string ans = tmp.ToString();
   return ans;
   }
   }
*/