using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������Ϸ�������ڲ���destroy
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
            if (usedPoint < attrib.m_CurrentPoint)
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

}
