import { NgModule } from '@angular/core';
import { ArticlesComponent } from './articles/articles.component';
import { CategoriesComponent } from './categories/categories.component';
import { HeaderModule } from '@app/header/header.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { CategoryComponent } from './category/category.component';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations: [
        ArticlesComponent,
        CategoriesComponent,
        CategoryComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        RouterModule,
        HeaderModule
    ]
})
export class ArticleModule {

}