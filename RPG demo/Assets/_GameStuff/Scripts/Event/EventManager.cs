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


        // 生成本周可执行的事项
        // todo
        public void RefreshEvent()
        {
            // todo 事件变得不可用
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

        // 使用场景：Flowchart 中调用后一天的事件，在对话之后
        // 功能：在仅有对话的预置日程天中，触发下一天日程
        public void CallHandleCurrentDay()
        {
            CalendarManager.m_Instance.m_CurrentDay++;
            Debug.Log("即将执行第" + CalendarManager.m_Instance.m_CurrentDay + "天");
            HandleDayEvent(CalendarManager.m_Instance.GetCurrentDayId());
        }
        public void HandleDayEvent(int dayId)
        {
            Debug.Log("第" + (dayId + 1) + "天");
            if (CheckDayScheduled(dayId))
            {
                Debug.Log("今天按照预置日程执行");
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

        // 按钮-执行第一天（计算属性-显示对话）-Fungus call第二天（计算属性-显示对话）...
        public void HandleFirstDay()
        {
            Debug.Log("第" + 1 + "天");
            CalendarManager.m_Instance.m_CurrentDay = 0;
            HandleDayEvent(0);

            //if (m_EventArray[0])
            //{
            //    // 无预置日程
            //    HandleDayEvent(0);
            //    //m_EventArray[0].HandleEvent();
            //    //PanelManager.m_Instance.OpenPanel(PanelManager.m_Instance.m_PopupPanel);
            //    //PanelManager.m_Instance.RefreshPopup(PanelManager.m_Instance.m_PopupPanel, m_EventArray[0]);    
            //    //ShowCG(m_EventArray[0].cg);
            //    Debug.Log("第" + toDay + "天CG");
            //}
            //else
            //{  
            //    // 更新日期
            //    CalendarManager.m_Instance.NextDate();
                
            //    // 处理对话
            //    CalendarManager.m_Instance.StartDialogue(0);
            //}
        }

        // 不用
        //public IEnumerator HandleEventArray()
        //{
        //    //EventFlowchart.ExecuteBlock(blockName);
        //    //EventFlowchart.SetBooleanVariable("Show", true);   // 设置变量

        //    PanelManager.m_Instance.OpenPanel(PanelManager.m_Instance.m_PopupPanel);
        //    // 逐事件行动
        //    for (int i = 0; i < m_EventArray.Count; i++)
        //    {
        //        Debug.Log("第" + (i + 1) + "天");
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
            // init-安排规划-点确定-during-遍历播放CG-点确定-End-init...
            if (CalendarManager.m_Instance.GetWeekStatus() == WeekStatus.During)
            {
                Debug.Log("During->End 下一周即将开始");
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
                // 开始第一天的日程。（通过fungus触发下一天）
                HandleFirstDay();
                //StartCoroutine(HandleEventArray());
                Debug.Log("Init->During Finish Event Array");
            }
            else if (CalendarManager.m_Instance.GetWeekStatus() == WeekStatus.End)
            {
                Debug.Log("End->Init 开始下一周");
                CalendarManager.m_Instance.SetWeekStatus(WeekStatus.Init);
                PracticeManager.m_Instance.GeneratePractices(); // 生成本周的练习事件
                m_CalenderParent.SetActive(true);
                EventGrid.m_Instance.ReloadCalender();

                int currentWeek = GetCurrentWeek();
                // 定位到本周第一天（的序号）
                firstWeekDay = toDay = ((int)DayOfWeek.Sunday)+ currentWeek * 7;
                // 找到本周最后一个空闲天
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
        // 找到本周最后一个空闲天，返回天序号
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
            Debug.Log("开始清除上周事务");
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
                Debug.Log("本周已经安排完成了,无法添加");
                return;
            }
            // 如果最后一个空闲天已经有日程规划
            // 则不再通过用户点击添加事项
            int w = GetCurrentWeek();
            int d = GetLastFreeDayInWeek(w);

            if (CheckDayScheduled(d))
            {
                return;
            }


            // 如果需要跳过
            // 不需要了
            //// 判断是否有预设的行动
            //// 如果有，则跳过，加入下一个最近的空闲天
            //while (CalendarManager.m_Instance.m_Calender[toDay].GetDayStatus() == DayStatus.Scheduled)
            //{
            //    //加入空项
            //    m_EventArray.Add(null);
            //    // 跳转到下一天
            //    toDay++;
            //    if (toDay >= firstWeekDay + 7)
            //    {
            //        return;
            //    }
            //}



            // 日常行动
            if (gameObject.GetComponent<PracticeEventButton>())
            {
                // 是练习行动
                Debug.Log("Add a practice event");
                m_EventArray.Add(gameObject.GetComponent<PracticeEventButton>().m_Event);
            }
            else if (gameObject.GetComponent<SocialEventButton>())
            {
                // 是外出行动
                Debug.Log("Add a social event");
                m_EventArray.Add(gameObject.GetComponent<SocialEventButton>().m_Event);
            }
            else if (gameObject.GetComponent<RestEventButton>())
            {
                // 是休息行动
                Debug.Log("Add a rest");
                m_EventArray.Add(gameObject.GetComponent<RestEventButton>().m_Event);
            }
            else if (gameObject.GetComponent<DevEventButton>())
            {
                // 是开发行动
                Debug.Log("Add a dev");
                m_EventArray.Add(gameObject.GetComponent<DevEventButton>().m_Event);
            }

        }
    }
}