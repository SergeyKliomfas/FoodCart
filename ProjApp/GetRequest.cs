using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ProjApp.ViewModels;

//Серега
/*
 * Реализуй в конструкторе класса
     * var request = new GetRequest(url);
       request.Run(); // Функция вызова метода GetRequest
       var response = request.Response;
       JObject json = JObject.Parse(response); // Парсишь в JObject, но потом надо преобразовать в string
 */
public class GetRequest // Класс реализующий GET запрос к API
{
    private HttpWebRequest _request;
    private string addr;

    public string Response { get; set; } // Поле для хранения ответа на запрос в виде строки.
    
    public GetRequest(string address) // Принимает url 
    {
        addr = address;
    }

    public void Run()
    {
        _request = (HttpWebRequest)WebRequest.Create(addr); // Создается объект _request типа HttpWebRequest 
        _request.Method = "Get";

        try
        {
            HttpWebResponse response = (HttpWebResponse)_request.GetResponse(); // Получается ответ от сервера(HttpWebResponse)
            var stream = response.GetResponseStream(); // Поток данных из ответа 
            if (stream != null) Response = new StreamReader(stream).ReadToEnd(); 
        }
        catch (Exception)
        {
        }
    }
}