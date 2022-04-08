/**********************************************************************************************************

												   On the Ship
												 by: Steven Torres
                                                    CSC 240
                                                   March 2022
                                                 Assignment #2
                     
ABOUT THE GAME:
You were sent out on a planet scouting mission to the nearby unexplored planet to see whether its habitable or not for 
future settlement. On the way back, a stowaway finds its way on your ship, but he isn't the friendly kind either, 
disrupting your journey back to the outpost. Will you make it back to the outpost? Or will the stowaway make everything
go to the worst-case scenario?

WARNING:
The game is a survival/puzzle game with some concepts of violence and death. Therefore, this is rated PG-13 and 
should not be played by anyone under unless authorized by guardian consent or guardian supervision.

PURPOSE:
Provide an intro to C# programming using an Interactive Fiction (IF) text-based game format.

*************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

class OnTheShip{
	//Game variables
	public static bool HaveRifle= false;
	public static bool HaveLantern= false;
	public static bool HaveFirstAid= false;
	public static bool HaveTools=false;
	public static bool EngineRepair=false;
	public static bool biter=true;
	public static int MaxPlayerHealth= 80;
	public static int MaxBiterHealth= 100;
	public static int maxPlasmaRifleDmaage= 50;
	public static int maxPistolDamage=10;
	public static int maxBiterDamage= 20;
	public static int playerCurrentHealth = MaxPlayerHealth;
	public static int biterCurrentHealth= MaxBiterHealth;
	public static List<string> inventory = new List<string>();  

	public static void Main() {
	variableReset();
    Introduction();
	Cockpit();
	}
  
	//Game Introduction
	static void Introduction(){
	Console.Clear();

	//Who game was made by
	Console.WriteLine("On the Ship");
	Console.WriteLine("by: Steven Torres");
	Console.WriteLine("CSC240");
	Console.WriteLine("March 2022");
	Console.WriteLine("Assignment #2");
	Console.WriteLine();
	Console.WriteLine("/////////////////////////////////////////////////////////");

	//Game synopsis
	Console.WriteLine();
	Console.WriteLine("ABOUT THE GAME:");
	Console.WriteLine("You were sent out on a scouting mission to a nearby unexplored planet to see if it is habitable or not");
	Console.WriteLine("for future settlement. On the way back, a stowaway found their way on your ship,however he isn't the friendly");
	Console.WriteLine("kind, thus, disrupting your journey back to the outpost. Will you make it back to the outpost? Or will the ");
	Console.WriteLine("stowaway make everything go to the worst-case scenario?");
	Console.WriteLine();

	//Game Commands
	Console.WriteLine("Commands are as follows: directions (N,S,E,W,NE,NW,SE,SW), take <item>, I/inventory and look");
	Console.WriteLine();
	Console.WriteLine("/////////////////////////////////////////////////////////");

	//Game Warning
	Console.WriteLine();
	Console.WriteLine("WARNING:");
	Console.WriteLine("The game is a survival, puzzle game with some concepts of violence and death. Therefore, this is rated PG-13 and");
	Console.WriteLine("should not be played by anyone under unless authorized by guardian consent or guardian supervision.");
	Console.WriteLine();
	Console.WriteLine("/////////////////////////////////////////////////////////");

	//Character name creation
	Console.Write("Please enter your character's name to start: ");
	string name = Console.ReadLine();

	//Prolougue
	Console.WriteLine();
	Console.WriteLine($"Scout {name},");
	Console.WriteLine();
	Console.WriteLine("   Your ship has entered the atmosphere and the ships interphase indicates everything is stable and well. It's a");
	Console.WriteLine("2-hour drive from the outpost where you're supposed to deliver the charted map of the new planet that you were ");
	Console.WriteLine("assigned to explore. \"Supplies are still in stock, and it's going to be a smooth cruise\" you think to yourself.");
	Console.WriteLine("Suddenly, the sensor alarm goes off, indicating multiple objects ahead. Turns out they're just a cluster of");
	Console.WriteLine("asteroids, small but not critical to the ship.You redirect power from the cannons to the forward shields, so they");
	Console.WriteLine("won't damage the hull. The faint noise of the energy shields taking the hit is heard across the cockpit, but ");
	Console.WriteLine("nothing to worry about. You keep pressing forward through the asteroid belt, eventually reaching open space. The");
	Console.WriteLine("outpost is still 2 hours away, all being sub light speed of course, though no gate nearby means no lightspeed, ");
	Console.WriteLine("so autopilot is the way to go. You decide to close your eyes while the auto pilot is engaged, giving yourself");
	Console.WriteLine("some time to nap.");
	Console.WriteLine("   The loud sound of an alarm going off awoke you. You look at the time, 14:50, only an hour has gone. The ");
	Console.WriteLine("ship has stopped moving, with emergency power switched on. With the outpost being an hour away, knowing you were ");
	Console.WriteLine("sent to scout, meaning no human nearby, you're stuck. You must figure out how to get the ship back online and ");
	Console.WriteLine("continue the route to the outpost. ");
	Console.WriteLine();
	Console.WriteLine("Press Enter to continue.");
	Console.ReadLine();
	}

	/// WIN AND LOOSE CONDITIONS
	static void LossConiditon(){  ////achived by pushing engine start wihtout repairing
		Console.WriteLine();
		Console.WriteLine("You sit back down in your commander's seat and start the engine. The systems start booting up, and after nearly ");
		Console.WriteLine("finishing the systems check, your interphase starts to light up red, reading: SYSTEMS CRITICAL! ABORT! The next");
		Console.WriteLine("thing you hear is a loud explosion, along with the heat coming through the door to be engulfed in flames. The ");
		Console.WriteLine("engine wasn't repaired and it overloaded, causing for a total system failure. The ship exploded.");
	}

	static void WinCondition(){  //achived after repairing engine and pushing engine start
		Console.WriteLine();
		Console.WriteLine("You sit back down in your commander's seat and start the engine. The systems start booting up and after the system ");
		Console.WriteLine("check, you get the green lit signal. You're ready to continue the journey back to the outpost. Thrusters full power");
		Console.WriteLine("and you're on your way!");
		Console.WriteLine();
	}
	static void LossCombat(){  //achives by dying in combat
		Console.WriteLine();
		Console.WriteLine("The Biter delivered its final blow to you, a bite that resulted in cutting your arm artery. Blood is spilling ");
		Console.WriteLine("everywhere, everything is fading black, and you collapse to the floor. No one around you, no way to help yourself, ");
		Console.WriteLine("you lie there.");
	}

	//////////////////////////RESET FOR GAME RESET
	static void variableReset(){
		OnTheShip.HaveRifle= false;
		OnTheShip.HaveLantern= false;
		OnTheShip.HaveFirstAid= false;
		OnTheShip.HaveTools=false;
		OnTheShip.EngineRepair=false;
		OnTheShip.inventory = new List<string>();
		playerCurrentHealth = MaxPlayerHealth;
		biterCurrentHealth= MaxBiterHealth;
		biter=true;
	}

	////////////////////////////CREDITS
	static void Credits(){
	Console.WriteLine("\n\n===============================================================================");
	Console.WriteLine("     OnTheShip");
	Console.WriteLine("     Designed and developed by Steven Torres");
	Console.WriteLine("     Kutztown University Computer Science and Information Technology Department"); 
	Console.WriteLine("     for CSC 240, Assignment #2");  
	Console.WriteLine("     Copyright © 2022");
	Console.WriteLine("===============================================================================\n\n");    
    Environment.Exit(1); // Safely exit the program
  }

	////////HELPER FUNCTION
	static void invalidChoice(string choice){ //// used mainly in switches, not having to type all this out helps. If user types in something that isnt related, a warning is displayed
		Console.WriteLine();
    	Console.WriteLine($"\nSorry, but I do not understand what is {choice}.");
		Console.WriteLine();
	}

	///////////////START OVER FUNCTION
	static void StartOver(){
		Console.WriteLine("You have died.");
		Console.WriteLine();
		Console.WriteLine("-----------------------" );
		Console.Write("\nWould you like to start over? Y/N: ");
			string playerRespond = Console.ReadLine();
    		switch (playerRespond){
				case "Y": case "y": case "Yes": case "yes": case "YES":
					Console.WriteLine("STARTING OVER");
					Console.WriteLine("-------------");
					variableReset();
					Cockpit();
				break;
				case "N": case "n": case "No": case "no": case "NO":
					variableReset();
					Introduction();
				break;
				default:
					invalidChoice(playerRespond);
    	        break;
			}//end switch
	}

//////////////////////////////////////////////////////////////////////////

	//COCKPIT
	static void ViewCockpitEngineOff(){  ////different dialgue to indicate different flags of booleans
		Console.WriteLine();
		Console.WriteLine("The Cockpit");
		Console.WriteLine("-----------");
		Console.WriteLine("You see the ships control panel in front of the chair indicating there is critical damage at the Engine Room. \nThere's the doorway to the south of the cockpit. \nThe lights are extremely dim, with only emergency lights providing low vision. \nThe button for Start Engine is lit red, ready to be pushed.");
		Console.WriteLine("The \"push\" command is avaliable in this room.");
		Console.WriteLine();
	}

	static void ViewCockpitEngineOn(){
		Console.WriteLine();
		Console.WriteLine("The Cockpit");
		Console.WriteLine("-----------");
		Console.WriteLine("You see the control panel no longer blinking, its a clear screen. \nThere's the doorway to the south of the cockpit. \nThe button for Start Engine is lit green, ready to be pushed.");
		Console.WriteLine("The \"push\" command is avaliable in this room.");
		Console.WriteLine();
	}
	
	static void Cockpit(){
	while (true){
		if (OnTheShip.EngineRepair==false){
			ViewCockpitEngineOff();
			Console.Write("\nWhat would you like to do next?: " );
			string playerRespond = Console.ReadLine();
    		switch (playerRespond){
				case "S": case "s": case "go south": case "go South": case "south": case "South":
					theMainCabin();
				break;
				case "look": case "Look" : case "LOOK":
					ViewCockpitEngineOff();
				break;
				case "inventory": case "i": case "I":
					viewInventory();
				break;
				case "push button": case "push":
					LossConiditon();
					StartOver();
				break;
				default:
					invalidChoice(playerRespond);
    	        break;
			}//swiotch end
		}//if end

		else {
			ViewCockpitEngineOn();
			Console.Write("\nWhat would you like to do next?: " );
			string playerRespond = Console.ReadLine();
    		switch (playerRespond){
				case "S": case "s": case "go south": case "go South": case "South": case "south":
					theMainCabin();
				break;
				case "look": case "Look" : case "LOOK":
					ViewCockpitEngineOn();
				break;
				case "inventory": case "i": case "I":
					viewInventory();
				break;
				case "push button": case "push":
					WinCondition();
					Credits();
				break;
				default:
					invalidChoice(playerRespond);
    	        break;
			}//switch end
		}//else end
 	 }//while end
 }//function end

////////// MAIN CABIN
	static void viewMainCabin(){
		Console.WriteLine();
		Console.WriteLine("The Main Cabin");
		Console.WriteLine("--------------");
		Console.WriteLine("There is the doorway to the west leading into the External Exit, to the east the Sleeping Quarters, Southwest ");
		Console.WriteLine("Engine Room, and Southeast the Storage Bay. \nThe Main Cabin consists of a resting area with a couch and a small table with a responsive lantern on top of it.");
		Console.WriteLine();
	}
	
	static void lanternRetreival(){  /////used to indicate if item has been retrived
		if (OnTheShip.HaveLantern==false){
			OnTheShip.HaveLantern=true;
			inventory.Add("Lantern");
			Console.WriteLine();
			Console.WriteLine("You grabbed the lantern and attached it to your suit, allowing you to see better.");
			Console.WriteLine();
		}
		else
			Console.WriteLine("The item no longer exists."); /// used to indicate item has already been retrived and is in inventory
	}

	static void viewNoLantern(){  ///////used to indicate if item has been retrived
		Console.WriteLine();
		Console.WriteLine("The Main Cabin");
		Console.WriteLine("--------------");
		Console.WriteLine("There is the doorway to the west leading into the External Exit, to the east the Sleeping Quarters, Southwest ");
		Console.WriteLine("Engine Room, and Southeast the Storage Bay. \nThe lantern is no longer on the table.");
		Console.WriteLine();
	}
	static void theMainCabin(){
		if (OnTheShip.HaveLantern==false) /////true and false provide different text based on enviroment variables.
			viewMainCabin();
		else
			viewNoLantern();
		while (true){
			Console.Write("\nWhat would you like to do next?: " );
			string playerRespond = Console.ReadLine();
    		switch (playerRespond){
				case "N": case "n": case "go north": case "go North": case "north": case "North":
					Cockpit();
					break;
				case "E": case "e": case "go east": case "go East": case "East": case "east":
					SleepingQuaters();
					break;
				case "W": case "w": case "go west": case "go West": case "west": case "West":
					ExternelExit();
					break;
				case "SE": case "se": case "Se": case "go southeast": case "go SouthEast": case "go south east": case "go South East": case "southeast": case"SouthEast":
					StorageBay();
					break;
				case "SW": case "sw": case "go southwest": case "go SouthWest": case "go south west": case "go South West": case "southwest": case "SouthWest":
					EngineRoom();
					break;
				case "look": case "Look" : case "LOOK":
				if (OnTheShip.HaveLantern==false){
					viewMainCabin();
					break;
				}
				else{				
					viewNoLantern();
				break;
				}
				case "take lantern":
					lanternRetreival();
					break;
				case "inventory": case "i": case "I":
					viewInventory();
				break;
				default:
					invalidChoice(playerRespond);
    	        break;
			}//siwtch end
		}//while end
	}//function end

//// EXTERNAL EXIT
	static void viewExternalExit(){
		Console.WriteLine();
		Console.WriteLine("The External Exit");
		Console.WriteLine("-----------------");
		Console.WriteLine("You see the ramp adjacent from the entrance to the Main Cabin which is east. \nThere is a first aid kit hung against the wall that can be used for personal use.");
		Console.WriteLine();
	}

	static void viewNoFirstAidKit(){
		Console.WriteLine();
		Console.WriteLine("The External Exit");
		Console.WriteLine("-----------------");
		Console.WriteLine("You see the ramp adjacent from the entrance to the Main Cabin which is east. \nThe first aid kit is no longer in it's holder.");
		Console.WriteLine();
	}

	static void firstAidRetrival(){
		if (OnTheShip.HaveFirstAid==false){
			OnTheShip.HaveFirstAid=true;
			inventory.Add("FirstAid kit");
			Console.WriteLine();
			Console.WriteLine("You grabbed the first aid kit and put it into your inventory.");
			Console.WriteLine();
		}
		else
			Console.WriteLine("The item no longer exists.");
	}

	static void ExternelExit(){
		if (OnTheShip.HaveFirstAid==false)
			viewExternalExit();
		else 
			viewNoFirstAidKit();
		while (true){
			Console.Write("\nWhat would you like to do next?: " );
			string playerRespond = Console.ReadLine();
    		switch (playerRespond){
				case "E": case "e": case "go east": case "go East": case "East": case "east":
					theMainCabin();
					break;
				case "look": case "Look" : case "LOOK":
				if (OnTheShip.HaveFirstAid==false){
					viewExternalExit();
					break;
				}
				else{
					viewNoFirstAidKit();
					break;
				}
				case "take first aid": case "take firstaid": case "take First aid": case "take First Aid": case "take first Aid":
					firstAidRetrival();
					break;
				case "inventory": case "i": case "I":
					viewInventory();
				break;
				default:
				invalidChoice(playerRespond);
    	        break;
			}//switch end
		}//while end
	}//function end

/////////SLEEPING QUATERS

	static void viewSleepingQuaters(){
		Console.WriteLine();
		Console.WriteLine("The Sleeping Quarters");
		Console.WriteLine("--------------------");
		Console.WriteLine("You see your bed in the wall, leaving room to walk around. \nThe gun rack holds the plasma rifle. \nThe dresser is against the South wall with all your clothes for the journey.");
		Console.WriteLine("To the West is the Main Cabin.");
		Console.WriteLine();
	}

	static void rifleRetrival(){
		if (OnTheShip.HaveRifle==false){
			OnTheShip.HaveRifle=true;
			inventory.Add("Plasma Rifle");
			Console.WriteLine();
			Console.WriteLine("You grab the plasma rifle from the rack and holister it over your left shoulder.");
			Console.WriteLine();
		}
		else
			Console.WriteLine("The item no longer exists.");
	}

	static void viewNoRifle(){
			Console.WriteLine();
			Console.WriteLine("The Sleeping Quarters");
			Console.WriteLine("--------------------");
			Console.WriteLine("You see your bed in the wall, leaving room to walk around. \nThe gun rack is empty. \nThe dresser is against the South wall with all your clothes for the journey.");
			Console.WriteLine("To the West is the Main Cabin.");
			Console.WriteLine();
	}

	static void SleepingQuaters(){
		if (OnTheShip.HaveRifle==false)
			viewSleepingQuaters();
		else
			viewNoRifle();
		while (true){
			Console.Write("\nWhat would you like to do next?: " );
			string playerRespond = Console.ReadLine();
    		switch (playerRespond){
				case "W": case "w": case "West": case "west": case "go west": case "go West":
					theMainCabin();
					break;
				case "look": case "Look" : case "LOOK":
				if (OnTheShip.HaveRifle== false){
					viewSleepingQuaters();
					break;
				}
				else {
					viewNoRifle();
					break;
				}
				case "take rifle": case "take plasma rifle": case "take plasmarifle": case "take Plasma Rifle":
					rifleRetrival();
					break;
				case "inventory": case "i": case "I":
					viewInventory();
				break;
				default:
				invalidChoice(playerRespond);
    	        break;
			}// switch end
		}// while end
	}// function end

///////////////////////////////////////STORAGE BAY
	static void viewStorageBay(){
		Console.WriteLine();
		Console.WriteLine("The Storage Bay");
		Console.WriteLine("---------------");
		Console.WriteLine("As you walk into the storage bay, you hear loud snapping and crackling noises from the Engine Room to the West.");
		Console.WriteLine("The Main cabin is to the North.");
		if (OnTheShip.HaveTools==false){
			Console.WriteLine("The toolbox is sitting against the wall to the south.");
			Console.WriteLine();
		}
		else{
			Console.WriteLine("The tool box is no longer in its place.");
			Console.WriteLine();
		}
	}

	static void toolRetrival(){
		if (OnTheShip.HaveTools==false){
			OnTheShip.HaveTools=true;
			inventory.Add("Tool Box");
			Console.WriteLine();
			Console.WriteLine("You grab the tool box, surprised by the light weight.");
			Console.WriteLine();
		}
		else
			Console.WriteLine("The item no longer exists.");
	}

	static void StorageBayViewElectric(){
		Console.WriteLine();
		Console.WriteLine("The Storage Bay");
		Console.WriteLine("---------------");
		Console.WriteLine("You no longer hear the Biter nor the crackling of wires from the Engine Room to the West.");
		Console.WriteLine("The Main cabin is to the North with its lights on.");
		if (OnTheShip.HaveTools==true)
			Console.WriteLine("The tools are no longer in their place.");
		else
			Console.WriteLine("The tools are still located against the wall.");
	}

	static void StorageBayViewNoElectic(){
		Console.WriteLine("The Storage Bay");
		Console.WriteLine("---------------");
		Console.WriteLine("You no longer hear the biter, however the crackling of the wires from the Engine Room to the");
		Console.WriteLine("West is still sounding. The Main Cabin is to the North.");
		if (OnTheShip.HaveTools==true)
			Console.WriteLine("The tools are no longer in their place.");
		else
			Console.WriteLine("The tools are still located against the wall.");
	}

	static void StorageBay(){
		if (OnTheShip.biter==true)
			viewStorageBay();
		else
			if (EngineRepair==false)
				StorageBayViewNoElectic();
			else
				StorageBayViewElectric();
		while (true){
			Console.Write("\nWhat would you like to do next?: " );
			string playerRespond = Console.ReadLine();
    		switch (playerRespond){
				case "N": case "n": case "North": case "north": case "go North": case "go north":
					theMainCabin();
					break;
				case "W": case "w": case "West": case "west": case " go West": case "go west":
					EngineRoom();
					break;
				case "look": case "Look" : case "LOOK":
				if (OnTheShip.EngineRepair==false && OnTheShip.biter==true){
					viewStorageBay();
					break;
				}
				else if (OnTheShip.EngineRepair==false && OnTheShip.biter==false){
					StorageBayViewNoElectic();
					break;
				}
				else if (OnTheShip.EngineRepair==true && OnTheShip.biter==false){
					StorageBayViewElectric();
					break;
				}
				else 
				break;
				case "take toolbox": case "take tool box": case "take TOOLBOX": case "take TOOL BOX": case "take tools": case "take TOOLS": case "take tool":
					toolRetrival();
					break;
				case "inventory": case "i": case "I":
					viewInventory();
					break;
				default:
    	        invalidChoice(playerRespond);
    	        break;
			}// switch end
		}//while end 
	}// function end

///////////////////////////ENGINE ROOM

	static void visableEngineRoom(){
		Console.WriteLine();
		Console.WriteLine("The Engine Room");
		Console.WriteLine("---------------");
		Console.WriteLine("As you walk through the doorway, you see lights flickering - looks like wire sparks. You decide to use your lantern");
		Console.WriteLine("and you see it. Low to the ground, but as big as a rat terrier."); 
		Console.WriteLine("8 legs - 4 on each side, a long body with an exoskeleton, its face long and eyes popping out of its sides so it can ");
		Console.WriteLine("see more than what you can. It starts to snarl and runs towards you.");
		Console.WriteLine("You know exactly what it is: an asteroid Biter. Then it leaps towards you.");
		Console.WriteLine();
	}

	static void nonvisableEngineRoom(){
		Console.WriteLine();
		Console.WriteLine("The Engine Room");
		Console.WriteLine("---------------");
		Console.WriteLine("As you walk through the doorway, you see lights flickering - looks like wire sparks. It is extremely hard to see, but ");
		Console.WriteLine("through the light you see a bug like shadow, but no more.");
		Console.WriteLine("The shadow then turns and screeches at you, and before you know it, it leaps towards you.");
		Console.WriteLine();
	}

	static void EngineRoom(){
		while(true){
			if (biter==true){
				if (HaveLantern==true){
					visableEngineRoom();
					Combat();
				}
				else{
					nonvisableEngineRoom();
					Combat();
				}
			}
			else {
				if (EngineRepair==false){
					Console.WriteLine();
					Console.WriteLine("The Engine Room");
					Console.WriteLine("---------------");
					Console.WriteLine("The biter lays dead on the floor, the wires are still sparking, the engine is still in need of repair.");
					Console.WriteLine("To the North is the Main Cabin. To the East is the Storage Bay.");
					Console.WriteLine("The \"repair\" command is avaliable in this room");
					Console.WriteLine();
				}
				else {
					Console.WriteLine();
					Console.WriteLine("The Engine Room");
					Console.WriteLine("---------------");
					Console.WriteLine("The biter lays dead on the floor, the damage of the combat is everywhere. Blood stains the floor. The ");
					Console.WriteLine("engine isn't sparking anymore.");
					Console.WriteLine("To the North is the Main Cabin. To the East is the Storage Bay.");
					Console.WriteLine("The \"repair\" command is avaliable in this room.");
					Console.WriteLine();
				}
			Console.Write("\nWhat would you like to do next?: " );
			string playerRespond = Console.ReadLine();
			switch (playerRespond){
				case "N": case "n": case "North": case "north": case "go North": case "go north":
					theMainCabin();
					break;
				case "E": case "e": case "East": case "east": case "go East": case "go east":
					StorageBay();
					break;
				case "inventory": case "i": case "I":
					viewInventory();
					break;
				case "repair": case "Repair":
					if (EngineRepair==false){
						if (HaveTools==true){
							EngineRepair=true;
							Console.WriteLine();
							Console.WriteLine("You open your tool box and grab your tools to start tinkering with the engine.");
							Console.WriteLine("After a few minutes, the alarm that has been sounding throughout the ship has shut");
							Console.WriteLine("off, and the main lights illuminate the ship again, while the emergency lights");
							Console.WriteLine("shut off.");
							break;
						}
						else
							Console.WriteLine("You don't have the tools to repair the engine.");
						break;
						}
					else
						Console.WriteLine("The engine is already repaired!");
						break;
				default:
    	        invalidChoice(playerRespond);
    	        break;
				}
			}
		}
	}
	
	//////////////////////////COMBAT
	static void Combat(){
		Random rand = new Random();
   		int biterDamage;
    	int playerDamage;
    	bool gameOver = false;
		while (!gameOver){
			biterDamage = rand.Next(0,maxBiterDamage); 
			Console.WriteLine();
			Console.WriteLine("IN COMBAT");
			Console.WriteLine("---------");
			Console.WriteLine($"Player HP: {playerCurrentHealth}");
			Console.WriteLine($"Biter HP: {biterCurrentHealth}");
			Console.WriteLine("What would you like to do? Choices: Fight, Heal, Run: ");
			string playerRespond = Console.ReadLine();
			Console.WriteLine();
			Console.WriteLine("-------------------------------------------------------");
			switch(playerRespond){
				case "Fight": case "fight":
				if (HaveLantern==true && HaveRifle==true){   /////////////Gun and eviroment variables gives damage modifire. Most damage avaliable to player
					Console.WriteLine("You unholister your rifle and take aim, clear shot in sight");
					playerDamage=rand.Next(0,maxPlasmaRifleDmaage);
					if (playerDamage==0){
						Console.WriteLine("\nYou missed!");
						Console.WriteLine($"\nThe biter leaped and bit you, dealing {biterDamage} damage.");
						playerCurrentHealth= playerCurrentHealth - biterDamage;
						}
					else{
						Console.WriteLine($"\nYou did {playerDamage} damage to the biter."); 
						biterCurrentHealth = biterCurrentHealth - playerDamage;
						Console.WriteLine($"\nThe biter leaped and bit you, dealing {biterDamage} damage.");
						playerCurrentHealth= playerCurrentHealth - biterDamage;
					}
				
					if (playerCurrentHealth<=0){
							gameOver = true;
							LossCombat();
							StartOver();
						}
					if (biterCurrentHealth<0){
						gameOver = true;
						biter=false;
						Console.WriteLine("The creature receives the final blow, blood splatters everywhere. You have survived and the biter lays dead on the floor.");
						EngineRoom();
						}
				}
				
				else if(HaveLantern==false && HaveRifle==true){ /////////////Gun and eviroment variables gives damage modifire. Low light lowers damage from player while rifle equipt.
					Console.WriteLine("You unholister your rifle and take aim, the darkness is preventing you from getting a clear shot.");
					playerDamage=rand.Next(0,25);
					 if (playerDamage==0){
						Console.WriteLine("\nYou missed!");
						Console.WriteLine($"\nThe biter leaped and bit you, dealing {biterDamage} damage.");
						playerCurrentHealth= playerCurrentHealth - biterDamage;
					 }
					else{
						Console.WriteLine($"\nYou did {playerDamage} damage to the biter."); 
						biterCurrentHealth = biterCurrentHealth - playerDamage;
						Console.WriteLine($"\nThe biter leaped and bit you, doing {biterDamage} to you.");
						playerCurrentHealth= playerCurrentHealth - biterDamage;
					}
				
					if (playerCurrentHealth<0){
							gameOver = true;
							LossCombat();
							StartOver();
						}
					if (biterCurrentHealth<0){
						gameOver = true;
						biter=false;
						}
				}
				
				else if(HaveLantern==true && HaveRifle==false){ /////////////Gun and eviroment variables gives damage modifire. No rifle means less damage cieling for player
					Console.WriteLine("You ready your fist, with the bug in clear visability.");
					playerDamage=rand.Next(0,18);
					 if (playerDamage==0){
						Console.WriteLine("\nYou missed!");
						Console.WriteLine($"\nThe biter leaped and bit you, dealing {biterDamage} damage.");
						playerCurrentHealth= playerCurrentHealth - biterDamage;
					 }
					else{
						Console.WriteLine($"\nYou did {playerDamage} damage to the biter. Though the exoskeleton negates most damage from physical damage."); 
						biterCurrentHealth = biterCurrentHealth - playerDamage;
						Console.WriteLine($"\nThe biter leaped and bit you, doing {biterDamage} to you.");
						playerCurrentHealth= playerCurrentHealth - biterDamage;
					}
				
					if (playerCurrentHealth<0){
							gameOver = true;
							LossCombat();
							StartOver();
						}
					if (biterCurrentHealth<0){
						gameOver = true;
						biter=false;
						}
				}
				
				else { ///////////////////Gun and eviroment variables gives damage modifire. Low light and no rifle gives lowest damage possible
					Console.WriteLine("You ready your fist. However, its too dark, so you dont know where you're hitting.");
					playerDamage=rand.Next(0,10);
					 if (playerDamage==0){
						Console.WriteLine("\nYou missed!");
						Console.WriteLine($"\nThe biter leaped and bit you, dealing {biterDamage} damage.");
						playerCurrentHealth= playerCurrentHealth - biterDamage;
					 }
					else{
						Console.WriteLine($"\nYou did {playerDamage} damage to the biter. Though the exoskeleton negates most damage from physical damage."); 
						biterCurrentHealth = biterCurrentHealth - playerDamage;
						Console.WriteLine($"\nThe biter leaped and bit you, doing {biterDamage} to you.");
						playerCurrentHealth= playerCurrentHealth - biterDamage;
					}
				
					if (playerCurrentHealth<0){
							gameOver = true;
							LossCombat();
							StartOver();
						}
					if (biterCurrentHealth<0){
						gameOver = true;
						biter=false;
						}
				}
				break;
				case "Heal": case "heal":
				if (HaveFirstAid==true){
					playerCurrentHealth+=50;
					if (playerCurrentHealth>MaxPlayerHealth){
						playerCurrentHealth=MaxPlayerHealth;
						Console.WriteLine("You healed for 50 hp!");
						Console.WriteLine($"\nThe biter leaped and bit you, dealing {biterDamage} damage.");
						playerCurrentHealth= playerCurrentHealth - biterDamage;
					}
					else{
						Console.WriteLine("You healed for 50 hp!");
						Console.WriteLine($"\nThe biter leaped and bit you, dealing {biterDamage} damage.");
						playerCurrentHealth= playerCurrentHealth - biterDamage;
					}
					if (playerCurrentHealth<=0){
							gameOver = true;
							LossCombat();
							StartOver();
						}
					inventory.RemoveAll(x=>x.Contains("FirstAid kit"));
					HaveFirstAid=false;	
				}
				else {
					Console.WriteLine();
					Console.WriteLine("You dont have anything to heal with.");
					Console.WriteLine($"\nThe biter leaped and bit you, dealing {biterDamage} damage.");
					playerCurrentHealth= playerCurrentHealth - biterDamage;
					Console.WriteLine();
					if (playerCurrentHealth<=0){
							gameOver = true;
							LossCombat();
							StartOver();
						}
				}
				break;
				case "run": case "RUN":
					Console.WriteLine();
					Console.WriteLine("You managed to get away safely to the storage bay.");
					Console.WriteLine();
					StorageBay();
				break;
				default:
    	        invalidChoice(playerRespond);
    	        break;
			}
		}//end while
	}//end function

	////////////////////////INVENTORY
	static void viewInventory(){
		Console.WriteLine();
		Console.WriteLine("Here's your inventory");
		Console.WriteLine("=====================");
		String[] bag=inventory.ToArray();
		foreach(string item in bag){
			Console.WriteLine(item);
		}//foreach end
		Console.WriteLine();
	}//function end
}//Class end