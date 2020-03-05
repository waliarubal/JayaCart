import { Component, OnInit } from '@angular/core';
import { UserAccountService } from '@services/user-account.service';

@Component({
    selector: 'app-accounts',
    templateUrl: './accounts.component.html',
    providers: [UserAccountService]
})
export class AccountsComponent implements OnInit {
    UserAccounts: any;

    constructor(private readonly _accountsService: UserAccountService) {

    }

    ngOnInit(): void {
        this.UserAccounts = this._accountsService.GetAllUsers();
    }
}