using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour {
    static public int[] matchArray = new int[3] { 0, 0, 0 };
    static public void CollisionEnter(Collider2D collider1, Collider2D collider2)
    {
        string name1 = collider1.name;
        string name2 = collider2.name;
        bool allow = true;
        int imgIndex = 0;
        int snapIndex = 0;
        if (name1.Contains("img"))
        {
            imgIndex = Convert.ToInt32(name1.Remove(0, 8));
            snapIndex = Convert.ToInt32(name2.Remove(0, 9));
        }
        else
        if (name2.Contains("img"))
        {
            imgIndex = Convert.ToInt32(name2.Remove(0, 8));
            snapIndex = Convert.ToInt32(name1.Remove(0, 9));
        }

        for (int i = 0; i < 3; i++)
        {
            if (imgIndex == DragAndDropManager.matchArray[i])
                allow = false;
        }
        if (DragAndDropManager.matchArray[snapIndex - 1] == 0 && allow)
            DragAndDropManager.matchArray[snapIndex - 1] = imgIndex;
    }

    static public void CollisionExit(Collider2D collider1, Collider2D collider2)
    {
        int imgIndex = 0;
        int snapIndex = 0;
        string name1 = collider1.name;
        string name2 = collider2.name;

        if (name1.Contains("img"))
        {
            imgIndex = Convert.ToInt32(name1.Remove(0, 8));
            snapIndex = Convert.ToInt32(name2.Remove(0, 9));
        }
        else
    if (name2.Contains("img"))
        {
            imgIndex = Convert.ToInt32(name2.Remove(0, 8));
            snapIndex = Convert.ToInt32(name1.Remove(0, 9));
        }
        if (DragAndDropManager.matchArray[snapIndex - 1] == imgIndex)
            DragAndDropManager.matchArray[snapIndex - 1] = 0;
    }


}
