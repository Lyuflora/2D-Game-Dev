using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestEventButton : EventButton
{
     public RestEvent m_Event;

    private void Awake()
    {
        base.Awake();
        m_Text.text = m_Event.name;
    }
    override public void OnEventButtonPressed()
    {
        base.OnEventButtonPressed();
    }
}