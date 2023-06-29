using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualifiedScript : MonoBehaviour
{
    public GameObject marble;
    public TMPro.TextMeshProUGUI qualifiedCountText;
    public List<Marble> qualified;
    private int cutoff, currentCount;
    // Start is called before the first frame update
    void Start()
    {
        cutoff = GameObject.Find("MarbleGenerator(Clone)").GetComponent<MarbleGeneratorScript>().GetCutoff();
        qualifiedCountText.text = "0/" + cutoff.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToQualified(Marble m)
    {
        qualified.Add(m);
        DisplayNewMarble();
        updateText();
    }

    private void DisplayNewMarble()
    {
        Debug.Log("Displaying qualified");
        Vector2 pos = new Vector2(6.88f + ((qualified.Count-1) % 4) / 2f, 3f - (((qualified.Count-1) / 4) / 1.60f));
        GameObject m = Instantiate(marble, pos, Quaternion.identity);
        m.GetComponent<MarbleScript>().SetColor(qualified[qualified.Count - 1].c);
        m.GetComponent<MarbleScript>().SetTag(qualified[qualified.Count - 1].nametag);
        m.GetComponent<MarbleScript>().Deactivate();
    }

    private void updateText()
    {
        currentCount += 1;
        qualifiedCountText.text = currentCount.ToString() + "/" + cutoff.ToString();
    }
}
