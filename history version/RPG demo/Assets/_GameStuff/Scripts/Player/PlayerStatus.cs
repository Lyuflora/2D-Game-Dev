using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 伴随游戏整个周期不被destroy
public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus m_Instance;

    [Header("Main Player Stats")]
    public string PlayerName;
    public int PlayerCoin = 0;
    public int PlayerExp = 0;
    public int PlayerLvl = 0;

    [Header("Player Attributes")]
    public List<Attribute> m_Attributes = new List<Attribute>();
      
    private void Awake()
    {
        m_Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadInitialData();
    }

    void LoadInitialData()
    {
        PlayerName = PlayerPrefs.GetString("Name");

        // 从PlayerPrefs加载初始点数分配结果
        m_Attributes[0].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Body");
        m_Attributes[1].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Willpower");
        m_Attributes[2].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Mind");
        m_Attributes[3].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Knowledge");
        m_Attributes[3].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Practical");

    }

    // 对于一个技能按钮，找到对应的属性
    Attribute FindAttrib(SkillDisplay SD)
    {
        return SD.m_Skill.GetAffectedAttrib();
    }

   

    // 加点
    public void AddInitPointOnSkill(GameObject SkillDesplayObject)
    {
        if (SkillDesplayObject)
        {
            SkillDisplay SD = SkillDesplayObject.GetComponent<SkillDisplay>();
            Attribute attrib = FindAttrib(SD);
            // 判断是否超过上限
            int usedPoint = SumPoint(attrib);
            Debug.Log(usedPoint);
            if (usedPoint < attrib.m_CurrentPoint)
            {
                SD.m_Skill.m_Points++;
            }
        }
    }

    // 减点
    public void DropInitPointOnSkill(GameObject SkillDesplayObject)
    {
        if (SkillDesplayObject)
        {
            SkillDisplay SD = SkillDesplayObject.GetComponent<SkillDisplay>();
            Attribute attrib = FindAttrib(SD);
            // 判断是否低于下限
            int usedPoint = SumPoint(attrib);
            Debug.Log(usedPoint);
            if (usedPoint > 0 && SD.m_Skill.m_Points>0)
            {
                SD.m_Skill.m_Points--;
            }
        }
    }

    // 遍历同一属性的技能，返回已加点
    int SumPoint(Attribute attrib)
    {
        int currentPoint = 0;
        for(int i = 0; i < attrib.m_Skills.Count; i++)
        {
            var skill = attrib.m_Skills[i];
            currentPoint += skill.m_Points;
        }

        return currentPoint;
    }

}
