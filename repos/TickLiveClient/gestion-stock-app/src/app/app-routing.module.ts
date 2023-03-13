import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArticleAddComponent } from './article-add/article-add.component';
import { ArticleListComponent } from './article-list/article-list.component';
import { EditArticleComponent } from './edit-article/edit-article.component';
import { SearchArticleComponent } from './search-article/search-article.component';

const routes: Routes = [
  {
    path: '', component:ArticleListComponent
  },
  {
    path: 'add/article', component:ArticleAddComponent
  },
  {path: 'edit/article/:ArticleId', component: EditArticleComponent},
  {path: 'search/article', component: SearchArticleComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
