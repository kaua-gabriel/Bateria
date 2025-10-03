using UnityEngine;

public class DrumHit : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Baqueta"))
        {
            float velocity = collision.relativeVelocity.magnitude;
            audioSource.volume = Mathf.Clamp01(velocity / 5f); // ajusta volume pelo impacto
            audioSource.Play();
        }
    }
}
