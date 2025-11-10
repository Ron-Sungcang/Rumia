using Godot;
using System;

Public interface CardInfo{ 
	Unit CardOwner {
		get;set;
	}
	
	// For a healing card just get a negative
	int Damage {
		get;set;
	}
	
	Unit Targets {
		get;set;
	}
	
	String CardName {
		get;set;
	}
	
	String CardEffect {
		get;set;
	}
	
	bool CardSelected {
		get;set;
	}
	
	bool CardPlayed {
		get;set;
	}
	
	bool CardUsed {
		get;set;
	}
}
