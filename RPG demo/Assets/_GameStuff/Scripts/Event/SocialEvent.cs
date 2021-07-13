using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gmds
{
    [CreateAssetMenu(menuName = "gmds/Event/Create Social Event")]
    public class SocialEvent : DailyEvent
    {

        private void Awake()
        {
            base.Awake();
            m_Genre = EventGenre.Social;
        }

        void UpdateFriendableNPCs()
        {
            // todo
            //去掉已经是好友的NPC
        }

        void GenerateFriends()
        {
            // Display Friends
            // Generate random integer
            // get result
            // 随机从池中抽一个好友 概率0.5
            int friendId = 0;
            friendId = Random.Range(0, 3); // [0, 5)
            Debug.Log("尝试结交好友" + friendId);
            NPC npc = FriendManager.m_Instance.GetNPCByIndex(friendId);

            float success = Random.Range(-1f, 1f);
            if (success > 0)
            {
                Debug.Log("添加好友成功");
                FriendManager.m_Instance.AddFriend(npc);
                Debug.Log("与" + npc.name + "成为好友");
            }
            else
            {
                Debug.Log("添加失败");
                Debug.Log(npc.name + "拒绝了你的好友邀请");
            }

        }

        public override void HandleEvent()
        {
            base.HandleEvent();
            Debug.LogFormat("去{0}", m_Type.ToString());

            // 好友收获
            GenerateFriends();
            Debug.Log("结交朋友结束...");
        }
    }
}