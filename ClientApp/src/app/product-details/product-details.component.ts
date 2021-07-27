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
  @Input() products: Product[];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
  }

  addProduct(id: string, name: string, price: string, isActive: boolean) {

    const product = new Product(Number(id), name, Number(price), isActive);
    this.productService.updateProduct(product).subscribe(result => {
      this.products.splice(this.products.findIndex(x => x.productId == product.productId), 1, product);
    });
    this.product = null;
  }

}
