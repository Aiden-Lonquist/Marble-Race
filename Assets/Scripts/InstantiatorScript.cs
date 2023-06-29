using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatorScript : MonoBehaviour
{
    static bool started;
    public GameObject marbleGen;
    public int marbleCount, reductionAmount;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!started)
        {
            started = true;
            GameObject gen = Instantiate(marbleGen);
            gen.GetComponent<MarbleGeneratorScript>().SetReductionAmount(reductionAmount);
            gen.GetComponent<MarbleGeneratorScript>().PopulateList(marbleCount);
        }
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
