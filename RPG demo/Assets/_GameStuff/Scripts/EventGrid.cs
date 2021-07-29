using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gmds
{
    public class EventGrid : MonoBehaviour  // �Ų��¼���ť
    {
        static public EventGrid m_Instance;
        public List<GameObject> m_AvailableEventBts;    // ������ʾ���¼���ť
        public GameObject CalenderParent;   //   �¼���ť��parent

        public GameObject m_DevEvParent;
        public GameObject m_PracEvParent;
        public GameObject m_SocialEvParent;
        public GameObject m_RestEvParent;

        public List<GameObject> m_EventButtonList;
        public List<GameObject> m_DevEventButtonList;
        public List<GameObject> m_PracticeEventButtonList;
        public List<GameObject> m_SocialEventButtonList;
        public List<GameObject> m_RestEventButtonList;

        public List<GameObject> m_ResultEventButtonList;

        public void ReloadCalender()
        {
            CalenderParent = this.gameObject;

            m_DevEvParent = GameObject.Find("Canvas/Calendar/Schedule/Devs");
            m_PracEvParent = GameObject.Find("Canvas/Calendar/Schedule/Practices");
            m_SocialEvParent = GameObject.Find("Canvas/Calendar/Schedule/Socials");
            m_RestEvParent = GameObject.Find("Canvas/Calendar/Schedule/Rest");
        }

        private void Awake()
        {
            m_Instance = this;
            DontDestroyOnLoad(this);
            ReloadCalender();
        }

        private void Start()
        {
            
        }

        // todo
        public void ReloadEventButton()
        {
            // ��ʼ��ʱĬ����ʾ��ϰ��Ŀ
            for(int i = 0; i < 3; i++)
            {
                
                int prac_id = PracticeManager.m_Instance.m_WeekPractice[i];
                Debug.Log("��ʾ��ϰ" + prac_id);
                GameObject pracBt = m_PracticeEventButtonList[prac_id];
                var newItem = Instantiate(pracBt, m_ResultEventButtonList[i].gameObject.transform.position, Quaternion.identity);
                newItem.transform.parent = m_PracEvParent.transform;
            }

            float x = CalenderParent.transform.position.x;
            float y = CalenderParent.transform.position.y;
            float Xanchor = 60f;
            float Yoffset = 40f;

            // load event array
            for (int i = 0; i < m_AvailableEventBts.Count; i++)
            {
                var newItem = Instantiate(m_AvailableEventBts[i], new Vector3(x + Xanchor, y - Yoffset * (i - 1), 0), Quaternion.identity);
                var type = newItem.GetComponent<EventButton>().m_Type;
                Transform itemParent = CalenderParent.transform;
                if (type == EventGenre.BaseDev || type == EventGenre.Dev)
                {
                    itemParent = m_DevEvParent.transform;
                }
                else if (type == EventGenre.Practice)
                {
                    itemParent = m_PracEvParent.transform;
                }
                else if (type == EventGenre.Social)
                {
                    itemParent = m_SocialEvParent.transform;
                }
                else if (type == EventGenre.Rest)
                {
                    itemParent = m_RestEvParent.transform;
                }

                if (itemParent)
                {
                    newItem.transform.parent = itemParent;
                }
                newItem.transform.position = new Vector3(x + Xanchor + itemParent.transform.position.x, y - Yoffset * (i - 1), 0);
            }

            // load "selected" event buttons
            // Ĭ����������ϰ��1 2 3��
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
}