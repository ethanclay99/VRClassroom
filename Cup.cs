using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public float acidContent;
    private bool fill;
    private float rate;
    private beaker beeker;
    // Start is called before the first frame update
    void Start()
    {
        beeker = FindObjectOfType<beaker>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (fill)
        {
            if (beeker.getFillAmt() >= 0)
            {
                acidContent += rate * Time.deltaTime;
            }
            else
            {
                StopFill();
            }
        }
    }
    public void Fill(float rrate)
    {
        fill = true;
        rate = rrate;
    }
    public void StopFill()
    {
        fill = false;
    }
    public float getAcidAdded()
    {
        return acidContent;
    }
}
