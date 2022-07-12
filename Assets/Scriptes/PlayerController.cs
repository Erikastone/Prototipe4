using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public float speed;
    private GameObject focalPoint;
    public bool hasPowerUp;
    private float powerupStrenght = 15.0f; //сила импульса к врагу
    public GameObject powerupIndicators; //индикатор включения для усиления
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

   
    void Update()
    {
        float forvardInput = Input.GetAxis("Vertical");
        rbPlayer.AddForce(focalPoint.transform.forward * speed * forvardInput);
        powerupIndicators.transform.position = transform.position + new Vector3(0, -0.5f, 0); //расположение индикатора относительно игрока
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCounDownRounTime());
            powerupIndicators.gameObject.SetActive(true);
        }
    }
    IEnumerator PowerupCounDownRounTime()
    {
        yield return new WaitForSeconds(7);
        powerupIndicators.gameObject.SetActive(false);
        hasPowerUp = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            //если плеер подберет усиление то он оттолкнет врага
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collider with" + collision.gameObject.name + "with powerup set to"+ hasPowerUp);
            enemyRb.AddForce(awayFromPlayer * powerupStrenght , ForceMode.Impulse);
        }
    }
}
