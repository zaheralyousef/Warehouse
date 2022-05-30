import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { ProductsComponent } from './components/products/products.component';
import { NewProductComponent } from './components/new-product/new-product.component';
import { ShowProductComponent } from './components/show-product/show-product.component';
import { UpdateProductComponent } from './components/update-product/update-product.component';
import { ProductService } from './services/product.service';
import { DeleteProductComponent } from './components/delete-product/delete-product.component';
import { InventoryComponent } from './components/inventory/inventory.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProductsComponent,
    NewProductComponent,
    ShowProductComponent,
    UpdateProductComponent,
    DeleteProductComponent,
    InventoryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
        { path: '', component: HomeComponent, pathMatch: 'full' },
        { path: 'products', component: ProductsComponent },
        { path: 'new-product', component: NewProductComponent },
        { path: 'show-product/:id', component: ShowProductComponent },
        { path: 'update-product/:id', component: UpdateProductComponent },
        { path: 'delete-product/:id', component: DeleteProductComponent },
        { path: 'inventory', component: InventoryComponent }
    ])
  ],
  providers: [ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
