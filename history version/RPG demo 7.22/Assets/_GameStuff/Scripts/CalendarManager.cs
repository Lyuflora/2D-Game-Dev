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

        //[SerializeField]
        //private GameObject[] m_EventArray;  // ?¼???

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

        public void NextDay()
        {
            // Update date text
            CalendarManager.m_Instance.m_CurrentDay++;
            m_DayNum += 1;
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

            // ?????Ի?
            StartDialogue();
        }
        public int GetCurrentDayId()
        {
            m_CurrentDay = m_DayNum + (m_MonthNum - 9) * 30 - 1;
            return m_CurrentDay;
        }

        public void StartDialogue()
        {
            // ????Ԥ???ճ?
            // ?????????й̶??¼????򴥷?
            // ????û?У???
            m_CurrentDay = GetCurrentDayId();
            int dayId = m_CurrentDay;
            Debug.Log("Day " + m_DayNum + " "+ m_MonthNum + " "+dayId);
            var today = m_Calender[dayId];
            if (today.GetDayStatus() == DayStatus.Scheduled)
            {
                string dialog = today.m_Dialogues[0].m_BlockName;
                m_EventFlowchart.ExecuteBlock(dialog);
            }
            else
            {
                return;
            }
            //    dialogue.m_Dialogue.ExecuteBlock(m_StartBlockName);
            //    //EventFlowchart.SetBooleanVariable("Show", true);   // ???ñ???
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

        // ?̶??Ĵ????Ի????¼?

    }
}