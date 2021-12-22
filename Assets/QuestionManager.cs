using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private MonsterManager monsterManager;
    [SerializeField] private TMP_Text messageBoxTextField;
    [SerializeField] private TMP_InputField answerInputField;
    
    [Header("")] 
    [SerializeField] private string answer;

    void Start()
    {
        GenerateQuestion();
    }

    private void GenerateQuestion()
    {
        if (monsterManager.monstersList.Count <= 0)
        {
            Debug.LogWarning("Monsters list count is <=0");
            ClearInputField();
            return;
        }
        
        var qa = 
            monsterManager.monstersList[0]
            .GetComponent<IQuestion>()
            .GenerateQuestion();
        
        messageBoxTextField.text = qa.question;
        answer = qa.answer;
        
        ClearInputField();
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
            Debug.Log("Check your answer");
            ClearInputField();
        }
    }

    private void ClearInputField()
    {
        answerInputField.text = "";
        answerInputField.ActivateInputField();
    }
}