export class Model {
    categoryName: string;
    products: Array<Product>;

    /**
     *
     */
    constructor() {
        this.categoryName = "Telefon";
        this.products = [
            new Product(1, "Samsung S5", 2000, true),
            new Product(2, "Samsung S6", 4000, true),
            new Product(3, "Samsung S7", 5000, false),
            new Product(4, "Samsung S8", 6000, true),
            new Product(5, "Samsung S9", 7000, false),
            new Product(6, "Samsung S10", 7000, false),
        ];
    }
}

export class Product {
    id: number;
    name: string;
    price: number;
    isActive: boolean;

    constructor(id: number, name: string, price: number, isActive: boolean) {
        this.id = id;
        this.name = name;
        this.price = price;
        this.isActive = isActive;
    }
}