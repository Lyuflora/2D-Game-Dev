using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class RatingSlider : MonoBehaviour
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

    public void SetRating(int value)
    {
        slider.maxValue = 10f;
        slider.value = value;
        text.text = value.ToString();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    void onProgress(int progress)
    //    {
    //        slider.value = progress;
    //    }
    //    text.text = (slider.value * 10).ToString("f0") ;
    //    //if () {

    //        //slider.value += 0.1f;
    //    //}
    //}
}
