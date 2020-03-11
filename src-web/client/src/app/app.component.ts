import { Component } from '@angular/core';
import { Router, RouterEvent } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  IsCollapsed: boolean[];

  constructor(private readonly _router: Router) {
    this.IsCollapsed = [
      true
    ];

    this._router.events.subscribe((e: RouterEvent) => this.Navigated(e));
  }

  private Navigated(data: RouterEvent): void {
    if (!data.url)
      return;

    console.log(data.url);
  }
}
