﻿using UnityEngine;
using System.Collections;

public class PerasEvent : ButtonEvent {

	private Skill skill;
	
	// Use this for initialization
	void Start () {
		skill = GetComponent<Skill>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void DoEvent(){
		skill.DoSkill(3);
	}
}
