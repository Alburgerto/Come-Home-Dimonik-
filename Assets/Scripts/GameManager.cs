using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Location { Left, Right, Up, Down };

// Handles the flow of the game: starting game event, changing room (calling RoomRandomizer) and logic for the end of the game
public class GameManager : MonoBehaviour
{
    public Dimonik m_dimonik;
    public SpriteRenderer m_shutter;
    private RoomRandomizer m_roomRandomizer;

    // Start is called before the first frame update
    void Start()
    {
        m_roomRandomizer = GetComponent<RoomRandomizer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Pass door location where player changed room to calculate new player position (opposite side)?
    public void ChangeRoom(Location l_spawnLocation)
    {
        StartCoroutine(ChangeRoomSequence(l_spawnLocation));
    }

    private IEnumerator ChangeRoomSequence(Location l_spawnLocation)
    {
        yield return FadeRoom(false, 0.5f);

        m_dimonik.CanMove(false);
        m_roomRandomizer.RandomizeRoom(l_spawnLocation);
        yield return new WaitForSeconds(1);
        m_dimonik.CanMove(true);
        
        yield return FadeRoom(true, 0.5f);
    }

    private IEnumerator FadeRoom(bool l_fadeIn, float l_time)
    {
        float timePassed = 0;
        float alphaFrom = l_fadeIn ? 1 : 0;
        float alphaTo = l_fadeIn ? 0 : 1;
        Color color = m_shutter.color;
        while (timePassed < l_time)
        {
            color.a = Mathf.Lerp(alphaFrom, alphaTo, (timePassed/l_time));
            m_shutter.color = color;
            timePassed += Time.deltaTime;
            yield return null;
        }
        color.a = alphaTo;
        m_shutter.color = color;
    }
}
