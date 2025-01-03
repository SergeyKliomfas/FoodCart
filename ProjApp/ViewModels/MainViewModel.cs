using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjApp.ViewModels;

public class MainViewModel : ObservableObject
{
    private string[] url =
    {
        "https://world.openfoodfacts.org/api/v2/product/5449000214799.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/8002270014901.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/8076809513753.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/3228886048436.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/8076800195057.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/5411188115472.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/8076809529433.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/9002490205973.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/7622300744663.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/3347761000670.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/3228857001118.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/4001954161010.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/3038352880305.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/3229820791074.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/3474341105842.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url"
    };
    
    public ObservableCollection<Product> Products { get; set; } // коллекция продуктов
    public ObservableCollection<Product> CartColl { get; set; } // коллекция продуктов в корзине
    
    private int CountN { get; set; }
    private int Count { get; set; }

    private string mean;
    public string Mean {
        get
        {
            return mean;
        }
        set
        {
            mean = value;
        } 
    }

    public string MeanNutri() //ф-я для подсчета среднего N-score
    {
        string tmp;
        if (Count != 0)
        {
            double sum = CountN / Count;
            switch (Math.Round(sum))
            {
                case (5):
                    tmp = "A";
                    break;
                case (4):
                    tmp = "B";
                    break;
                case (3):
                    tmp = "C";
                    break;
                case (2):
                    tmp = "D";
                    break;
                case (1):
                    tmp = "E";
                    break;
                case (0):
                    tmp = "0";
                    break;
                default:
                    tmp = "-1";
                    break;
            }
        }
        else
        {
            tmp = "";
        }

        return tmp;
    }

    public void AddCart(Product obj) // Добавление в корзигу
    {
        Product tmp = obj;
        CartColl.Add(tmp);
        CountN += tmp.n_count;
        Count++;
        Mean = MeanNutri();
        OnPropertyChanged(nameof(Mean));
    }
    
    public void DeleteProduct(Product obj) // Удаление из корзины
    {
        Product tmp = obj;
        CartColl.Remove(tmp);
        CountN -= tmp.n_count;
        Count--;
        Mean = MeanNutri();
        OnPropertyChanged(nameof(Mean));
    }
    public MainViewModel() // Инициализация коллекций 
    {
        CartColl = new ObservableCollection<Product>();
        Products = InitProducts(url);
    }
    
    private ObservableCollection<Product> InitProducts(string[] str) //ф-я для инициализации Product коллекции
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
