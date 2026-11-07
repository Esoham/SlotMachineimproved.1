# SlotMachineimproved.1 — Earlier C# Practice Version

**Status: historical learning project.** This is an earlier C# console implementation of slot-machine/game-loop logic. It is not a payment or gambling service and does not process real money.

The source is in `SlotMachineimproved.1/` with `Program.cs`, `SlotMachineGame.cs`, `SlotMachineUI.cs`, and supporting types. It targets **.NET 7**, which is out of support. No build or test execution was verified during the current portfolio review.

## Where to start
The newer and better documented iteration is [SlotMachineUltra](https://github.com/Esoham/SlotMachineUltra). Prefer that repository when reviewing this learning sequence.

For historical code exploration with a compatible SDK:
```bash
dotnet restore SlotMachineimproved.1.sln
dotnet run --project SlotMachineimproved.1/SlotMachineimproved.1.csproj
```

**Portfolio note:** This repo shows progression through programming exercises; it is not a flagship application. Both versions remain available to preserve the learning history. No real-money features are supported.
