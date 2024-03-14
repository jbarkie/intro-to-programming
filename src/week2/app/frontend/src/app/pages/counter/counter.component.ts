import { Component, computed } from '@angular/core';
import { Store } from '@ngrx/store';
import { counterFeature } from './state';
import { CounterActions } from './state/actions';
import { count } from 'rxjs';

@Component({
  selector: 'app-counter',
  standalone: true,
  imports: [],
  template: `
    @if(isEven()) {
    <p>Even</p>
    } @else {
    <p>Odd</p>
    }
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
      <p>
        If you increment, the next count will be {{ nextAdd() }}, but if you
        decrement then it will be {{ nextDec() }}
      </p>
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
  isEven = computed(() => this.current() % 2 == 0);
  nextAdd = this.store.selectSignal(counterFeature.nextValueIfIncrement);
  nextDec = this.store.selectSignal(counterFeature.nextValueIfDecrement);
  increment() {
    this.store.dispatch(CounterActions.incremented());
  }

  decrement() {
    this.store.dispatch(CounterActions.decremented());
  }

  reset() {
    this.store.dispatch(CounterActions.reset());
  }
}
