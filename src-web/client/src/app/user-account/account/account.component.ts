import { Component } from '@angular/core';
import { BaseComponent } from '@shared/base.component';
import { UserAccount } from '@models/user-account.model';
import { UserAccountService } from '@services/user-account.service';
import { NgForm } from '@angular/forms';

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

    async Save(form: NgForm) {
        form.form.disable();
        
        this.IsBusy = true;
        let account = await this._accountService.CreateUser(this.Account);
        this.IsBusy = false;

        form.form.enable();
        
        if (account) {
            this.Account = new UserAccount();
        }
    }
}