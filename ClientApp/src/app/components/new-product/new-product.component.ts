import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.css']
})
export class NewProductComponent implements OnInit {

    addProductForm: FormGroup;
    showError: boolean = false;

    constructor(private service: ProductService,
        private fb: FormBuilder,
        private router: Router) { }

    ngOnInit() {
        this.addProductForm = this.fb.group({
            id: [null, Validators.required],
            name: [null, Validators.compose([Validators.required, Validators.maxLength(50)])],
            price: [null, Validators.required]
        })
    }

    onSubmit() {
        this.service.addProduct(this.addProductForm.value).subscribe(data => {
            this.router.navigate(["/products"])  
        }, error => {
            this.showError = true;
        });
    }

}
