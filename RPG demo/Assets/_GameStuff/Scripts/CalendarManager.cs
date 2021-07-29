using TMPro;
using UnityEngine;
using static Gmds.Day;

namespace Gmds
{
    public class CalendarManager : MonoBehaviour
    {
        static public CalendarManager m_Instance;
        public GameObject m_CalendarPanel;

        [Header("Date")]
        [SerializeField]
        private TMP_Text m_WeekText;
        int currentWeek = 1;

        public TMP_Text m_DayText;
        public TMP_Text m_MonthText;


        [SerializeField]
        public int m_WeekNum;
        [SerializeField]
        private int m_DayNum;
        [SerializeField]
        private int m_MonthNum;

        [SerializeField]
        private WeekStatus m_weekStatus;

        [Header("Schedule")]
        public Day[] m_Calender;

        public GameObject CalenderParent;

        public int m_CurrentDay;

        [Header("Flowchart")]
        public Fungus.Flowchart m_EventFlowchart;
        public string m_StartBlockName = "Start";
        public string m_DefaultBlockName = "DefaultBlock";

        //[SerializeField]
        //private GameObject[] m_EventArray;  // 事件库

        void Start()
        {
            CalenderInit();
        }
        private void Awake()
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
            SetWeekStatus(WeekStatus.Init);
        }

        public void CalenderInit()
        {
            m_DayText = GameObject.Find("Canvas/Calendar/Date/DayText").GetComponent<TMP_Text>();
            m_MonthText = GameObject.Find("Canvas/Calendar/Date/MonthText").GetComponent<TMP_Text>();
            m_WeekText = GameObject.Find("Canvas/Calendar/Date/WeekText").GetComponent<TMP_Text>();
            m_WeekText.text = "Week 1";
            m_WeekNum = 1;
            m_DayNum = 1;
            m_MonthNum = 9;
            m_DayText.text = "1";
            m_MonthText.text = "9";
        }

        public WeekStatus GetWeekStatus()
        {
            return m_weekStatus;
        }

        public void SetWeekStatus(WeekStatus s)
        {
            m_weekStatus = s;
        }

        public void NextDate()
        {
            // Update date text
            m_DayNum += 1;
            Debug.Log("Update Day: " + m_DayNum);
            if (m_DayNum == 31)
            {
                m_DayNum = 1;
                m_MonthNum += 1;
            }
            if (m_DayNum % 7 == 1)
            {
                m_WeekNum++;
            }
            UpdateDateText();
        }
        public int GetCurrentDayId()
        {
            m_CurrentDay = m_DayNum + (m_MonthNum - 9) * 30-1 ;
            Debug.Log("Get Current Day:" + m_CurrentDay);
            return m_CurrentDay;
        }

        public void StartDialogue(int dayId)
        {
            // 根据日程，触发对话
            Debug.Log("Day " + m_DayNum + " "+ m_MonthNum + " "+dayId);
            string dialog= m_DefaultBlockName;
            var today = m_Calender[dayId];
            // 当天有预置事件
            // 执行Calendar数组中当天的Dialogue成员
            // 可自定义对话Block
            // 最后一行为"CallHandleDay.."
            if (today.GetDayStatus() == DayStatus.Scheduled)
            {
                if (today.m_Dialogues.Length>0)
                {
                    if (today.m_Dialogues[0].m_BlockName != "")
                    {
                        dialog = today.m_Dialogues[0].m_BlockName;
                    }
                    else
                    {
                        dialog = m_DefaultBlockName;
                    }
                }
                          
            }
            else
            {             
                // 当天无预置事件，执行玩家自己添加的事件
                // 通过代码直接调用日程对应的Dialogue
                // 内容固定
                if (EventManager.m_Instance.m_EventArray[dayId])
                {
                    dialog = EventManager.m_Instance.m_EventArray[dayId].m_DialogBlock;
                }
                else
                {
                    dialog = m_DefaultBlockName;
                }
            }
            m_EventFlowchart.ExecuteBlock(dialog);
            //    //EventFlowchart.SetBooleanVariable("Show", true);   // 设置变量
        }

        public void UpdateDateText()
        {
            m_DayText = GameObject.Find("Canvas/Calendar/Date/DayText").GetComponent<TMP_Text>();
            m_MonthText = GameObject.Find("Canvas/Calendar/Date/MonthText").GetComponent<TMP_Text>();
            m_WeekText = GameObject.Find("Canvas/Calendar/Date/WeekText").GetComponent<TMP_Text>();
            m_DayText.text = m_DayNum.ToString();
            //m_MonthText.text = monthNum.ToString();
            m_WeekText.text = "Week " + currentWeek.ToString();
        }

        public void NextWeek()
        {
            currentWeek++;
            m_WeekText.text = "Week " + currentWeek.ToString();
            UpdateDateText();
        }

        // 固定的触发对话、事件

    }
}