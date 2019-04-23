using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

public class PhotonImplementer : MonoBehaviourPunCallbacks
{
    public bool prepend = true;
    public bool replace = false;
    GameObject Player;
    GameObject SingleSphere;

    public bool autocreateOnJoinRandomFailed = true;

    public void ReportState(string state, Color color)
    {
        Debug.Log("State Update: " + state);
    }

    private void Awake()
    {
        ReportState("Ready", Color.white);
    }

    public void ReportStatus(string status)
    {
        ReportState(status, Color.white);
    }

    public override void OnConnected()
    {
        ReportStatus("Photon Connected");
        ReportState("Photon Connected", Color.yellow);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        ReportStatus("Create Room Failed");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        ReportStatus("Join Random Room Failed");
        if (autocreateOnJoinRandomFailed)
        {
            PhotonNetwork.JoinOrCreateRoom("PhotonRoom", null, Photon.Realtime.TypedLobby.Default);
        }
    }

    public override void OnJoinedRoom()
    {
        ReportStatus("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
        Player = PhotonNetwork.Instantiate("CharacterHead", Vector3.zero, Quaternion.identity);
        PhotonNetwork.Instantiate("CharacterRacket", new Vector3(0.1f, 0, -1.6f), Quaternion.identity);
        //PhotonNetwork.Instantiate("Cube", Vector3.zero, Quaternion.identity);

        //Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();

        //foreach(Renderer ren in renderers)
        //{
        //   ren.enabled = false;
        //}

        //if(Player.GetComponent<PhotonView>().ViewID == 1001) {
        //  SingleSphere = PhotonNetwork.Instantiate("Sphere", Vector3.up, Quaternion.identity);
        //} else
        //{
        //    SingleSphere = GameObject.Find("Sphere");
        //}

        GameObject.Find("Controller").GetComponent<MagicLeap.ControllerFeedbackExample>().ball = SingleSphere;

        ReportState("In Room", Color.green);
    }

    public override void OnJoinedLobby()
    {
        ReportStatus("Joined Lobby");
        ReportState("In Lobby", Color.cyan);
    }

    public override void OnCreatedRoom()
    {
        ReportStatus("Created Room " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnConnectedToMaster()
    {
        ReportStatus("Connected to Master");
    }

    public override void OnLeftRoom()
    {
        ReportStatus("Left Room");
    }

    public override void OnLeftLobby()
    {
        ReportStatus("Left Lobby");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        ReportStatus("Join Room Failed: " + message);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        ReportStatus("Player '" + otherPlayer.NickName + "' Left");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        ReportStatus("Player '" + newPlayer.NickName + "' Entered");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        ReportStatus("Disconnected: " + cause);
        ReportState("Disconnected", Color.red);
    }
}
