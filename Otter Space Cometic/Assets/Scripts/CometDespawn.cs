using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometDespawn : MonoBehaviour {

    private GameObject CometSpawner;

    public int maxDistanceToRocket;

    void CometSpawnerID(GameObject ID)
    {
        CometSpawner = ID;
    }

    void OnDestroy()
    {
        if (CometSpawner != null)
        {
            CometSpawner.SendMessage("RequestCometSpawn");
        }
    }

    void Update()
    {
        if (CometSpawner != null)
        {
            float distanceToRocket = Vector3.Distance(CometSpawner.transform.position, this.gameObject.transform.position);
            
            if (distanceToRocket > maxDistanceToRocket) DestroyObject(this.gameObject);
        }
    }
}