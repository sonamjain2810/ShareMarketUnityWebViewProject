using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionUI : MonoBehaviour
{
    public TextMeshProUGUI QuestionLabel;

    public TextMeshProUGUI Answer1Label;

    public TextMeshProUGUI Answer2Label;

    public TextMeshProUGUI Answer3Label;

    public TextMeshProUGUI Answer4Label;

    public Button BackButton;

    public TextMeshProUGUI TitleLabel;

    public TextMeshProUGUI TimerLabel;

    public float TimeRemaining;

    public bool TimerIsRunning = false;

    float timerReset; 
    private void Awake()
    {
        timerReset = TimeRemaining;
    }


    public void PopulateQuestion(QuestionModel questionModel)
    {
        QuestionLabel.text = questionModel.Question;

        Answer1Label.text = questionModel.Answer1;

        Answer2Label.text = questionModel.Answer2;

        Answer3Label.text = questionModel.Answer3;

        Answer4Label.text = questionModel.Answer4;
       
    }

   public void ResetTimer()
    {
        TimeRemaining = timerReset;
    }
}
