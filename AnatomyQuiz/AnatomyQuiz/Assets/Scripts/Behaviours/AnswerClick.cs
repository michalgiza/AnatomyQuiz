
using UnityEngine;

public class AnswerClick : MonoBehaviour
{

    private Question.PossibleAnswer currentAnswer;

    public class AnswerClickResult
    {
        public Question.PossibleAnswer answer;

        public AnswerClickResult(Question.PossibleAnswer currentAnswer)
        {
            answer = currentAnswer;
        }
    }

    public void ClickAnswer()
    {
        string name = transform.parent.name;
        switch (name)
        {
            case "AnswerA":
                currentAnswer = Question.PossibleAnswer.A;
                break;
            case "AnswerB":
                currentAnswer = Question.PossibleAnswer.B;
                break;
            case "AnswerC":
                currentAnswer = Question.PossibleAnswer.C;
                break;
            case "AnswerD":
                currentAnswer = Question.PossibleAnswer.D;
                break;
        }

        Singleton.EventManager.Raise(new AnswerClickResult(currentAnswer));
    }
}
