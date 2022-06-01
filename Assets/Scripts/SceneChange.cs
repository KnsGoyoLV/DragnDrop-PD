using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IzvelneiScript : MonoBehaviour
{
    public void uzIzvelnei()
    {
        SceneManager.LoadScene("MainStart", LoadSceneMode.Single);
    }
}
   
