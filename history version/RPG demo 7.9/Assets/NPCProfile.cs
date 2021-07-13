using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCProfile : MonoBehaviour
{
    public TMP_Text m_NameText;
    public TMP_Text m_AgeText;
    public Image m_Image;

    public void RefreshProfile(NPC npc)
    {
        m_NameText.text = npc.name;
        m_AgeText.text = npc.age.ToString();
        m_Image.sprite = npc.img;
    }
}
