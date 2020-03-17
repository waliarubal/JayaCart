import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AccountsComponent } from './accounts/accounts.component';
import { AccountComponent } from './account/account.component';
import { LoginComponent } from './login/login.component';
import { HeaderComponent } from '@app/header/header.component';

@NgModule({
    declarations: [
        AccountsComponent,
        AccountComponent,
        LoginComponent,
        HeaderComponent
    ],
    imports: [
        BrowserModule,
        FormsModule
    ]
})
export class UserAccountModule { }