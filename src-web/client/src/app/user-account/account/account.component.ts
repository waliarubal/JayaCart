import { Component, OnInit, OnDestroy } from '@angular/core';
import { BaseComponent } from '@shared/base.component';
import { UserAccount } from '@models/user-account.model';
import { UserAccountService } from '@services/user-account.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { MessageService, MessageType } from '@services/message.service';

@Component({
    selector: 'app-account',
    templateUrl: './account.component.html'
})
export class AccountComponent extends BaseComponent implements OnInit, OnDestroy {
    private _isEdit: boolean;
    private _isProfile: boolean;
    private _subscription: Subscription;
    Account: UserAccount;

    constructor(
        private readonly _accountService: UserAccountService,
        private readonly _route: ActivatedRoute,
        messageService: MessageService,
        router: Router) {
        super(messageService, router);
        this.Account = new UserAccount();

        this.SetValidationMessage('PhoneNumber',
            { key: 'required', value: 'Mobile phone number not entered.' },
            { key: 'minlength', value: 'Mobile phone number must be ten characters long.' },
            { key: 'maxlength', value: 'Mobile phone number must not exceed ten characters.' });
        this.SetValidationMessage('FirstName', { key: 'required', value: 'First name not entered.' });
        this.SetValidationMessage('AddressLine1', { key: 'required', value: 'Address not entered.' });
        this.SetValidationMessage('City', { key: 'required', value: 'City not selected.' });
    }

    get IsEdit(): boolean {
        return this._isEdit;
    }

    get IsProfile(): boolean {
        return this._isProfile;
    }

    ngOnInit(): void {
        this._subscription = this._route.params.subscribe(async param => {
            let phoneNumber = param['PhoneNumber'];
            if (!phoneNumber) {
                phoneNumber = this._accountService.Account.PhoneNumber;
                this._isProfile = true;
            }
            
            this._isEdit = true;
            this.Account = await this._accountService.GetUser(phoneNumber);
        });
    }

    ngOnDestroy(): void {
        this._subscription.unsubscribe();
    }

    async Save() {
        if (!this.Validate())
            return;

        this.IsBusy = true;

        let account = this.IsEdit ?
            await this._accountService.Update(this.Account) :
            await this._accountService.CreateUser(this.Account);
        if (account) {
            this.Toast('Record saved successfully.', MessageType.Info);
            if (!this.IsEdit)
                this.Account = new UserAccount();
        }

        this.IsBusy = false;
    }

    Clear(): void {
        if (this.IsEdit)
            super.Clear(undefined, { PhoneNumber: this.Account.PhoneNumber }, 'FirstName');
        else
            super.Clear(undefined, undefined, 'PhoneNumber');
    }
}