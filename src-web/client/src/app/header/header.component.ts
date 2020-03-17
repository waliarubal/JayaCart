import { Component, Input, EventEmitter, Output } from '@angular/core';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html'
})
export class HeaderComponent {
    @Output() readonly OnSearch: EventEmitter<string>;

    constructor(){
        this.OnSearch = new EventEmitter();
        this.SearchBoxPlaceholder = 'What are you looking for?';
    }

    @Input() IsBusy: boolean;
    @Input() Title: string;
    @Input() SearchBoxPlaceholder: string;
    @Input() IsSearchAllowed: boolean;
    Keywoards: string;
}