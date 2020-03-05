import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AccountsComponent } from './accounts/accounts.component';

@NgModule({
    declarations: [
        AccountsComponent
    ],
    imports: [
        BrowserModule,
        FormsModule
    ],
    exports: [
        AccountsComponent
    ]
})
export class UserAccountModule { }