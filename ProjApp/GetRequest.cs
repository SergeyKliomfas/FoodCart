using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ProjApp.ViewModels;

public class GetRequest
{
    private HttpWebRequest _request;
    private string addr;

    public string Response { get; set; }
    
    public GetRequest(string address)
    {
        addr = address;
    }

    public void Run()
    {
        _request = (HttpWebRequest)WebRequest.Create(addr);
        _request.Method = "Get";

        try
        {
            HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
            var stream = response.GetResponseStream();
            if (stream != null) Response = new StreamReader(stream).ReadToEnd();
        }
        catch (Exception)
        {
        }
    }
}