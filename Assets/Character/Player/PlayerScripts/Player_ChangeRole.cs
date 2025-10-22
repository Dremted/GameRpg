using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ChangeRole : MonoBehaviour
{
    public Player_bow player_bow;
    public Player_Combat player_combat;

    public void ChangeRole()
    {
        player_bow.enabled = !player_bow.enabled;
    }
}
