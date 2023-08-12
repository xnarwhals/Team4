using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioClip DroneScan;
    public AudioClip DroneHit;
    public AudioClip DroneDeath;

    public AudioClip ShootPaint;
    public AudioClip colorWheel;

    public float volume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.ScanStart>(scan);
        EvtSystem.EventDispatcher.AddListener<GameEvents.EnemyHit>(droneHit);
        EvtSystem.EventDispatcher.AddListener<GameEvents.EnemyDie>(droneDeath);

        EvtSystem.EventDispatcher.AddListener<GameEvents.ShootPaint>(shootPaint);
        EvtSystem.EventDispatcher.AddListener<GameEvents.ColorWheelChange>(ColorWheel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void scan(GameEvents.ScanStart evt)
    {
        AudioSource.PlayClipAtPoint(DroneScan, evt.enemy.transform.position, volume * 1.5f);
    }

    void droneHit(GameEvents.EnemyHit evt)
    {
        AudioSource.PlayClipAtPoint(DroneHit, evt.enemy.transform.position, volume);
    }

    void droneDeath(GameEvents.EnemyDie evt)
    {
        AudioSource.PlayClipAtPoint(DroneDeath, evt.enemy.transform.position, volume);
    }

    void shootPaint(GameEvents.ShootPaint evt)
    {
        AudioSource.PlayClipAtPoint(ShootPaint, Vector3.zero, volume * 1.5f);
    }

    void ColorWheel (GameEvents.ColorWheelChange evt)
    {
        AudioSource.PlayClipAtPoint(colorWheel, Vector3.zero, volume);
    }
}