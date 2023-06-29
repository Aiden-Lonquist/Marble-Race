using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MarbleGeneratorScript : MonoBehaviour
{
    public List<Marble> Marbles;
    public GameObject Marble;
    public int total, cutoff, reductionAmount;
    private bool generated;
    private string roomTitle;
    private int numRooms = 5;
    private bool topThree = false;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        //Debug.Log("Awaken");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("On Start: total " + total + ", marble count " + Marbles.Count);
        //PopulateList(total);
    }


    // Update is called once per frame
    void Update()
    {

        if (Marbles.Count >= cutoff && generated)
        {
            // go to next room
            if (!topThree)
            {
                Debug.Log("go to next room");
                generated = false;
                total = cutoff;
                roomTitle = GetNextRoom();
                SceneManager.LoadScene(roomTitle);
            } else
            {
                Debug.Log("go to podium display");
                generated = false;
                SceneManager.LoadScene("RoomPodium");
            }
        } else if (!generated && GameObject.Find("EventSystem").GetComponent<EventSystemScript>().GetLevel())
        {
            if (total - reductionAmount > 3)
            {
                cutoff = total - reductionAmount;
            } else
            {
                cutoff = 3;
                topThree = true;
            }
            GenerateMarbles();
        } else if (GameObject.Find("EventSystem").GetComponent<EventSystemScript>().GetViewMarbles())  
        {
            Debug.Log("should be displaying marbles");
            GameObject.Find("EventSystem").GetComponent<EventSystemScript>().ToggleViewMarbles();
            if (!topThree)
            {
                DisplayMarbles();
            } else
            {
                DisplayMarblesPodium();
            }
            
        }
    }

    public void PopulateList(int amount)
    {
        total = amount;
        for (int i=0; i<amount; i++)
        {
            //Debug.Log("Populating list of marbles");
            //Marbles.Add(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
            Marble m = new Marble();
            m.nametag = (i+1).ToString();
            m.c = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            m.index = i;
            Marbles.Add(m);
        }
    }

    private void GenerateMarbles()
    {
        for (int i=0; i<Marbles.Count; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-1f, 1f), Random.Range(6.5f, 10f));
            GameObject m = Instantiate(Marble, pos, Quaternion.identity);
            m.GetComponent<MarbleScript>().SetColor(Marbles[i].c);
            m.GetComponent<MarbleScript>().SetTag(Marbles[i].nametag);
            m.GetComponent<MarbleScript>().SetIndex(Marbles[i].index);
            //Debug.Log("Generating Marble: " + i);
        }
        //Debug.Log("All marbles generated, clearing list");
        Marbles.Clear();
        generated = true;
    }

    private void DisplayMarbles()
    {
        for (int i = 0; i < Marbles.Count; i++)
        {
            Vector2 pos = new Vector2((i % 10) -4.5f, 2 - (i / 10));
            GameObject m = Instantiate(Marble, pos, Quaternion.identity);
            m.GetComponent<MarbleScript>().SetColor(Marbles[i].c);
            m.GetComponent<MarbleScript>().SetTag(Marbles[i].nametag);
            m.GetComponent<MarbleScript>().SetIndex(Marbles[i].index);
            //Debug.Log("Generating Marble: " + i);
        }
    }

    private void DisplayMarblesPodium()
    {
        Vector2 firstPlace_pos = new Vector2(0, 0.5f);
        GameObject firstPlace = Instantiate(Marble, firstPlace_pos, Quaternion.identity);
        firstPlace.GetComponent<MarbleScript>().SetColor(Marbles[0].c);
        firstPlace.GetComponent<MarbleScript>().SetTag(Marbles[0].nametag);
        firstPlace.GetComponent<MarbleScript>().SetIndex(Marbles[0].index);

        Vector2 secondPlace_pos = new Vector2(-2, -0.5f);
        GameObject secondPlace = Instantiate(Marble, secondPlace_pos, Quaternion.identity);
        secondPlace.GetComponent<MarbleScript>().SetColor(Marbles[1].c);
        secondPlace.GetComponent<MarbleScript>().SetTag(Marbles[1].nametag);
        secondPlace.GetComponent<MarbleScript>().SetIndex(Marbles[1].index);

        Vector2 thirdPlace_pos = new Vector2(2, -1.5f);
        GameObject thirdPlace = Instantiate(Marble, thirdPlace_pos, Quaternion.identity);
        thirdPlace.GetComponent<MarbleScript>().SetColor(Marbles[2].c);
        thirdPlace.GetComponent<MarbleScript>().SetTag(Marbles[2].nametag);
        thirdPlace.GetComponent<MarbleScript>().SetIndex(Marbles[2].index);
    }

    private string GetNextRoom()
    {
        int num = Random.Range(1, numRooms+1);
        string room = "Room" + num.ToString();
        return room;
    }

    public void AddMarble(Marble m)
    {
        if (Marbles.Count < cutoff)
        {
            Marbles.Add(m);
        }
    }

    public void ReplaceMarble(Marble m, int index)
    {
        Marbles[index] = m;
    }

    public void ToggleGenerated()
    {
        generated = !generated;
    }

    public void SetReductionAmount(int a)
    {
        reductionAmount = a;
    }

    public int GetCutoff()
    {
        if (total - reductionAmount > 3)
        {
            return total - reductionAmount;
        }
        return 3;
    }
}
