using System;
using System.Collections.Generic;
using System.Text;

public class BatteryLimits : IBatteryLimits
{
    public float minTemperature => 0;
    public float maxTemperature => 45;
    public float minStateOfCharge => 20;
    public float maxStateOfCharge => 80;
    public float minChargeRate => 0.8F;
}

