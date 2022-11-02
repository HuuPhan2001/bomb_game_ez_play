using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;

    public void CheckWinState(string name)
    {
        int aliveCount = 0;

        foreach (GameObject player in players)
        {
            if (player.activeSelf) {
                aliveCount++;
            }
        }

        if (aliveCount <= 1)
        {
            Control.name = name;
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
            AudioManager.instance.Stop("Theme");
            AudioManager.instance.Play("GameOver");
            //Invoke(nameof(NewRound), 3f);
        }
    }

    //private void NewRound()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

}
