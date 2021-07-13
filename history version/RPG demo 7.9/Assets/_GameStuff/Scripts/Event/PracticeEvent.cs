using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "gmds/Event/Create Practice Event")]
public class PracticeEvent : DailyEvent
{
    [SerializeField]
    private int difficulty; // 练习项目难度（与积累exp相关）
    [SerializeField]
    private PlayerMode mode;    // 云玩或真玩

    private int level;  //  氪金？

    [SerializeField]
    private int tech_R_No = 0;  // 普通技能序号
    [SerializeField]
    private int tech_SR_No = 0; // 稀有技能序号
    [SerializeField]
    private float success_R = 0.5f;
    [SerializeField]
    private float success_SR = 0.1f;

    // 积累exp
    // 技术（为了区分“技能”）收获

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
            Debug.Log("学会普通技能");
            LearnTech(tech_R_No);
        }
        else if (result == 1)
        {
            Debug.Log("学会稀有技能");
            LearnTech(tech_SR_No);
        }

    }

    void LearnTech(int techId)
    {
        // todo
        Debug.Log("学习技术" + techId);
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
        // 显示CG画面

        // 习得技术
        GenerateTech();
        Debug.Log("习得技能结束...");
    }
}
