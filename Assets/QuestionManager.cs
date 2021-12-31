using System;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private MonsterManager monsterManager;
    [SerializeField] private TMP_Text messageBoxTextField;
    [SerializeField] private TMP_InputField answerInputField;

    [Header("")] [SerializeField] private string answer;

    private Action<QuestionAnswer> _afterQuestionGeneration;

    public event Action OnGameWin;

    private void Start()
    {
        _afterQuestionGeneration += LogQuestion;
        _afterQuestionGeneration += LogAnswer;

        GenerateQuestion(_afterQuestionGeneration);

        OnGameWin += () => {answerInputField.text = "Well done, you cleared the wave";
                            messageBoxTextField.text = "Wave cleared";
                            };
        
    }

    private void GenerateQuestion(Action<QuestionAnswer> afterqgCallback = null)
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

        afterqgCallback?.Invoke(qa);

        messageBoxTextField.text = qa.question;
        answer = qa.answer;

        ClearInputField("Enter your answer");
    }

    private void LogQuestion(QuestionAnswer qa) => Debug.Log(qa.question);
    private void LogAnswer(QuestionAnswer qa) => Debug.Log(qa.answer);

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