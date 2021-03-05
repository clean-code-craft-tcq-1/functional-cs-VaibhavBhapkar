using System;
using System.Diagnostics;

class Checker
{
   static int Main()
    {
        IBatteryLimits iBatteryLimits = new BatteryLimits();
        BatteryExamine batteryExamine = new BatteryExamine(iBatteryLimits);
        Console.WriteLine("-- Tests which are returning correct results with true limits --");
        batteryExamine.BatteryIsOk(25, 70, 0.7f);
        batteryExamine.BatteryIsOk(50, 85, 0.3f);
        Console.WriteLine("-- Tests which are returning false results with fake limits --");
        IBatteryLimits iBatteryFakeLimits = new FakeBatteryLimits();
        BatteryExamine fakeBatteryExamine = new BatteryExamine(iBatteryFakeLimits);
        fakeBatteryExamine.BatteryIsOk(25, 70, 0.7f);
        fakeBatteryExamine.BatteryIsOk(50, 85, 0.3f);
        return 0;
    } 
}
