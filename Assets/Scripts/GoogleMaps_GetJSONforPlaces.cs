using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
using Assets.Controllers;
//using static Locations;

public class GoogleMaps_GetJSONforPlaces : MonoBehaviour
{
    string url;

    Location origin; // = new Location();

    public Text DebugText;

    //void Start()
    IEnumerator Start()
    {
        origin = new Location("HackAThon", 32.378826F, -86.310236F, "", "googlemaps");
             

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
        ArrayList locations = new ArrayList();

        //DebugText.text = jsonString;
        var N = JSON.Parse(jsonString);
        for (int i = 0; i < N.Count; i++)
        {
            String geoLocLat = N["results"][i]["geometry"]["location"]["lat"];
            String geoLocLon = N["results"][i]["geometry"]["location"]["lng"];
            String name = N["results"][i]["name"];
            String photoref = N["photos"][""];
            locations.Add(new Location(name, geoLocLat, geoLocLon, name, photoref));

        }



        //For each location draw a cube on the plane
        String distances = "";
        foreach (object o in locations)
        {
            //YourObject myObject = (YourObject)o;
            Location temp = (Location)o;
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //cube.transform.position = new Vector3(temp.getlat(), temp.getlog(), 0.5F);

            VectorController vc = new VectorController();
            //float meters_away = vc.GetDistance(temp.getlat(), temp.getlog(), origin.getlat(), origin.getlog());
            float meters_away = vc.GetDistance(origin.getlat(), origin.getlog(), temp.getlat(), temp.getlog());
            temp.setDistanceFromOrigin(meters_away);
            
            distances += temp.getName() + ": " + Convert.ToString(meters_away);
        }

        DebugText.text = Convert.ToString(distances);

        //cube.transform.position = new Vector3(temp.getlat(), 0.5F, temp.getlog());
        //VectorController vc = new VectorController();
        //float meters_away = vc.GetDistance(32.378826f, -86.310236f, 32.376867f, -86.311105f);
        //DebugText.text = Convert.ToString(meters_away);
        //for (int i = 0; i < locations.Count; i++ )
        //{
        //    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //    Location temp = locations.
        //    cube.transform.position = new Vector3(locations[i]. 0.5F, 0);
        //}

        //DebugText.text = N.ToString();

        //var versionString = N["version"].Value;        // versionString will be a string containing "1.0"
        //var versionNumber = N["version"].AsFloat;      // versionNumber will be a float containing 1.0
        //var name = N["data"]["sampleArray"][2]["name"];// name will be a string containing "sub object"

        //Console.WriteLine("Out");
        //Console.WriteLine(geoLocLat + "," + geoLocLon);
        //DebugText.text = geoLocLat + "," + geoLocLon;
    }

}
