using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace ImageExample.Helpers
{
    //класс для подключения изображения по url для image 
    public static class ImageHelper
    {
        
        public static Bitmap LoadFromResource(Uri resourceUri) // Метод для локальных файлов, строго такой шаблон, иначе не будет работать("avares://ProjApp/Assets/Images/...")
        {
            return new Bitmap(AssetLoader.Open(resourceUri));
        }

        public static async Task<Bitmap?> LoadFromWeb(Uri url) // Метод загружает объект по URL(из API адрес изображения будешь брать), в конце ставь "^", т.к. асинхронный метод
        {
            using var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.GetAsync(url); // Внутри блока создается HttpClient, Выполняется асинхронный get-запрос
                response.EnsureSuccessStatusCode(); // Проверка запроса
                var data = await response.Content.ReadAsByteArrayAsync();
                return new Bitmap(new MemoryStream(data));
            }
            catch (HttpRequestException ex) //ловим ошибку
            {
                Console.WriteLine($"An error occurred while downloading image '{url}' : {ex.Message}");
                return null;
            }
        }
    }
}