using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds
{
    public class TechProfile : MonoBehaviour
    {
        //[SerializeField] private Tech m_Tech;
        public TMP_Text m_NameText;
        public TMP_Text m_TypeText; //稀有度
        public TMP_Text m_LevelText;    // 难度
        public Image m_Image;


        public void RefreshTech(Tech tech)
        {
            m_NameText.text = tech.name;
            m_LevelText.text = tech.level.ToString();
            m_Image.sprite = tech.icon;
            if (tech.type == TechType.N)
            {
                m_TypeText.text = "N";
            }
            else if (tech.type == TechType.R)
            {
                m_TypeText.text = "R";
            }

        }

    }
}
