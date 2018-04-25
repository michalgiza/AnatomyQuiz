using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Image filledImage;
    public Text counterText;
    public float time;
    private float maxTime;

	// Use this for initialization
	void Start ()
    {
        counterText.text = time.ToString();
        maxTime = time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        time -= Time.deltaTime;
        Debug.Log(Time.deltaTime.ToString());
        counterText.text = time.ToString();
        float proportion = time/maxTime;
        filledImage.fillAmount = proportion;
    }
}
