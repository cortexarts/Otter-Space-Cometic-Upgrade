using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollowScript : MonoBehaviour {

    [SerializeField]
    private Transform m_FollowTarget;
    [SerializeField]
    private Vector3 m_Offset;
	
	// Update is called once per frame
	void Update () {
        transform.position = m_FollowTarget.position + m_Offset;	
	}
}
