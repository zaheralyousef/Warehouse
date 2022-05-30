import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

    _baseURL: string = "api/Articles";
    constructor(private http: HttpClient) { }

    getAllArticles() {
        return this.http.get<Article[]>(this._baseURL + "/GetArticles");
    }

    addArticle(article: Article) {
        return this.http.post(this._baseURL + "/AddArticle", article);
    }

    getArticleById(id: number) {
        return this.http.get<Article>(this._baseURL + "/SingleArticle/" + id);
    }

    updateArticle(article: Article) {
        return this.http.put(this._baseURL + "/UpdateArticle/" + article.artId, article);
    }

    deleteArticle(id: number) {
        return this.http.delete(this._baseURL + "/DeleteArticle/" + id);
    }
}
