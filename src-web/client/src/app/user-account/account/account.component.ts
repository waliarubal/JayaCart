import { Component } from '@angular/core';
import { BaseComponent } from '@shared/base.component';
import { UserAccount } from '@models/user-account.model';
import { UserAccountService } from '@services/user-account.service';

@Component({
    selector: 'app-account',
    templateUrl: './account.component.html',
    providers: [UserAccountService]
})
export class AccountComponent extends BaseComponent {
    Account: UserAccount;

    constructor(private readonly _accountService: UserAccountService) {
        super();
        this.Account = new UserAccount();

        this.SetValidationMessage('PhoneNumber',
            { key: 'required', value: 'Mobile phone number not entered.' },
            { key: 'minlength', value: 'Mobile phone number must be ten characters long.' },
            { key: 'maxlength', value: 'Mobile phone number must not exceed ten characters.' });
    }

    async Save() {
        if (!this.Validate())
            return;

        this.IsBusy = true;

        let account = await this._accountService.CreateUser(this.Account);
        if (account)
            this.Account = new UserAccount();

        this.IsBusy = false;
    }
}