using System;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private MonsterManager monsterManager;
    [SerializeField] private TMP_Text messageBoxTextField;
    [SerializeField] private TMP_InputField answerInputField;

    [Header("")] [SerializeField] private string answer;

    //private Action<QuestionAnswer> _afterQuestionGeneration;

    public event Action OnGameWin;

    private void Start()
    { 
        // _afterQuestionGeneration += LogQuestion;
        // _afterQuestionGeneration += LogAnswer;
       // GenerateQuestion(_afterQuestionGeneration);
       
       //Generate another question
       GenerateQuestion();
                        
        OnGameWin += () => {answerInputField.text = "Well done, you cleared the wave";
                            messageBoxTextField.text = "Wave cleared";
                            };
        
    }

    //private void GenerateQuestion(Action<QuestionAnswer> afterqgCallback = null)
    //Generate a question 
    private void GenerateQuestion()
    {
        if (monsterManager.monstersList.Count == 0)
        {
            Debug.LogWarning("Monsters list count is = 0");
            OnGameWin?.Invoke();

            ClearInputField();
            return;
        }

        var qa =
            monsterManager.monstersList[0]
                .GetComponent<IQuestion>()
                .GenerateQuestion();

        messageBoxTextField.text = qa.question;
        answer = qa.answer;

        ClearInputField("Enter your answer");
    }

    public void ValidateAnswer()
    {
        if (answerInputField.text == answer)
        {
            monsterManager.KillMonster(0);
            monsterManager.MonsterAttacks(0);
            monsterManager.MoveNextMonsterToQueue();
            GenerateQuestion();
        }
        else
        {
            ClearInputField("Incorrect answer. try again");
        }
    }

    private void ClearInputField(string inputFieldPlaceHolder = "")
    {
        answerInputField.text = inputFieldPlaceHolder;
        answerInputField.ActivateInputField();
    }
}