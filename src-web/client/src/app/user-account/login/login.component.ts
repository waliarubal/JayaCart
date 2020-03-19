import { Component } from '@angular/core';
import { BaseComponent } from '@shared/base.component';
import { UserAccountService } from '@services/user-account.service';
import { Router } from '@angular/router';
import { MessageService } from '@services/message.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html'
})
export class LoginComponent extends BaseComponent {
    PhoneNumber: string;
    Password: string;

    constructor(
        private readonly _accountService: UserAccountService,
        messageService: MessageService, 
        router: Router) {
        super(messageService, router);

        this.SetValidationMessage('PhoneNumber',
            { key: 'required', value: 'Mobile phone number not entered.' },
            { key: 'minlength', value: 'Mobile phone number must be ten characters long.' },
            { key: 'maxlength', value: 'Mobile phone number must not exceed ten characters.' });
        this.SetValidationMessage('Password', { key: 'required', value: 'Password not entered.' })
    }

    Clear(): void {
        super.Clear();
        super.Focus('PhoneNumber');
    }

    async LogIn() {
        if (!this.Validate())
            return;

        this.IsBusy = true;

        let result = await this._accountService.LogIn(this.PhoneNumber, this.Password);
        if (result)
            this.Navigate('Dashboard');
    }
}