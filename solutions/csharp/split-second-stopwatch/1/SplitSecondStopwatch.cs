using System;
using System.Collections.Generic;

public enum StopwatchState
{
    Ready,
    Running,
    Stopped
}

public class SplitSecondStopwatch(TimeProvider timeProvider)
{
    private readonly TimeProvider _timeProvider = timeProvider ?? TimeProvider.System;
    private DateTimeOffset? _startTime;
    private TimeSpan _currentLapElapsed = TimeSpan.Zero;
    private TimeSpan _totalElapsed = TimeSpan.Zero;
    private readonly List<TimeSpan> _previousLaps = new();

    public StopwatchState State { get; private set; } = StopwatchState.Ready;

    public TimeSpan CurrentLap => State == StopwatchState.Running
        ? _currentLapElapsed + (_timeProvider.GetUtcNow() - _startTime!.Value)
        : _currentLapElapsed;

    public TimeSpan Total => State == StopwatchState.Running
        ? _totalElapsed + (_timeProvider.GetUtcNow() - _startTime!.Value)
        : _totalElapsed;

    public IReadOnlyCollection<TimeSpan> PreviousLaps => _previousLaps.AsReadOnly();

    public void Start()
    {
        if (State == StopwatchState.Running)
            throw new InvalidOperationException("Stopwatch is already running.");

        _startTime = _timeProvider.GetUtcNow();
        State = StopwatchState.Running;
    }

    public void Stop()
    {
        if (State != StopwatchState.Running)
            throw new InvalidOperationException("Stopwatch is not running.");

        var elapsed = _timeProvider.GetUtcNow() - _startTime!.Value;
        _currentLapElapsed += elapsed;
        _totalElapsed += elapsed;
        _startTime = null;
        State = StopwatchState.Stopped;
    }

    public void Reset()
    {
        if (State == StopwatchState.Ready || State == StopwatchState.Running)
            throw new InvalidOperationException("Reset can only be called from stopped state.");

        _currentLapElapsed = TimeSpan.Zero;
        _totalElapsed = TimeSpan.Zero;
        _previousLaps.Clear();
        State = StopwatchState.Ready;
    }

    public void Lap()
    {
        if (State != StopwatchState.Running)
            throw new InvalidOperationException("Lap can only be called from running state.");

        var elapsed = _timeProvider.GetUtcNow() - _startTime!.Value;
        _currentLapElapsed += elapsed;
        _totalElapsed += elapsed;
        _previousLaps.Add(_currentLapElapsed);

        _currentLapElapsed = TimeSpan.Zero;
        _startTime = _timeProvider.GetUtcNow();
    }
}