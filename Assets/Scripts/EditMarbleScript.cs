using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditMarbleScript : MonoBehaviour
{
    public string input;
    public TMPro.TextMeshProUGUI nameUserInput, redUserInput, greenUserInput, blueUserInput;
    public TMPro.TMP_InputField nameInputField, redInputField, greenInputField, blueInputField;
    public Image SampleMarble;
    private Marble m;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMarble(string name, Color color)
    {
        Debug.Log("Name: " + name + " , Color: " + color);
        Marble marble = new Marble();
        marble.nametag = name;
        marble.c = color;
        m = marble;
        UpdateInputField(name, color);
        UpdateSampleMarble();
    }

    public void CancelButton()
    {
        Destroy(gameObject);
    }

    public void ConfirmButton()
    {
        // update marble name
        //Debug.Log(userInput.text);
        if (nameUserInput.text != "" || nameUserInput.text != " " || nameUserInput.text != null)
        {    
            Color c = RGBToDecimal(StringToInt(redInputField.text), StringToInt(greenInputField.text), StringToInt(blueInputField.text));
            gameObject.transform.parent.GetComponent<MarbleScript>().SetColor(c);

            gameObject.transform.parent.GetComponent<MarbleScript>().SetTag(nameUserInput.text);
            gameObject.transform.parent.GetComponent<MarbleScript>().ReplaceMarbleInList();
        }
        Destroy(gameObject);
    }

    public void UpdateSampleMarble()
    {
        Debug.Log("Update Marble Called");
        int r = StringToInt(redInputField.text);
        int g = StringToInt(greenInputField.text);
        int b = StringToInt(blueInputField.text);
        Color c = RGBToDecimal(r, g, b);
        SampleMarble.color = c;
    }

    private void UpdateInputField(string text, Color c)
    {
        //nameInputPlaceholder.text = text;
        nameInputField.text = text;
        redInputField.text = (Mathf.Round(c.r * 255)).ToString();
        greenInputField.text = (Mathf.Round(c.g * 255)).ToString();
        blueInputField.text = (Mathf.Round(c.b * 255)).ToString();
    }

    private Color RGBToDecimal(int r, int g, int b)
    {
        float r_dec = r / 255f;
        float g_dec = g / 255f;
        float b_dec = b / 255f;
        r_dec = CheckBounds(r_dec);
        g_dec = CheckBounds(g_dec);
        b_dec = CheckBounds(b_dec);

        Color c = new Color(r_dec, g_dec, b_dec);
        return c;
    }

    private float CheckBounds(float f)
    {
        if (f > 1)
        {
            return 1;
        } else if (f < 0)
        {
            return 0;
        }

        return f;
    }

    private int StringToInt(string s)
    {
        int.TryParse(s, out int num);
        return num;
    }
}
