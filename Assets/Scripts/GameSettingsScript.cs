using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingsScript : MonoBehaviour
{
    public TMPro.TMP_InputField countInputField, reductionInputField;
    public GameObject instantiator;

    // Start is called before the first frame update
    void Start()
    {
        UpdateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateInputField() // set input field with values from instantiator (erorr returning 0s)
    {
        //nameInputPlaceholder.text = text;
        // countInputField.text = instantiator.GetComponent<InstantiatorScript>().GetReductionAmount().ToString();
        // reductionInputField.text = instantiator.GetComponent<InstantiatorScript>().GetMarbleCount().ToString();

        // hardcoding default values for now.
        countInputField.text = "50";
        reductionInputField.text = "10";
        UpdateGameSettings();

    }

    public void UpdateGameSettings()
    {
        Debug.Log("Update Settings Called");
        instantiator.GetComponent<InstantiatorScript>().SetMarbleCount(StringToInt(countInputField.text));
        instantiator.GetComponent<InstantiatorScript>().SetReductionAmount(StringToInt(reductionInputField.text));
    }

    private int StringToInt(string s)
    {
        int.TryParse(s, out int num);
        return num;
    }
}
