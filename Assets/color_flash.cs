using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_flash : MonoBehaviour {
    public float duration = 1.0F;
    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void Update()
    {
        float hue = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.color = Color.HSVToRGB(hue, 0.8f, 0.8f);
    }
}
