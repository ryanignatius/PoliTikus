using UnityEngine;
using System.Collections;

public class MoveEvent : ButtonEvent {
	
	public int move_ap = 2;
	
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
		if (player.main_player[player.cur_player].ap >= move_ap){
			//player.main_player[player.id-1].ap -= move_ap;
			player.action_type = 1;
			player.button.SetActive(false);
			player.button_selectchar.SetActive(true);
			for (int i=0; i<7; i++){
				player.button_chars[i].SetActive(player.chars[player.cur_player*7+i].is_active
				&& (!player.chars[player.cur_player*7+i].is_move));
			}
		}
	}
}
