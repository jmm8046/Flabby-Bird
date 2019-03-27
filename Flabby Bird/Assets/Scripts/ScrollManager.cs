using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;

    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject background;

    private Vector3 groundStartPos;
    private Vector3 backStartPos;

    // Start is called before first frame update
    private void Start()
    {
        groundStartPos = ground.transform.position;
        backStartPos = background.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ground.transform.Translate(Vector3.left * scrollSpeed * 0.05f);
        background.transform.Translate(Vector3.left * scrollSpeed * 0.05f);

        Vector3 groundPos = ground.transform.position;

        if (groundPos.x < -1)
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
