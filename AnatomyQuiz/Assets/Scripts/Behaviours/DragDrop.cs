using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
public class DragDrop : MonoBehaviour
{
    // Use this for initialization
    bool pressed = false;
    bool allow = false;
    RaycastHit2D hit;
    GameObject touchedObject;
    Vector3 worldPosition;
    Vector3 lastMousePosition;
    Component[] component;
    public static int[] matchArray;

    void Start()
    {
        matchArray = new int[3] { 0, 0, 0 };
    }

    // Update is called once per frame
    void Update()
    { 

        if (Input.GetMouseButtonDown(0))
        {
            pressed = true;
            hit = Physics2D.Raycast(Input.mousePosition, Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0)) {
            pressed = false;
            allow = false; 
        }

        if (pressed)
        {
            worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (hit.collider != null)
            {
                component = GetComponentsInChildren(typeof(Canvas), true);
                touchedObject = hit.transform.gameObject;
                switch (touchedObject.name)
                {
                    case "imgOrgan1":
                        allow = true;
                        break;
                    case "imgOrgan2":
                        allow = true;
                        break;
                    case "imgOrgan3":
                        allow = true;
                        break;
                }
                if (allow == true)
                    if (lastMousePosition != Input.mousePosition)
                    {
                        touchedObject.transform.position -= lastMousePosition - worldPosition;

                    }
                }
            }
        lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

  

}

