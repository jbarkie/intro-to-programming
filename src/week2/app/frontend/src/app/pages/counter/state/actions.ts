import { createActionGroup, emptyProps } from '@ngrx/store';

export const CounterAction = createActionGroup({
  source: 'Counter Component Events',
  events: {
    Incremented: emptyProps(),
    Decremented: emptyProps(),
    Reset: emptyProps(),
  },
});
