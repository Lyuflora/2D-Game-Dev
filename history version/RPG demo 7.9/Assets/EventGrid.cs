using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGrid : MonoBehaviour  // �Ų��¼���ť
{
    static public EventGrid m_Instance;
    public List<GameObject> m_AvailableEventBts;    // ������ʾ���¼���ť
    public EventButton[] m_EventButtons;    //  ��ť�����,todo
    public GameObject CalenderParent;   //   �¼���ť��parent
    private void Awake()
    {
        m_Instance = this;
        DontDestroyOnLoad(this);
        CalenderParent = this.gameObject;
    }

    public void ReloadEventButton()
    {
        float x = CalenderParent.transform.position.x;
        float y = CalenderParent.transform.position.y;
        float Xanchor = 60f;
        float Yoffset = 40f;

        // load event array
        for (int i = 0; i < m_AvailableEventBts.Count; i++)
        {
            //m_AvailableEventBts[i].Getcomponent<>().

            
            var newItem = Instantiate(m_AvailableEventBts[i], new Vector3(x+Xanchor, y-Yoffset * (i-1), 0), Quaternion.identity);
            newItem.transform.parent = CalenderParent.transform;
        }
    }

    void RefreshButtonProperties()
    {
        //for (int i = 0; i < m_EventButtons.Length; i++)
        //{

            //int numBrushesInBrushList = EventCatalog.m_Instance.m_GuiEventList.Count;
            // int iEventIndex = i;
            //if (iEventIndex < numBrushesInBrushList)
            //{
                //if (!m_EventButtons[i].IsHover())
                //{
                    //BaseEvent rEvent = EventCatalog.m_Instance.m_GuiEventList[iEventIndex];
                    //m_EventButtons[i].SetButtonProperties(rEvent);
                    //m_EventButtons[i].SetButtonSelected(rBrush == BrushController.m_Instance.ActiveBrush);
                    //m_EventButtons[i].gameObject.SetActive(true);
                //}
            //}

        //}
    }
}
