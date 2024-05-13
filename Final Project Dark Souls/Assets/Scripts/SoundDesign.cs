using UnityEngine;

public class SoundDesign : MonoBehaviour
{
    [SerializeField] private AudioClip[] songs;          // Array of songs to choose from
    public bool isBossFightScene;                        // Set this in the Inspector for the boss fight scene
    public AudioClip bossFightSong;                      // Assign the boss fight scene song in the Inspector
    public AudioClip hitSound;                           // Assign the hit sound in the Inspector
    public AudioClip playerHitSound;                     // Assign the player hit sound in the Inspector
    public AudioClip deathSound;                         // Assign the deeath sound in the Inspector
    public AudioClip walkingSound;                       // Assign the walking sound in the Inspector
    private AudioSource backgroundMusicSource;           // AudioSource for playing background music
    private AudioSource walkingSoundSource;              // AudioSource for playing walking sound
    private static Vector3 PlayerVelocity;               // Obtain player velocity for walking sound
    private Rigidbody rigbod;                            // Sounddesign must obtain Rigidbody from player; attach script to player

    // volumes
    public float backgroundMusicVolume = .05f;           // Volume for background music
    public float walkingSoundVolume = .75f;              // Volume for walking sound
    public float punchSoundVolume = 1.0f;

    void Start()
    {
        // Set up background music AudioSource
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicSource.loop = true; // The background music should loop

        // Set up walking sound AudioSource
        walkingSoundSource = gameObject.AddComponent<AudioSource>();
        walkingSoundSource.loop = true; // The walking sound should loop

        // Play initial song or boss fight song
        if (isBossFightScene)
        {
            backgroundMusicSource.clip = bossFightSong;
        }
        else
        {
            int randomIndex = Random.Range(0, songs.Length);
            backgroundMusicSource.clip = songs[randomIndex];
        }
        //set intiial volumes 
        backgroundMusicSource.volume = backgroundMusicVolume; 
        walkingSoundSource.volume = walkingSoundVolume;      

        backgroundMusicSource.Play(); // Play the selected song

        rigbod = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the player's speed is above 5 to play walking sound
        PlayerVelocity = rigbod.velocity;
        if (rigbod.velocity.magnitude > 5 && !walkingSoundSource.isPlaying)
        {
            walkingSoundSource.clip = walkingSound; // Set the walking sound clip
            walkingSoundSource.Play(); // Start playing the walking sound
        }
        else if (rigbod.velocity.magnitude <= 5 && walkingSoundSource.isPlaying)
        {
            walkingSoundSource.Stop(); // Stop playing the walking sound
        }
    }

    // Play the hit sound
    public void PlayHitSound()
    {
        AudioSource.PlayClipAtPoint(hitSound, transform.position);
    }

    // Play the player hit sound
    public void PlayPlayerHitSound()
    {
        AudioSource.PlayClipAtPoint(playerHitSound, transform.position);
    }

    // Play the death sound
    public void PlayDeathSound()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }
}
