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
    public void BatteryIsOk(BatteryFactors batteryFactors)
    {
        CompareTemperatureWithRange(batteryFactors.batteryTemprature);
        CompareStateOfChargeWithRange(batteryFactors.batteryStateOfCharge);
        CompareChargeRateWithRange(batteryFactors.batteryChargeRate);       
    }
    private void CompareTemperatureWithRange(float batteryTemperature)
    {
        if (batteryTemperature < batteryLimits.minTemperature)
        {
            DisplayMessage("Temperature","Low");
        }
        else if(batteryTemperature > batteryLimits.maxTemperature)
        {
            DisplayMessage("Temperature", "High");
        }
        else
        {
            DisplayMessage("Temperature", "Normal");
        }
    }
    public void CompareStateOfChargeWithRange(float stateOfCharge)
    {
        if (stateOfCharge < batteryLimits.minStateOfCharge)
        {
            DisplayMessage("State of Charge", "Low");
        }
        else if (stateOfCharge > batteryLimits.maxStateOfCharge)
        {
            DisplayMessage("State of Charge", "High");
        }
        else
        {
            DisplayMessage("State of Charge", "Normal");
        }
    }
    public void CompareChargeRateWithRange(float chargeRate)
    {
        if (chargeRate > batteryLimits.minChargeRate)
        {
            DisplayMessage("Charge Rate", "High");
        }
        else
        {
            DisplayMessage("Charge Rate", "Normal");
        }
    }    
    static void DisplayMessage(string batteryParameter,string breachParameter)
    {
        Console.WriteLine("Battery {0} is {1}!", batteryParameter,breachParameter);
    }
}

