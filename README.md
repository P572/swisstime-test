# Solution for bowling counter test task

Solution is split into three projects:
* BowlingCounterConsole - Console application to get bowling scores. Contains logic regarding rendering results
* Core - Contains core business logic
* Core.Tests - Contains unit test example 

Example of console application working:
![image](https://user-images.githubusercontent.com/16199901/230677213-a746839a-f929-43b7-a1a0-b9cdcb5254da.png)

Triangle is used to denote a Spare frame, as default console fonts usually don't support half filled square symbol.

---
According to design requirement, actual bowling score counter logic is decoupled and can be used anywhere. All that is needed is to register it:
```
        var serviceProvider = new ServiceCollection()
            .AddBowlingCounterServices()
            .BuildServiceProvider();
```

After that, request `IBowlingScoreFactory` from DI and use it:
```
        var scoreResult = bowlingScoreCounter.Create(frameInputs);
```
