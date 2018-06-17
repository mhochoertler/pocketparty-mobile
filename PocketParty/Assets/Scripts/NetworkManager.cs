using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour {

    public GameObject main_menu;
    public GameObject lobby_menu;
    public InputField input_roomname;

    public RectTransform room_list;
    public GameObject room_list_entry;

    private string selected_room;

    public void OnReceivedRoomListUpdate()
    {
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();

        for(int i = 0; i < room_list.childCount; i++)
        {
            Destroy(room_list.GetChild(i));
        }

        room_list.DetachChildren();

        foreach(RoomInfo room in rooms)
        {
            GameObject new_entry = (GameObject)Instantiate(room_list_entry);
            new_entry.transform.SetParent(room_list);
            new_entry.GetComponent<Text>().text = room.Name;
        }
    }

    public void selectRoom(GameObject room)
    {
        selected_room = room.GetComponent<Text>().text;
    }

    public void createRoom()
    {
        string roomname = input_roomname.text;

        if(roomname.Length == 0)
        {
            Debug.Log("No name was entered!");
            return;
        }

        RoomInfo[] rooms = PhotonNetwork.GetRoomList();

        foreach(RoomInfo room in rooms)
        {
            if (room.Name == roomname)
            {
                Debug.Log("Room already exists!");
                return;
            }
        }

        PhotonNetwork.CreateRoom(roomname);
        Debug.Log("Room " + "'" + roomname + "'" + " created");
    }

    public void joinRoom()
    {
        PhotonNetwork.JoinRoom(selected_room);
    }

    public void connect()
    {
        Debug.Log("Connecting to master server");
        PhotonNetwork.ConnectUsingSettings("v1.0");
    }

    void OnConnectedToMaster()
    {
        Debug.Log("Connecting established");
        PhotonNetwork.JoinLobby();
    }

    void OnJoinedLobby()
    {
        Debug.Log("Joined lobby successfully");
        main_menu.SetActive(false);
        lobby_menu.SetActive(true);
    }

    void OnJoinedRoom()
    {
        Debug.Log("Joined room successfully");
    }

    void OnJoinedRoomFailed()
    {
        Debug.Log("Joining room failed");
    }

    // Use this for initialization
    void Start ()
    {
        lobby_menu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
