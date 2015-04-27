using UnityEngine;
using System.Collections;

public class BackEvent : ButtonEvent {

	public string prev;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void DoEvent(){
		Debug.Log ("back "+prev);
		Application.LoadLevel(prev);
	}
}
