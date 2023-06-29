using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemScript : MonoBehaviour
{
    public bool isLevel;
    public bool isMarbleView = false;
    // Start is called before the first frame update
    void Start()
    {
        if (isMarbleView)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 0.9f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetLevel()
    {
        return isLevel;
    }

    public bool GetViewMarbles()
    {
        return isMarbleView;
    }

    public void ToggleViewMarbles()
    {
        isMarbleView = !isMarbleView;
    }
}
