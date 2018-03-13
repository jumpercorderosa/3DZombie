using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemScript : MonoBehaviour {

	public GameObject Personagem;
	public float velocidade;

	Vector3 novaPosicao;
	Animation ani;

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.tag == "item") {
			Destroy (c.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
		//Captura a posicao inicial do personagem
		novaPosicao = transform.position;
		ani = Personagem.GetComponent<Animation> ();

		//Defini a animação inicial do personagem
		ani.CrossFade("idle");

	}
	
	// Update is called once per frame
	void Update () {

		//Touch ou clique do mouse
		if (Input.GetButton ("Fire1")) {
			//if(Input.GetButtonDown("Fire1")) {

			//Transforma o clique na tela em coordenada 3D
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			//Obtem a nova posição
			if (Physics.Raycast (ray, out hit)) {
				novaPosicao = hit.point;
			}

			//Animacao de idle
			ani.CrossFade("run");

			transform.position = Vector3.MoveTowards (transform.position, novaPosicao, velocidade * Time.deltaTime);
			transform.LookAt(hit.point);

			//Move o personagem
			//transform.position = Vector3.Lerp(transform.position, novaPosicao, velocidade * Time.deltaTime);

				
		} else {
			//Animacao de idle
			ani.CrossFade("idle");
		}
	}
}
