import { Component } from '@angular/core';
import { PageHeaderComponent } from "./components/page-header/page-header.component";

@Component({
    selector: 'app-root',
    standalone: true,
    template: `
    <app-page-header />
    <main>
      <p>Our stuff goes here</p>
    </main>
  `,
    styles: [],
    imports: [PageHeaderComponent]
})
export class AppComponent {
}
