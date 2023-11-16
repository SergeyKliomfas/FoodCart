using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjApp.ViewModels;

public class MainViewModel
{
    public async Task ApiTest()
    {
        string url = "https://world.openfoodfacts.net/api/v2/product/5449000214911";
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Выполняем GET-запрос к API
                HttpResponseMessage response = await client.GetAsync(url);

                // Проверяем успешность запроса
                if (response.IsSuccessStatusCode)
                {
                    // Читаем ответ в виде строки
                    string responseData = await response.Content.ReadAsStringAsync();
                    
                    // Обрабатываем данные, например, выводим их на консоль
                    Console.WriteLine(responseData);
                }
                else
                {
                    // Обработка ошибок
                    Console.WriteLine($"Ошибка: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        
    }
}
