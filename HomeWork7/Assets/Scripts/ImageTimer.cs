using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    public float MaxTime;

    private Image img;
    private float currentTime = 0;
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= MaxTime)
            currentTime = 0;

        img.fillAmount = currentTime / MaxTime;
    }
}
