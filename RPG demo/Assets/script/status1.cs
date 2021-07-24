using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class status1 : MonoBehaviour
{

    // 进度条
    public Slider slider;
    // 进度文本
    Text text;
    public GameObject percent;
    void Start()
    {
        slider = GetComponent<Slider>();
        text = percent.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        void onProgress(int progress)
        {
            slider.value = progress;
        }
        text.text = (slider.value * 10).ToString("f0") ;
        //if () {

            //slider.value += 0.1f;
        //}
    }
}
