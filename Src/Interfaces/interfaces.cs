using Godot;
using System;

public interface ICardInfo{ 
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
	
	string CardName {
		get;set;
	}
	
	string CardEffect {
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


public interface IUnitInfo {
	string Name {
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
