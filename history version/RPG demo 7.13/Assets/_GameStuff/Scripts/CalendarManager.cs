using TMPro;
using UnityEngine;
using static Gmds.Date;

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
        private int m_DayNum;
        [SerializeField]
        private int m_MonthNum;

        [SerializeField]
        private WeekStatus m_weekStatus;

        [Header("Schedule")]
        public Day[] m_Calender;

        public GameObject CalenderParent;

        [Header("Flowchart")]
        public Fungus.Flowchart m_EventFlowchart;
        public string m_StartBlockName = "Start";

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

        public void NextDay()
        {
            m_DayNum += 1;
            if (m_DayNum == 31)
            {
                m_DayNum = 1;
                m_MonthNum += 1;
            }
            UpdateDateText();
            // 触发对话
            StartDialogue(m_DayNum, m_MonthNum);
        }

        public void StartDialogue(int day, int month)
        {
            // 根据预设日程
            // 如果当天有固定事件，则触发
            // 如果没有，过
            int dayId = day + (month - 9) * 30-1;
            Debug.Log("Day " + day+" "+month+" "+dayId);
            var today = m_Calender[dayId];
            if (today.GetDayStatus() == DayStatus.Scheduled)
            {
                string dialog = today.m_Dialogues[0].m_BlockName;
                m_EventFlowchart.ExecuteBlock(dialog);
            }
            //    dialogue.m_Dialogue.ExecuteBlock(m_StartBlockName);
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