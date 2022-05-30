import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

    public products: Product[];
    constructor(private service: ProductService, private router: Router) { }

    ngOnInit() {
        this.service.getAllProducts().subscribe(data => {
            this.products = data;
        })
    }

    showProduct(id: number) {
        this.router.navigate(["/show-product/" + id]);
    }

    updateProduct(id: number) {
        this.router.navigate(["/update-product/" + id]);
    }

    deleteProduct(id: number) {
        this.router.navigate(["/delete-product/" + id]);
    }

}
