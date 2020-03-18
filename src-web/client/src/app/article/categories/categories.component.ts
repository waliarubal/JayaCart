import { Component } from '@angular/core';
import { BaseComponent } from '@shared/base.component';
import { Category } from '@models/category.model';
import { CategoryService } from '@services/category.service';
import { MessageService } from '@services/message.service';

@Component({
    selector: 'app-categories',
    templateUrl: './categories.component.html',
    providers: [CategoryService]
})
export class CategoriesComponent extends BaseComponent {
    private _categories: Category[];

    constructor(private readonly _categoryService: CategoryService, messageService: MessageService) {
        super(messageService);
        this._categories = [];
    }

    get Categories(): Category[] {
        return this._categories;
    }

    async Search(keywoards: string) {
        this.IsBusy = true;
        this._categories = await this._categoryService.GetAllCategories();
        this.IsBusy = false;
    }
}