import { Component, OnInit } from '@angular/core';
import { UserAccountService } from '@services/user-account.service';
import { UserAccount } from '@models/user-account.model';

@Component({
    selector: 'app-accounts',
    templateUrl: './accounts.component.html',
    providers: [UserAccountService]
})
export class AccountsComponent implements OnInit {
    private _accounts: UserAccount[];

    constructor(private readonly _accountsService: UserAccountService) {
        this._accounts = [];
    }

    get Accounts(): UserAccount[] {
        return this._accounts;
    }

    ngOnInit(): void {
        this._accountsService.GetAllUsers()
            .then((accounts) => this._accounts = accounts);
    }
}