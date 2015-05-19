using UnityEngine;
using System.Collections;

public class KoleksiEvent : ButtonEvent {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void DoEvent(){
		
	}
	
	public override void DoEnter(){
		transform.Translate(0f,0f,-5f);
	}
	
	public override void DoExit(){
		transform.Translate(0f,0f,5f);
	}
}
