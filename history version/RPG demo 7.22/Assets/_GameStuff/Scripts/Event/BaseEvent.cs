using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds
{
    public class BaseEvent : ScriptableObject
    {
        public EventGenre m_Genre;    // ��������ϰ����Ϣ�����

        public Sprite cg;
        public Texture2D m_ButtonTexture;

        // public Attribute m_AffectAttrib;
        public float m_Possibility;
        public bool m_isSuccess;

        [Header("����")]
        [SerializeField]
        public int dCoin;  // ��Ǯ
        [SerializeField]
        public int dStrength;  // ������
        [SerializeField]
        public int dMental;    // ����

        [Header("��������")]
        [SerializeField]
        public int dStrengthExp;  // ������EXP
        [SerializeField]
        public int dMentalExp;    // ����EXP

        virtual protected void Awake()
        {

        }
        virtual public void HandleEvent()
        {
            Debug.Log("Start Today's event...");

            // ��ʾCG
            EventManager.m_Instance.DisplayEventCG(cg);
            // ������Դ
            PlayerStatus.m_Instance.GainLoseCoin(dCoin);
            // ��������
            PlayerStatus.m_Instance.GainLoseStrength(dStrength);
            PlayerStatus.m_Instance.GainLoseMental(dMental);

            Debug.LogFormat("coin: {0}\nstrength: {0}\nmental: {0}\n", dCoin, dStrength, dMental);
        }
    }
}