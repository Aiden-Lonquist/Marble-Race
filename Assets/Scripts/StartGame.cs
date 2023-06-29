using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private string roomTitle;
    private int numRooms = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameButton()
    {
        roomTitle = GetNextRoom();
        SceneManager.LoadScene("room6"); // should be roomTitle, set to specific room for testing
    }

    public void ViewMarblesButton()
    {
        SceneManager.LoadScene("RoomViewMarbles");
    }

    private string GetNextRoom()
    {
        int num = Random.Range(1, numRooms + 1);
        string room = "Room" + num.ToString();
        return room;
    }
}
