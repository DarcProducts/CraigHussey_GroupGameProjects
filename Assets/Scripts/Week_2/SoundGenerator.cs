using UnityEngine;

public class SoundGenerator : MonoBehaviour
{
    AudioSource source;
    [SerializeField] string sourceName = "FXSource";
    [SerializeField] AudioClip spawnSound;
    [SerializeField] AudioClip collideSound;
    [SerializeField] float activateSound;
    [SerializeField] Vector2 minMaxCollideVolume;
    [SerializeField] Vector2 minMaxSpawnVolume;
    [SerializeField] Vector2 minMaxPitch;
    Rigidbody _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
        source = GameObject.FindWithTag(sourceName).GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (source == null || spawnSound == null) return;
        source.PlayOneShot(spawnSound, Random.Range(minMaxSpawnVolume.x, minMaxSpawnVolume.y));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (source == null || collideSound == null) return;
        if (_rigid.velocity.magnitude > activateSound)
            source.PlayOneShot(collideSound, Random.Range(minMaxCollideVolume.x, minMaxCollideVolume.y));
    }
}
