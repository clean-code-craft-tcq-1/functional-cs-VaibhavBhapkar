using System;
using System.Diagnostics;

class Checker
{
    static void ExpectTrue(bool expression)
    {
        if (!expression)
        {
            Console.WriteLine("Expected true, but got false");
        }
    }
    static void ExpectFalse(bool expression)
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
        ExpectTrue(batteryExamine.BatteryIsOk(25, 70, 0.7f));
        ExpectFalse(batteryExamine.BatteryIsOk(50, 85, 0.3f));
        Console.WriteLine("All Ok !!!");
        Console.WriteLine("-- Tests which are returning false results with fake limits --");
        IBatteryLimits iBatteryFakeLimits = new FakeBatteryLimits();
        BatteryExamine fakeBatteryExamine = new BatteryExamine(iBatteryFakeLimits);
        ExpectTrue(fakeBatteryExamine.BatteryIsOk(25, 70, 0.7f));
        ExpectFalse(fakeBatteryExamine.BatteryIsOk(50, 85, 0.3f));
        return 0;
    }
}
