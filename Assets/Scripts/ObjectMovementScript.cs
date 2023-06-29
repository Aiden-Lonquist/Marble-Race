using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementScript : MonoBehaviour
{
    public bool rotational, linear, reverse;
    public bool horizontalBound;
    public float rotationalSpeed, linearSpeed;
    public float maxX, minX, maxY, minY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (linear)
        {
            if (reverse)
            {
                gameObject.transform.position -= linearSpeed * Time.deltaTime * gameObject.transform.up;
            } else
            {
                gameObject.transform.position += linearSpeed * Time.deltaTime * gameObject.transform.up;
            }
        }

        if (rotational)
        {
            transform.Rotate(0, 0, rotationalSpeed * Time.deltaTime);
        }

        CheckReverse();


    }

    private void CheckReverse()
    {
        if (horizontalBound)
        {
            if (gameObject.transform.position.x >= maxX)
            {
                reverse = true;
            }
            else if (gameObject.transform.position.x <= minX)
            {
                reverse = false;
            }
        } else
        {
            if (gameObject.transform.position.y >= maxY)
            {
                reverse = true;
            }
            else if (gameObject.transform.position.y <= minY)
            {
                reverse = false;
            }
        }
    }
}
