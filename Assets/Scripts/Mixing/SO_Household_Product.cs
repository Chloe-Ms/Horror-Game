using NaughtyAttributes;
using UnityEngine;


[CreateAssetMenu(fileName = "SO_Household_Product", menuName = "Scriptable Objects/SO_Household_Product")]
public class SO_Household_Product : ScriptableObject
{
    public float ToxicityInitialValue = 0.5f;
    public float ToxicityMultiplierValue = 1.0f;
    public float ToxicityAdditionValue = 0.5f;

    public float ApplyToxicityValue(EToxicityOperator toxicityOperator, float value)
    {
        if (toxicityOperator == EToxicityOperator.Addition) 
        {
            value += ToxicityAdditionValue;
        } 
        else
        {
            value *= ToxicityMultiplierValue;
        }

        return value;
    }
}