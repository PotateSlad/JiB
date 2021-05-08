using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        //set variables to starting levels
        Game.gameInit();
        SceneManager.LoadScene(3); //https://www.google.com/search?q=make+new+game+screen+unity&rlz=1C5GCEM_enUS942US942&ei=rDVnYN-gB8artQbK7YWgDw&oq=make+new+game+screen+unity&gs_lcp=Cgdnd3Mtd2l6EAM6BwgAEEcQsAM6BAghEApQvRhYkTtg8j1oAnACeACAAbIBiAHvB5IBAzcuM5gBAKABAaoBB2d3cy13aXrIAQi4AQLAAQE&sclient=gws-wiz&ved=0ahUKEwjfpubV7d_vAhXGVc0KHcp2AfQQ4dUDCA0&uact=5#kpvalbx=_2DVnYIeoLZn5tAbA2p2YDw12
    } 
    public void LoadGame()
    {
        Creature creature = new Creature();
        Game.gameLoad();
        creature.LoadCreature();
        SceneManager.LoadScene(1); //https://www.google.com/search?q=make+new+game+screen+unity&rlz=1C5GCEM_enUS942US942&ei=rDVnYN-gB8artQbK7YWgDw&oq=make+new+game+screen+unity&gs_lcp=Cgdnd3Mtd2l6EAM6BwgAEEcQsAM6BAghEApQvRhYkTtg8j1oAnACeACAAbIBiAHvB5IBAzcuM5gBAKABAaoBB2d3cy13aXrIAQi4AQLAAQE&sclient=gws-wiz&ved=0ahUKEwjfpubV7d_vAhXGVc0KHcp2AfQQ4dUDCA0&uact=5#kpvalbx=_2DVnYIeoLZn5tAbA2p2YDw12
    }
    public void Quit()
    {
        Debug.Log("Quit"); //https://www.google.com/search?q=make+new+game+screen+unity&rlz=1C5GCEM_enUS942US942&ei=rDVnYN-gB8artQbK7YWgDw&oq=make+new+game+screen+unity&gs_lcp=Cgdnd3Mtd2l6EAM6BwgAEEcQsAM6BAghEApQvRhYkTtg8j1oAnACeACAAbIBiAHvB5IBAzcuM5gBAKABAaoBB2d3cy13aXrIAQi4AQLAAQE&sclient=gws-wiz&ved=0ahUKEwjfpubV7d_vAhXGVc0KHcp2AfQQ4dUDCA0&uact=5#kpvalbx=_2DVnYIeoLZn5tAbA2p2YDw12
        Application.Quit(); //https://www.google.com/search?q=make+new+game+screen+unity&rlz=1C5GCEM_enUS942US942&ei=rDVnYN-gB8artQbK7YWgDw&oq=make+new+game+screen+unity&gs_lcp=Cgdnd3Mtd2l6EAM6BwgAEEcQsAM6BAghEApQvRhYkTtg8j1oAnACeACAAbIBiAHvB5IBAzcuM5gBAKABAaoBB2d3cy13aXrIAQi4AQLAAQE&sclient=gws-wiz&ved=0ahUKEwjfpubV7d_vAhXGVc0KHcp2AfQQ4dUDCA0&uact=5#kpvalbx=_2DVnYIeoLZn5tAbA2p2YDw12
    }  
}
