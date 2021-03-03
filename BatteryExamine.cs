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
            CompareTemperatureWithLimits(batteryTemperature);
            DisplayMessage("Temperature");
            return false;
        }
        return true;
    }
    public bool CompareStateOfChargeWithRange(float stateOfCharge)
    {
        if (stateOfCharge < batteryLimits.minStateOfCharge || stateOfCharge > batteryLimits.maxStateOfCharge)
        {
            CompareStateOfChargeWithLimits(stateOfCharge);
            DisplayMessage("State of Charge");
            return false;
        }
        return true;
    }
    public bool CompareChargeRateWithRange(float chargeRate)
    {
        if (chargeRate > batteryLimits.minChargeRate)
        {
            DisplayMaximumLimit("Charge Rate", batteryLimits.minChargeRate);
            DisplayMessage("Charge Rate");
            return false;
        }
        return true;
    }
    public void CompareTemperatureWithLimits(float batteryTemperature)
    {
        if(batteryTemperature < batteryLimits.minTemperature)
        {
            DisplayMinimumLimit("Temperature", batteryLimits.minTemperature);
        }
        else
        {
            DisplayMaximumLimit("Temperature", batteryLimits.maxTemperature);
        }
    }
    public void CompareStateOfChargeWithLimits(float stateOfCharge)
    {
        if (stateOfCharge < batteryLimits.minStateOfCharge)
        {
            DisplayMinimumLimit("State Of Charge", batteryLimits.minStateOfCharge);
        }
        else
        {
            DisplayMaximumLimit("State Of Charge", batteryLimits.maxStateOfCharge);
        }
    }
   
    static void DisplayMessage(string batteryParameter)
    {
        Console.WriteLine("{0} is out of range!", batteryParameter);
    }
    static void DisplayMinimumLimit(string batteryParameter,float batteryParameterLimit)
    {
        Console.WriteLine("{0} value is less than minimun limit of {1}!", batteryParameter,batteryParameterLimit);
    }
    static void DisplayMaximumLimit(string batteryParameter,float batteryParameterLimit)
    {
        Console.WriteLine("{0} value is more than maximum limit of {1}!", batteryParameter,batteryParameterLimit);
    }
}

