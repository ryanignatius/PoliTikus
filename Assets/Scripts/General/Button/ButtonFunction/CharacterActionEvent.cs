using UnityEngine;
using System.Collections;

public class CharacterActionEvent : ButtonEvent {
	
	private MovePlayer mp;
	
	// Use this for initialization
	void Start () {
		mp = GetComponent<MovePlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void DoEvent(){
		if (player == null){
			player = GameObject.Find ("PlayerController").GetComponent<PlayerController>();
		}
		if (player.cur_player == ((mp.player_id-1)/7)
		    && player.chars[mp.player_id-1].is_active
		    && (!player.chars[mp.player_id-1].is_move)){
			if (player.action_type == 1){ // move
				player.MoveCharacter(mp.player_id-1);
				player.RenderText();
			} else if (player.action_type >= 10) { // skill
				player.UseSkill(mp.player_id-1);
				player.RenderText();
			}
			
			//player.button_selectchar.SetActive(false);
			//player.button.SetActive(true);
			if (player.action_type >= 10){ // skill
				player.player_select.gameObject.SetActive(false);
			}
			DoExit();
		}
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
				player.chars[mp.player_id-1].transform.position.x,
				player.chars[mp.player_id-1].transform.position.y,
				-1
				);
		} else {
			spinner.transform.position = new Vector3(
				this.transform.position.x,
				this.transform.position.y,
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
