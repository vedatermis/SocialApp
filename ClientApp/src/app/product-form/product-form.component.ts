import { Component, OnInit } from '@angular/core';
import { Product } from '../Model';
import { ProductService } from '../product.service';

@Component({
  selector: 'product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
  }

  addProduct(name: string, price: string, isActive: boolean) {
    const product = new Product(0, name, Number(price), isActive);
    this.productService.saveProduct(product);
  }
}
