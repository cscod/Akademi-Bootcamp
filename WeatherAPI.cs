using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Xml;
using TMPro;
using UnityEngine.UI;
using System;


public class WeatherAPI : MonoBehaviour
{
    [SerializeField] private string apiKey;
    [SerializeField] private string location;
    [SerializeField] private TextMeshProUGUI cityText;
    [SerializeField] private TextMeshProUGUI temperatureText;
    [SerializeField] private TextMeshProUGUI weatherText;
    [SerializeField] private Image weatherIcon;

    private const string weatherURL = "http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}";

    private void Start()
    {
        StartCoroutine(GetWeatherData());
    }

    private IEnumerator GetWeatherData()
    {
        string url = string.Format(weatherURL, location, apiKey);
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                string jsonResponse = webRequest.downloadHandler.text;
                WeatherData weatherData = JsonUtility.FromJson<WeatherData>(jsonResponse);
                UpdateWeatherUI(weatherData);
            }
        }
    }

    private void UpdateWeatherUI(WeatherData weatherData)
    {
        cityText.text = weatherData.name;
        float temperature = weatherData.main.temp - 273.15f;
        temperatureText.text = temperature.ToString("0.0") + "°C";
        weatherText.text = weatherData.weather[0].description;
        string iconCode = weatherData.weather[0].icon;
        StartCoroutine(LoadWeatherIcon(iconCode));
    }

    private IEnumerator LoadWeatherIcon(string iconCode)
    {
        string url = string.Format("http://openweathermap.org/img/w/{0}.png", iconCode);
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(webRequest);
                weatherIcon.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
        }
    }
}

[Serializable]
public class WeatherData
{
    public string name;
    public MainData main;
    public Weather[] weather;
}

[Serializable]
public class MainData
{
    public float temp;
}

[Serializable]
public class Weather
{
    public string description;
    public string icon;
}
