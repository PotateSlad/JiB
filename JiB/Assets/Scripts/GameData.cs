//Reference from https://www.youtube.com/watch?v=XOjd_qU2Ido
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public int[] partyMembers;
    public bool[] charactersUnlocked;
    public int[] characterLvls;
    public int[] characterExps;
    public int[] inventory;
    public int[] mapStatus;
    public int currentRoom;

    public GameData()
    {
        partyMembers = new int[3];
        partyMembers[0] = Game.partyMembers[0];
        partyMembers[1] = Game.partyMembers[1];
        partyMembers[2] = Game.partyMembers[2];

        charactersUnlocked = new bool[21];
        characterLvls = new int[21];
        characterExps = new int[21];
        for(int a=0; a<21; a++)
        {
            charactersUnlocked[a] = Game.charactersUnlocked[a];
            characterLvls[a] = Game.characterLvls[a];
            characterExps[a] = Game.characterExps[a];
        }

        inventory = new int[2];
        inventory[0] = Game.inventory[0];
        inventory[1] = Game.inventory[1];

        mapStatus = new int[41];
        for(int b=0; b<41; b++)
        {
            mapStatus[b] = Game.mapStatus[b];
        }

        currentRoom = Game.currentRoom;
    }
}
//End Reference