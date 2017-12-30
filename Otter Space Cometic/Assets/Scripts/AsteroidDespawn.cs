using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDespawn : MonoBehaviour {

    private GameObject AsteroidSpawner;

    public int maxDistanceToRocket;

    void AsteroidSpawnerID(GameObject ID)
    {
        AsteroidSpawner = ID;
    }

    void OnDestroy()
    {
        if (AsteroidSpawner != null)
        {
            AsteroidSpawner.SendMessage("RequestAsteroidSpawn");
        }
    }

    void Update()
    {
        if (AsteroidSpawner != null)
        {
            float distanceToRocket = Vector3.Distance(AsteroidSpawner.transform.position, this.gameObject.transform.position);
            
            if (distanceToRocket > maxDistanceToRocket) DestroyObject(this.gameObject);
        }
    }
}