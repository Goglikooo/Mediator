#define SOLUTION

using System;
using System.Collections.Generic;
using System.Linq;


public sealed class Runway
{
    public bool IsFree { get; private set; } = true;

    public void Reserve(Aircraft aircraft)
    {
        Reserve(aircraft.CallSign);
    }

    // Used by both the original version and the Mediator version.
    public void Reserve(string callSign)
    {
        IsFree = false;
        Console.WriteLine($"Runway reserved for {callSign}.");
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
        Console.WriteLine($"{CallSign} requests permission to land.");

        if (runway.IsFree &&
            nearbyAircraft.All(aircraft => !aircraft.IsLanding))
        {
            IsLanding = true;
            runway.Reserve(this);

            foreach (var other in nearbyAircraft)
            {
                other.ReceiveWarning($"{CallSign} is landing.");
            }
        }
        else
        {
            Console.WriteLine($"{CallSign}: Hold and wait.");
        }
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

        // Add a fourth aircraft.
        var kl555 = new Aircraft("KL555", runway);

        // INSTRUCTOR SOLUTION:
        // The new aircraft must be added to every old aircraft's list,
        // and every old aircraft must be added to the new aircraft's list.
        lh101.AddNearbyAircraft(kl555);
        ba204.AddNearbyAircraft(kl555);
        af330.AddNearbyAircraft(kl555);

        kl555.AddNearbyAircraft(lh101);
        kl555.AddNearbyAircraft(ba204);
        kl555.AddNearbyAircraft(af330);


        Console.WriteLine();
        Console.WriteLine("After adding KL555:");
        lh101.PrintNearbyAircraft();
        ba204.PrintNearbyAircraft();
        af330.PrintNearbyAircraft();
        kl555.PrintNearbyAircraft();

        Console.WriteLine();
        lh101.RequestLanding();

        Console.WriteLine();
        ba204.RequestLanding();

        Console.WriteLine();
        kl555.RequestLanding();

        Console.WriteLine();
        Console.WriteLine("LH101 finishes landing:");
        lh101.FinishLanding();

        Console.WriteLine();
        ba204.RequestLanding();

        Console.WriteLine();
        Console.WriteLine("==============================");
        Console.WriteLine("TASK 2: MEDIATOR VERSION");
        Console.WriteLine("==============================");

        var mediatorRunway = new Runway();
        var tower = new ControlTower(mediatorRunway);

        var mediatorLh101 = new MediatorAircraft("LH101", tower);
        var mediatorBa204 = new MediatorAircraft("BA204", tower);
        var mediatorAf330 = new MediatorAircraft("AF330", tower);

        mediatorLh101.RequestLanding();
        mediatorBa204.RequestLanding();
        mediatorAf330.RequestLanding();

        Console.WriteLine();
        Console.WriteLine("LH101 finishes landing:");
        tower.ClearRunway();
    }
}

public interface IAirTrafficMediator
{
    void RequestLanding(MediatorAircraft aircraft);
    void ClearRunway();
}

public sealed class MediatorAircraft
{
    private readonly IAirTrafficMediator mediator;

    public string CallSign { get; }

    public MediatorAircraft(
        string callSign,
        IAirTrafficMediator mediator)
    {
        CallSign = callSign;
        this.mediator = mediator;
    }

    public void RequestLanding()
    {
        // The aircraft asks the mediator to coordinate the request.
        mediator.RequestLanding(this);
    }

    public void ReceiveInstruction(string instruction)
    {
        Console.WriteLine($"{CallSign}: {instruction}");
    }
}

public sealed class ControlTower : IAirTrafficMediator
{
    private readonly Runway runway;
    private readonly Queue<MediatorAircraft> landingQueue = new();
    private MediatorAircraft? runwayOccupant;

    public ControlTower(Runway runway)
    {
        this.runway = runway;
    }

    public void RequestLanding(MediatorAircraft aircraft)
    {
        Console.WriteLine(
            $"{aircraft.CallSign} requests permission to land.");

        if (runway.IsFree)
        {
            runwayOccupant = aircraft;
            runway.Reserve(aircraft.CallSign);
            aircraft.ReceiveInstruction("Land now.");
        }
        else
        {
            landingQueue.Enqueue(aircraft);
            aircraft.ReceiveInstruction("Hold and wait.");
        }
    }

    public void ClearRunway()
    {
        runway.Clear();
        runwayOccupant = null;

        if (landingQueue.TryDequeue(out var nextAircraft))
        {
            RequestLanding(nextAircraft);
        }

    }
}
