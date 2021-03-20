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
    public bool BatteryIsOk(BatteryFactors batteryFactors)
    {
        bool temperatureResult = CompareTemperatureWithRange(batteryFactors.batteryTemprature);
        bool stateOfChargeResult = CompareStateOfChargeWithRange(batteryFactors.batteryStateOfCharge);
        bool chargeRateResult = CompareChargeRateWithRange(batteryFactors.batteryChargeRate);
        return (temperatureResult & stateOfChargeResult & chargeRateResult);
    }
    private bool CompareTemperatureWithRange(float batteryTemperature)
    {
        if (batteryTemperature < batteryLimits.minTemperature)
        {
            DisplayMessage("Temperature", "Low");
            return false;
        }
        else if (batteryTemperature > batteryLimits.maxTemperature)
        {
            DisplayMessage("Temperature", "High");
            return false;
        }
        else
        {
            DisplayMessage("Temperature", "Normal");
            return true;
        }
    }
    private bool CompareStateOfChargeWithRange(float stateOfCharge)
    {
        if (stateOfCharge < batteryLimits.minStateOfCharge)
        {
            DisplayMessage("State of Charge", "Low");
            return false;
        }
        else if (stateOfCharge > batteryLimits.maxStateOfCharge)
        {
            DisplayMessage("State of Charge", "High");
            return false;
        }
        else
        {
            DisplayMessage("State of Charge", "Normal");
            return true;
        }
    }
    private bool CompareChargeRateWithRange(float chargeRate)
    {
        if (chargeRate > batteryLimits.minChargeRate)
        {
            DisplayMessage("Charge Rate", "High");
            return false;
        }
        else
        {
            DisplayMessage("Charge Rate", "Normal");
            return true;
        }
    }
    static void DisplayMessage(string batteryParameter, string breachParameter)
    {
        Console.WriteLine("Battery {0} is {1}!", batteryParameter, breachParameter);
    }
}

