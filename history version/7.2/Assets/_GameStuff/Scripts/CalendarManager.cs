using TMPro;
using UnityEngine;

public class CalendarManager : MonoBehaviour
{
    static public CalendarManager m_Instance;
    public GameObject m_CalendarPanel;

    [Header("Date")]
    [SerializeField]
    private TMP_Text weekText;
    int currentWeek = 1;

    public TMP_Text m_DayText;
    public TMP_Text m_MonthText;

    [SerializeField]
    private int dayNum;
    [SerializeField]
    private int monthNum;

    [SerializeField]
    private WeekStatus m_weekStatus;

    void Start()
    {
        weekText.text = "Week 1";
    }
    private void Awake()
    {
        m_Instance = this;
        DontDestroyOnLoad(gameObject);
        m_weekStatus = WeekStatus.Init;
    }

    public void SetWeekStatus(WeekStatus s)
    {
        m_weekStatus = s;
    }
    
    // Click on Confirm Button
    public void FinishPlanning()
    {
        m_CalendarPanel.SetActive(false);
        m_weekStatus = WeekStatus.During;
    }

    public void NextDay()
    {
        dayNum += 1;
        if (dayNum == 32)
        {
            dayNum = 1;
            monthNum += 1;
        }

        //UpdateDateText();

    }

    public void UpdateDateText()
    {
        m_DayText.text = dayNum.ToString();
        m_MonthText.text = monthNum.ToString();
    }

    public void GoWeek()
    {
        currentWeek++;
        weekText.text = "Week " + currentWeek.ToString();
    }
}
