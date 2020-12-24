using System.Collections.Generic;
using UnityEngine;
public class EnemyActiveTankManager : MonoSingletonGeneric<EnemyActiveTankManager>
{
    EnemyTankState m_currentEnemyTankState;

    [SerializeField] private List<EnemyTankState> states = new List<EnemyTankState>();
    private void Start()
    {
        DeactiveAllStates();
        ChangeState(states[0]);
    }

    private void DeactiveAllStates()
    {
        for(int i=0;i<states.Count;i++)
        {
            states[i].OnExit();
        }
    }

    public void ChangeState(EnemyTankState state)
    {
        if(m_currentEnemyTankState !=null)
        {
            m_currentEnemyTankState.OnExit();
        }
        
        m_currentEnemyTankState = state;
        m_currentEnemyTankState.OnEnter();
    }

    public EnemyTankState GetNextState()
    {
        int index = states.FindIndex(x => x.Equals(m_currentEnemyTankState));
        if(index < states.Count - 1)
        {
            index++;
        }
        else
        {
            index = 0;
        }

        return states[index];
    }
    public EnemyTankState GetPrevState()
    {
        int index = states.FindIndex(x => x.Equals(m_currentEnemyTankState));
        if (index == 0)
        {
            index = 0;
        }
        else
        {
            index--;
        }

        return states[index];
    }
}