using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endGameScript : MonoBehaviour
{
    public string levelName = "level 2";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MainPlayer"))
        {
            StartCoroutine(LoadSceneAgain());
           


        }
    }
    IEnumerator LoadSceneAgain(){
        yield return new WaitForSeconds(1f);
        SoundMangerScript.instance.PlayWinSound();
        yield return new WaitForSeconds(3f);

        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(levelName);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
