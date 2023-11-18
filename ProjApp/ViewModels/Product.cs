using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

namespace ProjApp.ViewModels;

public class Product : INotifyPropertyChanged
{
    public string name;
    public string nutriscore_grade;
    public string allergens;
    public string image_url;
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
        nutriscore_grade = _nut.ToString();
        allergens = _allergens.ToString();
        image_url = _image.ToString();
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