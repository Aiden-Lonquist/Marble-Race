using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatorScript : MonoBehaviour
{
    static bool started;
    public GameObject marbleGen, levelManager;
    public int marbleCount, reductionAmount, levelCount;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!started)
        {
            started = true;
            InstantiateMarbleGen();
            InstantiateLevelManager();
        }
        // Destroy(gameObject);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InstantiateMarbleGen()
    {
        if (GameObject.Find("MarbleGenerator(Clone)"))
        {
            Destroy(GameObject.Find("MarbleGenerator(Clone)"));
        }
        GameObject gen = Instantiate(marbleGen);
        gen.GetComponent<MarbleGeneratorScript>().SetReductionAmount(reductionAmount);
        gen.GetComponent<MarbleGeneratorScript>().PopulateList(marbleCount);
    }

    public void InstantiateLevelManager()
    {
        GameObject lvMngr = Instantiate(levelManager);
        lvMngr.GetComponent<LevelManagerScript>().PopulateList(levelCount);
    }

    public int GetMarbleCount()
    {
        return marbleCount;
    }

    public int GetReductionAmount()
    {
        return reductionAmount;
    }

    public void SetMarbleCount(int c)
    {
        marbleCount = c;
    }

    public void SetReductionAmount(int a)
    {
        reductionAmount = a;
    }
}
