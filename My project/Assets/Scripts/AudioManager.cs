using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _nailInsertSFX;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound(string soundName)
    {
        switch (soundName)
        {
            case "Insert": _nailInsertSFX.Play();
                break;
        }
    }
}
