using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVScrolling : MonoBehaviour
{
    public int materialIndex = 0;
    public float U_AnimationRate = 1.0f;
    public float V_AnimationRate = 0.0f;
    public string textureName = "_MainTex";

    private Rigidbody2D playerPhysics;
    private Vector2 uvOffset;

    private MeshRenderer mr;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        playerPhysics = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        float U_Offset = playerPhysics.velocity.x * U_AnimationRate;
        float V_Offset = playerPhysics.velocity.y * V_AnimationRate;
        Debug.Log(U_Offset + " V: " + V_Offset);
        uvOffset += new Vector2(U_Offset, V_Offset);

        if (mr.enabled)
        {
            mr.materials[materialIndex].SetTextureOffset(textureName, uvOffset);
        }
    }
}
