import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { counterFeature } from './state';
import { CounterAction } from './state/actions';

@Component({
  selector: 'app-counter',
  standalone: true,
  imports: [],
  template: `
    <div>
      <button (click)="decrement()" class="btn btn-primary">-</button>
      <span class="mx-2">{{ current() }}</span>
      <button (click)="increment()" class="btn btn-primary">+</button>
    </div>
    <div>
      <button
        (click)="reset()"
        class="btn btn-accent btn-md mt-5"
        [disabled]="current() === 0"
      >
        Reset Count
      </button>
    </div>
  `,
  styles: ``,
})
export class CounterComponent {
  // private store: Store; // backing field
  // constructor(store: Store) {{
  //   this.store = store;
  // }}
  constructor(private store: Store) {}
  current = this.store.selectSignal(counterFeature.selectCurrent);

  increment() {
    this.store.dispatch(CounterAction.incremented());
  }

  decrement() {
    this.store.dispatch(CounterAction.decremented());
  }

  reset() {
    this.store.dispatch(CounterAction.reset());
  }
}
