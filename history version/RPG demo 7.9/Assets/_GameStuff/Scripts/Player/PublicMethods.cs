using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Rest,
        Social,
        BaseDev,
        Dev,
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
        Designer = 1,
        Artist,
        Programmer,
    }

    public enum TechType
    {
        N,  //  ��ͨ
        R, //  ϡ��
    }

    public enum DevType
    {
        System = 1,
        Data, 
        Level,
        Story,
    }
