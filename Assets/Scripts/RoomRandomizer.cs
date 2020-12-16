using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In charge of choosing a room at random, fill it randomly with details / enemies and place doors very randomly as well
public class RoomRandomizer : MonoBehaviour
{
    // Background
    public Sprite[] m_backgroundImages; // Set of sprites from which 1 will be chosen to use as the Background's object sprite
    public SpriteRenderer m_background;

    // Dimonik
    public Transform m_dimonik;
    public Transform[] m_dimonikSpawnPositions; // Position where Dimonik can spawn (opposite the door he entered in previous room)

    // Door
    public GameObject m_door;
    public Transform[] m_doorPositions; // Position AND rotation that will be inherited by the door/s

    // Details
    public Sprite[] m_collidableDetails; // Environmental details the player/NPCs can collide with
    public Sprite[] m_nonCollidableDetails; // Environmental details the player/NPCs can walk over

    // Enemies
    public GameObject[] m_enemies;


    public void RandomizeRoom(Location l_spawnLocation)
    {
        RandomizeBackground();
        SpawnDimonic(l_spawnLocation);
        SpawnDoors(l_spawnLocation);
        RandomizeDoors();
        RandomizeDetails();
        RandomizeEnemies();
    }

    private void RandomizeBackground()
    {
        // TODO: logic to maybe avoid going to a room with the same BG as the previous room
        int bgSprite = Random.Range(0, m_backgroundImages.Length);
        m_background.sprite = m_backgroundImages[bgSprite];
        
        m_background.flipX = Random.Range(0, 2) == 0 ? true : false;
        m_background.flipY = Random.Range(0, 2) == 0 ? true : false;
    }

    private void SpawnDimonic(Location l_spawnLocation)
    {
        int position = -1;
        if (l_spawnLocation == Location.Left)
        {
            position = 0;
        }
        else if (l_spawnLocation == Location.Right)
        {
            position = 1;
        }
        else if (l_spawnLocation == Location.Up)
        {
            position = 2;
        }
        else if (l_spawnLocation == Location.Down)
        {
            position = 3;
        }
        m_dimonik.GetComponent<Animator>().SetBool("FacingForward", true);
        m_dimonik.position = m_dimonikSpawnPositions[position].position;
    }

    private void SpawnDoors(Location l_spawnLocation)
    {

    }

    private void RandomizeDoors()
    {
        int doorsToSpawn = Random.Range(1, m_doorPositions.Length + 1);
    }

    private void RandomizeEnemies()
    {

    }

    private void RandomizeDetails()
    {

    }


}
