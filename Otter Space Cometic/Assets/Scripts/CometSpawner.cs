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

    public int valueAnswerMin = 1;
    public int valueAnswerMax = 10;
    public int valueMultiplicationMin = 1;
    public int valueMultiplicationMax = 10;


    // Use this for initialization
    void Start ()
    {
        int cometsCount = (int)Random.Range(amountExtrema.x, amountExtrema.y);

        comets = new List<GameObject>();

        for (int i = 0; i < cometsCount; i++)
        {
            GameObject newComet = Instantiate(cometPrefab, this.transform.position + new Vector3(Random.Range(offsetExtrema.x, offsetExtrema.y), Random.Range(offsetExtrema.x, offsetExtrema.y), 0), Quaternion.identity) as GameObject;
            newComet.transform.localScale = new Vector3(Random.Range(scaleExtrema.x, scaleExtrema.y), Random.Range(scaleExtrema.x, scaleExtrema.y), 1);
            comets.Add(newComet);

            List<int> value = new List<int> { Random.Range(valueAnswerMin, valueAnswerMax), Random.Range(valueMultiplicationMin, valueMultiplicationMax)};
            newComet.SendMessage("SetAnswer", value);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
