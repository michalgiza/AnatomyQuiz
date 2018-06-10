using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Snap : MonoBehaviour {
    bool insideCollider = false;
    Collision2D collisionObj;
    // Use this for initialization
    void Start () {
        DragAndDropManager.matchArray = new int[3] { 0, 0, 0 };
    }
	// Update is called once per frame
	void Update() {
        if (Input.GetMouseButtonUp(0) & insideCollider)
        {
            string name1 = collisionObj.collider.name;
            string name2 = collisionObj.otherCollider.name;

            if (name1.Contains("img"))
                collisionObj.collider.transform.position = collisionObj.otherCollider.transform.position;
            else
            if (name2.Contains("img"))
               collisionObj.otherCollider.transform.position = collisionObj.collider.transform.position;

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        insideCollider = true;
        collisionObj = collision;

  
        DragAndDropManager.CollisionEnter(collision.collider, collision.otherCollider);

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        insideCollider = false;
        DragAndDropManager.CollisionExit(collision.collider, collision.otherCollider);

        collisionObj = null;
    }
}
