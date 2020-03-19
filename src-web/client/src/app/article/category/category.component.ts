import { Component } from '@angular/core';
import { BaseComponent } from '@shared/base.component';
import { CategoryService } from '@services/category.service';
import { Category } from '@models/category.model';
import { MessageService } from '@services/message.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-category',
    templateUrl: './category.component.html',
    providers: [CategoryService]
})
export class CategoryComponent extends BaseComponent {
    Category: Category;

    constructor(private readonly _categoryService: CategoryService, messageService: MessageService, router: Router) {
        super(messageService, router);
        this.Category = new Category();

        this.SetValidationMessage('Code',
            { key: 'required', value: 'Category code not entered.' },
            { key: 'minlength', value: 'Category code must be two characters long.' },
            { key: 'maxlength', value: 'Category code must not exceed twenty four characters.' });
        this.SetValidationMessage('Name', { key: 'required', value: 'Category name not entered.' });
    }

    async Save() {
        if (!this.Validate())
            return;

        this.IsBusy = true;

        let account = await this._categoryService.CreateCategory(this.Category);
        if (account)
            this.Category = new Category();

        this.IsBusy = false;
    }

    Clear(): void {
        super.Clear();
        super.Focus('Code');
    }
}