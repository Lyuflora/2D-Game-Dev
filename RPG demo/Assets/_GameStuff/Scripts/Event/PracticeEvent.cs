using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gmds
{
    [CreateAssetMenu(menuName = "gmds/Event/Create Practice Event")]
    public class PracticeEvent : DailyEvent
    {
        [SerializeField]
        private int difficulty; // 练习项目难度（与积累exp相关）
        [SerializeField]
        private PlayerMode mode;    // 云玩或真玩

        private int level;  //  氪金？

        [SerializeField]
        private int tech_R_No = 0;  // 稀有技能序号
        [SerializeField]
        private int tech_N_No = 0; // 普通技能序号
        [SerializeField]
        private float success_N = 1.0f;
        [SerializeField]
        private float success_R = (float)(1.0f/6.0f);

        // 积累exp
        // 技术（为了区分“技能”）收获
        // 进度储存在PracticeManager的Exp数组中，通过PracticeId访问
        int PracticeId;

        private void Awake()
        {
            base.Awake();
            m_Genre = EventGenre.Practice;
        }

        public void GenerateTech(float prop_N,float prop_R)
        {
            float[] probsArray = new float[3];
            probsArray[0] = 0;
            probsArray[1] = prop_R;
            probsArray[2] = 1 - 0 - prop_R;

            float result = Choose(probsArray);
            PracticeManager.m_Instance.LearnTech(tech_R_No);    // 必学会
            if (result == 1)
            {
                Debug.Log("学会稀有技能");
                PracticeManager.m_Instance.LearnTech(tech_N_No);
            }
            else
            {
                Debug.Log("只学会普通技能");
                    
            }

        }



        // 独立事件
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

        int JudgePractice()
        {
            float prop_0 = 9f / 16f;
            float prop_1 = 23f / 16f;
            float prop_2 = 23f / 16f;
            float prop_3 = 9f / 16f;
            float[] probsArray = new float[4];
            probsArray[0] = prop_0;
            probsArray[1] = prop_1;
            probsArray[2] = prop_2;
            probsArray[3] = prop_3;

            int result = Choose(probsArray);
            PracticeManager.m_Instance.LearnTech(tech_R_No);    // 必学会
            if (result == 1)
            {
                Debug.Log("+1");
                
            }
            else if (result == 2)
            {
                Debug.Log("+2");

            }
            else if (result == 3)
            {
                Debug.Log("+3");

            }
                return result;

        }

        public override void HandleEvent()
        {
            base.HandleEvent();            

            // 判断进度
            // 氪金的话，可以自由花钱加属性
            if (PracticeManager.m_Instance.m_Exp[PracticeId] >= 10)
            {
                // 习得技术, 判断学习的技术是普通技能/稀有技能
                GenerateTech(success_N, success_R);
                Debug.Log("习得技能结束...");
                PracticeManager.m_Instance.m_Exp[PracticeId] -= 10;
            }
            else
            {
                int result = JudgePractice();
                PracticeManager.m_Instance.m_Exp[PracticeId]+=result;
            }

            
        }
    }

}