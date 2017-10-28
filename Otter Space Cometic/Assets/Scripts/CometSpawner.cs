﻿using System.Collections;
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

    bool IsColliding(Vector3 a_FirstVec, Vector3 a_SecondVec, float a_Radius)
    {
        // SIMD optimized AABB-AABB test
        // Optimized by removing conditional branches
        bool x = Mathf.Abs(a_FirstVec.x - a_SecondVec.x) <= (a_Radius + a_Radius);
        bool y = Mathf.Abs(a_FirstVec.y - a_SecondVec.y) <= (a_Radius + a_Radius);

        return x && y;
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
            if (IsColliding(newPosition, lastPosition, 2.0f))
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
                case 0: SetRanges(valueAnswerMin, valueAnswerMax, 0, 0, 1, 1, 0, 0); break;
                case 1: SetRanges(valueAnswerMin, valueAnswerMax, 0, 0, 1, 1, 0, 10); break;
                case 2: SetRanges(valueAnswerMin, valueAnswerMax, 0, 0, 1, 5, 0, 0); break;
                case 3: SetRanges(valueAnswerMin, valueAnswerMax, 0, 0, 1, 5, 0, 10); break;
                case 4: SetRanges(valueAnswerMin, valueAnswerMax, 0, 0, 1, 10, 0, 30); break;
                case 5: SetRanges(valueAnswerMin, valueAnswerMax, 1, 1, 0, 0, 0, 0); break;
                case 6: SetRanges(valueAnswerMin, valueAnswerMax, 1, 1, 0, 0, 0, 10); break;
                case 7: SetRanges(valueAnswerMin, valueAnswerMax, 1, 1, 1, 5, 0, 0); break;
                case 8: SetRanges(valueAnswerMin, valueAnswerMax, 0, 1, 1, 10, 0, 30); break;
                case 9: SetRanges(valueAnswerMin, valueAnswerMax, 0, 2, 1, 10, 0, 30); break;
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
