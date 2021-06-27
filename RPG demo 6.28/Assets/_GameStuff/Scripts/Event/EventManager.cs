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
        EventFlowchart.SetBooleanVariable("Show", true);   // ���ñ���

        for (int i = 0; i < m_EventArray.Count; i++)
        {
            m_EventArray[i].HandleEvent();
            if (m_EventArray[i].m_Type == EventType.Bar)
            {
                Debug.Log("ȥ�ư�");
                //EventFlowchart.SetBooleanVariable("Bar", true);   // ���ñ���
                EventFlowchart.ExecuteBlock("Bar");
            }
            if (m_EventArray[i].m_Type == EventType.Gym)
            {
                Debug.Log("ȥ����");
                EventFlowchart.ExecuteBlock("Gym");
            }
            CalendarManager.m_Instance.NextDay();
        }

        GameObject.Find("CG Image").SetActive(false);
        CalendarManager.m_Instance.SetWeekStatus(WeekStatus.End);
    }

    internal void AddEventToWishlist(GameObject gameObject)
    {
        // �ճ��ж�
        if (gameObject.GetComponent<PracticeEventItem>())
        {
            // ����ϰ�ж�
            Debug.Log("Add a practice event");
            m_EventArray.Add(gameObject.GetComponent<PracticeEventItem>().ev);
        }
        else if (gameObject.GetComponent<SocialEventItem>())
        {
            // ������ж�
            Debug.Log("Add a social event");
            m_EventArray.Add(gameObject.GetComponent<SocialEventItem>().ev);
        }
        else if (gameObject.GetComponent<RestEventItem>())
        {
            // ����Ϣ�ж�
            Debug.Log("Add a rest");
            m_EventArray.Add(gameObject.GetComponent<RestEventItem>().ev);
        }
        
    }
}
