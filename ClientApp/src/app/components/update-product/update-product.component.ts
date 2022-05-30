import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-update-product',
  templateUrl: './update-product.component.html',
  styleUrls: ['./update-product.component.css']
})
export class UpdateProductComponent implements OnInit {
    product: Product;
    updateProductForm = new FormGroup({
        id: new FormControl(),
        name: new FormControl(),
        price: new FormControl()
    });

    constructor(private service: ProductService,
        private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder) { }

    ngOnInit() {
        this.service.getProductById(this.route.snapshot.params.id).subscribe(data => {
            this.product = data;
            
            this.updateProductForm = this.fb.group({
                id: [data.id],
                name: [data.name],
                price: [data.price]
            })
            
        })
    }

    onSubmit() {
        this.service.updateProduct(this.updateProductForm.value).subscribe(data => {
            this.router.navigate(["/products"]);
        })
    }

}
