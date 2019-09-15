using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class beaker : MonoBehaviour
{
    private Vial vial;
    private bool fill, unfill;
    private float fillAmount;
    public float fillRate, emptyRate;
    private Vector3 resetScale;
    public Text vol;
    private float volumeAmt;
    private LabManager lab;


    // Start is called before the first frame update
    void Start()
    {
        lab = FindObjectOfType<LabManager>();
        emptyRate = lab.dropRate;
        vol = lab.acidVolume;
        vial = FindObjectOfType<Vial>();
        resetScale = new Vector3(gameObject.transform.localScale.x, 0, gameObject.transform.localScale.z);
        gameObject.transform.localScale = resetScale;
    }

    // Update is called once per frame
    void Update()
    {
            if (fill == true)
            {
                fillAmount += fillRate * Time.deltaTime;
            volumeAmt = 250.0f * fillAmount;
            UpdateText();
                if (fillAmount > 1)
                {

                    fillAmount = 1.0f;
                volumeAmt = 250.0f * fillAmount;
                UpdateText();
            }
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x,(float)fillAmount, gameObject.transform.localScale.z);
            }
            if (unfill == true && fill != true)
        {
            fillAmount -= emptyRate * Time.deltaTime;
            volumeAmt = 250.0f * fillAmount;
            UpdateText();
            if (fillAmount < 0)
            {

                fillAmount = 0.0f;
                volumeAmt = 250.0f * fillAmount;
                lab.StopAcid();
                UpdateText();
            }
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, (float)fillAmount, gameObject.transform.localScale.z);
        }
    }
    public float getFillAmt()
    {
        return fillAmount;
    }
    public void Fill()
    {
        fill = true;
    }
    public void StopFill()
    {
        fill = false;
    }
    public void UnFill()
    {
        unfill = true;
    }
    public void StopUnfill()
    {
        unfill = false;
    }
    public void Reset()
    {
        gameObject.transform.localScale = resetScale;
    }
    private void UpdateText()
    {
        vol.text = "Acid Volume: " + volumeAmt + "mL";
    }
   
}
