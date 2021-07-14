using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Gmds
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager m_Instance;

        public List<BaseEvent> m_EventArray = new List<BaseEvent>();
        public Fungus.Flowchart m_EventFlowchart;
        public string blockName;
        public GameObject m_CGParent;
        public GameObject CGImage;
        public GameObject m_CalenderParent;


        private void Awake()
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
            //EventFlowchart.SetBooleanVariable("Show", false);
        }
        private void Start()
        {
            RefreshEvent();
            EventGrid.m_Instance.ReloadEventButton();
        }


        // ���ɱ��ܿ�ִ�е�����
        // todo
        public void RefreshEvent()
        {
            // todo �¼���ò�����
            EventGrid.m_Instance.m_AvailableEventBts = EventCatalog.m_Instance.m_EventButtonList;
        }

        public void DisplayCG()
        {
            m_CGParent.SetActive(true);
        }

        public void DisplayEventCG(Sprite cg)
        {
            CGImage.GetComponent<Image>().sprite = cg;
        }

        public IEnumerator HandleEventArray()
        {
            //EventFlowchart.ExecuteBlock(blockName);
            //EventFlowchart.SetBooleanVariable("Show", true);   // ���ñ���
            PanelManager.m_Instance.OpenPanel(PanelManager.m_Instance.m_PopupPanel);
            // ���¼��ж�
            for (int i = 0; i < m_EventArray.Count; i++)
            {
                Debug.Log("��" + (i + 1) + "��");
                PanelManager.m_Instance.RefreshPopup(PanelManager.m_Instance.m_PopupPanel, m_EventArray[i]);
                
                m_EventArray[i].HandleEvent();
                StartCoroutine(ShowCG(i));
                CalendarManager.m_Instance.NextDay();
                yield return new WaitForSeconds(0.5f);

            }
            PanelManager.m_Instance.OpenPanel(PanelManager.m_Instance.m_PopupPanel);
        }

        public void UpdateWeekStatus()
        {
            // init-���Ź滮-��ȷ��-during-��������CG-��ȷ��-End-init...
            if (CalendarManager.m_Instance.GetWeekStatus() == WeekStatus.During)
            {
                Debug.Log("During->End ��һ�ܼ�����ʼ");
                CalendarManager.m_Instance.SetWeekStatus(WeekStatus.End);
                m_CGParent.SetActive(false);
                ClearOldEventButtons();
                m_EventArray.Clear();
            }
            else if (CalendarManager.m_Instance.GetWeekStatus() == WeekStatus.Init)
            {
                CalendarManager.m_Instance.SetWeekStatus(WeekStatus.During);
                m_CGParent.SetActive(true);
                m_CalenderParent.SetActive(false);
                StartCoroutine(HandleEventArray());
                Debug.Log("Init->During Finish Event Array");
            }
            else if (CalendarManager.m_Instance.GetWeekStatus() == WeekStatus.End)
            {
                Debug.Log("End->Init ��ʼ��һ��");
                CalendarManager.m_Instance.SetWeekStatus(WeekStatus.Init);
                PracticeManager.m_Instance.GeneratePractices(); // ���ɱ��ܵ���ϰ�¼�
                m_CalenderParent.SetActive(true);
                EventGrid.m_Instance.ReloadCalender();
                NextWeek();
            }


        }
        public IEnumerator ShowCG(int num)
        {
            Debug.Log("��" + num + "��CG");
            DisplayEventCG(m_EventArray[num].cg);
            yield return new WaitForSeconds(1);
        }

        public void Day1()
        {
            Debug.Log("This is Day 1 Dialog----------");
        }

        public void Day2()
        {
            Debug.Log("This is Day 2 Dialog----------");
        }

        public void ClearOldEventButtons()
        {
            Debug.Log("��ʼ�����������");
            PanelManager.m_Instance.ClearOldChilds(EventGrid.m_Instance.m_DevEvParent);
            PanelManager.m_Instance.ClearOldChilds(EventGrid.m_Instance.m_PracEvParent);
            PanelManager.m_Instance.ClearOldChilds(EventGrid.m_Instance.m_SocialEvParent);
            PanelManager.m_Instance.ClearOldChilds(EventGrid.m_Instance.m_RestEvParent);
        }

        public void NextWeek()
        {
            Debug.Log("New Week");
            CalendarManager.m_Instance.NextWeek();
            RefreshEvent();
            EventGrid.m_Instance.ReloadEventButton();
            CalendarManager.m_Instance.m_CalendarPanel.SetActive(true);
        }

        internal void AddEventToWishlist(GameObject gameObject)
        {

            // �ճ��ж�
            if (gameObject.GetComponent<PracticeEventButton>())
            {
                // ����ϰ�ж�
                Debug.Log("Add a practice event");
                m_EventArray.Add(gameObject.GetComponent<PracticeEventButton>().m_Event);
            }
            else if (gameObject.GetComponent<SocialEventButton>())
            {
                // ������ж�
                Debug.Log("Add a social event");
                m_EventArray.Add(gameObject.GetComponent<SocialEventButton>().m_Event);
            }
            else if (gameObject.GetComponent<RestEventButton>())
            {
                // ����Ϣ�ж�
                Debug.Log("Add a rest");
                m_EventArray.Add(gameObject.GetComponent<RestEventButton>().m_Event);
            }
            else if (gameObject.GetComponent<DevEventButton>())
            {
                // �ǿ����ж�
                Debug.Log("Add a dev");
                m_EventArray.Add(gameObject.GetComponent<DevEventButton>().m_Event);
            }

        }
    }
}