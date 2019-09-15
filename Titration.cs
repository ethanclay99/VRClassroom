using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titration : MonoBehaviour
{
    bool colorChange;
    bool isPouring;
    const double FlowRate=0.5;
    const double InitialBuretVolume=50.0;
    const double InitialFlaskVolume=250.0;
    double molarityBuret;
    double molarityFlask;
    double volumeBuret;
    double volumeFlask;
    double molesOfBase;
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