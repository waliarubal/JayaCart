import { Component } from '@angular/core';
import { BaseComponent } from '@shared/base.component';
import { UserAccount } from '@models/user-account.model';
import { UserAccountService } from '@services/user-account.service';

@Component({
    selector: 'app-account',
    templateUrl: './account.component.html',
    providers: [UserAccountService]
})
export class AccountComponent extends BaseComponent  {
    Account: UserAccount;

    constructor(private readonly _accountService: UserAccountService){
        super();
        this.Account = new UserAccount();
    }

    async Save() {
        this.Disable();
        this.IsBusy = true;

        let account = await this._accountService.CreateUser(this.Account);
        
        this.IsBusy = false;
        this.Enable();
        
        if (account) {
            this.Account = new UserAccount();
        }
    }
}