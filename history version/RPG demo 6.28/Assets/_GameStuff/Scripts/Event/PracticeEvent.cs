using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "gmds/Event/Create Practice Event")]
public class PracticeEvent : BaseEvent
{
    [SerializeField]
    private int difficulty; // ��ϰ��Ŀ�Ѷȣ������exp��أ�
    [SerializeField]
    private PlayerMode mode;    // ���������

    // ����exp
    // ������Ϊ�����֡����ܡ����ջ�

    private void Awake()
    {
        base.Awake();
        m_Genre = EventGenre.Practice;
    }
    public override void HandleEvent()
    {
        base.HandleEvent();

        // ��ʾCG����

        // �����ջ�
        Debug.Log("�������...");
    }
}
