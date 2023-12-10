using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PaintShooter : SingletonLite<PaintShooter>
{
    public float fireRate = 0.1f;
    public float shotRadius = 0.05f;

    float fireTimer = 0.0f;

    PaintExample paintScript;

    struct tileInfo
    {
        public tileInfo(Vector2 Pos, Vector2Int Coords)
        {
            pos = Pos;
            coords = Coords;
        }

        public Vector2 pos;
        public Vector2Int coords;
    }

    // Start is called before the first frame update
    void Start()
    {
        paintScript = FindAnyObjectByType<PaintExample>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0.0f)
            return;

        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;

        if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.JoystickButton0)) 
            && fireTimer >= fireRate)
        {
            fireTimer = 0;
            if (paintScript.CanPaint())
            {

                BuildingGrid grid = GetHitBuilding();
                if (grid == null) return;

                tileInfo info = GetHitTile(grid);

                EvtSystem.EventDispatcher.Raise(new GameEvents.ShootPaint()
                { position = info.pos, hitGrid = grid, hitCoords = info.coords });
            }
        }
    }

    BuildingGrid GetHitBuilding()
    {
        Ray ray = Camera.main.ScreenPointToRay
            (Camera.main.WorldToScreenPoint(Reticle.Instance.transform.position));

        RaycastHit[] hits = Physics.RaycastAll(ray);
        for (int h = 0; h < hits.Length; h++)
        {
            BuildingGrid grid = hits[h].collider.gameObject.GetComponent<BuildingGrid>();
            if (grid != null)
            {
                return grid;
            }
        }

        return null; //never happens
    }

    tileInfo GetHitTile(BuildingGrid grid)
    {
        Vector2[,] tiles = grid.tiles;

        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                Vector2 pos = Reticle.Instance.transform.position;
                Vector2 tile = tiles[i, j];

                if (pos.x >= tile.x - (grid.tileSize.x * 0.5f) && pos.x <= tile.x + (grid.tileSize.x * 0.5f)
                    && pos.y >= tile.y - (grid.tileSize.x * 0.5f) && pos.y <= tile.y + (grid.tileSize.y * 0.5f))
                {
                    return new tileInfo(tile, new Vector2Int(i, j));
                }
            }
        }

        return new tileInfo();
    }
}
