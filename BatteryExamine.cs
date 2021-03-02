using System;
using System.Collections.Generic;
using System.Text;


public class BatteryExamine
{
    private readonly IBatteryLimits batteryLimits;
    public BatteryExamine(IBatteryLimits iBatteryLimits)
    {
        this.batteryLimits = iBatteryLimits;
    }
    public bool BatteryIsOk(float batteryTemperature, float stateOfCharge, float chargeRate)
    {
        bool checkTemperatureResult = CompareTemperatureWithRange(batteryTemperature);
        bool checkStateOfChargeResult = CompareStateOfChargeWithRange(stateOfCharge);
        bool checkChargeRateResult = CompareChargeRateWithRange(chargeRate);
        return (checkTemperatureResult && checkStateOfChargeResult && checkChargeRateResult);
    }
    private bool CompareTemperatureWithRange(float batteryTemperature)
    {
        if (batteryTemperature < batteryLimits.minTemperature || batteryTemperature > batteryLimits.maxTemperature)
        {
            DisplayMessage("Temperature");
            return false;
        }
        return true;
    }
    public bool CompareStateOfChargeWithRange(float stateOfCharge)
    {
        if (stateOfCharge < batteryLimits.minStateOfCharge || stateOfCharge > batteryLimits.maxStateOfCharge)
        {
            DisplayMessage("State of Charge");
            return false;
        }
        return true;
    }
    public bool CompareChargeRateWithRange(float chargeRate)
    {
        if (chargeRate > batteryLimits.minChargeRate)
        {
            DisplayMessage("Charge Rate");
            return false;
        }
        return true;
    }
    static void DisplayMessage(string batteryParameter)
    {
        Console.WriteLine("{0} is out of range!", batteryParameter);
    }
}

