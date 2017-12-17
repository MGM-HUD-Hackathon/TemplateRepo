//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using SimpleJSON;
//using UnityEngine.UI;
//using Assets.Controllers;
////using static Locations;

////public class GoogleMaps_GetJSONforPlaces : MonoBehaviour
////{
////    string url;
////    private VectorController controller = new VectorController();

////    Location origin; // = new Location();

////    public Text DebugText;

////    public GameObject display;

////    public Material KitchenMat;
////    public Material BathroomMat;
////    public Material DoorMat;

////    //void Start()
////    IEnumerator Start()
////    {
////        //origin = new Location("HackAThon", 32.378826F, -86.310236F, "", "googlemaps");
////        origin = new Location("HackAThon", 32.378457F, -86.309882F, "", "googlemaps");

////        url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=32.3784892,-86.3155911&radius=500&keyword=historical&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";

////        WWW www = new WWW(url);
////        yield return www;
////        if (www.error == null)
////        {
////            //Processjson(www.data);
////            Processjson(www.text);
////        }
////        else
////        {
////            DebugText.text = "ERROR: " + www.error;
////            //Debug.Log("ERROR: " + www.error);
////        }

////        //return;

////    }


//    //private void Processjson(string jsonString)
//    //{
//    //    Vector3 untityTempLocation = new Vector3(controller.LatitudeToMeters(origin.getlat()), controller.LongitudeToMeters(origin.getlog()));
//    //    display.transform.position = new Vector3(Convert.ToSingle(untityTempLocation.x), 0.5f, Convert.ToSingle(untityTempLocation.y));

//    //    ArrayList locations = new ArrayList();

//    //    //DebugText.text = jsonString;
//    //    var N = JSON.Parse(jsonString);
//    //    for (int i = 0; i < N.Count; i++)
//    //    {
//    //        String geoLocLat = N["results"][i]["geometry"]["location"]["lat"];
//    //        String geoLocLon = N["results"][i]["geometry"]["location"]["lng"];
//    //        String name = N["results"][i]["name"];
//    //        String photoref = N["photos"][""];
//    //        //locations.Add(new Location(name, geoLocLat, geoLocLon, name, photoref));

//    //    }

//    //    //For each location draw a cube on the plane
//    //    String distances = "";
//    //    //   ^
//    //    //   |
//    //    //   2
//    //    //   |
//    //    //   >
//    //    //
//    //    //    
//    //    //<-1-->
//    //    //locations.Add(new Location("Kitchen1", 3, 3, "", ""));
//    //    //locations.Add(new Location("Kitchen2", 3, 4, "", ""));

//    //    //locations.Add(new Location("Kitchen3", -3, 8, "", ""));

//    //    locations.Add(new Location("Bathroom", "32.378601", "-86.309699", "", ""));

//    //    locations.Add(new Location("Kitchen", "32.378545", "-86.309782", "", ""));



//    //    //locations.Add(new Location("Frount Door", "32.378423", "-86.309932", "", ""));


//    //    locations.Add(new Location("Frount Door", "32.3783423", "-86.3099101", "", ""));


//    //    //32.3783423,-86.3099101



//    //    //locations.Add(new Location("Kitchen", 12, -3, "", ""));


//    //    //Normalize the locations before we render the on the screen
//    //    //locations = Normalize_Locations(origin, locations);
//    //    controller.NormalizeLocations(origin, locations);

//    //    foreach (object o in locations)
//    //    {
//    //        //YourObject myObject = (YourObject)o;
//    //        Location temp = (Location)o;
//    //        //Vector2d untityLocation = Conversions.LatLonToMeters(new Vector2d(temp.getlat(), temp.getlog()));
//    //        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
//    //        cube.transform.position = new Vector3(Convert.ToSingle(temp.getunityLat()), 0.0F, Convert.ToSingle(temp.getunityLog()));
//    //        //cube.transform.position = new Vector3(Convert.ToSingle(untityLocation.x),0.5f,Convert.ToSingle(untityLocation.y));

//    //        //SimpleMaths sm = new SimpleMaths();
//    //        //Vector3 tVector= sm.GetLocationFromMeV2(temp.getName(), origin.getlat(), origin.getlog(), temp.getlat(), temp.getlog());
//    //        //cube.transform.position = tVector;
//    //        switch (temp.getName())
//    //        {
//    //            case "Frount Door":
//    //                {
//    //                    cube.transform.GetComponent<Renderer>().material = KitchenMat;
//    //                    break;
//    //                }
//    //            case "Bathroom":
//    //                {
//    //                    cube.transform.GetComponent<Renderer>().material = BathroomMat;
//    //                    break;
//    //                }
//    //            case "Kitchen":
//    //                {
//    //                    cube.transform.GetComponent<Renderer>().material = DoorMat;
//    //                    break;
//    //                }

//    //        }
//    //        //cube.transform.GetComponent<Renderer>().material = 

//    //        //VectorController vc = new VectorController();
//    //        //Vector3 tVector = vc.getRelativePosition(origin.getlat(), origin.getlog(), temp.getlat(), temp.getlog());
//    //        //cube.transform.position = tVector;

//    //        //cube.transform.position = tVector;

//    //        //Vector3 tVector = vc.getRelativePosition(origin.getlat(), origin.getlog(), temp.getlat(), temp.getlog());
//    //        //getRelativePosition
//    //        if (temp.getName() == "Kitchen2")
//    //        {
//    //            //cube.renderer.material.mainTexture = "mypicture.jpg";
//    //            //Texture tex = new Texture();
//    //            //tex.
//    //            //cube.GetComponent<Renderer>().material.mainTexture = new Texture("invade.jpg");
//    //            //getRelativePosition
//    //        }
//    //        //SimpleMaths sm = new SimpleMaths();
//    //        //Vector3 tVector= sm.GetLocationFromMe(origin.getlat(), origin.getlog(), temp.getlat(), temp.getlog());
//    //        //
//    //        //
//    //        //DebugText.text = "X: [" + Convert.ToString(tVector.x) + "],[" + Convert.ToString(tVector.y) + "],[" + Convert.ToString(tVector.z) + "]";


//    //        //VectorController vc = new VectorController();
//    //        //Vector3 tVector = vc.getRelativePosition(origin.getlat(), origin.getlog(), temp.getlat(), temp.getlog());

//    //        //float meters_away = vc.GetDistance(temp.getlat(), temp.getlog(), origin.getlat(), origin.getlog());

//    //        ////DebugText.text = "X: ["+ Convert.ToString(tVector.x) + "],[" + Convert.ToString(tVector.y) +"],[" + Convert.ToString(tVector.z) + "]";
//    //        //float meters_away = vc.GetDistance(origin.getlat(), origin.getlog(), temp.getlat(), temp.getlog());
//    //        //temp.setDistanceFromOrigin(meters_away);

//    //        //distances += temp.getName() + ": " + Convert.ToString(meters_away);
//    //    }

//    //    //DebugText.text = Convert.ToString(distances);

//    //    //cube.transform.position = new Vector3(temp.getlat(), 0.5F, temp.getlog());
//    //    //VectorController vc = new VectorController();
//    //    //float meters_away = vc.GetDistance(32.378826f, -86.310236f, 32.376867f, -86.311105f);
//    //    //DebugText.text = Convert.ToString(meters_away);
//    //    //for (int i = 0; i < locations.Count; i++ )
//    //    //{
//    //    //    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
//    //    //    Location temp = locations.
//    //    //    cube.transform.position = new Vector3(locations[i]. 0.5F, 0);
//    //    //}

//    //    //DebugText.text = N.ToString();

//    //    //var versionString = N["version"].Value;        // versionString will be a string containing "1.0"
//    //    //var versionNumber = N["version"].AsFloat;      // versionNumber will be a float containing 1.0
//    //    //var name = N["data"]["sampleArray"][2]["name"];// name will be a string containing "sub object"

//    //    //Console.WriteLine("Out");
//    //    //Console.WriteLine(geoLocLat + "," + geoLocLon);
//    //    //DebugText.text = geoLocLat + "," + geoLocLon;
//    //}


//}