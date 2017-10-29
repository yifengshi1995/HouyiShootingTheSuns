using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    [SerializeField]
    AnswerBoard answerBoard;
    [SerializeField]
    QuestionBoard questionBoard;
    [SerializeField]
    float timeBetweenTwoQuestion;
    [SerializeField]
    Text timeCounterText;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    int numberOfQuestions;
    [SerializeField]
    Text correctWrong;
    [SerializeField]
    GameObject resultScreen;
    [SerializeField]
    int stage;

    float timeUntilNextQuestion;
    float perQuestionPause;
    int score;
    int currentNumberOfQuestions;
    bool nextQuestionTrigger;
    bool isResultShown;

    void Awake()
    {
        timeUntilNextQuestion = timeBetweenTwoQuestion;
        perQuestionPause = 1f;

    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            NextQuestion();
        }

        if (timeUntilNextQuestion <= 0)
        {
            NextQuestion();
        }

        if (!nextQuestionTrigger)
        {
            if (currentNumberOfQuestions == numberOfQuestions)
            {
                CheckResult();
                isResultShown = true;
            }
            else
            {
                timeUntilNextQuestion -= Time.deltaTime;
                timeCounterText.text = "Time left for current question: " + Mathf.Max(0, timeUntilNextQuestion).ToString("0.00");
            }    
        }
        else
        {
            perQuestionPause -= Time.deltaTime;
            if (perQuestionPause <= 0)
            {
                NextQuestion();
                perQuestionPause = 1f;
                nextQuestionTrigger = false;
                correctWrong.text = "";
            }
        }
    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString() + " / " + numberOfQuestions.ToString();
    }

    public void NextQuestion()
    {
        questionBoard.NextQuestion();
        answerBoard.NextQuestion();
        timeUntilNextQuestion = timeBetweenTwoQuestion;
        currentNumberOfQuestions++;
    }

    public void CheckResult()
    {
        resultScreen.SetActive(true);
        if (score == numberOfQuestions)
        {
            resultScreen.GetComponent<Result>().SetStars(true, true, true);
            resultScreen.GetComponent<Result>().GetText().text = "Perfect!";
        }
        else if (score >= 0.8 * numberOfQuestions)
        {
            resultScreen.GetComponent<Result>().SetStars(true, true, false);
            resultScreen.GetComponent<Result>().GetText().text = "Excellent!";
        }
        else if (score >= 0.5 * numberOfQuestions)
        {
            resultScreen.GetComponent<Result>().SetStars(true, false, false);
            resultScreen.GetComponent<Result>().GetText().text = "Good!";
        }
        else
        {
            resultScreen.GetComponent<Result>().SetStars(false, false, false);
            resultScreen.GetComponent<Result>().GetText().text = "Try Again!";
        }
    }

    public void CheckAnswer(int number)
    {
        if (!isResultShown && !nextQuestionTrigger)
        {
            Number answerNumber = questionBoard.GetNumbers()[questionBoard.GetNumbers().Length - 1].GetComponent<Number>();
            answerNumber.SetNumber(number);
            if (answerBoard.GetAnswer() == number)
            {
                AddScore();
                answerNumber.GetText().color = Color.green;
                correctWrong.text = "Correct!";
                correctWrong.color = Color.green;
            }
            else
            {
                answerNumber.GetText().color = Color.red;
                correctWrong.text = "Wrong!";
                correctWrong.color = Color.red;
            }

            nextQuestionTrigger = true;
        } 
    }
}
