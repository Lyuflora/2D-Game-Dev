using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public TMP_Text[] m_AttribPointsText;

    [Serializable]
    public struct Skill
    {
        public string name;
        public int points;
    }

    [Serializable]
    public struct Attribute
    {
        // 属性名，该属性下的技能点数，下属细分技能（4项）
        public string name;
        public int points;
        public Skill[] skills;
    }

    private void Start()
    {
        m_AttribPointsText[0].text = PlayerPrefs.GetInt("Attribute_Body").ToString();
        m_AttribPointsText[1].text = PlayerPrefs.GetInt("Attribute_Willpower").ToString();
        m_AttribPointsText[2].text = PlayerPrefs.GetInt("Attribute_Mind").ToString();
        m_AttribPointsText[3].text = PlayerPrefs.GetInt("Attribute_Knowledge").ToString();
        m_AttribPointsText[4].text = PlayerPrefs.GetInt("Attribute_Practical").ToString();
    }


    void OnSkillPointAddButtonClick(int skillID, int num)
    {

    }

    void OnSkillPointDropButtonClick(int skillID, int num)
    {

    }
}
