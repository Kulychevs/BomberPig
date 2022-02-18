﻿using UnityEngine;


namespace BomberPig
{
    public sealed class PlayerBuilder : IBuildPlayer
    {
        public UnitView BuildPlayer(GameObject player, Vector2 position)
        {
            var go = GameObject.Instantiate(player, position, Quaternion.identity);

            return go.GetComponent<UnitView>();
        }
    }
}
