import { Injectable } from '@angular/core';
import { Actions, concatLatestFrom, createEffect, ofType } from '@ngrx/effects';
import { map, tap } from 'rxjs';
import { CounterActions } from './actions';
import { Store } from '@ngrx/store';
import { counterFeature, initialState } from '.';
import { ApplicationActions } from '../../../actions';

@Injectable()
export class CounterEffects {
  //   logTheActions$ = createEffect(
  //     () => this.actions.pipe(tap((a) => console.log(a.type))),
  //     { dispatch: false }
  //   );

  loadTheDataOnApplicationStart$ = createEffect(() =>
    this.actions.pipe(
      ofType(ApplicationActions.applicationStarted),
      map(() => CounterActions.counterEntered())
    )
  );

  // turn a counterEntered into a state either with initialState or what's in local storage
  loadUserCounterData$ = createEffect(() =>
    this.actions.pipe(
      ofType(CounterActions.counterEntered),
      map(() => localStorage.getItem('counter')), // string or null
      map((stuff) => (stuff === null ? initialState : JSON.parse(stuff))),
      map((payload) => CounterActions.state({ payload }))
    )
  );

  saveUserCounterData$ = createEffect(
    () =>
      this.actions.pipe(
        ofType(
          CounterActions.countByChanged,
          CounterActions.reset,
          CounterActions.incremented,
          CounterActions.decremented
        ),
        concatLatestFrom(() =>
          this.store.select(counterFeature.selectCounterState)
        ),
        tap(([_, state]) =>
          localStorage.setItem('counter', JSON.stringify(state))
        )
      ),
    { dispatch: false }
  );
  constructor(private actions: Actions, private store: Store) {}
}
