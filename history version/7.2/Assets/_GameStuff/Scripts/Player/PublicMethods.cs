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
    }

// ��������
    public enum EventType
    {
        Bar=0,
        Gym,
        Exhibition,
        Practice,
        Rest,
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
