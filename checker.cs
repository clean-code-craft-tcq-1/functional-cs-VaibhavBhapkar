using System;
using System.Diagnostics;

class Checker
{
    static void ExpectTrue(bool expression)
    {
        if (!expression)
        {
            Console.WriteLine("Battery condition expected normal, but got faulty");
        }
    }
    static void ExpectFalse(bool expression)
    {
        if (expression)
        {
            Console.WriteLine("Battery condition expected faulty, but got normal");
        }
    }
    static int Main()
    {
        IBatteryLimits iBatteryLimits = new BatteryLimits();
        BatteryExamine batteryExamine = new BatteryExamine(iBatteryLimits);
        Console.WriteLine("-- Tests which are returning correct results with true limits --");
        ExpectTrue(batteryExamine.BatteryIsOk(new BatteryFactors(25, 70, 0.7f)));
        ExpectFalse(batteryExamine.BatteryIsOk(new BatteryFactors(50, 85, 0.3f)));
        Console.WriteLine("-- Tests which are returning false results with fake limits --");
        IBatteryLimits iBatteryFakeLimits = new FakeBatteryLimits();
        BatteryExamine fakeBatteryExamine = new BatteryExamine(iBatteryFakeLimits);
        ExpectTrue(fakeBatteryExamine.BatteryIsOk(new BatteryFactors(25, 70, 0.7f)));
        ExpectFalse(fakeBatteryExamine.BatteryIsOk(new BatteryFactors(50, 85, 0.3f)));
        return 0;
    }
}
