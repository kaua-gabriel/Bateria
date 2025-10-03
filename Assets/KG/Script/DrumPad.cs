using UnityEngine;

public class DrumPad : MonoBehaviour
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
            audioSource.Play();
        }
    }
}
