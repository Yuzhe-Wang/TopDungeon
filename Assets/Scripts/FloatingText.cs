using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    public bool isActive;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void show()
    {
        isActive = true;
        lastShown = Time.time;
        go.SetActive(isActive);
    }

    public void Hide()
    {
        isActive = false;
        go.SetActive(isActive);
    }

    // Update is called once per frame
    public void UpdateFloatingText()
    {
        if(!isActive)
        {
            return;
        }
        if(Time.time - lastShown > duration)
        {
            Hide();
        }
        go.transform.position += motion * Time.deltaTime;
    }
}
