using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevEventButton : EventButton
{
    public DevEvent m_Event;
    private void Awake()
    {
        base.Awake();
        m_Text.text = m_Event.name;
    }

    override public void OnEventButtonPressed()
    {
        base.OnEventButtonPressed();
        Debug.Log("添加开发事项");
    }

}
