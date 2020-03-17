import { NgModule } from '@angular/core';
import { ArticlesComponent } from './articles/articles.component';
import { CategoriesComponent } from './categories/categories.component';
import { HeaderModule } from '@app/header/header.module';

@NgModule({
    declarations: [
        ArticlesComponent,
        CategoriesComponent
    ],
    imports: [
        HeaderModule
    ]
})
export class ArticleModule {

}