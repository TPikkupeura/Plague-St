using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private GameObject player;
    private GameStateManager gameStateManager;
    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = GameObject.FindWithTag("GameManager").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        

        

    }

    void FixedUpdate(){
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (gameStateManager.currentGameState == GameState.Playing && player != null)
        {
                        transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.125f);
        }
    }





    public void ShakeAttack()
    {
        StartCoroutine(Shake(transform.position, 0.05f, 0.05f));
    }
    public void ShakeDamage()
    {
        StartCoroutine(Shake(transform.position, 0.1f, 0.1f));
    }
    public void ShakeSpecial()
    {
        StartCoroutine(Shake(transform.position, 0.3f, 0.3f));
    }
    IEnumerator Shake(Vector3 position, float duration, float magnitude)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.position = new Vector3(position.x + x, position.y + y, position.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

    }


}
