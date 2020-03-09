import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AccountsComponent } from './accounts/accounts.component';
import { AccountComponent } from './account/account.component';
import { UserAccountComponent } from './user-account.component';

@NgModule({
    declarations: [
        AccountsComponent,
        AccountComponent,
        UserAccountComponent
    ],
    imports: [
        BrowserModule,
        FormsModule
    ],
    exports: [
        UserAccountComponent
    ]
})
export class UserAccountModule { }