using System;
using workingcode.util;

class VendingMachine {
	static void Main() {
		XMLStateMachine fsm = new XMLStateMachine();
		fsm.StateTable = "vending.xml";
		fsm.CurrentState ="start";

		Random rnd = new Random();

		while ( fsm.Action != "dispense" ) {
			int coin = rnd.Next(0, 3);
			switch (coin) {
				case 0:
					fsm.Next("nickel");
					Console.WriteLine("Customer inserted a nickel.");
				break;
				case 1:
					fsm.Next("dime");
					Console.WriteLine("Customer inserted a dime.");
				break;
				case 2:
					fsm.Next("quarter");
					Console.WriteLine("Customer inserted a quarter.");
				break;
			}
		}
		
		Console.WriteLine("Dispensing can. Enjoy your soda!");
	}
}