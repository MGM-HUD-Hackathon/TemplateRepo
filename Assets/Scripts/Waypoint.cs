using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Controllers;

internal class Waypoint : MonoBehaviour
{
    public GameObject camera;
    private VectorController vectorController = new VectorController();


    public void Start()
    {
        InvokeRepeating("showRange", 1.0f, 1.0f);
    }

    public void Update()
    {
    }

    private void showRange()
    {
        Debug.Log("showRange");
        transform.LookAt(2 * Camera.main.transform.position - transform.position);

        foreach (Component c in gameObject.GetComponentsInChildren<TextMesh>())
        {
            c.transform.rotation = Quaternion.LookRotation(transform.position - camera.transform.position);
        }

        gameObject.transform.Find("Distance").GetComponent<TextMesh>().text = String.Format("{0:0}{1}", calculateRange(), "m");
        gameObject.transform.Find("Bearing").GetComponent<TextMesh>().text = String.Format("{0:0}{1}", vectorController.GetBearing(camera.transform.position, transform.position), "\u00B0");
        gameObject.GetComponent<GUIText>().text = calculateRange().ToString();
    }

    private float calculateRange()
    {
        return Vector3.Distance(transform.position, camera.transform.position);
    }

    //public void OnGUI()
    //{
    //    GUI.Label(new Rect(gameObject.transform.position.x, gameObject.transform.position.y, 100, 20), calculateRange().ToString() + "m");
    //    Vector3 pos = gameObject.transform.position + new Vector3(0, 2, 0);
    //    //transform.position = Camera.main.WorldToViewportPoint(pos);
    //    //text.enabled = true;
    //}

    //public GameObject WaypointFactory(Vector3 position, string description)
    //{
    //    GameObject returnMe = 
    //}

}