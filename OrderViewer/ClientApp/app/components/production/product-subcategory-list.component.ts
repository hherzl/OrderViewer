import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { IListResponse } from "../../responses/list.response";
import { ProductSubcategory } from "../../models/product.subcategory";
import { ProductionService } from "../../services/production.service";

@Component({
    selector: "product-subcategory-list",
    template: require("./product-subcategory-list.component.html")
})
export class ProductSubcategoryListComponent implements OnInit {
    public pageNumber: number;
    public pageSize: number;
    public result: IListResponse<ProductSubcategory>;

    constructor(private router: Router, private service: ProductionService) {
    }

    public ngOnInit(): void {
        this.search();
    }

    public search(): void {
        this.service.getProductSubcategories(this.pageNumber, this.pageSize).subscribe(result => {
            this.result = result.json() as IListResponse<ProductSubcategory>;
        });
    }
}
