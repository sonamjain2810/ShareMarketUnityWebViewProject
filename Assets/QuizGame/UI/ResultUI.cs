using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TotalQuestionLabel;
    [SerializeField] TextMeshProUGUI CorrectQuestionLabel;
    [SerializeField] TextMeshProUGUI InCorrectQuestionLabel;
    [SerializeField] TextMeshProUGUI UnAnsweredQuestionLabel;
    [SerializeField] Button GoToHomeBtn;

    private void Awake()
    {
        
        GoToHomeBtn.onClick.AddListener(GoToHomeBtnClicked);
        
    }

    private void Start()
    {
        FillUpText();
    }
    private void FillUpText()
    {
        TotalQuestionLabel.text = TotalQuestionLabel.text + QuizGameManager.Instance.TotalQuestionsCount;
        CorrectQuestionLabel.text = CorrectQuestionLabel.text + QuestionsManager.Instance.correctAnsCount;
        InCorrectQuestionLabel.text = InCorrectQuestionLabel.text + QuestionsManager.Instance.incorrectAnsCount;
        UnAnsweredQuestionLabel.text = UnAnsweredQuestionLabel.text + QuestionsManager.Instance.unAnsweredCount;
    }

    void GoToHomeBtnClicked()
    {
        SceneManager.LoadScene(0);
    }

}
