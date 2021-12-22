using TutorialAssets.Scripts;
using UnityEngine;

public class DivideMonster : MonsterController, IQuestion
{
    public int maxOperand = 50;
    public int maxMultiply = 10;
    
    public QuestionAnswer GenerateQuestion()
    {
        var operand1 = Random.Range(1, maxOperand);
        var operand2 = Random.Range(1, maxMultiply);

        var question1 = $"{operand1} / {operand2}";
        var answer1 = (float)operand1 / operand2;

        // If true, it's an integer
        var answerFormatted = answer1.ToString(answer1 % 1 == 0 ? "0" : "0.0");

        return new QuestionAnswer(question1, answerFormatted);
    }
}
