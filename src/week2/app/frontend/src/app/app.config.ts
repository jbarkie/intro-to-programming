import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { reducers } from './state';
import { routes } from './app.routes';
import { provideState, provideStore } from '@ngrx/store';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { counterFeature } from './pages/counter/state';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideStore(reducers),
    provideState(counterFeature),
    provideStoreDevtools(),
  ],
};
