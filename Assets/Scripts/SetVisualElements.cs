using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Set visual elements to the transition screen 
 */
public class SetVisualElements : MonoBehaviour {

	public Sprite[] leftCharactersList;
	public Sprite[] rightCharactersList;
	public Sprite[] backgroundList;
	Image bg;
	Image imgLeft;
	Image imgRight;
	Image boardRight;
	Image boardLeft;
	Text tipTxtRight;
	Text tipTxtLeft;
	List <string> Tips;
	//----------------------------------------------------------
	void Awake () 
	{
		getTips ();
		getUIComponents ();
		setUIComponents ();
	}
	//----------------------------------------------------------
	private void getUIComponents()
	{
		bg = GameObject.Find("UIBackground").GetComponent<Image>();

		boardRight = GameObject.Find("BoardRight").GetComponent<Image>();
		boardLeft = GameObject.Find("BoardLeft").GetComponent<Image>();

		imgLeft = GameObject.Find("CharacterLeftImg").GetComponent<Image> ();
		imgRight = GameObject.Find("CharacterRightImg").GetComponent<Image> ();

		tipTxtRight = GameObject.Find("TipTextRight").GetComponent<Text> ();
		tipTxtLeft = GameObject.Find("TipTextLeft").GetComponent<Text> ();
	}
	//----------------------------------------------------------
	private void setUIComponents()
	{
		int option = Random.Range(0, 2);
		int numTip = Random.Range (0,Tips.Count);

		if(option == 0){
			
			int characterOptionLeft = Random.Range(0, leftCharactersList.Length);
			imgLeft.sprite = leftCharactersList[characterOptionLeft];

			imgLeft.enabled = true;
			imgRight.enabled = false;
			tipTxtRight.enabled = true;
			tipTxtRight.text = Tips[numTip];
			tipTxtLeft.enabled = false;
			boardLeft.enabled = false;
			boardRight.enabled = true;

		}else{
			
			int characterOptionRight = Random.Range(0, rightCharactersList.Length);
			imgRight.sprite = rightCharactersList[characterOptionRight];

			imgLeft.enabled = false;
			imgRight.enabled = true;
			tipTxtLeft.enabled = true;
			tipTxtLeft.text = Tips[numTip];
			tipTxtRight.enabled = false;
			boardLeft.enabled = true;
			boardRight.enabled = false;
		}

		int backgroudOption = Random.Range (0, backgroundList.Length);
		bg.sprite = backgroundList[backgroudOption];
		bg.enabled = true;
	
	}
	//----------------------------------------------------------
	private void getTips()
	{
		Tips = new List<string>();
		Tips.Add ("Reciclar: Consiste en recoger y procesar los desechos para luego obtener productos nuevos.");
		Tips.Add ("Reducir: Se trata de evitar todas las acciones que generen desperdicios y residuos innecesariamente.");
		Tips.Add ("Reutilizar: Busca aprovechar los desechos para crear nuevos productos y darles otros usos.");
		Tips.Add ("Basureros de color verde, aqui van los desechos orgánicos como restos de alimentos, frutas, verduras, cascaras y residuos de jardin.");
		Tips.Add ("Basureros de color azul, aqui van los desechos de envases como botellas y bolsas o envases plasticos.");
		Tips.Add ("Basureros de color café, aqui van los desechos de manejo especial como baterías y aparatos electrónicos.");
		Tips.Add ("Basureros de color amarillo, aqui van los desechos de aluminio como latas, sartenes y cubiertos hechos de aluminio.");
		Tips.Add ("Basureros de color anaranjado, aqui van los desechos de vidrio como botellas, vasos, tazas y cristales, todos hechos de vidrio.");
		Tips.Add ("Basurero de color gris, aqui van los desechos de papel y cantón como revistas, cuadernos, periódicos, sobres y cajas de cartón.");
		Tips.Add ("Basurero de color negro, aqui van los desechos ordinarios como papel higuíenico, servilletas, residuos del barrido, residuos del jardin.");
		Tips.Add ("Una buena práctica para reducir el gasto de agua, es tomar duchas cortas.");
		Tips.Add ("Una buena práctica para reducir el gasto de agua, es cerrar la llave al lavarse los dientes, las manos o los platos.");
		Tips.Add ("Una buena práctica para reducir el gasto de agua, es decirle a otras personas cuando el grifo está goteando.");
		Tips.Add ("Una buena práctica para reducir el gasto de agua, es tomarse el agua que se sirve en un vaso.");
		Tips.Add ("Una buena práctica para la conservación de la energía, es apagar la luz cuando no la necesite.");
		Tips.Add ("Una buena práctica para la conservación de la energía, es utilizar la luz del día en vez de un bombillo.");
		Tips.Add ("Una buena práctica para la conservación de la energía, es apagar el aire acondicionado cuando no se necesite.");
		Tips.Add ("Una buena práctica para la conservación de la energía, es apagar el televisor cuando no esté en uso.");
		Tips.Add ("Una buena práctica para la conservación de la energía, es desconectar todos los enchufes cuando no este usando los aparatos.");
		Tips.Add ("Una buena práctica para la conservación de la energía, es utilizar un bombillo de menos consumo eléctrico como las LED.");
		Tips.Add ("La contaminación es el conjunto de todas las acciones del ser humano que dañan y enferman a nuestro planeta.");
		Tips.Add ("Una forma de contaminación es la del aire, ejemplo de esto sería la quema de combustible fósil, consumo de tabaco, productos de limpieza, etc...");
		Tips.Add ("Una forma de contaminación es la del agua, ejemplo de esto sería la tira de residuos, desechos químicos de fábricas, derramamiento de petreolo, etc...");
		Tips.Add ("Una forma de contaminación es la acústica o sonido, ejemplo de esto sería el tráfico de las calles, areas de construcción, los conciertos de rock, etc...");
		Tips.Add ("Los carros emiten mucho dióxido de carbono (CO2) por lo que se consideran una de las formas más comunes de contaminación.");
		Tips.Add ("La emisión de gases causa que el planeta se caliente, daña la vegetación, afecta el agua, repercute en los animales y a nosotros.");
		Tips.Add ("Una forma de transporte saludable, es usar el transporte público.");
		Tips.Add ("Una forma de transporte saludable, es montar en bicicleta.");
		Tips.Add ("Una forma de transporte saludable, es utilizar automóviles elétricos.");
		Tips.Add ("Una forma de transporte saludable, es compartir un carro con conocidos que van al mismo lugar.");
		Tips.Add ("Las plantas ayudan a disminuir la cantidad de CO2 en el planeta porque lo absorbe y lo convierte en oxígeno a través de un proceso llamado fotosíntesis.");
		Tips.Add ("Las plantas son una importante clave de nuestra sobrevivencia porque produce óxigeno.");
		Tips.Add ("Hay que cuidar nuestros parque nacionales, evitando acciones como tirar residuos, alimentar sin permiso a los animales, tocar los animales o las plantas.");
		
	}
	//----------------------------------------------------------
}
