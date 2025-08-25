using System;
using System.Collections.Generic;

public class VectorClock
{
    public Dictionary<string, int> Clock { get; private set; } = new();

    public void Increment(string nodeId)
    {
        if (!Clock.ContainsKey(nodeId)) Clock[nodeId] = 0;
        Clock[nodeId]++;
    }

    public void Merge(Dictionary<string, int> incomingClock)
    {
        foreach (var kvp in incomingClock)
        {
            if (!Clock.ContainsKey(kvp.Key) || Clock[kvp.Key] < kvp.Value)
            {
                Clock[kvp.Key] = kvp.Value;
            }
        }
    }

    public void Rollback(string nodeId)
    {
        if (Clock.ContainsKey(nodeId) && Clock[nodeId] > 0)
        {
            Clock[nodeId]--;
            Console.WriteLine($"[Rollback] {nodeId} rolled back to {Clock[nodeId]}");
        }
    }

    public Dictionary<string, int> GetClock() => new(Clock);
}
