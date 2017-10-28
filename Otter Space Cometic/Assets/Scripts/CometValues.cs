using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CometValues : MonoBehaviour
{
    private List<int> value = new List<int>();
    private int offset;
    private string stringToReturn;
    private string stringToAdd;

    public int answer;
    public int linearMultiplication;
    public int squareMultiplication;
    public int offsetLeft;
    public int offsetRight;
    public Text formula;


    // Use this for initialization
    void Start()
    {

    }

    void SetAnswer(List<int> value)
    {
        answer = value[0];
        linearMultiplication = value[1];
        squareMultiplication = value[2];
        offset = -((answer * answer * squareMultiplication) + (answer * linearMultiplication));
        offsetLeft = offset - value[3];
        offsetRight = value[3];
    }

    string cleanupText(int number, string stringToAdd, string positiveString, string negativeString)
    {
        stringToReturn = "";
        if (number != 0)
        {
            if (number > 0) stringToReturn += positiveString;
            else
            {
                number *= -1;
                stringToReturn += negativeString;
            }
            if (number != 1) stringToReturn += number.ToString();
            stringToReturn += stringToAdd;
             
        }
        return stringToReturn;
    }

    // Update is called once per frame
    void Update()
    {
        formula.text = "";
        formula.text += cleanupText(squareMultiplication, "x" + '\u00B2', "", "-");
        if(squareMultiplication != 0) formula.text += cleanupText(linearMultiplication, "x ", " + ", " - ");
        else formula.text += cleanupText(linearMultiplication, "x ", "", "-");
        formula.text += cleanupText(offsetLeft, "", "+ ", "- ");
        formula.text += " = ";

        if (offsetRight != 0) formula.text += cleanupText(offsetRight, "", "", "-");
        else formula.text += "0";
    }
}