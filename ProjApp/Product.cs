using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using ImageExample.Helpers;
using Newtonsoft.Json.Linq;
using ProjApp.ViewModels;
using ProjApp.Views;

namespace ProjApp;

public class Product : INotifyPropertyChanged
{
    public string name { get; }
    public string nutriscore_grade { get; }
    public string allergens { get; set; }
    public SolidColorBrush color { get; }
    public Task<Bitmap?> img { get; set; }
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
                color = new SolidColorBrush(Colors.LawnGreen);
                img = ImageHelper.LoadFromWeb(
                    new("https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Nutri-score-A.svg/440px-Nutri-score-A.svg.png"));
                break;
            case ("B"):
                color = new SolidColorBrush(Colors.Green);
                img = ImageHelper.LoadFromWeb(
                    new("https://www.isali.com/wp-content/uploads/2021/02/1920px-Nutri-score-B.svg_.png"));
                break;
            case ("C"):
                color = new SolidColorBrush(Colors.YellowGreen);
                img = ImageHelper.LoadFromWeb(
                    new("https://www.isali.com/wp-content/uploads/2021/02/1920px-Nutri-score-B.svg_.png"));
                break;
            case ("D"):
                color = new SolidColorBrush(Colors.Coral);
                img = ImageHelper.LoadFromWeb(
                    new("https://upload.wikimedia.org/wikipedia/commons/thumb/d/d6/Nutri-score-D.svg/1200px-Nutri-score-D.svg.png"));
                break;
            case ("E"):
                color =  new SolidColorBrush(Colors.Red);
                img = ImageHelper.LoadFromWeb(
                    new("https://upload.wikimedia.org/wikipedia/commons/thumb/8/8a/Nutri-score-E.svg/1200px-Nutri-score-E.svg.png"));
                break;
            default:
                color =  new SolidColorBrush(Colors.Wheat);
                img = ImageHelper.LoadFromWeb(
                    new("https://upload.wikimedia.org/wikipedia/commons/thumb/8/8a/Nutri-score-E.svg/1200px-Nutri-score-E.svg.png"));
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