import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

    _baseURL: string = "api/Products";
    constructor(private http: HttpClient) { }

    getAllProducts() {
        return this.http.get<Product[]>(this._baseURL + "/GetProducts");
    }

    addProduct(product: Product) {
        return this.http.post(this._baseURL + "/AddProduct", product);
    }

    getProductById(id: number) {
        return this.http.get<Product>(this._baseURL + "/SingleProduct/" + id);
    }

    updateProduct(product: Product) {
        return this.http.put(this._baseURL + "/UpdateProduct/" + product.id, product);
    }

    deleteProduct(id: number) {
        return this.http.delete(this._baseURL + "/DeleteProduct/" + id);
    }

    sellProduct(id: number) {
        return this.http.delete(this._baseURL + "/SellProduct/" + id);
    }
}
