import { Component, OnInit } from '@angular/core';
import { SidebarItem } from '@models/sidebar-item.model';
import { RoutesModule } from '@shared/routes.module';
import { UserAccountService } from '@services/user-account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  private _sidebarItems: SidebarItem[]

  constructor(
    private readonly _accountService: UserAccountService) {
  }

  get IsLoggedIn(): boolean {
    return this._accountService.IsLoggedIn;
  }

  get SidebarItems(): SidebarItem[] {
    return this._sidebarItems;
  }

  ngOnInit(): void {
    this._sidebarItems = RoutesModule.GetSidebarItems();
  }
}
