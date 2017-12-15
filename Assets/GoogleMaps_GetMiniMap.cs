﻿/***
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
    public int mapWidth = 640;
    public int mapHeight = 640;

    public enum mapType { roadmap, satellite, hybrid, terrain }
    public mapType mapSelected;
    public int scale;


    IEnumerator Map()
    {
        //toastedbuttercookies

        /****This one actually works with the drawing a map thing may be good for a mini map type thing    ***/
        //url = "https://maps.googleapis.com/maps/api/staticmap?center=montgomery+ga+historic+locations+map&zoom=13&size=600x300&maptype=roadmap&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";
        url = "https://maps.googleapis.com/maps/api/staticmap?center=montgomery+ga+historic+locations+map&zoom=13&size=70x50&maptype=roadmap&key=AIzaSyBhCpXhprxILdcwnzB7VLLcjqZBxlHDwI4";

        WWW www = new WWW(url);
        yield return www;
        img.texture = www.texture;
        img.SetNativeSize();

    }
    // Use this for initialization
    void Start()
    {
        img = gameObject.GetComponent<RawImage>();
        StartCoroutine(Map());
    }

    // Update is called once per frame
    void Update()
    {

    }
}