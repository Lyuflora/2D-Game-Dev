using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillDisplay : MonoBehaviour
{
    public Skill m_Skill;
    public TMP_Text m_SkillName;
    //public TMP_Text skillDescription;
    public Sprite m_BtSprite;
    public TMP_Text m_SkillPointNum;

    private PlayerStatus PS = PlayerStatus.m_Instance;
    private int m_Maximum;

    private void Start()
    {
        for(int i=0;i< PlayerStatus.m_Instance.m_Attributes.Count; i++)
        {
            var attribute = PlayerStatus.m_Instance.m_Attributes[i];
            //
        }

        m_Maximum = PlayerStatus.m_Instance.m_Attributes[1].m_CurrentPoint;
        m_Skill.SetValues(this.gameObject);
    }


    public void OnAddPointButtonClick()
    {
        PlayerStatus.m_Instance.AddInitPointOnSkill(this.gameObject);
        m_SkillPointNum.text = m_Skill.m_Points.ToString();
    }
    public void OnDropPointButtonClick()
    {
        PlayerStatus.m_Instance.DropInitPointOnSkill(this.gameObject);
        m_SkillPointNum.text = m_Skill.m_Points.ToString();
    }
}
