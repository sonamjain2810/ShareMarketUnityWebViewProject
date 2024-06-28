using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AnswerUi : MonoBehaviour
{
    public Image correctImage;

    public Image incorrectImage;

    public int answerIndex;



    bool canBeClicked = true;

    private void OnEnable()
    {
        QuestionsManager.OnNewQuestionLoaded += ResetValues;

        QuestionsManager.OnAnswerProvided += AnswerProvided;
    }

    private void AnswerProvided()
    {
        canBeClicked = false;
    }

    private void OnDisable()
    {
        QuestionsManager.OnNewQuestionLoaded -= ResetValues;

        QuestionsManager.OnAnswerProvided -= AnswerProvided;
    }

    private void ResetValues()
    {
        Debug.Log("Reset Values Called via new question loaded");
        correctImage.DOFade(0, 0.2f);
        incorrectImage.DOFade(0, 0.2f);
        canBeClicked = true;

    }



    public void OnAnswerClicked()
    {
        if (canBeClicked)
        {
            bool result = QuestionsManager.Instance.AnswerQuestion(answerIndex);

            if (result)
            {
                correctImage.DOFade(1, 0.5f);
            }
            else
            {
                incorrectImage.DOFade(1, 0.5f);
            }

            Debug.Log("Answer was clicked = " + result);
        }
    }
}
