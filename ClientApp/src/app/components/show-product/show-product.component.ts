import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-show-product',
  templateUrl: './show-product.component.html',
  styleUrls: ['./show-product.component.css']
})
export class ShowProductComponent implements OnInit {

    product: Product;
    constructor(private service: ProductService,
        private route: ActivatedRoute,
        private router: Router) { }

    ngOnInit() {
        this.service.getProductById(this.route.snapshot.params.id).subscribe(data => {
            this.product = data;
        })
    }

    sellProduct(id: number) {
        this.service.sellProduct(id).subscribe(data => {
            this.router.navigate(["/products"]);
        })
    }

}
