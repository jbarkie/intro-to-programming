import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, switchMap } from 'rxjs';
// never import development environment
import { environment } from '../../../../environments/environment';
import { ApplicationActions } from '../../../actions';
import { TodoCommands, TodoDocuments } from './actions';
import { TodoEntity } from '../types';

@Injectable()
export class TodoEffects {
  readonly baseUrl = environment.apiUrl;
  // When the application started, what does that mean for the todos feature?
  onStartup = createEffect(() =>
    this.actions$.pipe(
      ofType(ApplicationActions.applicationStarted),
      map(() => TodoCommands.loadTodos())
    )
  );
  // load the todos - when we get that command, go to the API, get the todos, and return the list of todos to the reducer
  loadTodos$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TodoCommands.loadTodos),
      switchMap(() =>
        this.httpClient
          .get<{ list: TodoEntity[] }>(this.baseUrl + '/todos') // returns Observable<{list: TodoEntity[]}>
          .pipe(
            map((results) => results.list),
            map((payload) => TodoDocuments.todos({ payload }))
          )
      )
    )
  );
  constructor(private actions$: Actions, private httpClient: HttpClient) {}
}
