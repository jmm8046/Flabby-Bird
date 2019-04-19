using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;

    [SerializeField] private Generator generator;

    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject background;

    private List<GameObject> fruitList;
    private List<GameObject> obsList;

    private Vector3 groundStartPos;
    private Vector3 backStartPos;

    // Start is called before first frame update
    private void Start()
    {
        fruitList = new List<GameObject>();
        obsList = new List<GameObject>();

        groundStartPos = ground.transform.position;
        backStartPos = background.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        fruitList = generator.getFruitList();

        foreach(GameObject fruit in fruitList.ToArray())
        {
            fruit.transform.Translate(Vector3.left * scrollSpeed * 0.05f);

            Vector3 fruitPos = fruit.transform.position;

            if(fruitPos.x < -10f)
            {
                fruitList.Remove(fruit);
                Destroy(fruit);
            }
        }

        obsList = generator.getObsList();

        foreach(GameObject obs in obsList.ToArray())
        {
            obs.transform.Translate(Vector3.left * scrollSpeed * 0.05f);

            Vector3 obsPos = obs.transform.position;

            if(obsPos.x < -10f)
            {
                obsList.Remove(obs);
                Destroy(obs);
            }
        }

        ground.transform.Translate(Vector3.left * scrollSpeed * 0.05f);
        background.transform.Translate(Vector3.left * scrollSpeed * 0.05f);

        Vector3 groundPos = ground.transform.position;

        if (groundPos.x < -1f)
        {
            ground.transform.SetPositionAndRotation(groundStartPos, Quaternion.identity);
        }

        Vector3 backPos = background.transform.position;

        if(backPos.x < -38.4f)
        {
            background.transform.SetPositionAndRotation(backStartPos, Quaternion.identity);
        }
    }
}
