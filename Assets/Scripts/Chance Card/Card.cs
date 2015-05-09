using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	private PlayerController player;
	
	private ToolsEffect tools_effect;
	private PositiveEventEffect positive_event_effect;
	private NegativeEventEffect negative_event_effect;
	private NeutralEventEffect neutral_event_effect;
	
	// Use this for initialization
	void Start () {
		tools_effect = new ToolsEffect();
		positive_event_effect = new PositiveEventEffect();
		negative_event_effect = new NegativeEventEffect();
		neutral_event_effect = new NeutralEventEffect();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void DrawCard(int d){
		if (d < ChanceCard.tools_name.Length){
			// tools
			if (player == null){
				player = GameObject.Find ("PlayerController").GetComponent<PlayerController>();
			}
			if (player.main_player[player.cur_player].num_tools == 2){
				player.main_player[player.cur_player].tools[0] = 
					player.main_player[player.cur_player].tools[1];
				player.main_player[player.cur_player].tools[1] = d;
			} else {
				player.main_player[player.cur_player].
					tools[player.main_player[player.cur_player].num_tools] = d;
				player.main_player[player.cur_player].num_tools++;
			}
		} else {
			// event
			DoEffectCard(d);
		}
	}
	
	public void DoEffectCard(int d){
		if (d < ChanceCard.tools_name.Length){
			// tools
			if (player == null){
				player = GameObject.Find ("PlayerController").GetComponent<PlayerController>();
			}
			tools_effect.DoToolsEffect(d);
		} else {
			// event
			// positive
			if (d == 5){
				
			} else if (d == 6){
				
			} else if (d == 7){
				
			} else if (d == 8){
				
			} else if (d == 9){
				
			} else if (d == 10){
				
			} else if (d == 11){
				
			} else if (d == 12){
				
			} else if (d == 13){
				
			} else
			// negative
			if (d == 14){
				
			} else if (d == 15){
				
			} else if (d == 16){
				
			} else if (d == 17){
				
			} else if (d == 18){
				
			} else if (d == 19){
				
			} else if (d == 20){
				
			} else if (d == 21){
				
			} else
			// netral
			if (d == 22){
				
			} else if (d == 23){
				
			} else if (d == 24){
				
			} else if (d == 25){
				
			} else if (d == 26){
				
			}
		}
	}
}
