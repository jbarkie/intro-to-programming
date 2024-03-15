import { Component, EventEmitter, Output, inject } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { Store } from '@ngrx/store';
import { TodoEvents } from '../../state/actions';
import { TodoEntity } from '../../types';

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
          class="input input-bordered w-full max-w-xs my-2 mx-2"
        />
        @if(description.invalid && (description.touched || description.dirty)) {
        <div>
          @if(description.getError('required')) {
          <p>You must provide a description.</p>
          } @if(description.getError('minlength')) {
          <p>A Todo that short isn't worth doing!</p>
          } @if(description.getError('maxlength')) {
          <p>Too long, are you crazy?!</p>
          }
        </div>
        }
        <div>
          <label>Due Date</label>
          <input
            type="date"
            formControlName="dueDate"
            placeholder="MM/DD/YYYY"
            class="input input-bordered w-full max-w-xs my-2 mx-2"
          />
        </div>
        @if (dueDate.invalid && (dueDate.touched || dueDate.dirty)) {
        <p>You cannot provide a due date that has already passed.</p>
        }
        <div>
          <label>Priority</label>
          <input
            type="text"
            formControlName="priority"
            placeholder="Low"
            class="input input-bordered w-full max-w-xs my-2 mx-2"
          />
        </div>
        @if (priority.invalid && (priority.touched || priority.dirty)) {
        <p>Priority must be Low or High.</p>
        }
        <button type="submit" class="btn btn-md btn-primary mb-3 ">
          Add Item
        </button>
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
    dueDate: new FormControl(null, {
      nonNullable: false,
      validators: [dateValidator],
    }),
    priority: new FormControl(null, {
      nonNullable: false,
      validators: Validators.pattern('(Low)|(High)'),
    }),
  });

  private store = inject(Store); // this or constructor

  get description() {
    return this.form.controls.description;
  }

  get dueDate() {
    return this.form.controls.dueDate;
  }

  get priority() {
    return this.form.controls.priority;
  }

  addItem() {
    if (this.form.valid) {
      this.store.dispatch(
        TodoEvents.todoItemAdded({
          description: this.description.value,
          dueDate: this.dueDate.value ?? undefined,
          priority: this.priority.value ?? undefined,
        })
      );
    }
    this.form.reset();
  }
}

function dateValidator(control: AbstractControl): ValidationErrors | null {
  if (control?.value) {
    const today = new Date();
    const dateToCheck = new Date(control.value.split('-'));
    if (dateToCheck <= today) {
      return { 'Invalid date': control.value };
    }
  }
  return null;
}
