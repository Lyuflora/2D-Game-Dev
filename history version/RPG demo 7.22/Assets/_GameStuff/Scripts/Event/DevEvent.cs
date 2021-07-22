using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds{

[CreateAssetMenu(menuName = "gmds/Event/Create Dev Event")]
public class DevEvent : BaseEvent
{
    public DevType m_type;
    // ���۵��������鴢��
    public Image icon;
    public int m_Progress;

    public override void HandleEvent()
    {
        base.HandleEvent();
            Debug.Log(m_type.ToString());
            Debug.Log("������Ŀ�ĵ�" + (int)m_type + "���Եõ�����");
        // ����
        // ��Ŀ���ԣ��ؿ�/ϵͳ/��ֵ/���飩
        GameStatus.m_Instance.m_GameFeatures[((int)m_type)]++;
        Debug.Log("��������+1");
        
    }
    }
}