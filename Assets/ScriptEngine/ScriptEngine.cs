using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEngine : MonoBehaviour
{
    public static ScriptEngine Instance { get; set; }

    public ScriptEngine()
    {
        Instance = this;
    }

    ItemCollection myItems = new ItemCollection();
    ItemCollection.ItemEnum getsItem;
    bool isAlive = true;
    GameStates gameState = new GameStates();

    public bool IsAlive
    {
        get
        {
            return isAlive;
        }

        set
        {
            isAlive = value;
        }
    }

    public ItemCollection.ItemEnum GetsItem
    {
        get
        {
            return getsItem;
        }

        set
        {
            getsItem = value;
        }
    }

    public void SetState(GameStates.States newState)
    {
        gameState.CurrentState = newState;
    }

    // Use this for initialization
    void Start()
    {
        print("Script Engine Starting");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAlive)
        {
            if (gameState.CurrentState == GameStates.States.Room1_WakeUp)
            {
            }
            else if (gameState.CurrentState == GameStates.States.Room1_EnterBathroom)
            {

            }
            else if (gameState.CurrentState == GameStates.States.Room1_BathroomBirdcage)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                gameState.Die(deathMessage: "Ethan hadn’t been able to leave Tweets behind when planning this trip, and he couldn’t leave him behind now. Ethan grabs the birdcage and whirls to make a quick getaway, Tweets safely in his hands. Unfortunately, zombie-Diane seems to be quicker than he could have imagined, and she blocks his exit from the bathroom. Ethan watches in horror as zombie-Diane swats the birdcage from his hands. He hopes the force of the cage slamming into the floor will free Tweets to escape. He knows he won’t be so lucky.");
            }
            else if (gameState.CurrentState == GameStates.States.Room1_LeaveWindow)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                gameState.LeaveWindow(true);
            }
            else if (gameState.CurrentState == GameStates.States.Room1_ZombieHand)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                gameState.Die(deathMessage: "Ethan knows he shouldn’t play with zombies. But when was he ever going to have another chance to check out a zombie up-close and in-person? He checks out the zombie hand, taking in all the unnatural green and blue skin hues. In his fascination, he fails to move fast enough to avoid his zombie friends when they come crashing through the wall. The zombies land on him and Ethan falls to the ground hard, knocking him unconscious. The world goes black, forever.");


            }
            else if (gameState.CurrentState == GameStates.States.Room1_Enter)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                gameState.Die("");

            }
            else if (gameState.CurrentState == GameStates.States.Room1_LeaveAjoin)
            {
                gameState.LeaveRoomToAjoin(false);
            }
            else if (gameState.CurrentState == GameStates.States.Room1_LeaveDoor)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                gameState.Die(deathMessage: "Ethan has decided it’s every man for himself.Tony is capable of finding his own way out, and Ethan is the one in imminent danger.He promises himself he will call his friend as soon as he has reached safety.Ethan throws open the hotel door and uses his momentum to rush forward into the hallway.Unfortunately, his friends’ inconvenient zombie - sounds had drowned out the groaning horde of undead in the hallway.Ethan has a moment to hope that his own screams will be enough to alert Tony to the impending zombie takeover.Reflective moment over, all thoughts are overcome by an all - consuming lust for braaaains.");
            }
            else if (gameState.CurrentState == GameStates.States.Room1_GetPhone)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                gameState.Die(deathMessage: "Ethan's phone was too close to the wall. The zombies broke through the wall just as he grabed his phone. With adrenline surging through his body, Ethan threw the broken phone at the zombies. Unfortunately, all that did was get their attention and lead to his demise.");

            }
            else if (gameState.CurrentState == GameStates.States.Room2_GetFriend)
            {

            }
            else if (gameState.CurrentState == GameStates.States.Room2_Explore)
            {

            }
            else if (gameState.CurrentState == GameStates.States.Room2_ExploreNewspaper)
            {
                gameState.CurrentState = GameStates.States.Room2_Explore;
            }
            else if (gameState.CurrentState == GameStates.States.Room2_ExploreFindObject)
            {
                gameState.CurrentState = GameStates.States.Room2_Explore;
            }
            else if (gameState.CurrentState == GameStates.States.Room2_Enter)
            {
                gameState.MeetTony();
            }
            else if (gameState.CurrentState == GameStates.States.Room2_LeaveWindow)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                gameState.LeaveWindow(true);
            }
            else if (gameState.CurrentState == GameStates.States.Room1_LeaveAjoin)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                gameState.LeaveRoomToAjoin(true);
            }
            else if (gameState.CurrentState == GameStates.States.Room2_LeaveDoor)
            {
                if (myItems.ItemInCollection(ItemCollection.ItemEnum.Lighter) && myItems.ItemInCollection(ItemCollection.ItemEnum.SprayCan))
                {
                    gameState.LeaveRoom2ToHallway(false);

                }
                else
                {
                    gameState.LeaveRoom2ToHallway(true);

                }
            }
            else if (gameState.CurrentState == GameStates.States.Room2_PickUpLighter)
            {
                myItems.CollectItem(ItemCollection.ItemEnum.Lighter);
                gameState.PickUpLighter();
                gameState.CurrentState = GameStates.States.Room2_Explore;
            }
            else if (gameState.CurrentState == GameStates.States.Room2_PickUpSprayCan)
            {
                myItems.CollectItem(ItemCollection.ItemEnum.SprayCan);
                gameState.PickUpSprayCan();
                gameState.CurrentState = GameStates.States.Room2_Explore;
            }
            else if (gameState.CurrentState == GameStates.States.Room2_PickUpPhone)
            {
                myItems.CollectItem(ItemCollection.ItemEnum.Phone);
                gameState.PickUpLighter();
                gameState.CurrentState = GameStates.States.Room2_Explore;
            }
            else if (gameState.CurrentState == GameStates.States.Room3_YellAtCop)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                gameState.Die("");
            }
            else if (gameState.CurrentState == GameStates.States.Room3_SayEmergency)
            {
                gameState.CopEmergency();
            }
            else if (gameState.CurrentState == GameStates.States.Room3_FollowCop)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                gameState.FollowCopToHallway();
            }
            else if (gameState.CurrentState == GameStates.States.Room3_LeaveCop) { }
            else if (gameState.CurrentState == GameStates.States.Room3_Explore) { }
            else if (gameState.CurrentState == GameStates.States.Room3_ExploreFindObject) { }
            else if (gameState.CurrentState == GameStates.States.Room3_Enter) { }
            else if (gameState.CurrentState == GameStates.States.Room3_LeaveWindow)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                gameState.LeaveWindow(true);
            }
            else if (gameState.CurrentState == GameStates.States.Room3_LeaveAjoin) { }
            else if (gameState.CurrentState == GameStates.States.Room3_LeaveDoor) { }
            else if (gameState.CurrentState == GameStates.States.Room4_UseFlashlight) { }
            else if (gameState.CurrentState == GameStates.States.Room4_ShootZombie) { }
            else if (gameState.CurrentState == GameStates.States.Room4_UseFriend) { }
            else if (gameState.CurrentState == GameStates.States.Room4_Explore) { }
            else if (gameState.CurrentState == GameStates.States.Room4_Enter) { }
            else if (gameState.CurrentState == GameStates.States.Room4_LeaveWindow) { }
            else if (gameState.CurrentState == GameStates.States.Room4_LeaveAjoin) { }
            else if (gameState.CurrentState == GameStates.States.Room4_LeaveDoor) {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                gameState.Die(deathMessage: "Ethan had already seen first-hand how many zombies waited for him in the hallway. He just didn’t see any other options. He tries the hallway door, hoping he can somehow manage to sneak around the corner to the fire escape. Wishful thinking did not make the hordes in the hallway disappear, however. Zombies rush Ethan and Tony as soon as they open the door.");
}
            else if (gameState.CurrentState == GameStates.States.Timeout)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                gameState.Die(deathMessage: "Nothing is more persistent than a starving zombie, and it doesn’t take long before the zombies in the Honeyroom Suite come crashing through the wall. He wishes he had tried to escape while he had the chance, but it looks like he is out of time.");
            }
            else if (gameState.CurrentState == GameStates.States.Hallway_Enter) { }
            else if (gameState.CurrentState == GameStates.States.Hallway_Room1)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                if (myItems.ItemInCollection(ItemCollection.ItemEnum.Lighter) && myItems.ItemInCollection(ItemCollection.ItemEnum.SprayCan))
                {
                    gameState.Die("Panicing Ethan heads back towards the bridal suite. The improvised flamethrower clears their path at first, until the lighter flickers out. Ethan frantically flips at the lighter, willing it to life, but it seems it is out of lighter fluid. Zombies surround them on all sides, and it becomes increasingly clear that they won’t be making it out of this hallway.");

                }
                else
                {
                    gameState.Die("There are too many zombies to avoid. Panic sets in as Ethan knows he will not see another day.");

                }
            }
            else if (gameState.CurrentState == GameStates.States.Hallway_Room2)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                if (myItems.ItemInCollection(ItemCollection.ItemEnum.Lighter) && myItems.ItemInCollection(ItemCollection.ItemEnum.SprayCan))
                {
                gameState.Die("Panicing Ethan heads back towards his own room. The improvised flamethrower clears their path at first, until the lighter flickers out. Ethan frantically flips at the lighter, willing it to life, but it seems it is out of lighter fluid. Zombies surround them on all sides, and it becomes increasingly clear that they won’t be making it out of this hallway.");

                }
                else
                {
                    gameState.Die("There are too many zombies to avoid. Panic sets in as Ethan knows he will not see another day.");

                }

            }
            else if (gameState.CurrentState == GameStates.States.Hallway_Room3) { }
            else if (gameState.CurrentState == GameStates.States.Hallway_Room4)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                gameState.Die("The fire escape seems too risky, but maybe the room closest to it is the next best thing. Ethan runs to the last room on the hall and pounds loudly on the door. This is Russell’s room, the last of the best men in the wedding. Ethan knows Russell tends to err on the side of caution. In fact, Russell had chosen this room immediately beside the fire escape for this exact reason. So it comes as no surprise to Ethan when his knocks go unanswered. He is surprised, however, by the zombie that quietly comes up behind him. Maybe Russell had made the right call by not answering, after all.");
            }
            else if (gameState.CurrentState == GameStates.States.Hallway_Stairwell)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                gameState.Die("The stairwell is the closest , and Ethan and Tony beeline it for the emergency exit at the end of the hall. The improvised flamethrower clears their path at first, until the lighter flickers out. Ethan frantically flips at the lighter, willing it to life, but it seems it is out of lighter fluid. Zombies surround them on all sides, and it becomes increasingly clear that they won’t be making it out of this hallway.");
            }
            else if (gameState.CurrentState == GameStates.States.Hallway_Zombie)
            {
                gameState.CurrentState = GameStates.States.Dead;
                IsAlive = false;
                gameState.Die("There are too many zombies to avoid. Panic sets in as Ethan knows he will not see another day.");

            }


        }
        else
        {
            gameState.Die(deathMessage: "There was a reason for your death! what was it? A mystery...");
        }
    }
}
