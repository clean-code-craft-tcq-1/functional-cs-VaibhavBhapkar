using System;
using System.Collections.Generic;
using System.Text;


public class FakeBatteryLimits : IBatteryLimits
{
    public float minTemperature => 40;
    public float maxTemperature => 60;
    public float minStateOfCharge => 75;
    public float maxStateOfCharge => 95;
    public float minChargeRate => 0.5F;
}

