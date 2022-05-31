using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagment;

public class Izvelne1Script : MonoBehavior {
    public void uzIvelni{
        Scene.Manager.LoadScene("MainStart",LoadSceneMode.Single);
     }
}
