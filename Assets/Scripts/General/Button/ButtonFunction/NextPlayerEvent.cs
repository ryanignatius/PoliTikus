using UnityEngine;
using System.Collections;

public class NextPlayerEvent : ButtonEvent {

	public int val;

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
		player.player_select.SetID(player.player_select.id+val);
	}
}
