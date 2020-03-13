import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router, RouterEvent } from '@angular/router';
import { Subscription } from 'rxjs';
import { SidebarItem } from '@models/sidebar-item.model';
import { RoutesModule } from '@shared/routes.module';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnDestroy, OnInit {
  private readonly _onRouteChanged: Subscription;
  private _sidebarItems: SidebarItem[]

  constructor(private readonly _router: Router) {
    this._onRouteChanged = this._router.events.subscribe((e: RouterEvent) => this.Navigated(e));
  }

  get SidebarItems(): SidebarItem[] {
    return this._sidebarItems;
  }

  ngOnInit(): void {
    this._sidebarItems = RoutesModule.GetSidebarItems();
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
