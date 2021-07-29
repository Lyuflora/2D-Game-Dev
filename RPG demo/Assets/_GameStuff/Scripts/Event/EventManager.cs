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

        [NonSerialized]
        public int m_CurrentScheduleDay;

        private int lastFreeDay;
        private int toDay;
        private int firstWeekDay;

        private void Awake()
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
            //EventFlowchart.SetBooleanVariable("Show", false);
        }
        private void Start()
        {
            RefreshEvent();
            m_CurrentScheduleDay = 0;
            EventGrid.m_Instance.ReloadEventButton();
        }


        // ���ɱ��ܿ�ִ�е�����
        // todo
        public void RefreshEvent()
        {
            // todo �¼���ò�����
            EventGrid.m_Instance.m_AvailableEventBts = EventGrid.m_Instance.m_EventButtonList;
        }

        public void DisplayCG()
        {
            m_CGParent.SetActive(true);
        }

        public void Test()
        {
            Debug.Log("----First Day Finished----");
        }

        public void DisplayEventCG(Sprite cg)
        {
            CGImage.GetComponent<Image>().sprite = cg;
        }

        // ʹ�ó�����Flowchart �е��ú�һ����¼����ڶԻ�֮��
        // ���ܣ��ڽ��жԻ���Ԥ���ճ����У�������һ���ճ�
        public void CallHandleCurrentDay()
        {
            CalendarManager.m_Instance.m_CurrentDay++;
            Debug.Log("����ִ�е�" + CalendarManager.m_Instance.m_CurrentDay + "��");
            HandleDayEvent(CalendarManager.m_Instance.GetCurrentDayId());
        }
        public void HandleDayEvent(int dayId)
        {
            Debug.Log("��" + (dayId + 1) + "��");
            if (CheckDayScheduled(dayId))
            {
                Debug.Log("���찴��Ԥ���ճ�ִ��");
            }
            else
            {
                PanelManager.m_Instance.RefreshPopup(PanelManager.m_Instance.m_PopupPanel, m_EventArray[dayId]);
                PanelManager.m_Instance.OpenPanel(PanelManager.m_Instance.m_PopupPanel);
                m_EventArray[dayId].HandleEvent();
                ShowCG(m_EventArray[dayId].cg);
                // StartCoroutine(ShowCG(i));    
            }
            CalendarManager.m_Instance.NextDate();  // Update date text
            CalendarManager.m_Instance.StartDialogue(dayId);
        }

        // ��ť-ִ�е�һ�죨��������-��ʾ�Ի���-Fungus call�ڶ��죨��������-��ʾ�Ի���...
        public void HandleFirstDay()
        {
            Debug.Log("��" + 1 + "��");
            CalendarManager.m_Instance.m_CurrentDay = 0;
            HandleDayEvent(0);

            //if (m_EventArray[0])
            //{
            //    // ��Ԥ���ճ�
            //    HandleDayEvent(0);
            //    //m_EventArray[0].HandleEvent();
            //    //PanelManager.m_Instance.OpenPanel(PanelManager.m_Instance.m_PopupPanel);
            //    //PanelManager.m_Instance.RefreshPopup(PanelManager.m_Instance.m_PopupPanel, m_EventArray[0]);    
            //    //ShowCG(m_EventArray[0].cg);
            //    Debug.Log("��" + toDay + "��CG");
            //}
            //else
            //{  
            //    // ��������
            //    CalendarManager.m_Instance.NextDate();
                
            //    // ����Ի�
            //    CalendarManager.m_Instance.StartDialogue(0);
            //}
        }

        // ����
        //public IEnumerator HandleEventArray()
        //{
        //    //EventFlowchart.ExecuteBlock(blockName);
        //    //EventFlowchart.SetBooleanVariable("Show", true);   // ���ñ���

        //    PanelManager.m_Instance.OpenPanel(PanelManager.m_Instance.m_PopupPanel);
        //    // ���¼��ж�
        //    for (int i = 0; i < m_EventArray.Count; i++)
        //    {
        //        Debug.Log("��" + (i + 1) + "��");
        //        PanelManager.m_Instance.RefreshPopup(PanelManager.m_Instance.m_PopupPanel, m_EventArray[i]);
                
        //        m_EventArray[i].HandleEvent();
        //        StartCoroutine(ShowCG(i));
        //        CalendarManager.m_Instance.NextDay();
        //        yield return new WaitForSeconds(0.5f);

        //    }
        //    PanelManager.m_Instance.OpenPanel(PanelManager.m_Instance.m_PopupPanel);
        //}

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
                // ��ʼ��һ����ճ̡���ͨ��fungus������һ�죩
                HandleFirstDay();
                //StartCoroutine(HandleEventArray());
                Debug.Log("Init->During Finish Event Array");
            }
            else if (CalendarManager.m_Instance.GetWeekStatus() == WeekStatus.End)
            {
                Debug.Log("End->Init ��ʼ��һ��");
                CalendarManager.m_Instance.SetWeekStatus(WeekStatus.Init);
                PracticeManager.m_Instance.GeneratePractices(); // ���ɱ��ܵ���ϰ�¼�
                m_CalenderParent.SetActive(true);
                EventGrid.m_Instance.ReloadCalender();

                int currentWeek = GetCurrentWeek();
                // ��λ�����ܵ�һ�죨����ţ�
                firstWeekDay = toDay = ((int)DayOfWeek.Sunday)+ currentWeek * 7;
                // �ҵ��������һ��������
                lastFreeDay = GetLastFreeDayInWeek(currentWeek);

                NextWeek();
            }

        }
        public bool CheckDayScheduled(int dayId)
        {
            var isFree = CalendarManager.m_Instance.m_Calender[dayId].GetDayStatus();
            if (isFree == DayStatus.Scheduled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // �ҵ��������һ�������죬���������
        public int GetLastFreeDayInWeek(int week)
        {
            Debug.Log("Week: " + week);
            int freeday = (week-1) * 7;
            for (int i = 6; i >= 0; i--)
            {
                int dayId = (week - 1) * 7 + i;
                if (!CheckDayScheduled(dayId))
                {
                    freeday = (week - 1) * 7 + i;
                    break;
                }
            }
            return freeday;
        }

        public void ShowCG(Sprite cg)
        {
            DisplayEventCG(cg);
            //yield return new WaitForSeconds(1);
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

        private int GetCurrentWeek()
        {
            return CalendarManager.m_Instance.m_WeekNum;
        }


        internal void AddEventToWishlist(GameObject gameObject)
        {
            if (m_EventArray.Count >= 7)
            {
                Debug.Log("�����Ѿ����������,�޷����");
                return;
            }
            // ������һ���������Ѿ����ճ̹滮
            // ����ͨ���û�����������
            int w = GetCurrentWeek();
            int d = GetLastFreeDayInWeek(w);

            if (CheckDayScheduled(d))
            {
                return;
            }


            // �����Ҫ����
            // ����Ҫ��
            //// �ж��Ƿ���Ԥ����ж�
            //// ����У���������������һ������Ŀ�����
            //while (CalendarManager.m_Instance.m_Calender[toDay].GetDayStatus() == DayStatus.Scheduled)
            //{
            //    //�������
            //    m_EventArray.Add(null);
            //    // ��ת����һ��
            //    toDay++;
            //    if (toDay >= firstWeekDay + 7)
            //    {
            //        return;
            //    }
            //}



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