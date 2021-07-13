using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseEvent : ScriptableObject
{
    public EventGenre m_Genre;    // ��������ϰ����Ϣ�����
    public EventType m_Type;
    public Sprite cg;
    public Texture2D m_ButtonTexture;

    // public Attribute m_AffectAttrib;
    public float m_Possibility;
    public bool m_isSuccess;

    [Header("����")]
    [SerializeField]
    protected int dCoin;  // ��Ǯ
    [SerializeField]
    protected int dStrength;  // ������
    [SerializeField]
    protected int dMental;    // ����

    [Header("��������")]
    [SerializeField]
    protected int dStrengthExp;  // ������EXP
    [SerializeField]
    protected int dMentalExp;    // ����EXP

    virtual protected void Awake()
    {

    }
    virtual public void HandleEvent()
    {
        EventManager.m_Instance.DisplayEventCG(cg);
        PanelManager.m_Instance.OpenPanel(PanelManager.m_Instance.m_PopupPanel);
        Debug.Log("doing...");
        // ����
        PlayerStatus.m_Instance.GainLoseCoin(dCoin);
        // ��������
        PlayerStatus.m_Instance.GainLoseStrength(dStrength);
        PlayerStatus.m_Instance.GainLoseMental(dMental);

        Debug.LogFormat("coin: {0}\nstrength: {0}\nmental: {0}\n", dCoin, dStrength, dMental);
    }
}
