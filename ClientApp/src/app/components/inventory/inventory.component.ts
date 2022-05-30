import { Component, OnInit } from '@angular/core';
import { ArticleService } from '../../services/article.service';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent implements OnInit {

    public articles: Article[];

    constructor(private service: ArticleService) { }

    ngOnInit() {
        this.service.getAllArticles().subscribe(data => {
            this.articles = data;
        })
  }

}
