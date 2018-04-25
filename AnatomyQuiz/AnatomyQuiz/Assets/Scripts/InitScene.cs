using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitScene : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Singleton.IsValid == false)
        {
            return;
        }
        else
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
