using System;
using System.Collections.Generic;
using System.Text;


public interface IBatteryLimits
{
    float minTemperature { get; }
    float maxTemperature { get; }
    float minStateOfCharge { get; }
    float maxStateOfCharge { get; }
    float minChargeRate { get; }
}

