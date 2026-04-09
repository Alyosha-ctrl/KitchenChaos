using UnityEngine;

public class PlateCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO plate;
    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    public override void Interact(Player player)
    {
        base.Interact(player);
    }

    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if(spawnPlateTimer > spawnPlateTimerMax)
        {
            kitchenObject.SpawnKitchenObject(plate, this);
            spawnPlateTimer = 0f;
        }
    }
}
