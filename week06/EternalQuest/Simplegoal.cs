// Eternal Quest Program
// This program tracks different types of goals with gamification features
// Exceeds core: Added leveling system and badges

using System;
using System.Collections.Generic;
using System.IO;

class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete() => _isComplete;
    public override string GetStatus() => (_isComplete ? "[X]" : "[ ]") + $" {_name} ({_description})";
    public override string GetStringRepresentation() => $"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}";
}
