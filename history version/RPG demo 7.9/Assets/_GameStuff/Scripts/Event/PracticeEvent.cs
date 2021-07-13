using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "gmds/Event/Create Practice Event")]
public class PracticeEvent : DailyEvent
{
    [SerializeField]
    private int difficulty; // ��ϰ��Ŀ�Ѷȣ������exp��أ�
    [SerializeField]
    private PlayerMode mode;    // ���������

    private int level;  //  봽�

    [SerializeField]
    private int tech_R_No = 0;  // ��ͨ�������
    [SerializeField]
    private int tech_SR_No = 0; // ϡ�м������
    [SerializeField]
    private float success_R = 0.5f;
    [SerializeField]
    private float success_SR = 0.1f;

    // ����exp
    // ������Ϊ�����֡����ܡ����ջ�

    private void Awake()
    {
        base.Awake();
        m_Genre = EventGenre.Practice;
    }

    public void GenerateTech()
    {
        float[] probs = new float[3];
        probs[0] = success_R;
        probs[1] = success_SR;
        probs[2] = 1- success_R-success_SR;

        float result = Choose(probs);
        if (result == 0)
        {
            Debug.Log("ѧ����ͨ����");
            LearnTech(tech_R_No);
        }
        else if (result == 1)
        {
            Debug.Log("ѧ��ϡ�м���");
            LearnTech(tech_SR_No);
        }

    }

    void LearnTech(int techId)
    {
        // todo
        Debug.Log("ѧϰ����" + techId);
    }

    int Choose(float[] probs)
    {
        float total = 0;
        foreach (float elem in probs)
        {
            total += elem;
        }
        float randomPoint = Random.value * total;
        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }

    public override void HandleEvent()
    {
        base.HandleEvent();
        // ��ʾCG����

        // ϰ�ü���
        GenerateTech();
        Debug.Log("ϰ�ü��ܽ���...");
    }
}
