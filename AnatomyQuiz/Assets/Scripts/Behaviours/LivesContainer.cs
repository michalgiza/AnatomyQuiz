using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesContainer : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        Singleton.QuizManager.OnBadAnswer += KillOneHeart;
    }

    private void KillOneHeart()
    {
        foreach (Transform heart in transform)
        {
            if (heart.gameObject.activeInHierarchy)
            {
                heart.gameObject.SetActive(false);
                break;
            }
        }
    }
}
