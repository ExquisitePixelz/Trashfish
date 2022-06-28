using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;
    private Question currentQuestion;
    private int unansweredQuestionsIndex = 0;

    [SerializeField]
    private TextMeshProUGUI question;
    [SerializeField]
    private TextMeshProUGUI button0Text;
    [SerializeField]
    private TextMeshProUGUI fishName;
    [SerializeField]
    private TMP_InputField userInputField;
    [SerializeField]
    private GameObject fishNamePanel;


    private void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0) 
        {
            unansweredQuestions = questions.ToList<Question>(); 
        } 
        SetCurrentQuestion();
    }

    public void Update()
    {
        checkEmptyButtons(button0Text);

        if (unansweredQuestionsIndex == 1)
        {
            fishNamePanel.SetActive(true);
        } else
        {
            fishNamePanel.SetActive(false);
        }
    }

    void SetCurrentQuestion()
    {
        currentQuestion = unansweredQuestions[unansweredQuestionsIndex];
        question.text = currentQuestion.question;

        button0Text.text = currentQuestion.answers[0];
    }

    public void UserSelectAnswer(int questionAnswer)
    {

        //Debug.Log(currentQuestion.answersTrashAmount.GetValue(questionAnswer));
        unansweredQuestionsIndex++;
        if(unansweredQuestionsIndex == unansweredQuestions.Count)
        {
            unansweredQuestionsIndex = unansweredQuestions.Count;
            Debug.Log("Finished game");
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
        } 
        else
        {
            Debug.Log("index = " + unansweredQuestionsIndex);
            Debug.Log("count = " + unansweredQuestions.Count);

            currentQuestion = unansweredQuestions[unansweredQuestionsIndex];
            question.text = currentQuestion.question;
            button0Text.text = currentQuestion.answers[0];
        }
    }

    public void checkEmptyButtons(TextMeshProUGUI button)
    {
        if (button.text == " ")
        {
            button.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            button.transform.parent.gameObject.SetActive(true);
        }
    }

    public void setName()
    {
        fishName.text = userInputField.text;
    }

    public void resetName()
    {
        fishName.text = " ";
        userInputField.text = " ";
    }
}

