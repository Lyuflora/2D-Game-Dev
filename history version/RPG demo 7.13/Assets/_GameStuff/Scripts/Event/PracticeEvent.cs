using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gmds
{
    [CreateAssetMenu(menuName = "gmds/Event/Create Practice Event")]
    public class PracticeEvent : DailyEvent
    {
        [SerializeField]
        private int difficulty; // ��ϰ��Ŀ�Ѷȣ������exp��أ�
        [SerializeField]
        private PlayerMode mode;    // ���������

        private int level;  //  봽�

        [SerializeField]
        private int tech_R_No = 0;  // ϡ�м������
        [SerializeField]
        private int tech_N_No = 0; // ��ͨ�������
        [SerializeField]
        private float success_N = 0.5f;
        [SerializeField]
        private float success_R = 0.1f;

        // ����exp
        // ������Ϊ�����֡����ܡ����ջ�

        private void Awake()
        {
            base.Awake();
            m_Genre = EventGenre.Practice;
        }

        public void GenerateTech(float prop_N,float prop_R)
        {
            float[] probsArray = new float[3];
            probsArray[0] = prop_N;
            probsArray[1] = prop_R;
            probsArray[2] = 1 - prop_N - prop_R;

            float result = Choose(probsArray);
            if (result == 0)
            {
                Debug.Log("ѧ����ͨ����");
                PracticeManager.m_Instance.LearnTech(tech_R_No);
            }
            else if (result == 1)
            {
                Debug.Log("ѧ��ϡ�м���");
                PracticeManager.m_Instance.LearnTech(tech_N_No);
            }

        }



        // �����¼�
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

            // ϰ�ü���, �ж�ѧϰ�ļ����ǿ�/��ͨ����/ϡ�м���
            GenerateTech(success_N, success_R);
            Debug.Log("ϰ�ü��ܽ���...");
        }
    }

}