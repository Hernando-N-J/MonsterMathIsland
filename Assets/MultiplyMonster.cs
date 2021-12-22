using TutorialAssets.Scripts;
using UnityEngine;

public class MultiplyMonster : MonsterController, IQuestion
{
    public int maxOperand = 50;
    public int maxMultiply = 12;

    public QuestionAnswer GenerateQuestion()
    {
        var operand1 = Random.Range(1, maxOperand);
        var operand2 = Random.Range(1, maxMultiply);

        return new QuestionAnswer(
            $"{operand1} * {operand2}",
            (operand1 * operand2).ToString()
            );
    }
}