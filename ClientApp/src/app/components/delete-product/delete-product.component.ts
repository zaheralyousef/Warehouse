import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-delete-product',
  templateUrl: './delete-product.component.html',
  styleUrls: ['./delete-product.component.css']
})
export class DeleteProductComponent implements OnInit {

    product: Product;
    constructor(private route: ActivatedRoute,
        private router: Router,
        private service: ProductService) { }

    ngOnInit() {
        this.service.getProductById(this.route.snapshot.params.id).subscribe(data => {
            this.product = data;
        })
    }

    deleteProduct(id: number) {
        this.service.deleteProduct(id).subscribe(data => {
            this.router.navigate(["/products"]);
        })
    }

}
