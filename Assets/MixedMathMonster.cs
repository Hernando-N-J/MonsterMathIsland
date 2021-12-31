using TutorialAssets.Scripts;
using Random = UnityEngine.Random;

public class MixedMathMonster : MonsterController
{
    public int maxOperand1 = 20;
    public int maxOperand2 = 20;

    public QuestionAnswer Question1()
    {
        var operand1 = Random.Range(1, maxOperand1);
        var operand2 = Random.Range(1, maxOperand2);
        
        return new QuestionAnswer( $"{operand1} * {operand2}",
                                    (operand1 * operand2).ToString()
                                );
    }
    
    public QuestionAnswer Question2()
    {
        QuestionAnswer qa2;
        
        var operand1 = Random.Range(1, maxOperand1);
        var operand2 = Random.Range(1, maxOperand2);
        
        return new QuestionAnswer( $"{operand1} * {operand2}",
            (operand1 * operand2).ToString()
        );
    }
}
