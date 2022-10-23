using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 50.0f;
    [SerializeField] private Transform towerBase;
    [SerializeField] private SpriteRenderer tSP;
    [SerializeField] private Sprite damagedOne;
    [SerializeField] private Sprite damagedTwo;
    [SerializeField] private Sprite damagedThree;
    [SerializeField] private Sprite damagedFour;

    public AK.Wwise.Event TowerDestorySoundPlay;
    public AK.Wwise.Event TowerDestorySoundStop;
    

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        AkSoundEngine.SetRTPCValue("health", 50f);
    }

    // Update is called once per frame
    void Update()
    {

    }
        

    public void Damaged(float damage)
    {
        health -= damage;

        if (health / maxHealth * 100 <= 75 && health / maxHealth * 100 > 50)
        {
            SwitchSprite(1);
            AkSoundEngine.SetRTPCValue("health", 35f);
        }
        else if (health / maxHealth * 100 <= 50 && health / maxHealth * 100 > 25)
        {
            SwitchSprite(2);
            AkSoundEngine.SetRTPCValue("health", 20f);
            TowerDestorySoundPlay.Post(gameObject);
        }
        else if (health / maxHealth * 100 <= 25 && health / maxHealth * 100 > 0)
        {
            SwitchSprite(3); 
            AkSoundEngine.SetRTPCValue("health", 10f);
        }
        else if (health == 0)
        {
            SwitchSprite(4);
            AkSoundEngine.SetRTPCValue("health", 0f);
            TowerDestorySoundStop.Post(gameObject);
        }
    }

    public Vector2 BaseGetPosition()
    {
        return towerBase.position;
    }

    public float GetHealth()
    {
        return health;
    }

    private void SwitchSprite(int index)
    {
        switch (index)
        {
            case 1:
                tSP.sprite = damagedOne;
                break;
            case 2:
                tSP.sprite = damagedTwo;
                break;
            case 3:
                tSP.sprite = damagedThree;
                break;
            case 4:
                tSP.sprite = damagedFour;
                break;

        }

    }
}
