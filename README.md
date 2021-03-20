# Programming Paradigms

Electric Vehicles have BMS - Battery Management Systems

[Here is an article that helps to understand the need for BMS](https://circuitdigest.com/article/battery-management-system-bms-for-electric-vehicles)

[Wikipedia gives an idea of the types and topologies](https://en.wikipedia.org/wiki/Battery_management_system)

[This site gives the optimum Charging-temperature limits](https://batteryuniversity.com/learn/article/charging_at_high_and_low_temperatures)

[This abstract suggests a range for the optimum State of Charge](https://www.sciencedirect.com/science/article/pii/S2352484719310911)

[Here is a reference for the maximum charge rate](https://www.electronics-notes.com/articles/electronic_components/battery-technology/li-ion-lithium-ion-charging.php#:~:text=Constant%20current%20charge:%20In%20the%20first%20stage%20of,rate%20of%20a%20maximum%20of%200.8C%20is%20recommended.)

## Possible purpose

- Protect batteries while charging:
at home, in public place, within vehicle / regenerative braking
- Estimate life, inventory and supply chains

## The Starting Point

We will explore the charging phase of Li-ion batteries to start with.

## Issues

- The code here has high complexity in a single function.
- The tests are not complete - they do not cover all the needs of a consumer

## Tasks

1. Reduce the cyclomatic complexity.
1. Separate pure functions from I/O
1. Avoid duplication - functions that do nearly the same thing
1. Complete the tests - cover all conditions.
1. To take effective action, we need to know
the abnormal measure and the breach -
whether high or low. Add this capability.

## The Exploration

How well does our code hold-out in the rapidly evolving EV space?
Can we add new functionality without disturbing the old?

## The Landscape

- Limits may change based on new research
- Technology changes due to obsolescence
- Sensors may be from different vendors with different accuracy
- Predicting the future requires Astrology!

## Keep it Simple

Shorten the Semantic distance

- Procedural to express sequence
- Functional to express relation between input and output
- Object oriented to encapsulate state with actions
- Apect oriented to capture repeating aspects

## My Assignment

For performing task i have added below files also explaining the need of each individual file,

- BatteryExamine.cs
- IBatteryLimits.cs
- BatteryLimits.cs
- FakeBatteryLimits.cs
- checker.cs

1) BatteryExamine.cs
   - purpose of adding this class is to refactor the battery condition checking facility separately.
   - Here, I have separated the each parameter check function(i.e Temperature,State of Charge & Charge rate) separately and perform battery condition status check in separate function.
   - Dependency Injection is used to get the default limit values for comparision.
   - Making it as readonly so nobody allowed to chnages its state and all the functions inside class will be pure.

2) IBatteryLimits.cs
   - Interface used to declare the default values for limits.
   - Using interface for constructor dependency injection.

3) BatteryLimits.cs
   - setting up the limits for paramaeters by inheriting interface.
   - Throgh this approch setting up limits is also easy in future in case of any chnage.

4) FakeBatteryLimits.cs
   - This class also going to inherit interface IBatteryLimit and set the fake values for limit which is used for testing.
   - By setting up false values we can cover testing function(ExpectTrue,ExpectFalse) which we are not able to covert testing initially.

5) checker.cs
   - Tetsing functions and executing tests.
   
