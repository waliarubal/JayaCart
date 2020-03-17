import { Component } from '@angular/core';
import { UserAccount } from '@models/user-account.model';
import { BaseComponent } from '@shared/base.component';
import { UserAccountService } from '@services/user-account.service';

@Component({
    selector: 'app-accounts',
    templateUrl: './accounts.component.html'
})
export class AccountsComponent extends BaseComponent {
    private _accounts: UserAccount[];

    constructor(private readonly _accountService: UserAccountService) {
        super()
        this._accounts = [];
    }

    get Accounts(): UserAccount[] {
        return this._accounts;
    }

    Keywoards: string;

    async Search(keywoards: string) {
        this.IsBusy = true;

        this._accounts = await this._accountService.GetAllUsers();
        
        this.IsBusy = false;
    }
}