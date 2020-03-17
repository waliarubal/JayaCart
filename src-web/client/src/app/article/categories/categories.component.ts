import { Component } from '@angular/core';
import { BaseComponent } from '@shared/base.component';

@Component({
    selector: 'app-categories',
    templateUrl: './categories.component.html'
})
export class CategoriesComponent extends BaseComponent {

    async Search(keywoards: string) {
        this.IsBusy = true;

        this.IsBusy = false;
    }
}