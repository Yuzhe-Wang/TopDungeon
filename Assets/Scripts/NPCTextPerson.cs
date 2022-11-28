using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTextPerson : Collectable
{
    public string message;
    private float cooldown = 4.0f;
    private float lastShout = -4.0f;

    protected override void OnCollect()
    {
        if (Time.time - lastShout > cooldown)
        {
            lastShout = Time.time;
            GameManager.manager.ShowText(message, 35, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, 4.0f);
        }
    }
}
