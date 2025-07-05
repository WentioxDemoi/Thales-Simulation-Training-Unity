using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ChatManager : MonoBehaviourPunCallbacks
{

    public GameObject Chat;
    public GameObject NickName;

    public InputField inputField;
    public InputField Name;

    public GameObject LMessage;
    public GameObject MyLMessage; 
    
    public GameObject MMessage;
    public GameObject MyMMessage; 

    public GameObject BMessage;
    public GameObject MyBMessage; 

    public GameObject Content;
    public ScrollRect scrollRect;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (Chat.activeSelf) {
                SendMessage();
            } else if (NickName.activeSelf) {
                SetNickname();
            }
        }

    }

    public void SendMessage()
    {
        if (inputField.text.Length <= 0)
            return;
        GetComponent<PhotonView>().RPC("GetMessage", RpcTarget.All, PhotonNetwork.NickName, inputField.text);
        inputField.text = "";
    }

    [PunRPC]
    public void GetMessage(string name, string ReceiveMessage)
    {
        GameObject M = null;

        if (name == PhotonNetwork.NickName)
        {
            if (ReceiveMessage.Length <= 30) {
                M = Instantiate(MyLMessage, Vector3.zero, Quaternion.identity, Content.transform);
            }
            else if (ReceiveMessage.Length <= 90) {
                M = Instantiate(MyMMessage, Vector3.zero, Quaternion.identity, Content.transform);
            }
            else {
                M = Instantiate(MyBMessage, Vector3.zero, Quaternion.identity, Content.transform);
            }
        }
        else
        {
            if (ReceiveMessage.Length <= 23) {
                M = Instantiate(LMessage, Vector3.zero, Quaternion.identity, Content.transform);
            }
            else if (ReceiveMessage.Length <= 90) {
                M = Instantiate(MMessage, Vector3.zero, Quaternion.identity, Content.transform);
            }
            else {
                M = Instantiate(BMessage, Vector3.zero, Quaternion.identity, Content.transform);
            }
        }
        M.transform.SetParent(Content.transform, false);
        M.transform.SetAsFirstSibling();
        M.GetComponent<Chat>().Message.text = ReceiveMessage;
        M.GetComponent<Chat>().Name.text = name;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions());
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Connecté à une room !");
    }

    public void SetNickname()
    {
        if (!string.IsNullOrEmpty(Name.text))
        {
            PhotonNetwork.NickName = Name.text;
            Chat.SetActive(true);
            NickName.SetActive(false);
        }
    }
}
