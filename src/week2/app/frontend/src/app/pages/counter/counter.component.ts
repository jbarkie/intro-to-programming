import { Component } from '@angular/core';

@Component({
  selector: 'app-counter',
  standalone: true,
  imports: [],
  template: `
    <div>
      <button class="btn btn-primary">-</button>
      <span>{{ current }}</span>
      <button class="btn btn-primary">+</button>
    </div>
  `,
  styles: ``,
})
export class CounterComponent {
  current = 0;

  increment() {
    this.current += 1;
  }

  decrement() {
    this.current -= 1;
  }
}
