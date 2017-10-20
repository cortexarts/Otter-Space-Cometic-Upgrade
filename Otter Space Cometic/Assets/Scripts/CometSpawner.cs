using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawner : MonoBehaviour
{
    public Vector2 amountExtrema;
    public Vector2 offsetExtrema;
    public Vector2 scaleExtrema;
    public GameObject cometPrefab;
    public List<GameObject> comets;

    public int difficulty;
    public int valueAnswerMin = 1;
    public int valueAnswerMax = 10;
    public int valueLinearMultiplicationMin = 1;
    public int valueLinearMultiplicationMax = 10;
    public int valueSquareMultiplicationMin = 1;
    public int valueSquareMultiplicationMax = 10;
    public int valueOffsetVariationMin = 1;
    public int valueOffsetVariationMax = 10;

    void SetRanges(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8)
    {
        valueAnswerMin = value1;
        valueAnswerMax = value2;
        valueSquareMultiplicationMin = value3;
        valueSquareMultiplicationMax = value4;
        valueLinearMultiplicationMin = value5;
        valueLinearMultiplicationMax = value6;
        valueOffsetVariationMin = value7;
        valueOffsetVariationMax = value8;
    }

    // Use this for initialization
    void Start ()
    {
        int cometsCount = (int)Random.Range(amountExtrema.x, amountExtrema.y);

        comets = new List<GameObject>();

        Vector3 newPosition;
        Vector3 lastPosition = new Vector3(0,0,0);

        for (int i = 0; i < cometsCount; i++)
        {
            // Generate random position that isn't overlapping with the previous position
            newPosition = this.transform.position + new Vector3(Random.Range(offsetExtrema.x, offsetExtrema.y), Random.Range(offsetExtrema.x, offsetExtrema.y), 0);
            if (newPosition.x - 2.0f > lastPosition.x && newPosition.y - 2.0f > lastPosition.y)
            {
                // Positions should be atleast 2.0f units apart
            }
            else
            {
                // Regenerate positition
                newPosition = this.transform.position + new Vector3(Random.Range(offsetExtrema.x, offsetExtrema.y), Random.Range(offsetExtrema.x, offsetExtrema.y), 0);
            }

            GameObject newComet = Instantiate(cometPrefab, newPosition, Quaternion.identity) as GameObject;
            newComet.transform.localScale = new Vector3(Random.Range(scaleExtrema.x, scaleExtrema.y), Random.Range(scaleExtrema.x, scaleExtrema.y), 1);
            comets.Add(newComet);

            // Store current position
            lastPosition = newPosition;

            switch (difficulty)
            {
                case 0: SetRanges(0, 10, 0, 0, 1, 1, 0, 0); break;
                case 1: SetRanges(0, 10, 0, 0, 1, 5, 0, 0); break;
                case 2: SetRanges(0, 10, 0, 0, 1, 5, 0, 10); break;
                case 3: SetRanges(0, 10, 0, 0, 1, 10, 0, 30); break;
                case 4: SetRanges(0, 10, 1, 1, 0, 0, 0, 0); break;
                case 5: SetRanges(0, 10, 1, 1, 1, 5, 0, 0); break;
                case 6: SetRanges(0, 10, 0, 1, 1, 10, 0, 30); break;
                case 7: SetRanges(0, 10, 0, 2, 1, 10, 0, 30); break;
            }

            List<int> value = new List<int> { Random.Range(valueAnswerMin, valueAnswerMax), Random.Range(valueLinearMultiplicationMin, valueLinearMultiplicationMax), Random.Range(valueSquareMultiplicationMin, valueSquareMultiplicationMax), Random.Range(valueOffsetVariationMin, valueOffsetVariationMax) };
            newComet.SendMessage("SetAnswer", value);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
