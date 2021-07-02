using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseEvent : ScriptableObject
{
    public EventGenre m_Genre;    // ��������ϰ����Ϣ�����
    public EventType m_Type;
    public Sprite cg;

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
        Debug.Log("doing...");
        // ����
        Debug.Log("���Ľ�Ǯ");
        PlayerStatus.m_Instance.GainLoseCoin(dCoin);
        // ��������
        Debug.Log("��������");
        PlayerStatus.m_Instance.GainLoseStrength(dStrength);
        PlayerStatus.m_Instance.GainLoseMental(dMental);
    }
}
