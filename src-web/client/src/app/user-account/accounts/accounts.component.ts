import { Component, OnInit, Input } from '@angular/core';
import { UserAccount } from '@models/user-account.model';

@Component({
    selector: 'app-accounts',
    templateUrl: './accounts.component.html'
})
export class AccountsComponent {
    @Input() Accounts: UserAccount[];
}