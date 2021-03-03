using System;
using System.Diagnostics;

class Checker
{
    static void ExpectOkBattery(bool expression)
    {
        if (!expression)
        {
            Console.WriteLine("Expected true, but got false");
        }
    }
    static void ExpectFaultyBattery(bool expression)
    {
        if (expression)
        {
            Console.WriteLine("Expected false, but got true");
        }
    }
    static int Main()
    {
        IBatteryLimits iBatteryLimits = new BatteryLimits();
        BatteryExamine batteryExamine = new BatteryExamine(iBatteryLimits);
        Console.WriteLine("-- Tests which are returning correct results with true limits --");
        ExpectOkBattery(batteryExamine.BatteryIsOk(25, 70, 0.7f));
        ExpectFaultyBattery(batteryExamine.BatteryIsOk(50, 85, 0.3f));
        Console.WriteLine("All Ok !!!");
        Console.WriteLine("-- Tests which are returning false results with fake limits --");
        IBatteryLimits iBatteryFakeLimits = new FakeBatteryLimits();
        BatteryExamine fakeBatteryExamine = new BatteryExamine(iBatteryFakeLimits);
        ExpectOkBattery(fakeBatteryExamine.BatteryIsOk(25, 70, 0.7f));
        ExpectFaultyBattery(fakeBatteryExamine.BatteryIsOk(50, 85, 0.3f));
        return 0;
    }
}
