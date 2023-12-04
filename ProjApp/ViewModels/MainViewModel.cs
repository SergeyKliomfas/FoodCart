using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    private string[] url =
    {
        "https://world.openfoodfacts.org/api/v2/product/737628064502.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/8002270014901.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/8076809513753.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/3228886048436.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/8076800195057.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/5411188115472.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/8076809529433.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/9002490205973.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/5053990138722.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/3229820791074.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url"
    };

    public ObservableCollection<Product> Products
    {
        get
        {
            return InitProducts(url);
        }
    }
    
    public ObservableCollection<Product> InitProducts(string[] str)
    {
        var tmp = new List<Product>();
        int n = str.Length;
        for (int i = 0; i < n; i++)
        {
            tmp.Add(new Product(str[i]));
        }

        return new ObservableCollection<Product>(tmp);
    }
}
