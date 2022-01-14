using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatWindow : MonoBehaviour
{
    private const int MAX_MESSAGES = 25;
    public TMP_InputField chatBox;
    public GameObject chatPanel, textObject, notifier, chatWindow;
    public Color playerMessage, info;
    public TMP_Text newChatNotificationText;
    private Queue<QueuedMessage> _outgoingMessages = new Queue<QueuedMessage>(5);
    [SerializeField] private readonly List<Message> _messages = new List<Message>();
    public string userName;

    void Update()
    {
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                QueueOutgoingMessage($"[{DateTime.Now:HH:mm}] [{userName}] : {chatBox.text}", 0);
                SendMessageToChat($"[{DateTime.Now:HH:mm}] [{userName}] : {chatBox.text}", 0);

                chatBox.text = "";
                // bring cursor back to message area so they can keep typing
                chatBox.ActivateInputField();
            }
            else
            {
                if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
                    chatBox.ActivateInputField();
            }
        }
    }

    private void QueueOutgoingMessage(string message, int chatMesageType)
    {
        _outgoingMessages.Enqueue(new QueuedMessage { MessageText = message, ChatMessageType = chatMesageType });
    }

    public void SendMessageToChat(string text, int messageType)
    {
        if (_messages.Count > MAX_MESSAGES)
        {
            Destroy(_messages[0].textObject.gameObject);
            _messages.Remove(_messages[0]);
        }

        var newMsg = new Message { text = text };
        GameObject nextText = Instantiate(textObject, chatPanel.transform);
        newMsg.textObject = nextText.GetComponent<TMP_Text>();
        newMsg.textObject.text = newMsg.text;
        newMsg.textObject.color = MessageTypeColor(messageType);
        // Console.WriteLine($"Adding message: {messageType} {newMsg.text}");
        _messages.Add(newMsg);
    }


    private Color MessageTypeColor(int messageType)
    {
        Color color = Color.white;
        switch (messageType)
        {
            case 0:
                color = playerMessage;
                break;
            case 1:
                color = info;
                break;
            default:
                Console.WriteLine($"Requested color for unexpected chat message type {messageType}");
                break;
        }

        return color;
    }

    public void Toggle(bool forceClosed = false)
    {
        bool desiredStatus = !forceClosed && !chatWindow.activeSelf;
        chatWindow.SetActive(desiredStatus);
        if (chatWindow.activeSelf)
        {
            // when the window is activated we assume user wants to type right away
            chatBox.ActivateInputField();
            notifier.SetActive(false);
        }
    }

    public QueuedMessage GetQueuedMessage()
    {
        return _outgoingMessages.Count > 0 ? _outgoingMessages.Dequeue() : null;
    }


    public class QueuedMessage
    {
        public string MessageText;
        public int ChatMessageType;
    }

    public void AddNotificationText(string notificationText)
    {
        newChatNotificationText.text = notificationText;
        notifier.SetActive(true);
    }
}


/// <summary>
/// This is what is rendered in the chat area (already sent chat messages)
/// </summary>
[Serializable]
public class Message
{
    public string text;
    public TMP_Text textObject;
    public int messageType;
}