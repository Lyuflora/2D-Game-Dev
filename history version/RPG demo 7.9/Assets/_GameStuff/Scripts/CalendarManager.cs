using TMPro;
using UnityEngine;

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
    private int dayNum;
    [SerializeField]
    private int monthNum;

    [SerializeField]
    private WeekStatus m_weekStatus;

    public GameObject CalenderParent;

    //[SerializeField]
    //private GameObject[] m_EventArray;  // ÊÂ¼þ¿â

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
    
  
    public void FinishPlanning()
    {

    }

    public void NextDay()
    {
        dayNum += 1;
        if (dayNum == 32)
        {
            dayNum = 1;
            monthNum += 1;
        }
        UpdateDateText();
    }

    public void UpdateDateText()
    {
        m_DayText = GameObject.Find("Canvas/Calendar/Date/DayText").GetComponent<TMP_Text>();
        m_MonthText = GameObject.Find("Canvas/Calendar/Date/MonthText").GetComponent<TMP_Text>();
        m_WeekText = GameObject.Find("Canvas/Calendar/Date/WeekText").GetComponent<TMP_Text>();
        m_DayText.text = dayNum.ToString();
        //m_MonthText.text = monthNum.ToString();
        m_WeekText.text = "Week "+currentWeek.ToString();
    }

    public void NextWeek()
    {
        currentWeek++;
        m_WeekText.text = "Week " + currentWeek.ToString();
        UpdateDateText();
    }
}
