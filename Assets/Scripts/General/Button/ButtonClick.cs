using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ButtonEvent))]

public class ButtonClick : MonoBehaviour {

	private SpriteRenderer pic;
	private Color temp,temp2;
	private ButtonEvent eve;
	
	// Use this for initialization
	void Start () {
		pic = GetComponent<SpriteRenderer>();
		eve = GetComponent<ButtonEvent>();
		temp = new Color(pic.color.r/2,pic.color.g/2,pic.color.b/2,pic.color.a);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown(){
		temp2 = pic.color;
		pic.color = temp;
	}
	
	void OnMouseUp(){
		pic.color = temp2;
	}
	
	void OnMouseUpAsButton(){
		pic.color = temp2;
		eve.DoEvent();
	}
	
	void OnMouseEnter(){
		eve.DoEnter();
	}
	
	void OnMouseExit(){
		eve.DoExit();
	}
}
