import { Component, Input, OnInit } from '@angular/core';
import { Product } from '../Model';
import { ProductService } from '../product.service';

@Component({
  selector: 'product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  @Input() product: Product;
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
  }

  addProduct(id: string, name: string, price: string, isActive: boolean) {

    const product = new Product(Number(id), name, Number(price), isActive);
    this.productService.saveProduct(product);
    this.product = null;
  }

}
