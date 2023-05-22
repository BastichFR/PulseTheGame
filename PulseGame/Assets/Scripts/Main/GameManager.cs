using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public Camera MainCamera;

    void Start()
    {
        if (playerPrefab != null)
        {
            GameObject Player = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0, 2, 0), Quaternion.identity, 0) as GameObject;
            MainCamera.GetComponent<SmoothFollow>().target = Player.transform;
;        }
    }

    public void OnPlayerEnterRoom(Player other)
    {
        print(other.NickName + " s'est connecté !");
    }

    public void OnPlayerLeftRoom(Player other)
    {
        print(other.NickName + " s'est déconnecté !");
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("LauncherScene");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}

