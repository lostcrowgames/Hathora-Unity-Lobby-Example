using UnityEngine;
using UnityEngine.UI;

namespace Hathora.Demos.Shared.Scripts.Client.ClientMgr
{
    public class LobbyPrefabController : MonoBehaviour
    {
        public string RoomId { get; private set; }

        public void Initialize(string roomId)
        {
            RoomId = roomId;
            Debug.Log("Initializing prefab with RoomId: " + RoomId); // Debug log for initialization
            Button joinButton = GetComponentInChildren<Button>();
            if (joinButton != null)
            {
                joinButton.onClick.AddListener(() => JoinLobby());
            }
        }

        private void JoinLobby()
        {
            HathoraClientMgrDemoUi clientMgrDemoUi = FindObjectOfType<HathoraClientMgrDemoUi>();
            if (clientMgrDemoUi != null)
            {
                Debug.Log("Joining lobby with RoomId: " + RoomId); // Debug log for joining lobby
                //clientMgrDemoUi.OnJoinLobbyAsClientBtnClick(RoomId);
            }
        }
    }
}
