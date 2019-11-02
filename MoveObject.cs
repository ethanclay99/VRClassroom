using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Transform startPt;
    public Transform endPt;
    private Transform targetPos;
    public float speed;
    public bool forwards = true;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = startPt;
    }

    // Update is called once per frame
    void Update()
    {
        if (forwards && isActive)
            targetPos = startPt;
        else if (!forwards && isActive)
            targetPos = endPt;

        if (isActive)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, targetPos.position, speed);
        }

        if (transform.position == targetPos.position)
        {   
            isActive = false;
            forwards = !forwards;
        }

    }
}
