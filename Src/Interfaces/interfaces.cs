using Godot;
using System;

Public interface ICardInfo{ 
	Units CardOwner {
		get;set;
	}
	
	// For a healing card just get a negative
	int Damage {
		get;set;
	}
	
	Units Targets {
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


Public interface IUnitInfo {
	String Name {
		get;set;
	}
	
	int Health {
		get;set;
	}

	int Sanity {
		get;set;
	}
	
	int Rumia {
		get;set;
	}
	
	int Strength {
		get;set;
	}
	
	int Intelligence {
		get;set;
	}
	
	int Defence {
		get;set;
	}
	
	int Speed {
		get;set;
	}
}
