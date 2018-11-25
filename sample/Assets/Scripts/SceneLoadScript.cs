using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
public class SceneLoadScript : MonoBehaviour {

    private bool goalEntered;
    public GameObject winnerLabelObject;

	//　スタートボタンを押したら実行する
	public void GameStart() {
		SceneManager.LoadScene ("Portal");
	}

    void LateUpdate() {
        if (SceneManager.GetActiveScene().name == "Portal")
        {
            if (goalEntered)
            {
                //SceneManager.LoadScene("Portal1");
                winnerLabelObject.SetActive (true);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            goalEntered = true;
        }
    }
}