import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { reducers } from './state';
import { routes } from './app.routes';
import { provideStore } from '@ngrx/store';
import { provideStoreDevtools } from '@ngrx/store-devtools';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideStore(reducers),
    provideStoreDevtools(),
  ],
};
