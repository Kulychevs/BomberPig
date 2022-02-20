using UnityEngine;
using System.Collections.Generic;


namespace BomberPig
{
    public sealed class MapBuilder
    {
        private const string OBSTACLES_PARENT_NAME = "Obstacles";


        public CellModel[,] CreateMap(MapData data)
        {
            var map = new CellModel[data.GetMap.Count, data.GetMap[0].Cells.Count];

            var columnStep = CalculateStep(data.GetUpperLeft, data.GetUpperRight, data.GetMap[0].Cells.Count);
            var rowStep = CalculateStep(data.GetUpperLeft, data.GetLowerLeft, data.GetMap.Count);

            for (int i = 0; i < data.GetMap.Count; i++)
            {
                var cellCenter = data.GetUpperLeft + i * rowStep;
                for (int j = 0; j < data.GetMap[0].Cells.Count; j++)
                {
                    map[i, j] = new CellModel(cellCenter, data.GetMap[i].Cells[j].IsObstacle);
                    cellCenter += columnStep;
                }
            }

            BuildObstacles(data.GetMap, map);

            return map;
        }

        private Vector2 CalculateStep(Vector2 begin, Vector2 end, int numberOfCells)
        {
            var stepDistance = (end - begin).magnitude / (numberOfCells - 1);
            var step = (end - begin).normalized * stepDistance;

            return step;
        }

        private void BuildObstacles(List<InitRow> initMap, CellModel[,] map)
        {
            var parentObstacle = new GameObject(OBSTACLES_PARENT_NAME);
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
