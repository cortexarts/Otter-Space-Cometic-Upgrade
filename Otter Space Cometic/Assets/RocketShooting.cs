using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShooting : MonoBehaviour
{
    public GameObject rocketPrefab;

    // Handle camera shaking
    public float camShakeAmt = 0.05f;
    public float camShakeLength = 0.1f;
   // CameraShake camShake;

    // Use this for initialization
    void Start ()
    {
      //  camShake = GameMaster.gm.GetComponent<CameraShake>();
      //  if (camShake == null)
       //     Debug.LogError("No CameraShake script found on GM object.");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject newRocket = Instantiate(rocketPrefab, this.transform.position, this.transform.rotation) as GameObject;

        //if (hitNormal != new Vector3(9999, 9999, 9999))
        //{
        //    Transform hitParticle = Instantiate(HitPrefab, hitPos, Quaternion.FromToRotation(Vector3.right, hitNormal)) as Transform;
        //    Destroy(hitParticle.gameObject, 1f);
        //}

        //Shake the camera
        //camShake.Shake(camShakeAmt, camShakeLength);
    }
}