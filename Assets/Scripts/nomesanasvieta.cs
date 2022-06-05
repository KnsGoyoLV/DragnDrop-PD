using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jāimportē, lai varētu piesaistīt IDropHandler interfeisu un lietot OnDrop funkciju
using UnityEngine.EventSystems;

public class nomesanasvieta : MonoBehaviour, IDropHandler
{

    //Uzglabās velkamā objekta rotāciju ap Z asi un noliekamās vietas rotāciju
    //Starpība uzglabās, cik liela Z ass rotācijas leņķa starpība starp abiem objektiem
	private float vietasZrot;

	private float velkamaObjZrot;

	private float rotacijasStarpiba;

	private Vector2 vietasIzm;

	private Vector2 velkamaObjIzm;
   //Uzglabās velkamā objekta un nomešanas vietas izmērus
	private float xIzmeruStarpiba;
  //Uzglabās objektu x un y ass izmētu starpību
	private float yIzmeruStarpiba;
//Norāde uz skriptu Objekti
	public objekti objektuSkripts;
	//Nostradā, ja objektu cenšas nomest uz nometamā lauka
	public void OnDrop(PointerEventData notikums)
	{
		//Pārbauda vai kāds objekts tiek vilkts un nomests
		if (notikums.pointerDrag != null)
		{
			//Ja nomešanas laukā uzmestā attēla tags sakrīt ar lauka tagu
			if (notikums.pointerDrag.tag.Equals(tag))
			{
				//Iegūst objektu rotāciju grādos
				vietasZrot = notikums.pointerDrag.GetComponent<RectTransform>().transform.eulerAngles.z;
				velkamaObjZrot = GetComponent<RectTransform>().transform.eulerAngles.z;
				//Aprēķina rotācijas starpību
				rotacijasStarpiba = Mathf.Abs(vietasZrot - velkamaObjZrot);
				//Iegūst objektu izmērus
				vietasIzm = notikums.pointerDrag.GetComponent<RectTransform>().localScale;
				velkamaObjIzm = GetComponent<RectTransform>().localScale;
				xIzmeruStarpiba = Mathf.Abs(vietasIzm.x - velkamaObjIzm.x);
				yIzmeruStarpiba = Mathf.Abs(vietasIzm.y - velkamaObjIzm.y);
                //Pārbauda vai objektu savstarpējā rotācija neatšķiras vairāk par 9 grādiem
                //un vai x un y izmēri neatšķiras vairāk par 0.15
				if ((rotacijasStarpiba <= 9 || (rotacijasStarpiba >= 355 && rotacijasStarpiba <= 360)) && (double)xIzmeruStarpiba <= 0.15 && (double)yIzmeruStarpiba <= 0.15)
				{
					objektuSkripts.vaiIstajaVIeta = true;
					//Nometamo objektu iecentrē nomešanas vietā
					notikums.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
					//Pielāgo nomestā objekta rotāciju
					notikums.pointerDrag.GetComponent<RectTransform>().localRotation = GetComponent<RectTransform>().localRotation;
					//Pielāgo nomestā objekta izmēru
					notikums.pointerDrag.GetComponent<RectTransform>().localScale = GetComponent<RectTransform>().localScale;
					
					 /*Pārbauda pēc tagiem, kurš no objektiem ir pareizi nomests, tad 
                    atskaņo atbilstošo skaņu*/
					switch (notikums.pointerDrag.tag)
					{
					case "Police":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[1]);
						break;
					case "Trac":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[2]);
						break;
					case "b2":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[3]);
						break;
					case "Autobuss":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[4]);
						break;
					case "Ambulance":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[5]);
						break;
					case "GarbageTruck":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[6]);
						break;
					case "cement":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[7]);
						break;
					case "firetruck":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[9]);
						break;
					case "ESC":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[10]);
						break;
					case "TRacYellow":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[11]);
						break;
					case "e47":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[14]);
						break;
					}
					Debug.Log("Nedefinēts tags!");
				}
			}
			//Ja objektu tagi neskarīt un nomet nepareizajā vietā
			else
			{
				objektuSkripts.vaiIstajaVIeta = false;
				//Atskaņo skaņu
				objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[0]);
				                /*Atkarībā no objektu taga, kurš tika vilkts, 
                 * objekt uaizbīda uz tā sākotnējām koordinātām*/
				switch (notikums.pointerDrag.tag)
				{
				case "GarbageTruck":
					objektuSkripts.atkritumuMasina.GetComponent<RectTransform>().localPosition = objektuSkripts.atkrKoord;
					break;
				case "Ambulance":
					objektuSkripts.atroMasina.GetComponent<RectTransform>().localPosition = objektuSkripts.atroKoord;
					break;
				case "Autobuss":
					objektuSkripts.autobuss.GetComponent<RectTransform>().localPosition = objektuSkripts.bussKoord;
					break;
				case "cement":
					objektuSkripts.cementaMasina.GetComponent<RectTransform>().localPosition = objektuSkripts.cemexKoord;
					break;
				case "e47":
					objektuSkripts.e46.GetComponent<RectTransform>().localPosition = objektuSkripts.e46Koord;
					break;
				case "ESC":
					objektuSkripts.eskavators.GetComponent<RectTransform>().localPosition = objektuSkripts.eskavatorsKoord;
					break;
				case "Police":
					objektuSkripts.policija.GetComponent<RectTransform>().localPosition = objektuSkripts.policijaKoord;
					break;
				case "TRacYellow":
					objektuSkripts.dzeltenaisTraktors.GetComponent<RectTransform>().localPosition = objektuSkripts.dzTraktorsKoord;
					break;
				case "Trac":
					objektuSkripts.traktorsArPiekabi.GetComponent<RectTransform>().localPosition = objektuSkripts.tArPiekabiKoord;
					break;
				case "firetruck":
					objektuSkripts.ugunsdzeseji.GetComponent<RectTransform>().localPosition = objektuSkripts.ugunsdzesejiKoord;
					break;
				default:
					Debug.Log("Objektam nav noteikta pārvietošanas vieta!");
					break;
				}
			}
		}
	}
}
