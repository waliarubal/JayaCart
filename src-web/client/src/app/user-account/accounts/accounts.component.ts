import { Component } from '@angular/core';
import { UserAccount } from '@models/user-account.model';
import { BaseComponent } from '@shared/base.component';
import { UserAccountService } from '@services/user-account.service';
import { MessageService } from '@services/message.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-accounts',
    templateUrl: './accounts.component.html'
})
export class AccountsComponent extends BaseComponent {
    private _accounts: UserAccount[];
    private _keywoards: string;

    constructor(private readonly _accountService: UserAccountService, messageService: MessageService, router: Router) {
        super(messageService, router)
        this._accounts = [];
    }

    get Accounts(): UserAccount[] {
        return this._accounts;
    }

    async Search(keywoards: string = '') {
        this._keywoards = keywoards;

        this.IsBusy = true;
        this._accounts = await this._accountService.GetAllUsers();
        this.IsBusy = false;
    }

    async Activate(account: UserAccount) {
        this.IsBusy = true;

        let record = await this._accountService.Activate(account.PhoneNumber, !account.IsActive);
        if (record)
            await this.Search(this._keywoards);

        this.IsBusy = false;
    }
}