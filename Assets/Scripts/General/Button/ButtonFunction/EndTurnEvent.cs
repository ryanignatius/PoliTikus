using UnityEngine;
using System.Collections;

public class EndTurnEvent : ButtonEvent {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void DoEvent(){
		if (player == null){
			player = GameObject.Find ("PlayerController").GetComponent<PlayerController>();
		}
		player.EndTurn();
	}
}
