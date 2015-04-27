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
		if (player.isAct){
			player.main_player[player.cur_player].ap = 0;
			player.main_player[player.cur_player].money += player.main_player[player.cur_player].money_income;
			player.main_player[player.cur_player].cur_fame = player.main_player[player.cur_player].max_fame;
		}
		player.EndTurn();
	}
}
