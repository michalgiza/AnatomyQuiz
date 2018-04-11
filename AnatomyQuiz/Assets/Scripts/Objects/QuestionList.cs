using UnityEngine;

public class QuestionList : MonoBehaviour
{
    public Question[] questions;
    // Use this for initialization
    void Start ()
    {
        Singleton.QuizManager.questions = this.questions;
	}
}
