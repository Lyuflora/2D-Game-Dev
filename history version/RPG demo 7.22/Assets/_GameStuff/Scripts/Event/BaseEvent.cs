using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds
{
    public class BaseEvent : ScriptableObject
    {
        public EventGenre m_Genre;    // 可能是练习，休息，外出

        public Sprite cg;
        public Texture2D m_ButtonTexture;

        // public Attribute m_AffectAttrib;
        public float m_Possibility;
        public bool m_isSuccess;

        [Header("消耗")]
        [SerializeField]
        public int dCoin;  // 金钱
        [SerializeField]
        public int dStrength;  // 精神力
        [SerializeField]
        public int dMental;    // 体力

        [Header("属性收益")]
        [SerializeField]
        public int dStrengthExp;  // 精神力EXP
        [SerializeField]
        public int dMentalExp;    // 体力EXP

        virtual protected void Awake()
        {

        }
        virtual public void HandleEvent()
        {
            Debug.Log("Start Today's event...");

            // 显示CG
            EventManager.m_Instance.DisplayEventCG(cg);
            // 消耗资源
            PlayerStatus.m_Instance.GainLoseCoin(dCoin);
            // 收益属性
            PlayerStatus.m_Instance.GainLoseStrength(dStrength);
            PlayerStatus.m_Instance.GainLoseMental(dMental);

            Debug.LogFormat("coin: {0}\nstrength: {0}\nmental: {0}\n", dCoin, dStrength, dMental);
        }
    }
}