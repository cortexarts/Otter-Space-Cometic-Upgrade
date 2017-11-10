using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    public int answer;

    public float lifeTime = 0;
    public float maxLifeTime = 5.0f;

    [SerializeField]
    public float m_Velocity = 150.0f;

    // Handle camera shaking
    public float camShakeAmt = 0.05f;
    public float camShakeLength = 0.1f;
    CameraShake camShake;

    private Rigidbody2D m_Rigidbody2D;

    public GameObject Shockwave;

    // Use this for initialization
    void Start ()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        camShake = Camera.main.GetComponent<CameraShake>();
        if (camShake == null)
        {
            Debug.LogError("No CameraShake script found.");
        }
    }

    void SetAnswer(int value)
    {
        answer = value;
    }

        // Update is called once per frame
        void Update ()
    {
        lifeTime += Time.deltaTime;

        if (lifeTime > maxLifeTime)
        {
            DestroyImmediate(this.gameObject);
        }
	}

    private void FixedUpdate()
    {
        m_Rigidbody2D.velocity = transform.up * m_Velocity * Time.fixedDeltaTime;
        m_Velocity += lifeTime * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Comet")
        {
            //Shake the camera
            if (collider.GetComponent<CometValues>().answer == answer)
            {
                DestroyObject(collider.gameObject);
                camShake.Shake(camShakeAmt, camShakeLength);
            }
            GameObject ShockwaveInstance = Instantiate(Shockwave, this.gameObject.transform.position, Quaternion.identity);
            DestroyObject(this.gameObject);
        }
    }
}
