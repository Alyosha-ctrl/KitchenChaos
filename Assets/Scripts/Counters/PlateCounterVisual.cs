using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlateCounterVisual : MonoBehaviour
{
    [SerializeField] private PlateCounter plateCounter;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform plateVisualPrefab;

    private List<GameObject> plateList;
    private void Awake()
    {
        plateList = new List<GameObject>();
    }

    private void Start()
    {
        plateCounter.OnPlateSpawned += PlateCounter_OnPlateSpawned;
        plateCounter.OnPlateRemoved += PlateCounter_OnPlateRemoved;
    }

    private void PlateCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(plateVisualPrefab, spawnPoint);

        float plateOffsetY = .1f;
        plateVisualTransform.localPosition = new Vector3(0, plateOffsetY*plateList.Count, 0);

        plateList.Add(plateVisualTransform.gameObject);
    }

    private void PlateCounter_OnPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject deadPlate = plateList[plateList.Count-1];
        plateList.Remove(deadPlate);
        Destroy(deadPlate);
    }
    }
