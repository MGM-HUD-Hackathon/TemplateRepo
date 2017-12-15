
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Location
{
    private float lat = 0.0F;
    private float log = 0.0F;
    private string imgURL = "";
    private string photoRef = "";
    private string name = "";

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

    /************************
     * Getters and Setters  *
     ************************/

    public float getlat()
    {
        return lat;
    }

    public float getlog()
    {
        return log;
    }

    public string getimgURL()
    {
        return imgURL;
    }

    public void setimgURL(string imgURL)
    {
        this.imgURL = imgURL;
    }

    public void setlog(string log)
    {
        this.log = float.Parse(log, CultureInfo.InvariantCulture.NumberFormat);
    }

    public void setlat(string lat)
    {
        this.lat = float.Parse(lat, CultureInfo.InvariantCulture.NumberFormat);
    }

    public void setlog(float log)
    {
        this.log = log;
    }

    public void setlat(float lat)
    {
        this.lat = lat;
    }
}
