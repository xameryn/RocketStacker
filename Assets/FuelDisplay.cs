using UnityEngine;
using TMPro;  // Add this line

public class FuelDisplay : MonoBehaviour
{
    public Ascend rocket;
    public TextMeshProUGUI fuelText;  // Modify this line

    void Update()
    {
        float initialFuel = RocketProperties.fueledMass - RocketProperties.emptyMass;
        float remainingFuelPercentage = (rocket.fuel / initialFuel) * 100;
        fuelText.text = "Fuel: " + remainingFuelPercentage.ToString("0.00") + "%";
    }
}