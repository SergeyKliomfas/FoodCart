using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjApp.ViewModels;

public class MainViewModel : INotifyPropertyChanged
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
        "https://world.openfoodfacts.org/api/v2/product/5053990138722.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url",
        "https://world.openfoodfacts.org/api/v2/product/3229820791074.json?fields=product_name,nutrition_grades,allergens,image_front_url,image_url"
    };
    
    public ObservableCollection<Product> Products { get; set; }
    public ObservableCollection<Product> CartColl { get; set; }
    
    public void AddCart(Product obj)
    {
        Product tmp = obj;
        CartColl.Add(tmp);
    }
    public MainViewModel()
    {
        CartColl = new ObservableCollection<Product>();
        Products = InitProducts(url);
    }
    
    private ObservableCollection<Product> InitProducts(string[] str)
    {
        var tmp = new List<Product>();
        int n = str.Length;
        for (int i = 0; i < n; i++)
        {
            tmp.Add(new Product(str[i]));
        }

        return new ObservableCollection<Product>(tmp);
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
