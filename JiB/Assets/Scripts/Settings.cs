using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public void Resume()
    {
        //reload game as it was
        SceneManager.LoadScene(1); //https://www.google.com/search?q=make+new+game+screen+unity&rlz=1C5GCEM_enUS942US942&ei=rDVnYN-gB8artQbK7YWgDw&oq=make+new+game+screen+unity&gs_lcp=Cgdnd3Mtd2l6EAM6BwgAEEcQsAM6BAghEApQvRhYkTtg8j1oAnACeACAAbIBiAHvB5IBAzcuM5gBAKABAaoBB2d3cy13aXrIAQi4AQLAAQE&sclient=gws-wiz&ved=0ahUKEwjfpubV7d_vAhXGVc0KHcp2AfQQ4dUDCA0&uact=5#kpvalbx=_2DVnYIeoLZn5tAbA2p2YDw12
    } 
    public void Save()
    {
        //need creature.SaveCreature();
        Game.gameSave();
    }
    public void Quit()
    {
        Debug.Log("Quit"); //https://www.google.com/search?q=make+new+game+screen+unity&rlz=1C5GCEM_enUS942US942&ei=rDVnYN-gB8artQbK7YWgDw&oq=make+new+game+screen+unity&gs_lcp=Cgdnd3Mtd2l6EAM6BwgAEEcQsAM6BAghEApQvRhYkTtg8j1oAnACeACAAbIBiAHvB5IBAzcuM5gBAKABAaoBB2d3cy13aXrIAQi4AQLAAQE&sclient=gws-wiz&ved=0ahUKEwjfpubV7d_vAhXGVc0KHcp2AfQQ4dUDCA0&uact=5#kpvalbx=_2DVnYIeoLZn5tAbA2p2YDw12
        Application.Quit(); //https://www.google.com/search?q=make+new+game+screen+unity&rlz=1C5GCEM_enUS942US942&ei=rDVnYN-gB8artQbK7YWgDw&oq=make+new+game+screen+unity&gs_lcp=Cgdnd3Mtd2l6EAM6BwgAEEcQsAM6BAghEApQvRhYkTtg8j1oAnACeACAAbIBiAHvB5IBAzcuM5gBAKABAaoBB2d3cy13aXrIAQi4AQLAAQE&sclient=gws-wiz&ved=0ahUKEwjfpubV7d_vAhXGVc0KHcp2AfQQ4dUDCA0&uact=5#kpvalbx=_2DVnYIeoLZn5tAbA2p2YDw12
    } 
}