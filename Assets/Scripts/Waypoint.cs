using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Waypoint : MonoBehaviour
{
    public GameObject camera;

    public void Start()
    {
        InvokeRepeating("showRange", 1.0f, 1.0f);
    }

    public void Update()
    {
    }

    private void showRange() {
        Debug.Log("showRange");
        transform.LookAt(2 * Camera.main.transform.position - transform.position);
        gameObject.GetComponentInChildren<TextMesh>().transform.rotation = Quaternion.LookRotation(transform.position - camera.transform.position);
        gameObject.GetComponentInChildren<TextMesh>().text = String.Format("{0:0.00}", calculateRange());
        gameObject.GetComponentInChildren<TextMesh>().
        gameObject.GetComponent<GUIText>().text = calculateRange().ToString();
        GUI.Label(new Rect(gameObject.transform.position.x, gameObject.transform.position.y, 100, 20), calculateRange().ToString() + "m");
    }

    private float calculateRange() {
        return Vector3.Distance(transform.position, camera.transform.position);
    }

    public void OnGUI()
    {
        GUI.Label(new Rect(gameObject.transform.position.x, gameObject.transform.position.y, 100, 20), calculateRange().ToString() + "m");
        Vector3 pos = gameObject.transform.position + new Vector3(0, 2, 0);
        //transform.position = Camera.main.WorldToViewportPoint(pos);
        //text.enabled = true;
    }

}