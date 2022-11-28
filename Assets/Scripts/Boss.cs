using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public float [] fireballSpeed = { 4.0f, -4.0f };
    public float distance = 0.4f;
    public Transform [] fireballs;


    private void Update()
    {
        for(int i = 0; i < fireballs.Length; ++i)
        {
            fireballs[i].position = transform.position + new Vector3(-Mathf.Cos(Time.time * fireballSpeed[i]) * distance, Mathf.Sin(Time.time * fireballSpeed[i]) * distance, 0);
        }
    }
}
