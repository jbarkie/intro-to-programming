import { NgClass } from '@angular/common';
import { Component, inject, input } from '@angular/core';
import { TodoListItem } from '../../models';
import { Store } from '@ngrx/store';
import { TodoEvents } from '../../state/actions';
import { AlertInformationComponent } from '../../../../components/alert-information/alert-information.component';

@Component({
  selector: 'app-todo-item-list',
  standalone: true,
  template: `
    @if(list().length === 0) {
    <app-alert-information message="You have nothing on your Todo List!" />
    }
    <ul>
      @for(item of list(); track item.id) {
      <li class="card bg-base-300 shawdow-xl mb-4">
        <div class="card-body">
          <span [ngClass]="{ 'line-through': item.completed }">{{
            item.description
          }}</span>
          @if (item.dueDate != null) {
          <span>Due Date: {{ toDate(item.dueDate.toString()) }}</span>
          } @if (item.priority != null) {
          <span>Priority: {{ item.priority.toString() }}</span>
          }
          <div class="card-actions justify-end">
            @if(item.completed === false) {
            <button
              (click)="toggleCompleted(item)"
              class="btn btn-sm btn-primary"
            >
              X
            </button>
            } @else {
            <button
              (click)="toggleCompleted(item)"
              class="btn btn-sm btn-accent"
            >
              +
            </button>
            }
          </div>
        </div>
      </li>
      }
    </ul>
  `,
  styles: ``,
  imports: [NgClass, AlertInformationComponent],
})
export class TodoItemListComponent {
  // @Input({ required: true }) list: TodoListItem[] = [];
  list = input.required<TodoListItem[]>();
  private store = inject(Store);

  toggleCompleted(item: TodoListItem) {
    this.store.dispatch(TodoEvents.todoItemCompletedToggled({ payload: item }));
  }

  toDate(dateString: string) {
    return dateString === null ? '' : new Date(dateString).toDateString();
  }
}
