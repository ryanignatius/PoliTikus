using UnityEngine;
using System.Collections;

public class HireEvent : ButtonEvent {
	
	public int hire_ap = 2;
	public int hire_money = 10;
	
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
		if (player.main_player[player.cur_player].num_char < 7 && 
		    player.main_player[player.cur_player].ap >= hire_ap && 
		    player.main_player[player.cur_player].money >= hire_money){
			
			player.action_type = 2;
			player.button.SetActive(false);
			player.button_selecttower.SetActive(true);
		}
	}
}
