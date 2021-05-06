using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    //party variables
    private static Arcana[] party = new Arcana[3];

    //game switches
    //NICK-- these are the things that need saved :)
    //arcana vars: in order of arcana, for ease of access
    //justice is required, so only 3 others...
    public static int[] partyMembers = new int[3];
    public static bool[] charactersUnlocked = new bool[21];
    public static int[] characterLvls = new int[21];
    public static int[] characterExps = new int[21];
    //inventory: index = item type (see enum), data at index = item quantity
    public static int[] inventory = new int[2];
    //map unlock vars, a sort of progress switch for us (see enum for order as well)
    public static int[] mapStatus = new int[41];
    public static int currentRoom;

    //public for our convenience!
    public enum Tarot
    {
        The_Fool,           //0
        The_Magician,       //1
        The_High_Priestess, //2
        The_Empress,        //3
        The_Emperor,        //4
        The_Heirophant,     //5
        The_Lovers,         //6
        The_Chariot,        //7
        Strength,           //8
        The_Hermit,         //9
        Wheel_of_Fortune,   //10
        Justice,            //11
        The_Hanged_Man,     //12
        Death,              //13
        Temperance,         //14
        The_Devil,          //15
        The_Tower,          //16
        The_Star,           //17
        The_Moon,           //18
        The_Sun,            //19
        Judgement,          //20
        The_World           //21
    }
    public static string[] TarotNames = new string[] {"Fool", "Magician", "High Pristess", "Empress", "Emperor",
                                        "Heirophant", "Lovers", "Chariot", "Strength", "Hermit",
                                        "Wheel of Fortune", "Justice", "Hanged Man", "Death", "Temperance",
                                        "Devil", "Tower", "Star", "Moon", "Sun", "Judgement", "World"};

    public enum Items
    {
        Potion,     //0
        Card        //1
    }

    public enum MapIDs
    {
        Library,        //0
        Sun_Room,       //1
        World_Room,     //2
        Star_Room,      //3
        Solar,          //4
        Tower_Room,     //5
        Fool_Room,      //6
        Moon_Room,      //7
        Magician_Tower, //8
        Chariot_Room,   //9
        Strength_Room,  //10
        Death_Room,     //11
        Temperance_Room,//12
        Devil_Room,     //13
        Judgement_Room, //14
        Justice_Room,   //15
        Lovers_Room,    //16
        Hanged_Room,    //17
        Wheel_Room,     //18
        Chapel,         //19
        Great_Hall,     //20
        Place_of_Arms,  //21
        Storeroom,      //22
        Cellar,         //23
        Store_Closet,   //24
        Kitchen,        //25
        Buttery,        //26
        Pantry,         //27
        Kitchen_Hall,   //28
        Screens,        //29
        Porch,          //30
        NW_Tower,       //31
        NE_Tower,       //32
        SW_Tower,       //33
        SE_Tower,       //34
        Forge,          //35
        Bowyer,         //36
        Ice_House,      //37
        Hermit_Hovel,   //38
        Dovecotes,      //39
        Gatehouse       //40
    }
    public enum MapStatus
    {
        Locked,             //0
        Unvisited_Red,      //1
        Unvisited_Yellow,   //2
        Unvisited_Green,    //3
        Visited_Red,        //4
        Visited_Yellow,     //5
        Visited_Green       //6
    }

    //game logic initialization for a new game
    public static void gameInit()
    {
        //initialize the other party members to -1 or null
        for (int i = 0; i < partyMembers.Length; i++)
        {
            partyMembers[i] = -1;
            party[i] = null;
        }

        //lock all characters, set all levels to 1, and exp to 0
        for (int i = 0; i < charactersUnlocked.Length; i++)
        {
            charactersUnlocked[i] = false;
            characterLvls[i] = 1;
            characterExps[i] = 0;
        }
        //unlock Justice...
        charactersUnlocked[(int)Tarot.Justice] = true;

        //0 out the inventory
        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = 0;
        }

        //lock all areas of the map
        for (int i = 0; i < mapStatus.Length; i++)
        {
            mapStatus[i] = (int)MapStatus.Locked;
        }
        //unlock the dovecotes (starting zone)...
        mapStatus[(int)MapIDs.Dovecotes] = (int)MapStatus.Unvisited_Green;
        //set current room to the dovecotes
        currentRoom = (int)MapIDs.Dovecotes;
    }

    //Referenced from https://www.youtube.com/watch?v=XOjd_qU2Ido
    public static void gameSave()
    {
        SaveSystem.SaveGameValues();
    }

    //similar to gameInit, but now we're loading in info from a save file
    public static void gameLoad()
    {
        GameData data = SaveSystem.LoadGameValues();

        Game.partyMembers[0] = data.partyMembers[0];
        Game.partyMembers[1] = data.partyMembers[1];
        Game.partyMembers[2] = data.partyMembers[2];

        for(int a=0; a<21; a++)
        {
            Game.charactersUnlocked[a] = data.charactersUnlocked[a];
            Game.characterLvls[a] = data.characterLvls[a];
            Game.characterExps[a] = data.characterExps[a];
        }

        Game.inventory[0] = data.inventory[0];
        Game.inventory[1] = data.inventory[1];
        Game.inventory[2] = data.inventory[2];
            
        for(int b=0; b<41; b++)
        {
            Game.mapStatus[b] = data.mapStatus[b];
        }
        Game.currentRoom = data.currentRoom;
    }
    //End reference

    //sets up the Arcana variable for adding a party member
    public static void addPartyMember(int id, int placement)
    {
        if (placement > 3 || party[placement] != null)
        {
            //space occupied, we can't add a party member here
            return;
        }
        //otherwise, we can init an Arcana based on their id and known level and exp
        Arcana toAdd = new Arcana(id);
        toAdd.setLevel(characterLvls[id]);
        toAdd.setExp(characterExps[id]);

        party[placement] = toAdd;
    }

    public static void removePartyMember(int placement)
    {
        if (placement > 3 || party[placement] == null)
        {
            //can't do anything here
            return;
        }
        //otherwise, update the Arcana's vars and remove from party
        Arcana cur = party[placement];
        characterLvls[cur.getId()] = cur.getLevel();
        characterExps[cur.getId()] = cur.getExp();
        party[placement] = null;
    }
}
