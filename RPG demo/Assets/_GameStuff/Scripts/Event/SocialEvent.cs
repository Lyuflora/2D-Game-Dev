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
            //ȥ���Ѿ��Ǻ��ѵ�NPC
        }

        void GenerateFriends()
        {
            // Display Friends
            // Generate random integer
            // get result
            // ����ӳ��г�һ������ ����0.5
            int friendId = 0;
            friendId = Random.Range(0, 3); // [0, 5)
            Debug.Log("���Խύ����" + friendId);
            NPC npc = FriendManager.m_Instance.GetNPCByIndex(friendId);

            float success = Random.Range(-1f, 1f);
            if (success > 0)
            {
                Debug.Log("��Ӻ��ѳɹ�");
                FriendManager.m_Instance.AddFriend(npc);
                Debug.Log("��" + npc.name + "��Ϊ����");
            }
            else
            {
                Debug.Log("���ʧ��");
                Debug.Log(npc.name + "�ܾ�����ĺ�������");
            }

        }

        public override void HandleEvent()
        {
            base.HandleEvent();
            Debug.LogFormat("ȥ{0}", m_Type.ToString());

            // �����ջ�
            GenerateFriends();
            Debug.Log("�ύ���ѽ���...");
        }
    }
}