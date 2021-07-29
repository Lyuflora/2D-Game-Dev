using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gmds { 

//[Serializable]
//public class PlayerAttributes
//{
//    public Attributes attributes;
//    public int points;

//    public PlayerAttributes(Attributes attributes, int points)
//    {
//        this.attributes = attributes;
//        this.points = points;
//    }
//}
    public enum CharacterType
    {
        Designer = 0,
        Artist,
        Programmer,
    }
    
    public enum AttributeType
    {
        Body = 0,
        Willpower,
        Mind,
        Knowledge,
        Practical
    }

    public enum SkillGenre
    {
        Genric,
        Expertise,
    }
    public enum SkillType
    {
        Research = 0,
        Communication,
        Proficiency,
        Deadline,
        Cheeky,
        Firmness,
        Decisiveness,
        Discipline,
        // רҵ����
        // ���
        DesignSystem,
        DesignData,
        DesignLevel,
        DesignStory,
        // ����
        Art2d,
        Art3d,
        ArtUi,
        ArtAnim,
        // ����
        CodeLogic,
        CodeAi,
        CodeUi,
        CodeGraphic,
    }

// һ������
    public enum EventGenre
    {
        Practice = 0,
        Dev,
        Social,
        Rest,
        BaseDev,
    }

// ��������
    public enum EventType
    {
        Bar=0,
        Gym,
        Exhibition,
        Practice,
        Rest,
        Research,
        Trainning,
        Communicate,
        Deadline,
        Data,
        System,
        Level,
        Story,
        None,
    }

    public enum PlayerMode
    {
        Cloud = 0,
        NotCloud,
    }

    public enum WeekStatus
    {
        Init = 0,
        During,
        End,
    }
    
    [Serializable]
    public struct NpcAttribute
    {
        public int Body;
        public int Willpower;
        public int Mind;
        public int Knowledge;
        public int Practical;
    }

    public enum NPCJob
    {
        ���ʦ = 0,
        ������,
        ����Ա,
    }

    public enum TechType
    {
        N,  //  ��ͨ
        R, //  ϡ��
    }

    public enum DevType
    {
        System = 0,
        Data, 
        Level,
        Story,
    }

    // �����NPC�Ŀ����׶�
    public enum DevStage
    {
        ���� = 0,  //  ����
        ԭ��,  //  ԭ��
        ����,  //  ����
        ����,  //  ����
    }

    public enum DayStatus
    {
        Scheduled,
        Not,
    }

    [Serializable]
    public class Day
{
    int day;
    int month;

    [SerializeField] private DayStatus status;

    [Header("Dialogue")]
    public DialogueDescriptor[] m_Dialogues;

    public DayStatus GetDayStatus()
    {
        return status;
    }
    public Day(int d, int m)
    {
        day = d;
        month = m;
    }

    public int GetDay()
    {
        return day;
    }

    public int GetMonth()
    {
        return month;
    }
    }
}
