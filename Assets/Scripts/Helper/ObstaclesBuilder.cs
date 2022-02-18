using UnityEngine;
using System.Collections.Generic;


namespace BomberPig
{
    public sealed class ObstaclesBuilder
    {
        public void BuildObstacles(List<InitRow> initMap, CellModel[,] map)
        {
            var parentObstacle = new GameObject("Obstacles");
            for (int i = 0; i < initMap.Count; i++)
            {
                for (int j = 0; j < initMap[i].Cells.Count; j++)
                {
                    if (map[i, j].IsObstacle)
                    {
                        var go = GameObject.Instantiate(initMap[i].Cells[j].ObstaclePrefab,
                            map[i, j].Center, Quaternion.identity, parentObstacle.transform);
                        var spriteRenderer = go.GetComponent<SpriteRenderer>();
                        spriteRenderer.sortingOrder = i;
                    }
                }
            }
        }
    }
}
