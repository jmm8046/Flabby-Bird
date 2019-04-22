using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject strawPrefab;
    [SerializeField] private GameObject melonPrefab;
    [SerializeField] private GameObject obsPrefab;
    [SerializeField] private GameObject treePrefab;

    private List<GameObject> fruitList;
    private List<GameObject> obsList;

    private float fruitTimer = 5;
    private float obsTimer = 6;
    private float treeTimer = 8;

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
            fruitTimer = Random.Range(2f, 5f);
            if (obsTimer < 1f)
                obsTimer += 1;
            if (treeTimer < 1f)
                treeTimer += 1;

            int fruitSelect = Random.Range(0, 2);

            if (fruitSelect == 0)
            {
                GameObject clone = Instantiate(applePrefab, new Vector3(10, Random.Range(-2.5f, 2.5f), 0), Quaternion.identity);
                fruitList.Add(clone);
            }
            else if (fruitSelect == 1)
            {
                GameObject clone = Instantiate(strawPrefab, new Vector3(10, Random.Range(-2.5f, 2.5f), 0), Quaternion.identity);
                fruitList.Add(clone);
            }
            else if (fruitSelect == 2)
            {
                GameObject clone = Instantiate(melonPrefab, new Vector3(10, Random.Range(-2.5f, 2.5f), 0), Quaternion.identity);
                fruitList.Add(clone);
            }
        }

        obsTimer -= Time.deltaTime;
        if (obsTimer <= 0)
        {
            obsTimer = Random.Range(3f, 6f);
            if(fruitTimer < 1f)
                fruitTimer += 1;
            if (treeTimer < 1f)
                treeTimer += 1;

            GameObject clone = Instantiate(obsPrefab, new Vector3(10, -2.78f, 0), Quaternion.identity);
            obsList.Add(clone);
        }

        treeTimer -= Time.deltaTime;
        if(treeTimer <= 0)
        {
            treeTimer = Random.Range(4f, 8f);
            if (fruitTimer < 1f)
                fruitTimer += 1;
            if (obsTimer < 1f)
                obsTimer += 1;

            GameObject clone = Instantiate(treePrefab, new Vector3(10, -1.55f, 0), Quaternion.identity);
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
