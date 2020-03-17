import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { Category } from '@models/category.model';

@Injectable()
export class CategoryService extends BaseService {

    constructor(httpClient: HttpClient) {
        super(httpClient, 'Categories');
    }

    GetAllCategories(): Promise<Category[]> {
        return this.GetAll();
    }

    CreateCategory(category: Category): Promise<Category> {
        return this.Post(category);
    }
}