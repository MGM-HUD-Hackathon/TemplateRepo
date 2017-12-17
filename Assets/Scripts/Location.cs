
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Location
{
    private double lat = 0.0F;
    private double log = 0.0F;
    private double unityLat = 0.0F;
    private double unityLog = 0.0F;
    private string imgURL = "";
    private string photoRef = "";
    private string name = "";

    //The getters and setters are done at the same time here
    public long timestamp { get; set; } //When data was last collected
    public float altitude { get; set; } //Meters above sea level (MSL)
    private string type { get; set; } //Restruant, Landmark etc...

    private float distanceFromOrigin = 0.0F;

    public Location(string name, string lat, string log, string photoRef, string datasource)
    {
        this.name = name;
        this.setlat(lat);
        this.setlog(log);
        this.photoRef = photoRef;
        switch (datasource)
        {
            case "googlemaps":
                {
                    this.imgURL = imgURL = "https://maps.googleapis.com/maps/api/place/photo?photoreference=" + photoRef + "&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";
                    break;
                }
            default:
                {
                    //For now try as google maps if the another map parser is not available
                    this.imgURL = imgURL = "https://maps.googleapis.com/maps/api/place/photo?photoreference=" + photoRef + "&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";
                    break;
                }
        }
        this.imgURL = imgURL = "https://maps.googleapis.com/maps/api/place/photo?photoreference=" + photoRef + "&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";
    }

    public Location(string name, float lat, float log, string photoRef, string datasource)
    {
        this.name = name;
        this.setlat(lat);
        this.setlog(log);
        this.photoRef = photoRef;
        switch (datasource)
        {
            case "googlemaps":
                {
                    this.imgURL = imgURL = "https://maps.googleapis.com/maps/api/place/photo?photoreference=" + photoRef + "&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";
                    break;
                }
            default:
                {
                    //For now try as google maps if the another map parser is not available
                    this.imgURL = imgURL = "https://maps.googleapis.com/maps/api/place/photo?photoreference=" + photoRef + "&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";
                    break;
                }
        }
        this.imgURL = imgURL = "https://maps.googleapis.com/maps/api/place/photo?photoreference=" + photoRef + "&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";
    }

    public Location(string name, double lat, double log, string photoRef, string datasource, long timestamp, float altitude, string type)
    {
        this.name = name;
        this.setlat(Convert.ToString(lat));
        this.setlog(Convert.ToString(log));
        this.photoRef = photoRef;
        switch (datasource)
        {
            case "googlemaps":
                {
                    this.imgURL = imgURL = "https://maps.googleapis.com/maps/api/place/photo?photoreference=" + photoRef + "&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";
                    break;
                }
            default:
                {
                    //For now try as google maps if the another map parser is not available
                    this.imgURL = imgURL = "https://maps.googleapis.com/maps/api/place/photo?photoreference=" + photoRef + "&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";
                    break;
                }
        }
        this.imgURL = imgURL = "https://maps.googleapis.com/maps/api/place/photo?photoreference=" + photoRef + "&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";
    }

    /************************
     * Getters and Setters  *
     ************************/
    public double getunityLat()
    {
        return unityLat;
    }

    public double getunityLog()
    {
        return unityLog;
    }

    public void setuntityLat(double unityLat)
    {
        this.unityLat = unityLat;
    }

    public void setuntityLog(double unityLog)
    {
        this.unityLog = unityLog;
    }

    public float getlat()
    {
        return (float)lat;
    }

    public float getlog()
    {
        return (float)log;
    }

    public string getName()
    {
        return name;
    }

    public string getimgURL()
    {
        return imgURL;
    }

    public float getDistanceFromOrigin()
    {
        return distanceFromOrigin;
    }

    public void setimgURL(string imgURL)
    {
        this.imgURL = imgURL;
    }

    public void setlog(string log)
    {
        this.log = double.Parse(log, CultureInfo.InvariantCulture.NumberFormat);
    }

    public void setlat(string lat)
    {
        this.lat = double.Parse(lat, CultureInfo.InvariantCulture.NumberFormat);
    }

    public void setlog(float log)
    {
        this.log = log;
    }

    public void setlat(float lat)
    {
        this.lat = lat;
    }

    public void setDistanceFromOrigin(float distance)
    {
        this.distanceFromOrigin = distance;
    }


}