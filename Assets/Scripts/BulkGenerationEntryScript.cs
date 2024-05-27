using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulkGenerationEntryScript : MonoBehaviour
{
    public GameObject eventSystem;
    public int index = 0;
    public int count;
    public string marble_name;
    public Color marble_color;
    public GameObject BulkEditor;
    public Image marbleIcon;
    // Start is called before the first frame update
    void Start()
    {
        marble_color = Color.gray;
        eventSystem = GameObject.Find("Instantiator");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIndex(int i)
    {
        index = i;
    }

    public int GetIndex()
    {
        return index;
    }

    public void SetCount(TMPro.TMP_InputField input)
    {
        Debug.Log("input: " + input.text);
        int c = StringToInt(input.text); // this is causing value to become 0 but it shouldn't
        Debug.Log("input after: " + c);
        count = c;
        UpdateBulkMarbleAtIndex();
    }

    public void SetName(TMPro.TMP_InputField input)
    {
        marble_name = input.text;
        UpdateBulkMarbleAtIndex();
    }

    public void SetColor(Color c)
    {
        marble_color = c;
        marbleIcon.color = c;
        UpdateBulkMarbleAtIndex();
    }

    public void EditBulkMarbleButton()
    {
        GameObject gui = Instantiate(BulkEditor);
        gui.transform.parent = gameObject.transform;
        gui.GetComponent<EditBulkMarbleScript>().SetMarble(marble_color);
    }

    private void UpdateBulkMarbleAtIndex()
    {
        BulkMarble bm = new BulkMarble();
        bm.count = count;
        bm.name = marble_name;
        bm.color = marble_color;
        eventSystem.GetComponent<InstantiatorScript>().AddBlukMarble(bm, index);
    }

    private int StringToInt(string s)
    {
        int.TryParse(s, out int num);
        return num;
    }

}
