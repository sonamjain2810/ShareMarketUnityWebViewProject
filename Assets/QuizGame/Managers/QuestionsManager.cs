using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionsManager : Singleton<QuestionsManager>
{
    public static Action OnNewQuestionLoaded;

    public static Action OnAnswerProvided;

    public Transform CorrectImage;

    public Transform InCorrectImage;

    public QuestionUI Question;

    private QuizGameManager gameManager;

    private QuestionModel currentQuestion;

    public int correctAnsCount=0;

    public int incorrectAnsCount=0;

    public int unAnsweredCount = 0;

    public string CategoryName;

    int TotalQuestions;

    public GameObject resultPanel;

    private void Start()
    {
        gameManager = QuizGameManager.Instance;

        Question.TitleLabel.text = CategoryName;

        Question.BackButton.onClick.AddListener(LoadHomePage);

        
        LoadNextQuestion();
    }

    private void LoadHomePage()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextQuestion()
    {
        currentQuestion = gameManager.GetQuestionForCategory(CategoryName);

        if(TotalQuestions == QuizGameManager.Instance.TotalQuestionsCount)
        {
            Debug.Log("QuestionCompleted Show Result");
            resultPanel.SetActive(true);
            return;
        }

        if(currentQuestion != null)
        {
            Question.PopulateQuestion(currentQuestion);
            
            Question.ResetTimer();

            Question.TimerIsRunning = true;
            TotalQuestions++;
        }

        OnNewQuestionLoaded?.Invoke();
    }

    public bool AnswerQuestion(int answerIndex)
    {
        //Debug.Log("currentQuestion = " + currentQuestion.CorrectAnswerIndex + "anser index- " + answerIndex);

        OnAnswerProvided?.Invoke();

        bool isCorrect = currentQuestion.CorrectAnswerIndex == answerIndex;

        if(isCorrect)
        {
            TweenResult(CorrectImage);
            correctAnsCount++;
        }
        else
        {
            TweenResult(InCorrectImage);
            incorrectAnsCount++;
        }

        return isCorrect;
    }

    private void TweenResult(Transform resultTransfrom)
    {
        
        Sequence result = DOTween.Sequence();

        result.Append(resultTransfrom.DOScale(1, 0.5f).SetEase(Ease.OutBack));

        result.AppendInterval(1f);

        result.Append(resultTransfrom.DOScale(0, 0.2f).SetEase(Ease.Linear));

        result.AppendCallback(LoadNextQuestion);

        Debug.Log("In Tween Result");
    }

    void Update()
    {
        
        if (Question.TimerIsRunning)
        {
            if (Question.TimeRemaining > 0)
            {
                Question.TimeRemaining -= Time.deltaTime;
                Question.TimerLabel.text = Mathf.Round(Question.TimeRemaining).ToString();
            }
            else
            {
                Debug.Log("Time has run out!");
                Question.TimeRemaining = 0;
                Question.TimerIsRunning = false;
                unAnsweredCount++;
                LoadNextQuestion();
               
            }
        }
    }
}
