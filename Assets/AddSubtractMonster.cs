using System;
using TutorialAssets.Scripts;
using Random = UnityEngine.Random;

public class AddSubtractMonster : MonsterController
{
    public int maxOperand1 = 50;
    public int maxOperand2 = 50;

    public delegate QuestionAnswer MixedQuestion(QuestionAnswer questionAnswer);

    public MixedQuestion mixedQuestion;

    private void Start()
    {
        mixedQuestion += GenerateQuestion;
    }

    public QuestionAnswer GenerateQuestion()
    {
        QuestionAnswer qa1;

        var operand1 = Random.Range(1, maxOperand1);
        var operand2 = Random.Range(1, maxOperand2);
        var randNumber = Random.value;

        if (randNumber < 0.5f)
        {
            // var question1 = $"{operand1} + {operand2} =";
            // var answer1 = operand1 + operand2;
            // qa = new QuestionAnswer(question1, answer1.ToString());

            qa1 = new QuestionAnswer(
                $"{operand1} - {operand2}",
                (operand1 - operand2).ToString()
            );
        }
        else
        {
            qa1 = new QuestionAnswer(
                $"{operand1} + {operand2}",
                (operand1 + operand2).ToString()
            );
        }

        return qa1;
    }
}
