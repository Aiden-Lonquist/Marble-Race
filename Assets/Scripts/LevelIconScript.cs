using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIconScript : MonoBehaviour
{
    public GameObject iconCover;
    public int levelNumber;
    public bool levelActive;
    private GameObject levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelSelectManager(Clone)");
        levelActive = levelManager.GetComponent<LevelManagerScript>().IsLevelActive(levelNumber);
        iconCover.SetActive(!levelActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        //Debug.Log("Mouse over marble");
        if (Input.GetMouseButtonDown(0))
        {
            ToggleLevelActive();
        }
    }

    private void ToggleLevelActive()
    {
        levelActive = !levelActive;
        iconCover.SetActive(!levelActive);
        if (levelActive)
        {
            levelManager.GetComponent<LevelManagerScript>().ActivateLevel(levelNumber);
        } else
        {
            levelManager.GetComponent<LevelManagerScript>().DeactivateLevel(levelNumber);
        }
        Debug.Log("Level " + levelNumber + " active: " + levelActive);
    }
}
