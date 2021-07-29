using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    // 项目属性（关卡/系统/数值/剧情）
    public int[] m_GameFeatures;
    // 重点指标
    public int[] m_PrimerFeatures;

    // 项目评价（美学/机制/口碑/商业/技术）
    [SerializeField]
    private int[] m_GameRatings = new int[5];

    [Header("UI")]
    [Header("Base Info")]
    public TMP_Text m_LevelText;
    public TMP_Text m_DifficultyText;
    public TMP_Text m_DayLeftText;

    public int m_Level = 1; // 体量
    public int m_DayLeft = 20;  // 剩余天数
    public int m_Difficulty = 3;    // 难度

    [Header("Ratings")]
    //public TMP_Text m_ArtText;
    //public TMP_Text m_BusText;
    //public TMP_Text m_MechanicText;
    //public TMP_Text m_ReputationText;
    //public TMP_Text m_TechText;

    public RatingSlider[] m_RatingSlider;

    static public GameStatus m_Instance;
    private void Start()
    {
        // ProjInfoInit();
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
        m_LevelText.text = m_Level.ToString();
        m_DayLeftText.text = m_DayLeft.ToString();
        m_DifficultyText.text = m_Difficulty.ToString();
    }

    public void UpdateProjRatings()
    {
        CalculateRatings();
        
        for(int i = 0; i < 5; i++)
        {
            m_RatingSlider[i].SetRating(m_GameRatings[i]);
            Debug.Log("Rating " + i + " = " + m_GameRatings[i]);
        }
        //m_ArtText.text = m_GameRatings[0].ToString();
        //m_BusText.text = m_GameRatings[1].ToString();
        //m_MechanicText.text = m_GameRatings[2].ToString();
        //m_ReputationText.text = m_GameRatings[3].ToString();
        //m_TechText.text = m_GameRatings[4].ToString();
    }

    public void ProjInfoInit()
    { 
        m_Level = 1;
        m_DayLeft = 20;
        m_Difficulty = 3;

        UpdateProjInfo();
        UpdateProjRatings();
    }
}
