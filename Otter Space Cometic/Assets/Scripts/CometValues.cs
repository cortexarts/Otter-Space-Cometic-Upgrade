using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CometValues : MonoBehaviour
{
    public List<int> value = new List<int>();
    public int answer;
    public int multiplication;
    public int offset;
    public Text formula;


	// Use this for initialization
	void Start () {
		
	}

    void SetAnswer(List<int> value)
    {
        answer = value[0];
        multiplication = value[1];
        offset = answer * multiplication;
    }
	
	// Update is called once per frame
	void Update () {
        formula.text = multiplication.ToString() + "x = " + offset.ToString();

    }
}
