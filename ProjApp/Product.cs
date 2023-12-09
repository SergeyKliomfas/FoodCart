using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using ImageExample.Helpers;
using Newtonsoft.Json.Linq;
using ProjApp.ViewModels;
using ProjApp.Views;

namespace ProjApp;

public class Product : INotifyPropertyChanged
{
    public string name { get; set; }
    public string nutriscore_grade { get;}
    public string allergens { get; set; }
    public SolidColorBrush color { get; }
    
    public int n_count { get; set; }
    public Bitmap img { get; set; }
    public Task<Bitmap?> ImageFromWebsite { get; }
    
    public Product(string url)
    {
        var request = new GetRequest(url);
        request.Run();
        var response = request.Response;
        JObject json = JObject.Parse(response);

        var product = json["product"];
        var _name = product["product_name"];
        var _nut = product["nutrition_grades"];
        var _allergens = product["allergens"];
        var _image = product["image_url"];
        
            
        name = _name.ToString();
        nutriscore_grade = _nut.ToString().ToUpper();
        allergens = _allergens.ToString();
        ImageFromWebsite = ImageHelper.LoadFromWeb(new Uri(_image.ToString()));
        
        allergens = allergens.Replace("en:", "");
        allergens = allergens.Replace("fr:", "");

        
        switch (nutriscore_grade)
        {
            case ("A"):
                color = new SolidColorBrush(Color.FromRgb(181, 221, 207));
                n_count = 5;
                img = ImageHelper.LoadFromResource(new Uri("avares://ProjApp/Assets/Images/A.png"));
                break;
            case ("B"):
                color = new SolidColorBrush(Color.FromRgb(181, 221, 207));
                n_count = 4;
                img = ImageHelper.LoadFromResource(new Uri("avares://ProjApp/Assets/Images/B.png"));
                break;
            case ("C"):
                color = new SolidColorBrush(Color.FromRgb(208, 227, 189));
                n_count = 3;
                img = ImageHelper.LoadFromResource(new Uri("avares://ProjApp/Assets/Images/C.png"));
                break;
            case ("D"):
                color = new SolidColorBrush(Color.FromRgb(208, 176, 153));
                n_count = 2;
                img = ImageHelper.LoadFromResource(new Uri("avares://ProjApp/Assets/Images/D.png"));
                break;
            case ("E"):
                color =  new SolidColorBrush(Color.FromRgb(214, 174, 165));
                n_count = 1;
                img = ImageHelper.LoadFromResource(new Uri("avares://ProjApp/Assets/Images/E.png"));
                break;
            default:
                color =  new SolidColorBrush(Colors.LightGray);
                n_count = 0;
                img = ImageHelper.LoadFromResource(new Uri("avares://ProjApp/Assets/Images/NONE.png"));
                break;
        }
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