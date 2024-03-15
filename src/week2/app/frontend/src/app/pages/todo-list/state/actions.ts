import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { TodoEntity } from '../types';
import { TodoListItem } from '../models';

// Command - order ("do this thing") - usually expects something specific to happen as a result
export const TodoCommands = createActionGroup({
  source: 'Todo Commands',
  events: {
    'Load Todos': emptyProps(),
  },
});

// Event - something that happened - that might mean multiple things need to happen, but the event is decoupled from that
export const TodoEvents = createActionGroup({
  source: 'Todo Events',
  events: {
    'Todo Item Added': props<{
      description: string;
      dueDate?: string;
      priority?: string;
    }>(),
    'Todo Item Completed Toggled': props<{ payload: TodoListItem }>(),
  },
});

// Document - often the result of a command
export const TodoDocuments = createActionGroup({
  source: 'Todo Documents',
  events: {
    Todos: props<{ payload: TodoEntity[] }>(),
    Todo: props<{ payload: TodoEntity }>(),
  },
});
