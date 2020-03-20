import { Component, OnInit } from '@angular/core';
import { SidebarItem } from '@models/sidebar-item.model';
import { RoutesModule } from '@shared/routes.module';
import { UserAccountService } from '@services/user-account.service';
import { MessageService, MessageType } from '@services/message.service';
import { BaseComponent } from '@shared/base.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent extends BaseComponent implements OnInit {
  readonly MessageType = MessageType;
  private _sidebarItems: SidebarItem[]
  IsSidebarCollapsed: boolean;

  constructor(
    messageService: MessageService,
    router: Router,
    private readonly _accountService: UserAccountService) {
    super(messageService, router);
  }

  get MessageService(): MessageService {
    return this._messageService;
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

  SignOut(): void {
    this._accountService.LogOff();
    this.Navigate('/Login');
  }
}
