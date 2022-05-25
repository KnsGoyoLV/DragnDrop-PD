using System;
using UnityEngine;


public class objektutransformesana : MonoBehaviour
{
	//Uzglabā norādi uz Objektu skriptu
	public objekti objektuSkripts;
	private void Update()
	{
		//Ja ir kāds pēdējais vilktais objekts, tad var veikt darbības ar to
        if(objektuSkripts.pedejaisVilktais != null)
        {
            //Nospiežot pogu Z objektu var rotēt pretēji pulksteņrādītāja virzienam
            if (Input.GetKey(KeyCode.Z))
            {
                objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.Rotate(0, 0, Time.deltaTime * 9f);
            }

            //Nospiežot pogu X objektu var rotēt pulksteņrādītāja virzienā
            if (Input.GetKey(KeyCode.X))
            {
                objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.Rotate(0, 0, -Time.deltaTime * 9f);
            }


            //Nospiežot bultiņu pa kreisi, iespējams objektu stiept šaurāku pa x asi
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //Lai objektu nevar izstiept mīnusā
                if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x > 0.35)
                {
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().localScale =
                        new Vector2(objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x - 0.001f,
                        objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y);
                }
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Lai objektu nevar izstiept pārāk palašu pa x asi
                if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x < 0.9)
                {
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().localScale =
                        new Vector2(objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x + 0.001f,
                        objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y);
                }
            }

            //Nospiežot bultiņu uz augšu, objektu stiepj lielāku pa y asi
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y < 0.8)
                {
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().localScale =
                        new Vector2(objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x,
                        objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y + 0.001f);
                }
            }

            //Nospiežot bultiņu uz leju, objektu stiepj šaurāku pa y asi
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y > 0.35)
                {
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().localScale =
                        new Vector2(objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x,
                        objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y - 0.001f);
                }
			}
        }
    }
}