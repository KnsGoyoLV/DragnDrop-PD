using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class dragdropskripts : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
	//Uzglabās norādi uz Objektu skriptu
	public objekti objektuSkripts;

	//public beigaspele uzvarasNoteicejaSkripts;
//Velkamam objektam piestiprinātā komponente
	private CanvasGroup kanvasGrupa;

	//Vilktā objekta atrašanās vietas koordinātu maiņai
	private RectTransform velkObjRectTransf;
	
	private void Awake()
	{
		//Piekļūst objektam piesaistītajai CanvasGroup komponentei
		kanvasGrupa = GetComponent<CanvasGroup>();
		//Piekļūst objekta RectTransform komponentei
		velkObjRectTransf = GetComponent<RectTransform>();
	}

	//Nostrādā nospiežot peles klikšķi uz objekta
	public void OnPointerDown(PointerEventData notikums)
	{
		Debug.Log("Uzklikšķināts uz velkamā objekta");
	}

	   //Nostrādā uzsākot vilkšanu
	public void OnBeginDrag(PointerEventData notikums){
		Debug.Log("Uzsākta vilkšana");
		//Attīra pēdējo vilkto objektu
		objektuSkripts.pedejaisVilktais = null;
		//Uzsākot vilkt objektu tas paliek nedaudz caurspīdīgs
		kanvasGrupa.alpha = 0.6f;
		//Lai objektam varētu iet cauri raycast stars
		kanvasGrupa.blocksRaycasts = false;
	}

	//Nostrādā reāli notiekot vilkšanai
	public void OnDrag(PointerEventData notikums)
	{
		Debug.Log("Notiek vilkšana");
		velkObjRectTransf.anchoredPosition += notikums.delta / objektuSkripts.kanva.scaleFactor;
		
	}

	   //Nostrādā, kad tiek beigta vilkšana
	public void OnEndDrag(PointerEventData notikums)
	{
		//Atlaižot objektu iestata to kā pēdējo vilkto
		objektuSkripts.pedejaisVilktais = notikums.pointerDrag;
		Debug.Log("Pēdējais vilktais objekts " + objektuSkripts.pedejaisVilktais);
		Debug.Log("Beigta vilkšana");
		 //Atlaižot objektu tas atkal paliek necaurspīdīgs
		kanvasGrupa.alpha = 1f;
		//Pārbauda vai objekts ir vienkārši nomest vai arī nomests pareizajā vietā
		if (objektuSkripts.vaiIstajaVIeta == false)
		{
			kanvasGrupa.blocksRaycasts = true;
		}
		else
		{
			           /*Ja ojbkets nolikts pareizajā vietā, izmērā, rotācijā, tad
            pēdējo vilkto attīra*/
			objektuSkripts.pedejaisVilktais = null;
		//	pareiziNomestoSkaits++;
		}
		        /*Ja viens objekts nomests pareizajā vietā, tad lai varētu turpināt
        pārvietot pārējos objektus*/
		objektuSkripts.vaiIstajaVIeta = false;
	}
	//public int pareiziNomestoSkaits;
}
