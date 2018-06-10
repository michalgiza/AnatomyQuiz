using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesContainer : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        Singleton.QuizManager.OnBadAnswer += KillOneHeart;
        ResetHeart();
    }

    private void KillOneHeart()
    {
        foreach (Transform heart in this.transform)
        {
            if (heart.gameObject.activeInHierarchy)
            {
                heart.gameObject.SetActive(false);
                break;
            }
        }
    }
    private void ResetHeart()
    {
        foreach (Transform heart in transform)
        {
            heart.gameObject.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        Singleton.QuizManager.OnBadAnswer -= KillOneHeart;
    }
}
