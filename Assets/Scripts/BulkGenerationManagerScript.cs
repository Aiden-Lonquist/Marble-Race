using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulkGenerationManagerScript : MonoBehaviour
{
    public int bulkMarbleCount;
    public GameObject BulkMarbleEntry;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBulkEntry()
    {
        Vector2 pos = new Vector2(gameObject.transform.position.x, (gameObject.transform.position.y+40)-bulkMarbleCount*25);
        GameObject bulkEntry = Instantiate(BulkMarbleEntry, pos, Quaternion.identity, gameObject.transform);
        //bulkEntry.transform.parent = gameObject.transform;
        bulkEntry.GetComponent<BulkGenerationEntryScript>().SetIndex(bulkMarbleCount);
        bulkMarbleCount += 1;
    }
}
