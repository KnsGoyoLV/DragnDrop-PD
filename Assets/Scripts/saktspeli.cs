using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saktspeli : MonoBehaviour
{
    //definējam spēles objektus
    public GameObject poga;
    public GameObject pogab;
    public GameObject attels;
    //izveidots public void izskritosais
    public void izkritosais(){
        //bilde parklaj spēli, tapēc ir izveidots true
    attels.SetActive(true);
    //ja poga ir nospiesta tad izslēdzās visi kas ir domāts sākumam
    if(poga == true){
        attels.SetActive(false);
        pogab.SetActive(false);
        poga.SetActive(false);
    }
    }
}