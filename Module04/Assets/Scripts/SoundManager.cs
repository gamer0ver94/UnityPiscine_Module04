using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;
    public static SoundManager Instance { get { return instance; } }
    [SerializeField]
    private  AudioClip jump;
    [SerializeField]
    private  AudioClip background;
    [SerializeField]
    private  AudioClip death;
    public AudioClip Jump
    {
        get { return jump; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
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
