using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawner : MonoBehaviour
{
    public Vector2 amountExtrema;
    public Vector2 offsetExtrema;
    public Vector2 scaleExtrema;
    public GameObject cometPrefab;
    private GameObject[] comets;

    // Use this for initialization
    void Start ()
    {
        int cometsCount = (int)Random.Range(amountExtrema.x, amountExtrema.y);

        comets = new GameObject[cometsCount];

        for (int i = 0; i < cometsCount; i++)
        {
            GameObject newComet = Instantiate(cometPrefab, this.transform.position + new Vector3(Random.Range(offsetExtrema.x, offsetExtrema.y) * i, Random.Range(offsetExtrema.x, offsetExtrema.y) * i, 0), Quaternion.identity) as GameObject;
            newComet.transform.localScale = new Vector3(Random.Range(scaleExtrema.x, scaleExtrema.y), Random.Range(scaleExtrema.x, scaleExtrema.y), 1);
            comets[i] = newComet;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
