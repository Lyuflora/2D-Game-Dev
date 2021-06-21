using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="gmds/Player/Create Skill")]
public class Skill : ScriptableObject
{
    public string m_Description;
    public SkillType m_Type;
    public SkillGenre m_Genre;
    public Sprite m_SkillTexture;
    public int m_Points;
    public Attribute m_AffectedAttrib;

    public SkillType GetSkillType()
    {
        return m_Type;
    }

    public Attribute GetAffectedAttrib()
    {
        return m_AffectedAttrib;
    }

    public void SetValues(GameObject SkillDesplayObject)
    {
        if (SkillDesplayObject)
        {
            SkillDisplay SD = SkillDesplayObject.GetComponent<SkillDisplay>();
            SD.m_SkillName.text = name;
            //if (SD.skillDescription)
            //    SD.skillDescription.text = description;
            if (SD.m_BtSprite)
            {
                var button = SD.GetComponent<Button>();
                button.image.sprite = m_SkillTexture;
            }
            if (SD.m_SkillPointNum)
                SD.m_SkillPointNum.text = m_Points.ToString();

        }
    }



}
