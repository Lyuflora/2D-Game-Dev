using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    // 项目属性（关卡/系统/数值/剧情）
    public int[] m_GameFeatures = new int[4];
    // 重点指标
    public int[] m_PrimerFeatures;

    // 项目评价
    [SerializeField]
    private int[] m_GameRatings = new int[5];

    [Header("UI")]
    public TMP_Text m_LevelText;
    public TMP_Text m_DifficultyText;
    public TMP_Text m_DayLeftText;

    int m_Level;
    int m_DayLeft;
    int m_Difficulty;

    static public GameStatus m_Instance;
    private void Start()
    {
        ProjInfoInit();
        // todo 随机生成重点项目
    }
    private void Awake()
    {
        m_Instance = this;
    }

    public void CalculateRatings()
    {
        // todo
        int sum = 0;
        for (int i = 0; i < m_GameFeatures.Length; i++)
        {
            sum += m_GameFeatures[i];
        }
        int avg = sum / m_GameFeatures.Length;
        for (int i = 0; i < m_GameRatings.Length; i++)
        {
            m_GameRatings[i] = avg;
        }
    }
    public void UpdateProjInfo()
    {

    }

    public void ProjInfoInit()
    {
        //m_LevelText = GameObject.Find("Canvas/ProjectPanel/Date/DayText").GetComponent<TMP_Text>();
        //m_DifficultyText = GameObject.Find("Canvas/ProjectPanel/Date/MonthText").GetComponent<TMP_Text>();
        //m_DayLeftText = GameObject.Find("Canvas/ProjectPanel/Date/WeekText").GetComponent<TMP_Text>();
        
        m_Level = 1;
        m_DayLeft = 30;
        m_Difficulty = 3;

        m_LevelText.text = "1";
        m_DayLeftText.text = "1";
        m_DifficultyText.text = "9";
    }
}
