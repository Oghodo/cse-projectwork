// Eternal Quest Program
// This program tracks different types of goals with gamification features
// Exceeds core: Added leveling system and badges

using System;
using System.Collections.Generic;
using System.IO;

class ChecklistGoal : Goal
{
    private int _required;
    private int _completed;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int required, int bonus, int completed = 0)
        : base(name, description, points)
    {
        _required = required;
        _bonus = bonus;
        _completed = completed;
    }

    public override int RecordEvent()
    {
        if (_completed < _required)
        {
            _completed++;
            if (_completed == _required)
                return _points + _bonus;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete() => _completed >= _required;
    public override string GetStatus() => ($"[{(_completed >= _required ? "X" : " ")}] {_name} ({_description}) -- Completed {_completed}/{_required}");
    public override string GetStringRepresentation() => $"ChecklistGoal|{_name}|{_description}|{_points}|{_required}|{_bonus}|{_completed}";
}

