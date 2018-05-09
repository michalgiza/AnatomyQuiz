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
    private bool RunningClock;

    // Use this for initialization
    void Start ()
    {
        time = Singleton.QuizManager.timeToAnswer;
        counterText.text = Mathf.Ceil(time).ToString();
        startColor = new Color(0, 162, 33);
        endColor = new Color(255, 0, 0);
        filledImage.fillAmount = 1;
        RunningClock = true;
    }

    private void OnEnable()
    {
        time = Singleton.QuizManager.timeToAnswer;
        counterText.text = Mathf.Ceil(time).ToString();
        startColor = new Color(0, 162, 33);
        endColor = new Color(255, 0, 0);
        filledImage.fillAmount = 1;
        RunningClock = true;
    }


    // Update is called once per frame
    void Update ()
    {
        if (RunningClock)
        {
            time -= Time.deltaTime;
            counterText.text = Mathf.Ceil(time).ToString();
            float proportion = time / Singleton.QuizManager.timeToAnswer;
            filledImage.fillAmount = proportion;
            Singleton.QuizManager.currentQuestionTime = time;
            //foreImage.color = Color.Lerp(startColor, endColor, proportion);
            if (time < 0.001f)
            {
                Singleton.QuizManager.currentAnswerTimeEnd = true;
                this.gameObject.SetActive(false);
            }
        }
        
    }

    public void StopClock (bool ifToStop)
    {
        RunningClock = !ifToStop;
    }
}
