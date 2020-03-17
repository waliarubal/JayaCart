import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HeaderComponent } from './header.component';

@NgModule({
    declarations: [HeaderComponent],
    imports: [
        BrowserModule,
        FormsModule
    ],
    exports: [HeaderComponent]
})
export class HeaderModule {

}