//Author: Yifeng Shi
//Logic of the game.

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

    float timeUntilNextQuestion;
    float perQuestionPause;
    int score;
    int numberOfQuestionsAsked;
    bool isPaused;
    bool isResultShown;

    void Start()
    {
        timeUntilNextQuestion = timeBetweenTwoQuestion;
        perQuestionPause = 1f;
    }
	
	void Update ()
    {
        //When the current question times up, go to the next question.
        if (timeUntilNextQuestion <= 0)
        {
            timeUntilNextQuestion = timeBetweenTwoQuestion;
            //Treat as wrong
            correctWrong.text = "No Answer!";
            correctWrong.color = Color.red;
            isPaused = true;
            perQuestionPause = 1f;
        }

        if (!isPaused)
        {
            //If is not in the paused status between two questions, proceed       
            if (numberOfQuestionsAsked == numberOfQuestions)
            {
                //If there are already enough questions asked, show the result
                CheckResult();
                isResultShown = true;
            }
            else
            {
                //Otherwise just count down the time for current question
                timeUntilNextQuestion -= Time.deltaTime;
                timeCounterText.text = "Time left for current question: " + Mathf.Max(0, timeUntilNextQuestion).ToString("0.00");
            }    
        }
        else
        {
            //If is in the paused status, count down the pause timer
            perQuestionPause -= Time.deltaTime;
            if (perQuestionPause <= 0)
            {
                //If pause times up, proceed to the next question
                NextQuestion();
                perQuestionPause = 1f;
                isPaused = false;
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
        numberOfQuestionsAsked++;
        //Do not show a new question if there are already enough questions showed.
        if (numberOfQuestionsAsked < 10)
        {
            questionBoard.NumberInstantiation();
            answerBoard.NextQuestion();
            timeUntilNextQuestion = timeBetweenTwoQuestion;
        }          
    }

    public void CheckResult()
    {
        //Give stars based on performance. If has earned more stars than 
        //the current performance, keep the higher one.
        resultScreen.SetActive(true);
        if (score == numberOfQuestions)
        {
            resultScreen.GetComponent<Result>().SetStars(true, true, true);
            resultScreen.GetComponent<Result>().GetText().text = "Perfect!";
            GameMaster.starsEachStage[GameMaster.stage - 1] = 3;
        }
        else if (score >= 0.8 * numberOfQuestions)
        {
            resultScreen.GetComponent<Result>().SetStars(true, true, false);
            resultScreen.GetComponent<Result>().GetText().text = "Excellent!";
            if (GameMaster.starsEachStage[GameMaster.stage - 1] < 2)
                GameMaster.starsEachStage[GameMaster.stage - 1] = 2;
        }
        else if (score >= 0.5 * numberOfQuestions)
        {
            resultScreen.GetComponent<Result>().SetStars(true, false, false);
            resultScreen.GetComponent<Result>().GetText().text = "Good!";
            if (GameMaster.starsEachStage[GameMaster.stage - 1] < 1)
                GameMaster.starsEachStage[GameMaster.stage - 1] = 1;
        }
        else
        {
            resultScreen.GetComponent<Result>().SetStars(false, false, false);
            resultScreen.GetComponent<Result>().GetText().text = "Try Again!";
        }
    }

    public void CheckAnswer(int number)
    {
        if (!isResultShown && !isPaused)
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

            isPaused = true;
        } 
    }

    public int GetCurrentQuestionIndex()
    {
        //Since the index start at 0, these two are actually the same
        return numberOfQuestionsAsked;
    }
}
