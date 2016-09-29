using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject shieldExplosion;
    public int scoreValue;

    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find gamecontroller script");
        }
    }

	void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case "Boundary":
                return;
            case "Player":
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
                break;
            case "Shield": //My extra case in which the shiled get hit
                Instantiate(shieldExplosion, transform.position, transform.rotation);
                gameController.AddScore(-2*scoreValue);
                break;
            default: //The case where the bullet hits
                Instantiate(explosion, transform.position, transform.rotation);
                gameController.AddScore(scoreValue);
                break;
        }
        
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
