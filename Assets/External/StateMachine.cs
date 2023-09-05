﻿using System.Collections.Generic;

public interface IState<AgentType> where AgentType : class
{
    public void Enter(AgentType agent);
    public void Update(AgentType agent, float deltaTime);
    public void Exit(AgentType agent);
}

public class StateMachine<AgentType> where AgentType : class
{
    protected AgentType _agent;
    protected IState<AgentType> _currentState = null;
    protected List<IState<AgentType>> _states;
    protected int _stateIndex = -1;

    public StateMachine(AgentType agent)
    {
        _agent = agent;
        _states = new List<IState<AgentType>>();
    }

    public void AddState<StateType>() where StateType : IState<AgentType>, new()
    {
        _states.Add(new StateType());
    }

    public void Update(float deltaTime)
    {
        _currentState.Update(_agent, deltaTime);
    }

    public void ChangeState(int index)
    {
        if (_currentState != null)
            _currentState.Exit(_agent);

        _currentState = _states[index];
        _currentState.Enter(_agent);
        _stateIndex = index;
    }

    public int CurrentState { get { return _stateIndex; } }
}

