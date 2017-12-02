using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawner : MonoBehaviour
{
    public Vector2 amountExtrema;
    public Vector2 offsetExtrema;
    public Vector2 scaleExtrema;
    [SerializeField]
    public float offset = 1.0f;
    public GameObject cometPrefab;
    public List<GameObject> comets;
    private List<Vector3> positions;

    public int TextSize;
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

    bool IsColliding(Vector3 a_FirstVec, Vector3 a_SecondVec, float a_Padding)
    {
        // SIMD optimized AABB-AABB test
        // Optimized by removing conditional branches
        bool x = Mathf.Abs(a_FirstVec.x - a_SecondVec.x) <= (a_Padding + a_Padding);
        bool y = Mathf.Abs(a_FirstVec.y - a_SecondVec.y) <= (a_Padding + a_Padding);

        return x && y;
    }

    public int CometSpawnRequestCounter;

    void RequestCometSpawn()
    {
        CometSpawnRequestCounter++;
    }

    private void Update()
    {
        while (CometSpawnRequestCounter > 0)
        {
            SpawnComets();
            CometSpawnRequestCounter--;
        }
    }

    void SpawnComets()
    {
        int cometsCount = 1;
        comets = new List<GameObject>();
        positions = new List<Vector3>();

        // Generate positions
        while (positions.Count < cometsCount * 2.0f)
        {
            float angle = Random.Range(0, Mathf.PI * 2f);
            Vector3 newPosition = this.transform.position + new Vector3(Mathf.Sin(angle) * Random.Range(offsetExtrema.x, offsetExtrema.y), Mathf.Cos(angle) * Random.Range(offsetExtrema.x, offsetExtrema.y), 0);
            positions.Add(newPosition);
        }

        for (int outer = 0; outer < positions.Count - 1; outer++)
        {
            for (int inner = outer + 1; inner < positions.Count; inner++)
            {
                if (IsColliding(positions[inner], positions[outer], offset))
                {
                    positions.RemoveAt(inner);
                    inner--;
                }
            }
        }

        for (int i = 0; i < positions.Count && i < cometsCount; i++)
        {
            GameObject newComet = Instantiate(cometPrefab, positions[i], Quaternion.identity) as GameObject;
            newComet.transform.localScale = new Vector3(Random.Range(scaleExtrema.x, scaleExtrema.y), Random.Range(scaleExtrema.x, scaleExtrema.y), 1);
            comets.Add(newComet);

            switch (difficulty) {
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

            List<int> value = new List<int> { Random.Range(valueAnswerMin, valueAnswerMax), Random.Range(valueLinearMultiplicationMin, valueLinearMultiplicationMax), Random.Range(valueSquareMultiplicationMin, valueSquareMultiplicationMax), Random.Range(valueOffsetVariationMin, valueOffsetVariationMax), TextSize };
            newComet.SendMessage("SetAnswer", value);
            newComet.SendMessage("CometSpawnerID", this.gameObject);
        }
    }

    void Start()
    {
        CometSpawnRequestCounter = (int)Random.Range(amountExtrema.x, amountExtrema.y);
        SpawnComets();
    }
}
