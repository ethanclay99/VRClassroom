using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titration : MonoBehaviour
{
    bool colorChange;
    bool isPouring;
    const float FlowRate=0.5;
    const float InitialBuretVolume=50.0;
    const float InitialFlaskVolume=250.0;
    float molarityBuret;
    float molarityFlask;
    float volumeBuret;
    float volumeFlask;
    float molesOfBase;
    void Start(molarityBuret,volumeBuret){
        this.molarityBuret=molarityBuret;
        this.volumeBuret=volumeBuret;
        isPouring=true;
    }

    void Update(){
        if (volumeBuret<=0){
            isPouring=false;
        }
        if (isPouring){
            volumeBuret-=FlowRate*Time.deltaTime;
            volumeFlask-=FlowRate*Time.deltaTime;
        }
        molesOfBase=(InitialBuretVolume-volumeBuret)*molarityBuret
        if (molesOfBase>=InitialFlaskVolume*molarityFlask){
            colorChange=true;
            isPouring=false;
        }

    }
} 
