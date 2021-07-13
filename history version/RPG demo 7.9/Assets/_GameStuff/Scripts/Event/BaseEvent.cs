using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseEvent : ScriptableObject
{
    public EventGenre m_Genre;    // 可能是练习，休息，外出
    public EventType m_Type;
    public Sprite cg;
    public Texture2D m_ButtonTexture;

    // public Attribute m_AffectAttrib;
    public float m_Possibility;
    public bool m_isSuccess;

    [Header("消耗")]
    [SerializeField]
    protected int dCoin;  // 金钱
    [SerializeField]
    protected int dStrength;  // 精神力
    [SerializeField]
    protected int dMental;    // 体力

    [Header("属性收益")]
    [SerializeField]
    protected int dStrengthExp;  // 精神力EXP
    [SerializeField]
    protected int dMentalExp;    // 体力EXP

    virtual protected void Awake()
    {

    }
    virtual public void HandleEvent()
    {
        EventManager.m_Instance.DisplayEventCG(cg);
        PanelManager.m_Instance.OpenPanel(PanelManager.m_Instance.m_PopupPanel);
        Debug.Log("doing...");
        // 消耗
        PlayerStatus.m_Instance.GainLoseCoin(dCoin);
        // 收益属性
        PlayerStatus.m_Instance.GainLoseStrength(dStrength);
        PlayerStatus.m_Instance.GainLoseMental(dMental);

        Debug.LogFormat("coin: {0}\nstrength: {0}\nmental: {0}\n", dCoin, dStrength, dMental);
    }
}
