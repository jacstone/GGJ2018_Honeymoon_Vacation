using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class GameStates : MonoBehaviour
{
    public enum States
    {
        Dead,
        Room1_WakeUp,
        Room1_EnterBathroom,
        Room1_BathroomBirdcage,//die
        Room1_ZombieHand,//die
        Room1_Enter,
        Room1_LeaveWindow,//die
        Room1_LeaveAjoin,
        Room1_LeaveDoor,//die
        Room1_GetPhone,
        Room2_GetFriend,
        Room2_Explore,
        Room2_ExploreNewspaper,
        Room2_ExploreFindObject,
        Room2_Enter,
        Room2_LeaveWindow,//die
        Room2_LeaveAjoin,//die
        Room2_LeaveDoor,
        Room2_PickUpLighter,
        Room2_PickUpSprayCan,
        Room2_PickUpPhone,
        Room3_YellAtCop,
        Room3_SayEmergency,
        Room3_FollowCop,
        Room3_LeaveCop,
        Room3_Explore,
        Room3_ExploreFindObject,
        Room3_Enter,//might die
        Room3_LeaveWindow,//die
        Room3_LeaveAjoin,
        Room3_LeaveDoor,//die
        Room3_PickUpFlashlight,
        Room3_PickUpBullets,
        Room3_PickUpGun,
        Room3_PickUpFireExtinguisher,
        Room4_UseFlashlight,
        Room4_ShootZombie,
        Room4_UseFriend,
        Room4_Explore,
        Room4_Enter,
        Room4_LeaveWindow,//whoohoo
        Room4_LeaveAjoin,//die
        Room4_LeaveDoor,//die
        Timeout,//die
        Hallway_Enter,
        Hallway_Room1,//die
        Hallway_Room2,//die
        Hallway_Room3,//die
        Hallway_Room4,//whoohoo
        Hallway_Room5,//die
        Hallway_Stairwell,//die
        Hallway_Zombie//die
        
    }
    States currentState;
    bool isDoor2Open = false;

    public States CurrentState
    {
        get
        {
            return currentState;
        }

        set
        {
            currentState = value;
        }
    }

   public GameStates()
    {
        currentState = States.Room1_WakeUp;
    }



    public void LeaveWindow(bool willDie)
    {
        if (willDie)
        {
            Die(deathMessage: "There’s no way to know if one of his friends is patient zero, or if the whole hotel is swarming. Ethan decides a quick exit from the hotel is best. He crawls through the large window and gets his footing, very carefully, on the gratuitous crown molding ledge. Before he can start to look for something climbable, the molding begins to crumble. Ethan knew he was on the 20th floor, but he was hoping for some kind of miraculous exit. Instead, he has a split second to regret his life choices before he falls from the ledge.");
        }
        else
        {
            print("I am Alive!");
            print("**Chicken Dance**");
        }
    }

    public void LeaveRoom2ToHallway(bool willDie)
    {
        if (willDie)
        {
            Die("They really had no other path to take, but the hallway is just too overrun with shambling zombies. Upon sight of Ethan and Tony, the zombies shift from shuffling aimlessly to zeroing in on their next meal.");
        }
        else
        {
            print("In Hallway and Killing Zombies!");
        }
    }

    internal void PickUpLighter()
    {
        print("Has Lighter Now!");
    }

    public void LeaveRoomToAjoin(bool willDie)
    {
        print("Leaving the Room to the ajoinning Room");
        if (willDie)
        {
            Die("");
        }
        else
        {
            print("In ajoining room");
        }
    }

    internal void PickUpSprayCan()
    {
        print("Has Spraycan now");
            }

    internal void ReadNewsPaper()
    {
        print("Read the newspaper");
    }

    internal void MeetTony()
    {
        print("You meet Tony");
    }

    public void Die(string deathMessage)
    {
        if (string.IsNullOrEmpty(deathMessage))
        {
            deathMessage ="There was a reason for your death! what was it? A mystery...";
        }
        DataMover.FinalMessage = deathMessage;
        DataMover.isDeath = true;

        SceneManager.LoadScene("Ending");
        //print("You are dead!");
    }

    internal void CopEmergency()
    {
        print("The cop opens the door at the request of emergency!");
    }

    internal void FollowCopToHallway()
    {
        print("You follow the cop into the hallway");
        Die("");
    }
}

