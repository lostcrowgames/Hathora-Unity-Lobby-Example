using TMPro;
using UnityEngine;

namespace Hathora.Demos.Shared.Scripts.Client.ClientMgr
{
    public class HathoraLobbyRow : MonoBehaviour
    {
        public TextMeshProUGUI roomText;
        public TextMeshProUGUI descriptionText;

        public void SetContent(string roomId, string createdAt, string createdBy)
        {
            Debug.Log($"Setting content for RoomId={roomId}");

            if (roomText == null || descriptionText == null)
            {
                Debug.LogError("Text components are not assigned!");
                return;
            }

            roomText.text = $"RoomId={roomId}";
            descriptionText.text = $"CreatedAt={createdAt}, CreatedBy={createdBy}";
        }

        public void SetRoomText(string text)
        {
            roomText.SetText(text);
        }
    }
}
