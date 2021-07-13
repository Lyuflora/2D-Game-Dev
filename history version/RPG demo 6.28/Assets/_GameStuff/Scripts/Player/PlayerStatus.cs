using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������Ϸ�������ڲ���destroy

[Serializable]
class State
{
    public string PlayerName;
    public int PlayerCoin = 0;
    public int PlayerExp = 0;
    public int PlayerLvl = 0;
    
    // 5��������
    public int Strength = 0;    // ����
    public int StrengthExp = 0; //  ����EXP

    public int Mental = 0;  //  ��־
    public int MentalExp = 0;   //  ��־EXP

    public int Mind = 0;   //  ˼ά
    public int MindExp = 0;   //  ˼άEXP

    public int Knowledge = 0;   //  ����
    public int KnowledgeExp = 0;   //  ����EXP

    public int Practical = 0;   //  ʵ��
    public int PracticalExp = 0;   //  ʵ��EXP
}   

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus m_Instance;

    [SerializeField]
    [Header("Main Player Stats")]
    private State m_BasicData;

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
        m_BasicData.PlayerName = "nameeee";
            //PlayerPrefs.GetString("Name");

        // ��PlayerPrefs���س�ʼ����������
        m_Attributes[0].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Body");
        m_Attributes[1].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Willpower");
        m_Attributes[2].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Mind");
        m_Attributes[3].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Knowledge");
        m_Attributes[3].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Practical");

    }

    // ����һ�����ܰ�ť���ҵ���Ӧ������
    Attribute FindAttrib(SkillDisplay SD)
    {
        return SD.m_Skill.GetAffectedAttrib();
    }

   

    // �ӵ�
    public void AddInitPointOnSkill(GameObject SkillDesplayObject)
    {
        if (SkillDesplayObject)
        {
            SkillDisplay SD = SkillDesplayObject.GetComponent<SkillDisplay>();
            Attribute attrib = FindAttrib(SD);
            // �ж��Ƿ񳬹�����
            int usedPoint = SumPoint(attrib);
            Debug.Log(usedPoint);
            if (usedPoint < attrib.m_CurrentPoint&& SD.m_Skill.m_Points < attrib.m_CurrentPoint)
            {
                SD.m_Skill.m_Points++;
            }
        }
    }

    // ����
    public void DropInitPointOnSkill(GameObject SkillDesplayObject)
    {
        if (SkillDesplayObject)
        {
            SkillDisplay SD = SkillDesplayObject.GetComponent<SkillDisplay>();
            Attribute attrib = FindAttrib(SD);
            // �ж��Ƿ��������
            int usedPoint = SumPoint(attrib);
            Debug.Log(usedPoint);
            if (usedPoint > 0 && SD.m_Skill.m_Points>0)
            {
                SD.m_Skill.m_Points--;
            }
        }
    }

    // ����ͬһ���Եļ��ܣ������Ѽӵ�
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

    // ���Ļ��ý�Ǯ
    public void GainLoseCoin(int coinNum)
    {
        m_BasicData.PlayerCoin += coinNum;
    }

    // ���Ļ������ԣ�����or��������
    public void GainLoseStrength(int strengthNum)
    {
        m_BasicData.Strength += strengthNum;
    }

    public void GainLoseMental(int mentalNum)
    {
        m_BasicData.Mental += mentalNum;
    }
}
