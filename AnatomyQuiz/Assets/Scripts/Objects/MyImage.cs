using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyImage : Image {

    int[] matchArray = new int[] { };
    public int[] MatchArray
    {
        get { return matchArray; }
        set { matchArray = value; }
    }


}
