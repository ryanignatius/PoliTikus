using UnityEngine;
using System.Collections;

public class CharEvent : ButtonEvent {
	
	public int num;
	
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
		if (player.action_type == 1){ // move
			player.MoveCharacter(player.cur_player*7+(num-1));
			player.RenderText();
		} else if (player.action_type >= 10) { // skill
			player.UseSkill(player.player_select.id*7+(num-1));
			player.RenderText();
		}
		player.button_selectchar.SetActive(false);
		player.button.SetActive(true);
		if (player.action_type >= 10){ // skill
			player.player_select.gameObject.SetActive(false);
		}
		DoExit();
	}
	
	public override void DoEnter(){
		if (player == null){
			player = GameObject.Find ("PlayerController").GetComponent<PlayerController>();
		}
		if (spinner == null){
			spinner = GameObject.Find ("Spinner");
		}
		if (player.action_type >= 10){ // skill
			spinner.transform.position = new Vector3(
				player.chars[player.player_select.id*7+(num-1)].transform.position.x,
				player.chars[player.player_select.id*7+(num-1)].transform.position.y,
				-1
				);
		} else {
			spinner.transform.position = new Vector3(
				player.chars[player.cur_player*7+(num-1)].transform.position.x,
				player.chars[player.cur_player*7+(num-1)].transform.position.y,
				-1
			);
		}
		//spinner.SetActive(true);
	}
	
	public override void DoExit(){
		spinner.transform.position = new Vector3(10,0,-1);
		//spinner.SetActive(false);
	}
}
