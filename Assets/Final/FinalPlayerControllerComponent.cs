using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalPlayerControllerComponent : MonoBehaviour
{
    public float speed = 5.0f;
    public Text scoreText;
    public AudioClip coinCollectAudio;

    private Rigidbody _rigidbody;
    private int _score;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 force = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _rigidbody.AddForce(force * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            _score += 1;
            scoreText.text = _score.ToString();

            Audio.Spawn(coinCollectAudio, transform.position);

            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Game_Final");
        }
    }
}
