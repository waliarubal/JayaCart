import { Component, OnDestroy } from '@angular/core';
import { Router, RouterEvent } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnDestroy {
  private readonly _onRouteChanged: Subscription;

  IsCollapsed: boolean[];

  constructor(private readonly _router: Router) {
    this.IsCollapsed = [
      true
    ];

    this._onRouteChanged = this._router.events.subscribe((e: RouterEvent) => this.Navigated(e));
  }

  ngOnDestroy(): void {
    this._onRouteChanged.unsubscribe();
  }

  private Navigated(data: RouterEvent): void {
    if (!data.url)
      return;

    //console.log(data.url);
  }
}
