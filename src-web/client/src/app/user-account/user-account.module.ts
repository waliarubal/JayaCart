import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AccountsComponent } from './accounts/accounts.component';
import { AccountComponent } from './account/account.component';
import { LoginComponent } from './login/login.component';
import { HeaderModule } from '@app/header/header.module';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations: [
        AccountsComponent,
        AccountComponent,
        LoginComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HeaderModule,
        RouterModule
    ]
})
export class UserAccountModule { }