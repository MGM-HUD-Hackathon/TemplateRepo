using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;

public class GoogleMaps_GetJSONforPlaces : MonoBehaviour
{
    string url;

    public Text DebugText;

    //void Start()
    IEnumerator Start()
    {

        url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=32.3784892,-86.3155911&radius=500&keyword=historical&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";

        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            //Processjson(www.data);
            Processjson(www.text);
        }
        else
        {
            DebugText.text = "ERROR: " + www.error;
            //Debug.Log("ERROR: " + www.error);
        }
    }


    private void Processjson(string jsonString)
    {
        DebugText.text = jsonString;
        var N = JSON.Parse(jsonString);

        //DebugText.text = N.ToString();

        //var versionString = N["version"].Value;        // versionString will be a string containing "1.0"
        //var versionNumber = N["version"].AsFloat;      // versionNumber will be a float containing 1.0
        //var name = N["data"]["sampleArray"][2]["name"];// name will be a string containing "sub object"

        String geoLocLat = N["results"][0]["geometry"]["location"]["lat"];
        String geoLocLon = N["results"][0]["geometry"]["location"]["lng"];
        String name = N["results"][0]["name"];

        //Console.WriteLine("Out");
        //Console.WriteLine(geoLocLat + "," + geoLocLon);
        DebugText.text = geoLocLat + "," + geoLocLon;
    }

}
