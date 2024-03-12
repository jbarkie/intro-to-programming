// tell TS about app state , what it looks like
// then, tell Ngrx Store that this is what the state IS

import { ActionReducerMap } from '@ngrx/store';

export interface ApplicationState {}

export const reducers: ActionReducerMap<ApplicationState> = {};
