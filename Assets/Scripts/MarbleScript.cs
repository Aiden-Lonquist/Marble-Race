using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarbleScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public TMPro.TextMeshProUGUI textTag;
    public GameObject editMarbleGUI;
    private string nametag; // numerical value or name for each marble, does not need to be unique but will be most often. 1-50 by default.
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        //sr.color = GetNewColor();
        // Debug.Log("new color: " + sr.color);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            Marble m = new Marble();
            m.nametag = nametag;
            m.c = sr.color;
            GameObject.Find("MarbleGenerator(Clone)").GetComponent<MarbleGeneratorScript>().AddMarble(m);
            GameObject.Find("EventSystem").GetComponent<QualifiedScript>().AddToQualified(m);
            Destroy(gameObject);
        } else if (collision.gameObject.CompareTag("Trap"))
        {
            Respawn();
        }
    }

    public void OnMouseOver()
    {
        //Debug.Log("Mouse over marble");
        if (Input.GetMouseButtonDown(0) && GameObject.Find("EditMarbleInterface(Clone)") == null && !GameObject.Find("EventSystem").GetComponent<EventSystemScript>().GetLevel())
        {
            Debug.Log("Edit button pressed");
            GameObject gui = Instantiate(editMarbleGUI);
            gui.transform.parent = gameObject.transform;
            gui.GetComponent<EditMarbleScript>().SetMarble(nametag, sr.color);
        }
    }

    public void EditMarbleButton()
    {
        // pull up GUI for changing marble colour: Colour slider (MVP: input box for hex code)
        // pull up GUI for changing marble name: Text box and confirm / cancel buttons
        
        //Debug.Log("Edit button pressed");
        //GameObject gui = Instantiate(editMarbleGUI);
        
        // set this marble as marble gui marble with build in set marble function
    }

    public void Respawn()
    {
        Vector2 pos = new Vector2(Random.Range(-1.5f, 1.5f), Random.Range(8f, 10.5f));
        transform.position = pos;
    }

    public void SetColor(Color c)
    {
        sr.color = c;
    }

    public void SetTag(string s)
    {
        nametag = s;
        textTag.text = s;
    }

    public void SetIndex(int i)
    {
        index = i;
    }

    public void ReplaceMarbleInList()
    {
        Marble m = new Marble();
        m.nametag = nametag;
        m.c = sr.color;
        m.index = index;
        GameObject.Find("MarbleGenerator(Clone)").GetComponent<MarbleGeneratorScript>().ReplaceMarble(m, index);
    }

    public void Deactivate()
    {
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
    }

    private Color GetNewColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
