using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    AudioMixerSnapshot menu;
    [SerializeField]
    AudioMixerSnapshot fight;
    private float tTime = 1f;
    void Start()
    {
        fight.TransitionTo(tTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckEnemyForTransition()
    {
        //if we running out enemies putthe mellow music on
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 2)
        {
            menu.TransitionTo(tTime);
        }
    }
}
