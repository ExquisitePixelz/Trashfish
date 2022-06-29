﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Material water;
    public float trashValue = 0f;
    public float lastValue;

    public Camera mainCamera;
    public Vector3 cameraPosition;
    private Vector3 pos1 = new Vector3(-9f, 10.82f, 68.47f);
    private Vector3 pos2 = new Vector3(-9f, 14.2f, 81.5f);
    private Vector3 pos3 = new Vector3(-9f, 10.2f, 43.7f);

    public GameObject fish;
    public GameObject deadFish;
    
    public float CameraPanTime = 5f;
    public bool isLerpingToPos3;
    public bool isLerpingToPos2;
    public bool isLerpingToPos1;
    private float timer;

    private bool pressedAnswer = false;
    int lastAnswer;

    public bool didTheFishDie = false;
    public bool gameFinished = false;

    public GameObject[] trashObjects;

    public Question[] questions;
    private static List<Question> unansweredQuestions;
    private Question currentQuestion;
    public int unansweredQuestionsIndex = 0;

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
        SetFirstQuestion();
        water.SetFloat("Vector1_TrashValue", 0);
        
        fish = GameObject.FindGameObjectWithTag("Boid");
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

        if (isLerpingToPos3)
        {
            timer += Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(pos1, pos3, timer / CameraPanTime);
        }

        if (isLerpingToPos2)
        {
            timer += Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(pos1, pos2, timer / CameraPanTime);
        }

        if (isLerpingToPos1)
        {
            timer += Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(pos2, pos1, timer / CameraPanTime);
        }


        if (pressedAnswer == true)
        {
            StartCoroutine(addTrash(lastAnswer));
            changeWaterTrashValue(lastAnswer);
        }


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

        if (trashValue > 0.5)
        {
            Debug.Log("game over");
            didTheFishDie = true;
        }
    }

    IEnumerator addTrash(int questionAnswer)
    {
        pressedAnswer = false;
        buttonsPanel.SetActive(false);
        question.transform.parent.gameObject.SetActive(false);

        isLerpingToPos2 = true;

        if (lastValue > 0)
        {
            if (lastValue == 0.02f)
            {
                Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], new Vector3(-9.14f, 45f, 1.9f), Quaternion.identity);
            }

            if (lastValue == 0.06f)
            {
                Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], new Vector3(-9.14f, 45f, 1.9f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], new Vector3(-9.14f, 45f, 1.9f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], new Vector3(-9.14f, 45f, 1.9f), Quaternion.identity);
            }

            if (lastValue == 0.10f)
            {
                Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], new Vector3(-9.14f, 45f, 1.9f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], new Vector3(-9.14f, 45f, 1.9f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], new Vector3(-9.14f, 45f, 1.9f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], new Vector3(-9.14f, 45f, 1.9f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], new Vector3(-9.14f, 45f, 1.9f), Quaternion.identity);
            }

            if (lastValue == 0.14f)
            {
                Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], new Vector3(-9.14f, 45f, 1.9f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], new Vector3(-9.14f, 45f, 1.9f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], new Vector3(-9.14f, 45f, 1.9f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], new Vector3(-9.14f, 45f, 1.9f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], new Vector3(-9.14f, 45f, 1.9f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], new Vector3(-9.14f, 45f, 1.9f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], new Vector3(-9.14f, 45f, 1.9f), Quaternion.identity);
            }


        }

        yield return new WaitForSeconds(3);
        timer = 0;
        isLerpingToPos2 = false;


        isLerpingToPos1 = true;
        yield return new WaitForSeconds(2);
        timer = 0;
        isLerpingToPos1 = false;


       
        if (gameFinished == true)
        {
            isLerpingToPos3 = true;
            yield return new WaitForSeconds(2);
           
            if(didTheFishDie == true)
            {
                Vector3 fishPos = fish.transform.position;
                Quaternion fishQuaternion = fish.transform.rotation;
                Destroy(fish);
                Instantiate(deadFish, fishPos, fishQuaternion);
            } else
            {
                Debug.Log("You WON!");
            }

            isLerpingToPos1 = false;
        } 
        else
        {
            question.transform.parent.gameObject.SetActive(true);
            buttonsPanel.SetActive(true);
        }
    }

    void SetFirstQuestion()
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
        lastAnswer = questionAnswer;
        pressedAnswer = true;
        lastValue = (float)currentQuestion.answersTrashAmount.GetValue(questionAnswer);

        unansweredQuestionsIndex++;
        if (unansweredQuestionsIndex == unansweredQuestions.Count)
        {
            unansweredQuestionsIndex = unansweredQuestions.Count;
            Debug.Log("Finished game");
            gameFinished = true;
            
        } 
        else
        {
            currentQuestion = unansweredQuestions[unansweredQuestionsIndex];
            question.text = currentQuestion.question;
            button0Text.text = currentQuestion.answers[0];
            button1Text.text = currentQuestion.answers[1];
            button2Text.text = currentQuestion.answers[2];
            button3Text.text = currentQuestion.answers[3];
            button4Text.text = currentQuestion.answers[4];
            button5Text.text = currentQuestion.answers[5];
            button6Text.text = currentQuestion.answers[6];
        }
    }

    void changeWaterTrashValue(int questionAnswer)
    {
        trashValue = trashValue + lastValue;
        water.SetFloat("Vector1_TrashValue", trashValue);
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
        unansweredQuestionsIndex++;
        currentQuestion = unansweredQuestions[unansweredQuestionsIndex];
        question.text = currentQuestion.question;
        buttonNextText.text = currentQuestion.answers[0];

        if (unansweredQuestionsIndex > 2)
        {
            buttonsPanel.SetActive(true);
            button0Text.text = currentQuestion.answers[0];
            button1Text.text = currentQuestion.answers[1];
            button2Text.text = currentQuestion.answers[2];
            button3Text.text = currentQuestion.answers[3];
            button4Text.text = currentQuestion.answers[4];
            button5Text.text = currentQuestion.answers[5];
            button6Text.text = currentQuestion.answers[6];
        }
    }
}

