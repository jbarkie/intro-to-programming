import { Component, EventEmitter, Output, inject } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Store } from '@ngrx/store';
import { TodoEvents } from '../../state/actions';

@Component({
  selector: 'app-todo-entry',
  standalone: true,
  imports: [ReactiveFormsModule],
  template: `
    <form [formGroup]="form" (ngSubmit)="addItem()">
      <div>
        <label>Description</label>
        <input
          type="text"
          formControlName="description"
          placeholder="Type here"
          class="input input-bordered w-full max-w-xs"
        />
        @if(description.invalid && (description.touched || description.dirty)) {
        <div>
          <p>You have errors</p>
          @if(description.getError('required')) {
          <p>You must provide a description.</p>
          } @if(description.getError('minlength')) {
          <p>A Todo that short isn't worth doing!</p>
          } @if(description.getError('maxlength')) {
          <p>Too long, are you crazy?!</p>
          }
        </div>
        }
        <button type="submit" class="btn btn-md btn-primary ">Add Item</button>
      </div>
    </form>
  `,
  styles: ``,
})
export class TodoEntryComponent {
  @Output() itemAdded = new EventEmitter<{ description: string }>();
  form = new FormGroup({
    description: new FormControl('', {
      nonNullable: true,
      validators: [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(124),
      ],
    }),
  });

  private store = inject(Store); // this or constructor

  get description() {
    return this.form.controls.description;
  }
  addItem() {
    if (this.form.valid) {
      this.store.dispatch(
        TodoEvents.todoItemAdded({
          payload: this.form.controls.description.value,
        })
      );
    }
    this.form.reset();
  }
}
