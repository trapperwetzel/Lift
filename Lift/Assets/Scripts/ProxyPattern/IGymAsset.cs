using UnityEngine;

public interface IGymAsset {
    void LoadAndDisplay();
}

public class RealGymAsset : IGymAsset {
    private GameObject model;

    public RealGymAsset(string modelPath)
    {
        model = Resources.Load<GameObject>(modelPath);
        GameObject.Instantiate(model);
    }

    public void LoadAndDisplay()
    {
        // Display logic
    }
}

public class GymAssetProxy : IGymAsset {
    private RealGymAsset realAsset;
    private string modelPath;

    public GymAssetProxy(string modelPath)
    {
        this.modelPath = modelPath;
    }

    public void LoadAndDisplay()
    {
        if (realAsset == null)
        {
            realAsset = new RealGymAsset(modelPath);
        }
        realAsset.LoadAndDisplay();
    }
}