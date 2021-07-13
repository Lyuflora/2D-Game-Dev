using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager m_Instance;
    public List<BaseEvent> m_EventArray = new List<BaseEvent>();
    public Fungus.Flowchart EventFlowchart; // Link the Flowchart in your script
    public string blockName;
    public GameObject CGparent;

    private void Awake()
    {
        m_Instance = this;
        DontDestroyOnLoad(gameObject);
        EventFlowchart.SetBooleanVariable("Show", false);
    }

    public void HandleEventArray()
    {
        CGparent.SetActive(true);

        EventFlowchart.ExecuteBlock(blockName);
        EventFlowchart.SetBooleanVariable("Show", true);   // 设置变量

        for (int i = 0; i < m_EventArray.Count; i++)
        {
            m_EventArray[i].HandleEvent();
            if (m_EventArray[i].m_Type == EventType.Bar)
            {
                Debug.Log("去酒吧");
                //EventFlowchart.SetBooleanVariable("Bar", true);   // 设置变量
                EventFlowchart.ExecuteBlock("Bar");
            }
            if (m_EventArray[i].m_Type == EventType.Gym)
            {
                Debug.Log("去锻炼");
                EventFlowchart.ExecuteBlock("Gym");
            }
            CalendarManager.m_Instance.NextDay();
        }

        GameObject.Find("CG Image").SetActive(false);
        CalendarManager.m_Instance.SetWeekStatus(WeekStatus.End);
    }

    internal void AddEventToWishlist(GameObject gameObject)
    {
        // 日常行动
        if (gameObject.GetComponent<PracticeEventItem>())
        {
            // 是练习行动
            Debug.Log("Add a practice event");
            m_EventArray.Add(gameObject.GetComponent<PracticeEventItem>().ev);
        }
        else if (gameObject.GetComponent<SocialEventItem>())
        {
            // 是外出行动
            Debug.Log("Add a social event");
            m_EventArray.Add(gameObject.GetComponent<SocialEventItem>().ev);
        }
        else if (gameObject.GetComponent<RestEventItem>())
        {
            // 是休息行动
            Debug.Log("Add a rest");
            m_EventArray.Add(gameObject.GetComponent<RestEventItem>().ev);
        }
        
    }
}
