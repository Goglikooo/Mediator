#define SOLUTION

using System;
using System.Collections.Generic;
using System.Linq;

public sealed class Runway
{
    public bool IsFree { get; private set; } = true;

    public void Reserve(Aircraft aircraft)
    {
        IsFree = false;
        Console.WriteLine($"Runway reserved for {aircraft.CallSign}.");
    }

    public void Clear()
    {
        IsFree = true;
        Console.WriteLine("Runway is clear.");
    }
}

public sealed class Aircraft
{
    private readonly Runway runway;
    private readonly List<Aircraft> nearbyAircraft = new();

    public string CallSign { get; }
    public bool IsLanding { get; private set; }

    public Aircraft(string callSign, Runway runway)
    {
        CallSign = callSign;
        this.runway = runway;
    }

    public void AddNearbyAircraft(Aircraft other)
    {
        if (other != this && !nearbyAircraft.Contains(other))
        {
            nearbyAircraft.Add(other);
        }
    }

    public void RequestLanding()
    {
        // ============================================================
        // STUDENT TASK: YOUR CODE GOES HERE
        // ============================================================
        // Implement the landing logic:
        // 1. Print that this aircraft requests permission to land.
        // 2. Check that the runway is free.
        // 3. Check that no nearby aircraft is already landing.
        // 4. If landing is allowed:
        //      - set IsLanding to true;
        //      - reserve the runway;
        //      - warn every nearby aircraft.
        // 5. Otherwise print: "<CallSign>: Hold and wait."
        // ============================================================
    }

    public void ReceiveWarning(string message)
    {
        Console.WriteLine($"{CallSign} receives warning: {message}");
    }

    public void FinishLanding()
    {
        IsLanding = false;
        runway.Clear();
    }

    public void PrintNearbyAircraft()
    {
        Console.Write($"{CallSign} knows: ");

        foreach (var aircraft in nearbyAircraft)
        {
            Console.Write($"{aircraft.CallSign} ");
        }

        Console.WriteLine();
    }
}

public static class Program
{
    public static void Main()
    {
        var runway = new Runway();

        var lh101 = new Aircraft("LH101", runway);
        var ba204 = new Aircraft("BA204", runway);
        var af330 = new Aircraft("AF330", runway);

        // Initial setup: every aircraft must know the other aircraft.
        // These are separate lists, so both directions must be configured.
        lh101.AddNearbyAircraft(ba204);
        lh101.AddNearbyAircraft(af330);

        ba204.AddNearbyAircraft(lh101);
        ba204.AddNearbyAircraft(af330);

        af330.AddNearbyAircraft(lh101);
        af330.AddNearbyAircraft(ba204);

        Console.WriteLine("Initial aircraft knowledge:");
        lh101.PrintNearbyAircraft();
        ba204.PrintNearbyAircraft();
        af330.PrintNearbyAircraft();

    }
}
