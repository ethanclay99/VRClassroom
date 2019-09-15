using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabManager : MonoBehaviour
{
    private Vial vial;
    private beaker beeker;
    private Cup cup;
    public float waitTime, waitTime2;
    public GameObject continueButton;
    public GameObject pour, unpour;
    public GameObject releaseKnob;
    public GameObject baseWater;
    public Material successColor;

    private bool canClick = true, moveStuff = false, moveStuff1= false;
    public Text acidVolume;
    public Transform beekPos, cupPos;

    public GameObject drop;
    public Text baseVolume;
    public Text acidMolarity;
    public Text baseMolarity;
    public Text acidAdded;
    public float dropRate;
    public float baseVol;
    public float acidMol;
    public float molarity;
    private bool titrated;
    private bool bruhSound2 = true;
    private bool canAddAcid;

    // Start is called before the first frame update
    void Start()
    {
        vial = FindObjectOfType<Vial>();
        beeker = FindObjectOfType<beaker>();
        cup = FindObjectOfType<Cup>();
        
    }
    void Update()
    {
        UpdateText();
        if (moveStuff)
        {
            beeker.transform.parent.transform.position = Vector3.MoveTowards(beeker.transform.parent.transform.position, beekPos.position, 0.5f);
            if (beeker.transform.parent.transform.position == beekPos.position)
                moveStuff = false;
        }
        if (moveStuff1) { 
            cup.transform.position = Vector3.MoveTowards(cup.transform.position, cupPos.position, 0.5f);
            if (cup.transform.position == cupPos.position)
                moveStuff1 = false;
        }
        if (cup.getAcidAdded() >= baseVol * molarity / acidMol)
            Success();
    }
    public bool IsTitrated()
    {
        if (cup.getAcidAdded() + 3 >= baseVol * molarity / acidMol && cup.getAcidAdded() - 3 <= baseVol * molarity / acidMol)
            return true;
        else
            return false;
    }
    public void UpdateText()
    {
        baseVolume.text = "Base Volume: " + baseVol + "mL";
        acidMolarity.text = "Acid Molarity: " + acidMol + "mol";
        acidAdded.text = "Acid Added: " + cup.getAcidAdded() + "mL";
        if (titrated)
            baseMolarity.text = "Base Molarity: " + molarity + "mol";
        else
            baseMolarity.text = "Base Molarity: ?";
    }
    public void MoveObject(GameObject g, Transform t)
    {
        g.transform.position = Vector3.MoveTowards(g.transform.position, t.position, 1f);
        if (g.transform.position == t.position)
            moveStuff = false;
        moveStuff1 = false;
    }
    public void StartPouring()
    {
        if (canClick)
        {
            StartCoroutine(StartPourCoroutine());
        }
    }
    public void StopPouring()
    {
        if (canClick)
        {
            StartCoroutine(StopPourCoroutine());
        }
    }
    public void Continue1()
    {
        pour.gameObject.SetActive(false);
        unpour.gameObject.SetActive(false);
        moveStuff = true;
        moveStuff1 = true;
        canAddAcid = true;
        //continueButton.gameObject.SetActive(false);
    }
    public void AddAcid()
    {
        if (canAddAcid)
        {
            if (bruhSound2)
            {
                releaseKnob.transform.rotation = Quaternion.Euler(new Vector3(releaseKnob.transform.rotation.x, releaseKnob.transform.rotation.y, releaseKnob.transform.rotation.z + 90));
                drop.gameObject.SetActive(true);
                beeker.UnFill();
                cup.Fill(dropRate);
                bruhSound2 = false;
            }
            else
            {
                releaseKnob.transform.rotation = Quaternion.Euler(new Vector3(releaseKnob.transform.rotation.x, releaseKnob.transform.rotation.y, releaseKnob.transform.rotation.z + 90));
                StopAcid();
                bruhSound2 = true;
            }
        }
    }
    public void StopAcid()
    {
        cup.StopFill();
        beeker.StopUnfill();
        drop.gameObject.SetActive(false);
        titrated = IsTitrated();
    }
    public void Success()
    {
        baseWater.GetComponent<MeshRenderer>().material = successColor;
    }
    IEnumerator StartPourCoroutine()
    {
        canClick = false;
        vial.Pour();
        yield return new WaitForSeconds(waitTime);
        vial.myAnim.SetBool("IsMoving", true);
        vial.myAnim.SetBool("IsPouring", true);
        yield return new WaitForSeconds(waitTime2);
        vial.myAnim.SetBool("IsMoving", false);
        beeker.Fill();
        canClick = true;
    }
    IEnumerator StopPourCoroutine()
    {
        canClick = false;
        beeker.StopFill();
        vial.myAnim.SetBool("IsPouring", false);
        vial.myAnim.SetBool("IsMoving", true);
        yield return new WaitForSeconds(waitTime2);
        vial.myAnim.SetBool("IsMoving", false);
        vial.StopPour();
        yield return new WaitForSeconds(waitTime);
        continueButton.SetActive(true);
        canClick = true;
    }

}
