import { createFeature, createReducer, on } from '@ngrx/store';
import { CountByValues, CounterActions } from './actions';
import { Action } from 'rxjs/internal/scheduler/Action';

export interface CounterState {
  current: number;
  by: CountByValues;
}

export const initialState: CounterState = {
  current: 0,
  by: 1,
};

export const counterFeature = createFeature({
  name: 'counter',
  reducer: createReducer(
    initialState,
    on(CounterActions.incremented, (state) => ({
      ...state,
      current: state.current + state.by,
    })),
    on(CounterActions.decremented, (state) => ({
      ...state,
      current: state.current - state.by,
    })),
    on(CounterActions.reset, (state) => ({
      ...state,
      current: initialState.current,
    })),
    on(CounterActions.countByChanged, (state, action) => ({
      ...state,
      by: action.payload,
    })),
    on(CounterActions.state, (_, action) => action.payload)
  ),
});
