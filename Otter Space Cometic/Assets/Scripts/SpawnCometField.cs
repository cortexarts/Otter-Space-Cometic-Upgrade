using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCometField : MonoBehaviour
{
    public GameObject CometField;
    public Vector3 SpawnOffset;
    public bool hasSpawnedFied;
    public float SpawnDelay;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.realtimeSinceStartup > SpawnDelay && !hasSpawnedFied)
        {
            SpawnComets(SpawnOffset);
            hasSpawnedFied = true;
        }
	}

    public void SpawnComets(Vector3 a_SpawnOffset)
    {
        Instantiate(CometField, this.gameObject.transform.position + a_SpawnOffset, Quaternion.identity);
    }
}
