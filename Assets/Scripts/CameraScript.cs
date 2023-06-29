using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera c;
    private bool moveDown = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!GameObject.Find("EventSystem").GetComponent<EventSystemScript>().GetViewMarbles())
        {
            transform.position = new Vector3(0, 7, -10);
        } else
        {
            c.orthographicSize = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            moveDown = true;
        }

        if (moveDown && transform.position.y > 0)
        {
            transform.position += new Vector3(0, -3, 0) * Time.deltaTime;
        } else if (moveDown)
        {
            moveDown = false;
            transform.position = new Vector3(0, 0, -10);
        }
       
    }
}
