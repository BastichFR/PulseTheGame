using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefabBlue;
    public GameObject playerPrefabRed;
    public Player player;




    void Start()
    {

        if (playerPrefabBlue != null)

            PhotonNetwork.Instantiate(this.playerPrefabBlue.name, new Vector3(11.77837f, 7.826f, 11.81067f), Quaternion.identity, 0);
        else
        {
            if (playerPrefabRed != null)
            {
                PhotonNetwork.Instantiate(this.playerPrefabRed.name, new Vector3(40.65236f, 7.889f, 41.143f), Quaternion.identity, 1);

            }
        }
    }

    public void OnPlayerEnterRoom(Player other)
    {
        print(other.NickName + " s'est connecté !");
    }

    public override void OnPlayerLeftRoom(Player other)
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
