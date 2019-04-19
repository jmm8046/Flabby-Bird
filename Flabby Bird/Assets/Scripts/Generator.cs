using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject fruitPrefab;
    [SerializeField] private GameObject obsPrefab;

    private List<GameObject> fruitList;
    private List<GameObject> obsList;

    private float fruitTimer = 5;
    private float obsTimer = 8;

    // Start is called before the first frame update
    void Start()
    {
        fruitList = new List<GameObject>();
        obsList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        fruitTimer -= Time.deltaTime;
        if(fruitTimer <= 0)
        {
            fruitTimer = 5;

            GameObject clone = Instantiate(fruitPrefab, new Vector3(10, Random.Range(-2.5f, 2.5f), 0), Quaternion.identity);
            fruitList.Add(clone);
        }

        obsTimer -= Time.deltaTime;
        if (obsTimer <= 0)
        {
            obsTimer = 5;

            GameObject clone = Instantiate(obsPrefab, new Vector3(10, -2.78f, 0), Quaternion.identity);
            obsList.Add(clone);
        }
    }

    public List<GameObject> getFruitList()
    {
        return fruitList;
    }
    
    public List<GameObject> getObsList()
    {
        return obsList;
    }
}
