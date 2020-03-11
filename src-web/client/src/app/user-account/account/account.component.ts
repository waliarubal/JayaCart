import { Component } from '@angular/core';
import { BaseComponent } from '@shared/base.component';
import { UserAccount } from '@models/user-account.model';

@Component({
    selector: 'app-account',
    templateUrl: './account.component.html'
})
export class AccountComponent extends BaseComponent  {
    Account: UserAccount;

    constructor(){
        super();
        this.Account = new UserAccount();
    }

}