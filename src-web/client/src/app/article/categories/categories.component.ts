import { Component } from '@angular/core';
import { BaseComponent } from '@shared/base.component';
import { Category } from '@models/category.model';

@Component({
    selector: 'app-categories',
    templateUrl: './categories.component.html'
})
export class CategoriesComponent extends BaseComponent {
    private _categories: Category[];

    constructor() {
        super();
        this._categories = [];
    }

    get Categories(): Category[] {
        return this._categories;
    }

    async Search(keywoards: string) {
        this.IsBusy = true;

        this.IsBusy = false;
    }
}