using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // tobe bonys ode
    float peop = 0;
    public Material wate;

    public Question[] questions;
    private static List<Question> unansweredQuestions;
    private Question currentQuestion;
    private int unansweredQuestionsIndex = 0;

    [SerializeField]
    private TextMeshProUGUI question;
    [SerializeField]
    private TextMeshProUGUI button0Text;
    [SerializeField]
    private TextMeshProUGUI button1Text;
    [SerializeField]
    private TextMeshProUGUI button2Text;
    [SerializeField]
    private TextMeshProUGUI button3Text;
    [SerializeField]
    private TextMeshProUGUI button4Text;
    [SerializeField]
    private TextMeshProUGUI button5Text;
    [SerializeField]
    private TextMeshProUGUI button6Text;
    [SerializeField]
    private GameObject buttonsPanel;

    [SerializeField]
    private TextMeshProUGUI buttonNextText;
    [SerializeField]
    private TextMeshProUGUI fishName;
    [SerializeField]
    private TMP_InputField userInputField;
    [SerializeField]
    private GameObject fishNamePanel;

    public string fishNameRaw;

    private void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0) 
        {
            unansweredQuestions = questions.ToList<Question>(); 
        }
        SetCurrentQuestion();

        //test wate
        wate.SetFloat("Vector1_TrashValue", 0);
    }

    public void Update()
    {
        checkEmptyButtons(button0Text);
        checkEmptyButtons(button1Text);
        checkEmptyButtons(button2Text);
        checkEmptyButtons(button3Text);
        checkEmptyButtons(button4Text);
        checkEmptyButtons(button5Text);
        checkEmptyButtons(button6Text);

        if (unansweredQuestionsIndex == 1)
        {
            fishNamePanel.SetActive(true);
        }
        else
        {
            fishNamePanel.SetActive(false);
        }

        if (unansweredQuestionsIndex > 2)
        {
            buttonNextText.transform.parent.gameObject.SetActive(false);
        }
    }

    void SetCurrentQuestion()
    {
        currentQuestion = unansweredQuestions[unansweredQuestionsIndex];
        question.text = currentQuestion.question;
        buttonNextText.text = currentQuestion.answers[0];
        button0Text.text = currentQuestion.answers[0];
        button1Text.text = currentQuestion.answers[1];
        button2Text.text = currentQuestion.answers[2];
        button3Text.text = currentQuestion.answers[3];
        button4Text.text = currentQuestion.answers[4];
        button5Text.text = currentQuestion.answers[5];
        button6Text.text = currentQuestion.answers[6];
    }

    public void UserSelectAnswer(int questionAnswer)
    {

        // esy maak wate peope
        peop += 0.06f;
        wate.SetFloat("Vector1_TrashValue", peop);


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
            buttonNextText.text = currentQuestion.answers[0];
            button0Text.text = currentQuestion.answers[0];
            button1Text.text = currentQuestion.answers[1];
            button2Text.text = currentQuestion.answers[2];
            button3Text.text = currentQuestion.answers[3];
            button4Text.text = currentQuestion.answers[4];
            button5Text.text = currentQuestion.answers[5];
            button6Text.text = currentQuestion.answers[6];
        }
    }

    void checkEmptyButtons(TextMeshProUGUI button)
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
        fishNameRaw = userInputField.text;
    }

    public void resetName()
    {
        fishName.text = " ";
        userInputField.text = " ";
    }

    public void nextScene()
    {
        if (unansweredQuestionsIndex == 2 && fishName.text != null)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            buttonsPanel.SetActive(true);
        }
    }
}

