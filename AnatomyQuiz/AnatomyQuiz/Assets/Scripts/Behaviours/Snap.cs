using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snap : MonoBehaviour {
    bool insideCollider = false;
    Collision2D collisionObj;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) & insideCollider)
        {
            string name1 = collisionObj.collider.name;
            string name2 = collisionObj.otherCollider.name;

            if(name1.Contains("img"))
                collisionObj.collider.transform.position = collisionObj.otherCollider.transform.position;
            else
                collisionObj.otherCollider.transform.position = collisionObj.collider.transform.position;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        insideCollider = true;
        collisionObj = collision;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        insideCollider = false;
        collisionObj = null;
    }
}
