using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    // Controls the width and height of the map
    [SerializeField] private int width = 80, height = 45;
    [SerializeField] private Color32 darkColor = new Color32(0, 0, 0, 0), lightColor = new Color32(255, 255, 255, 255);
    [SerializzeField] private TileBase floorTile, wallTile;
    [SerializeField] private Tilemap floorMap, ObstacleMap;

    // Getter methods
    public Tilemap FloorMap { get => floorMap; }
    public Tilemap ObstacleMap { get => obstacleMap; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }


}
