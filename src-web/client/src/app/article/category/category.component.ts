import { Component } from '@angular/core';
import { BaseComponent } from '@shared/base.component';
import { CategoryService } from '@services/category.service';
import { Category } from '@models/category.model';
import { MessageService, MessageType } from '@services/message.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
    selector: 'app-category',
    templateUrl: './category.component.html',
    providers: [CategoryService]
})
export class CategoryComponent extends BaseComponent {
    private _isEdit: boolean;
    private _subscription: Subscription;
    Category: Category;

    constructor(
        private readonly _categoryService: CategoryService,
        messageService: MessageService,
        router: Router,
        private readonly _route: ActivatedRoute, ) {
        super(messageService, router);
        this.Category = new Category();

        this.SetValidationMessage('Code',
            { key: 'required', value: 'Category code not entered.' },
            { key: 'minlength', value: 'Category code must be two characters long.' },
            { key: 'maxlength', value: 'Category code must not exceed twenty four characters.' });
        this.SetValidationMessage('Name', { key: 'required', value: 'Category name not entered.' });
    }

    get IsEdit(): boolean {
        return this._isEdit;
    }

    ngOnInit(): void {
        this._subscription = this._route.params.subscribe(async param => {
            let code = param['Code'];
            if (!code)
                return;

            this._isEdit = true;
            this.Category = await this._categoryService.GetCategory(code);
        });
    }

    async Save() {
        if (!this.Validate())
            return;

        this.IsBusy = true;

        let account = this.IsEdit ?
            await this._categoryService.Update(this.Category) :
            await this._categoryService.CreateCategory(this.Category);
        if (account) {
            this.Toast('Record saved successfully.', MessageType.Info);
            if (!this.IsEdit)
                this.Category = new Category();
        }

        this.IsBusy = false;
    }

    Clear(): void {
        if (this.IsEdit)
            super.Clear(undefined, { Code: this.Category.Code }, 'Name');
        else
            super.Clear(undefined, undefined, 'Code');
    }
}