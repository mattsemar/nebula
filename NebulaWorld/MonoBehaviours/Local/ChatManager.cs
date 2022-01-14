using CommonAPI.Systems;
using NebulaModel;
using NebulaModel.Logger;
using NebulaModel.Packets.Players;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NebulaWorld.MonoBehaviours.Local
{
    public class ChatManager : MonoBehaviour
    {
        private const long NOTIFICATION_DURATION_TICKS = TimeSpan.TicksPerMinute * 1;

        private int _attemptsToGetLocationCountDown = 25;
        private bool _sentLocation;
        private Queue<ChatWindow.QueuedMessage> _queuedMessages = new Queue<ChatWindow.QueuedMessage>(5);
        private long _notifierEndTime;
        private ChatWindow _chatWindow;
        public static ChatManager instance;

        private void Awake()
        {
            instance = this;
            GameObject prefab = InGameChatAssetLoader.AssetBundle.LoadAsset<GameObject>("Assets/Prefab/ChatV2.prefab");
            var uiGameInventory = UIRoot.instance.uiGame.inventory;
            var chatGo = Instantiate(prefab, uiGameInventory.transform.parent, false);
            _chatWindow = chatGo.transform.GetComponentInChildren<ChatWindow>();
            _chatWindow.userName = GetUserName();
        }

        void Update()
        {
            if (CustomKeyBindSystem.GetKeyBind("NebulaChatWindow").keyValue)
            {
                Log.Info("Chat window keybind triggered");
                _chatWindow.Toggle();
            }
            
            ChatWindow.QueuedMessage newMessage = _chatWindow.GetQueuedMessage();
            if (Multiplayer.IsActive && newMessage != null)
            {
                Multiplayer.Session.Network?.SendPacket(new NewChatMessagePacket((ChatMessageType)newMessage.ChatMessageType,
                    newMessage.MessageText, DateTime.Now, GetUserName()));
            }

            SendPostConnectionPlanetInfoMessage();
            if (_queuedMessages.Count > 0)
            {
                ChatWindow.QueuedMessage queuedMessage = _queuedMessages.Dequeue();
                _chatWindow.SendMessageToChat(queuedMessage.MessageText, queuedMessage.ChatMessageType);
                if (!_chatWindow.gameObject.activeSelf)
                {
                    if (Config.Options.AutoOpenChat)
                    {
                        _chatWindow.Toggle();
                    }
                    else
                    {
                        _chatWindow.AddNotificationText(queuedMessage.MessageText);
                        _notifierEndTime = DateTime.Now.Ticks + NOTIFICATION_DURATION_TICKS;
                    }
                }
            }

            HideExpiredNotification();
        }

        private void HideExpiredNotification()
        {
            if (_chatWindow.notifier.activeSelf && _notifierEndTime < DateTime.Now.Ticks)
            {
                Log.Debug($"Hiding new chat notification after {NOTIFICATION_DURATION_TICKS} ticks");
                _chatWindow.notifier.SetActive(false);
            }
        }

        private static string GetUserName()
        {
            return Multiplayer.Session?.LocalPlayer?.Data?.Username ?? "Unknown";
        }

        private void SendPostConnectionPlanetInfoMessage()
        {
            if (_sentLocation || !Multiplayer.IsActive || Multiplayer.Session.IsInLobby || Multiplayer.IsInMultiplayerMenu)
                return;
            if (GameMain.localPlanet == null && _attemptsToGetLocationCountDown-- > 0)
            {
                return;
            }

            string locationStr = GameMain.localPlanet == null ? "In Space" : GameMain.localPlanet.displayName;
            Multiplayer.Session.Network.SendPacket(new NewChatMessagePacket(ChatMessageType.SystemMessage,
                $"connected ({locationStr})", DateTime.Now, GetUserName()));
            _sentLocation = true;
        }

        // Queue a message to appear in chat window
        public void AddChatMessage(string text, ChatMessageType messageType)
        {
            _chatWindow.SendMessageToChat(text, (int)messageType);
        }
    }
}