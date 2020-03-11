import { Component } from '@angular/core';
import { UserAccountService } from '@services/user-account.service';
import { UserAccount } from '@models/user-account.model';
import { SharedComponent } from '@shared/shared.component';

@Component({
    selector: 'app-user-account',
    templateUrl: './user-account.component.html',
    providers: [UserAccountService]
})
export class UserAccountComponent extends SharedComponent {
    private _accounts: UserAccount[];

    constructor(private readonly _accountService: UserAccountService) {
        super();
        this._accounts = [];
    }

    get Accounts(): UserAccount[] {
        return this._accounts;
    }

    async Search() {
        this.IsBusy = true;
        this._accounts = await this._accountService.GetAllUsers();
        this.IsBusy = false;
    }
}