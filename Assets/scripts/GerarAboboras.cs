using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarAboboras : MonoBehaviour {

	public float limiteEsquerdo, limiteDireito, limiteFrontal, limiteTraseiro;
	public float frequencia;
	public GameObject aboboraPrefab;

	// Use this for initialization
	IEnumerator Start () {

		yield return new WaitForSeconds (Random.Range (3.0f, frequencia));
		Vector3 posicao = new Vector3 ();
		posicao.x = Random.Range(limiteEsquerdo, limiteDireito);
		posicao.y = transform.position.y;
		posicao.z = Random.Range (limiteFrontal, limiteTraseiro);
		Instantiate (aboboraPrefab, posicao, transform.rotation);
		StartCoroutine (Start ());

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
