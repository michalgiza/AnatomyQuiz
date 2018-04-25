using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Image filledImage;
    public TextMeshProUGUI counterText;
    public Image foreImage;

    
    private Color startColor;
    private Color endColor;
    private float time;
    // Use this for initialization
    void Start ()
    {
        counterText.text = Mathf.Ceil(time).ToString();
        time = Singleton.QuizManager.timeToAnswer;
        startColor = new Color(0, 162, 33);
        endColor = new Color(255, 0, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        time -= Time.deltaTime;
        Debug.Log(Time.deltaTime.ToString());
        counterText.text = Mathf.Ceil(time).ToString();
        float proportion = time/Singleton.QuizManager.timeToAnswer;
        filledImage.fillAmount = proportion;
        //foreImage.color = Color.Lerp(startColor, endColor, proportion);
        if(time < 0.001f)
        {
            Singleton.QuizManager.currentAnswerTimeEnd = true;
            counterText.text = Mathf.Ceil(time).ToString();
            time = Singleton.QuizManager.timeToAnswer;
            filledImage.fillAmount = 1;
        }
        
    }
}
