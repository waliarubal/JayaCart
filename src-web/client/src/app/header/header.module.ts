import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HeaderComponent } from './header.component';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations: [HeaderComponent],
    imports: [
        BrowserModule,
        FormsModule,
        RouterModule
    ],
    exports: [HeaderComponent]
})
export class HeaderModule {

}