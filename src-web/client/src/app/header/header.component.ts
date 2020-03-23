import { Component, Input, EventEmitter, Output, OnInit } from '@angular/core';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html'
})
export class HeaderComponent implements OnInit {
    private _keywoards: string;
    private _isInitialized: boolean;
    @Output() readonly KeywoardsChange: EventEmitter<string> = new EventEmitter();

    constructor() {
        this.SearchBoxPlaceholder = 'What are you looking for?';
    }

    @Input() IsBusy: boolean;
    @Input() Title: string;
    @Input() SearchBoxPlaceholder: string;
    @Input() IsSearchAllowed: boolean;
    @Input() NewRecordRouterLink: string;

    @Input()
    get Keywoards(): string {
        return this._keywoards;
    }

    set Keywoards(value: string) {
        this._keywoards = value;

        if (this._isInitialized)
            this.KeywoardsChange.emit(value);
    }

    ngOnInit(): void {
        this._isInitialized = true;
    }
}