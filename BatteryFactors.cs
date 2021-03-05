using System;
using System.Collections.Generic;
using System.Text;


public class BatteryFactors
{
    public float batteryTemprature, batteryStateOfCharge, batteryChargeRate;
    public BatteryFactors(float temprature, float soc, float chargeRate)
    {
        this.batteryTemprature = temprature;
        this.batteryStateOfCharge = soc;
        this.batteryChargeRate = chargeRate;
    }
}
