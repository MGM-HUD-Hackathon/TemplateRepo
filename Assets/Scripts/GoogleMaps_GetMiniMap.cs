/***
	Author Steven Haley
	Written for Datum
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleMaps_GetMiniMap : MonoBehaviour
{

    public RawImage img;

    string url;
    //32.3784892,-86.3155911,15

    //public float lat;
    //public float lon;

    public float lat = 32.3784892f;
    public float lon = -86.3155911f;

    LocationInfo li;

    public int zoom = 14;
    static public int mapMinWidth = 140;
    static public int mapMinHeight = 100;
    public int mapMaxWidth = 300;
    public int mapMaxHeight = 200;

    public int mapWidth = mapMinWidth;
    public int mapHeight = mapMinHeight;

    public enum mapType { roadmap, satellite, hybrid, terrain }
    public mapType mapSelected;
    public int scale;

    bool markersEnabled = true;

    private bool dirty;


    IEnumerator Map()
    {
        //toastedbuttercookies

        /****This one actually works with the drawing a map thing may be good for a mini map type thing    ***/
        //url = "https://maps.googleapis.com/maps/api/staticmap?center=montgomery+ga+historic+locations+map&zoom=13&size=600x300&maptype=roadmap&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";
        //url = "https://maps.googleapis.com/maps/api/staticmap?center=montgomery+ga+historic+locations+map&zoom=13&size="+ mapWidth + "x" + mapHeight + "&maptype=hybrid&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";
        //url = "https://maps.googleapis.com/maps/api/staticmap?center=32.3784118,-86.3097397,233&zoom=13&size=" + mapWidth + "x" + mapHeight + "&maptype=hybrid&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";

        //url = "https://maps.googleapis.com/maps/api/staticmap?center=32.3784118,-86.3097397,233&zoom=13&size=400x400&maptype=hybrid&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";
        //url = "https://maps.googleapis.com/maps/api/staticmap?center=32.3784118,-86.3097397&zoom=13&size=" + mapWidth + "x" + mapHeight +"&maptype=hybrid&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";
        url = "https://maps.googleapis.com/maps/api/staticmap?center=32.3784118,-86.3097397&zoom=17&size=" + mapWidth + "x" + mapHeight + "&maptype=roadmap&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";
        if (markersEnabled)
        {
            url += "&markers=color:red%7Clabel:Foe%7C32.378056,-86.310327" +
                "&markers=color:blue%7Clabel:Friend%7C32.378864,-86.310452" +
                "&markers=color:green%7Clabel:You%7C32.378466,-86.309870";
        }

        //@32.3784118,-86.3097397,233m
        WWW www = new WWW(url);
        yield return www;
        img.texture = www.texture;
        img.SetNativeSize();

        //Vector3.MoveTowards(transform.position, target.position, step);

    }
    // Use this for initialization
    void Start()
    {
        img = gameObject.GetComponent<RawImage>();
        StartCoroutine(Map());
    }

    public void EnlargeMap()
    {
        mapWidth = 300;
        mapHeight = 200;
        dirty = true;
    }

    public void ShrinkMap()
    {
        mapWidth = 70;
        mapHeight = 50;
        dirty = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (dirty)
        {
            img = gameObject.GetComponent<RawImage>();
            StartCoroutine(Map());
            dirty = false;
        }
        //img = gameObject.GetComponent<RawImage>();
        //StartCoroutine(Map());
    }
}