using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject strawPrefab;
    [SerializeField] private GameObject melonPrefab;
    [SerializeField] private GameObject burgrPrefab;
    [SerializeField] private GameObject pizzaPrefab;
    [SerializeField] private GameObject friesPrefab;
    [SerializeField] private GameObject obsPrefab;
    [SerializeField] private GameObject treePrefab;

    private List<GameObject> foodList;
    private List<GameObject> obsList;

    private float foodTimer = 3;
    private float obsTimer = 4;
    private float treeTimer = 5;

    // Start is called before the first frame update
    void Start()
    {
        foodList = new List<GameObject>();
        obsList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        foodTimer -= Time.deltaTime;
        if(foodTimer <= 0)
        {
            foodTimer = Random.Range(2f, 4f);
            if (obsTimer < 1f)
                obsTimer += 1;
            if (treeTimer < 1f)
                treeTimer += 1;

            int foodSelect = Random.Range(0, 8);

            if (foodSelect == 0)
            {
                GameObject clone = Instantiate(applePrefab, new Vector3(10, Random.Range(-2.5f, 2.5f), 0), Quaternion.identity);
                foodList.Add(clone);
            }
            else if (foodSelect == 1)
            {
                GameObject clone = Instantiate(strawPrefab, new Vector3(10, Random.Range(-2.5f, 2.5f), 0), Quaternion.identity);
                foodList.Add(clone);
            }
            else if (foodSelect == 2)
            {
                GameObject clone = Instantiate(melonPrefab, new Vector3(10, Random.Range(-2.5f, 2.5f), 0), Quaternion.identity);
                foodList.Add(clone);
            }
            else if (foodSelect == 3 || foodSelect == 6)
            {
                GameObject clone = Instantiate(burgrPrefab, new Vector3(10, Random.Range(-2.5f, 0f), 0), Quaternion.identity);
                foodList.Add(clone);
            }
            else if (foodSelect == 5 || foodSelect == 7)
            {
                GameObject clone = Instantiate(pizzaPrefab, new Vector3(10, Random.Range(-2.5f, 0f), 0), Quaternion.identity);
                foodList.Add(clone);
            }
            else if (foodSelect == 5 || foodSelect == 8)
            {
                GameObject clone = Instantiate(friesPrefab, new Vector3(10, Random.Range(-2.5f, 0f), 0), Quaternion.identity);
                foodList.Add(clone);
            }
        }

        obsTimer -= Time.deltaTime;
        if (obsTimer <= 0)
        {
            obsTimer = Random.Range(2f, 4f);
            if(foodTimer < 1f)
                foodTimer += 1;
            if (treeTimer < 1f)
                treeTimer += 1;

            GameObject clone = Instantiate(obsPrefab, new Vector3(10, -2.78f, 0), Quaternion.identity);
            obsList.Add(clone);
        }

        treeTimer -= Time.deltaTime;
        if(treeTimer <= 0)
        {
            treeTimer = Random.Range(3f, 5f);
            if (foodTimer < 1f)
                foodTimer += 1;
            if (obsTimer < 1f)
                obsTimer += 1;

            GameObject clone = Instantiate(treePrefab, new Vector3(10, -1.11f, 0), Quaternion.identity);
            obsList.Add(clone);
        }
    }

    public List<GameObject> getFruitList()
    {
        return foodList;
    }
    
    public List<GameObject> getObsList()
    {
        return obsList;
    }
}
