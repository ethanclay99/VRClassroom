using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vial : MonoBehaviour
{
    public double ph;
    public bool isPouring;
    public Animator myAnim;
    private MoveObject move;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = gameObject.GetComponent<Animator>();
        move = gameObject.GetComponent<MoveObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pour()
    {
        move.forwards = true;
        move.isActive = true;
            isPouring = true;
        
    }

    public void StopPour()
    {
        move.forwards = false;
        move.isActive = true;
        isPouring = false;
    }
}
