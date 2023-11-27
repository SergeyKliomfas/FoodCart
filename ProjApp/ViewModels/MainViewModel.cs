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
        "https://world.openfoodfacts.net/api/v2/product/8076809513753?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.net/api/v2/product/3175680011480?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.net/api/v2/product/5449000214799?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.net/api/v2/product/3228857000166?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.net/api/v2/product/20267605?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.net/api/v2/product/3033710084913?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.net/api/v2/product/3256540000698?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.net/api/v2/product/8076800195057?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.net/api/v2/product/3083680002875?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.net/api/v2/product/5941000025608?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.net/api/v2/product/8715700017006?fields=product_name,nutrition_grades,allergens,image_front_url,image_url"
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
