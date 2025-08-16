using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FloorController : MonoBehaviour
{
    public Tilemap myMap;
    public TileBase blackTile;
    public TileBase whiteTile;


    public static FloorController tileScript;
    public TMP_Text percentText;
    public TMP_Text finishText;

    public int tilePercentInt = 0;

    float allWhiteBlocksCount = 0;

    private void Awake()
    {
        tileScript = this;
    }

    void Start()
    {
        allWhiteBlocksCount = GetTileAmountSprite(whiteTile);
        percentText.text = allWhiteBlocksCount + " of 100";


    }

    
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        

        if (collision.tag == "Mop")
        {
            Vector3 tileAtWorldPositon = collision.transform.position;
            Vector3Int cellPositionTriggered = myMap.WorldToCell(tileAtWorldPositon);
            //Tilebase a = myMap.GetTile<TileBase>(cellPositionTriggered);

            myMap.SetTile(cellPositionTriggered, blackTile);
            myMap.RefreshTile(cellPositionTriggered);

            float amountOfWhiteTiles = GetTileAmountSprite(whiteTile);
            float tilePercent = (amountOfWhiteTiles / allWhiteBlocksCount) * 100;
            tilePercentInt = (int)tilePercent;

            percentText.text = tilePercentInt + " of 100";
            //print(tilePercentInt);
            

            if (tilePercentInt <= 0)
            {
                finishText.enabled = true;
            }
        }
        
    }

    public int GetTileAmountSprite(TileBase targetSprite)
    {
        int amount = 0;

        // loop through all of the tiles        
        BoundsInt bounds = myMap.cellBounds;
        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            
            TileBase tile = myMap.GetTile(pos);
            if (tile != null)
            {
                if (tile == targetSprite)
                {
                    amount += 1;
                }
            }
        }

        
        return amount;
    }
}
