using UnityEngine;
using System.Collections;

public class UbahKarakterEvent : ButtonEvent {

	private GameObject[] characters;
	private int cur;
	
	// Use this for initialization
	void Start () {
		characters = new GameObject[11];
		characters[0] = GameObject.Find ("STARTER PEDI-01");
		characters[1] = GameObject.Find ("STARTER PEDI-02");
		characters[2] = GameObject.Find ("STARTER PEDI-03");
		characters[3] = GameObject.Find ("STARTER DEMI-04");
		characters[4] = GameObject.Find ("STARTER DEMI-05");
		characters[5] = GameObject.Find ("STARTER DEMI-06");
		characters[6] = GameObject.Find ("STARTER DEMI-07");
		characters[7] = GameObject.Find ("STARTER GERI-08");
		characters[8] = GameObject.Find ("STARTER GERI-09");
		characters[9] = GameObject.Find ("STARTER GOLI-10");
		characters[10] = GameObject.Find ("STARTER GOLI-11");
		cur = 0;
		for (int i=1; i<11; i++){
			characters[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void DoEvent(){
		characters[cur].SetActive(false);
		cur++;
		cur %= 11;
		characters[cur].SetActive(true);
	}
	
	public override void DoEnter(){
		transform.Translate(0f,0f,-5f);
	}
	
	public override void DoExit(){
		transform.Translate(0f,0f,5f);
	}
}
