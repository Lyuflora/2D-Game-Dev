using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public static EventManager m_Instance;
    public List<BaseEvent> m_EventArray = new List<BaseEvent>();
    public Fungus.Flowchart m_EventFlowchart; 
    public string blockName;
    public GameObject CGparent;
    public GameObject CGImage;
    public PracticeEvent m_PracEvArray;
    public PracticeEvent m_AvailablePracEvArray;

    private void Awake()
    {
        m_Instance = this;
        DontDestroyOnLoad(gameObject);
        //EventFlowchart.SetBooleanVariable("Show", false);
    }

    public void GeneratePractices()
    {
        // C12 3

    }

    public void DisplayCG()
    {
        CGparent.SetActive(true);
    }

    public void DisplayEventCG(Sprite cg)
    {
        CGImage.GetComponent<Image>().sprite = cg;
    }


    public void HandleEventArray()
    {
        CGparent.SetActive(true);

        //EventFlowchart.ExecuteBlock(blockName);
        //EventFlowchart.SetBooleanVariable("Show", true);   // 设置变量

        // 逐事件行动
        for (int i = 0; i < m_EventArray.Count; i++)
        {
            m_EventArray[i].HandleEvent();
            DisplayEventCG(m_EventArray[i].cg);
            if (m_EventArray[i].m_Type == EventType.Bar)
            {
                Debug.Log("去酒吧");
                //EventFlowchart.SetBooleanVariable("Bar", true);   // 设置变量
                //EventFlowchart.ExecuteBlock("Bar");
            }
            if (m_EventArray[i].m_Type == EventType.Gym)
            {
                Debug.Log("去锻炼");
                //EventFlowchart.ExecuteBlock("Gym");
            }
            CalendarManager.m_Instance.NextDay();
        }
        //EventFlowchart.ExecuteBlock("Week Finish");
        CGparent.SetActive(false);
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
