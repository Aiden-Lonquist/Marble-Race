using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public List<int> activeLevels;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        //Debug.Log("Awaken");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateLevel(int l)
    {
        activeLevels.Add(l);
    }

    public void DeactivateLevel(int l)
    {
        activeLevels.Remove(l);
    }

    public bool IsLevelActive(int l)
    {
        return activeLevels.Contains(l);
    }

    public int GetRandomLevel()
    {
        int level = Random.Range(0, activeLevels.Count);
        return activeLevels[level];
    }

    public void PopulateList(int levelCount)
    {
        for (int i = 1; i<levelCount+1; i++)
        {
            activeLevels.Add(i);
        }
    }
}
