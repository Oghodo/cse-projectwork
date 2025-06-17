// Eternal Quest Program
// This program tracks different types of goals with gamification features
// Exceeds core: Added leveling system and badges

using System;
using System.Collections.Generic;
using System.IO;

Goal|{_name}|{_class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) {}

    public override int RecordEvent() => _points;
    public override bool IsComplete() => false;
    public override string GetStatus() => "[∞] " + _name + " (" + _description + ")";
    public override string GetStringRepresentation() => $"EternalGdescription}|{_points}";
}
